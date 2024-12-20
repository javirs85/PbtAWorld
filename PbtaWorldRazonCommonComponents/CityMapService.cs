﻿using PbtALib.ifaces;
using PbtALib;
using PbtaWorldRazonCommonComponents;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WhiteBoard.WhiteBoardService;
using WhiteBoard;

namespace PbtALib;

public class CityMapService
{
	public event EventHandler<Token> ForceSelection;
	public event EventHandler UpdateUI;
	public IGameController Game { get; set; }


	public string BackgroundImageName { get; set; } = string.Empty;
	public List<string> AvailableImagePaths { get; set; } = new();

	string RootBattleMapsURL = "/imgs/VTT/BattleMaps/";
	public string BackgroundImagePath => RootBattleMapsURL + BackgroundImageName;

	public List<Token> TokensOnScreen { get; set; } = new();
	public List<Annotation> Annotations { get; set; } = new();

	void Update(object? sender, EventArgs e) => Update();
	public void Update() => UpdateUI.Invoke(this, EventArgs.Empty);

	public List<Marker> MarkerPositions = new();

	public async Task ShowPlayerAttention(string _encodedClass, Point p)
	{
		var marker = MarkerPositions.Find(x => x.EncodedClass == _encodedClass);
		if (marker is not null)
		{
			marker.Position = p;
			marker.IsFlashing = true;
		}
		else
		{
			marker = new Marker { EncodedClass = _encodedClass, Position = p, IsFlashing = true };
			MarkerPositions.Add(marker);
		}

		Update();

		await Task.Delay(3000);

		marker.IsFlashing = false;
		Update();
	}

	public void AddTokenFromPeople(ICharacter dude)
	{
		AddToken(GenerateTokenFromPeople(dude));
	}

	public void AddToken(VTTTokens TokenType)
	{
		var t = new Token { ID = TokenType, X = 50, Y = 50, Status = TokenStatus.Hidden };
		t.UpdateNeeeded -= Update;
		t.UpdateNeeeded += Update;
		t.Status = TokenStatus.Normal;
		TokensOnScreen.Add(t);

		//ForceSelection?.Invoke(this, t);
		Update();
	}

	public void RemoveToken(Token t)
	{
		t.UpdateNeeeded -= Update;
		TokensOnScreen.Remove(t);
		Update();
	}

	private void AddToken(Token t)
	{
		t.UpdateNeeeded -= Update;
		t.UpdateNeeeded += Update;
		t.Status = TokenStatus.Normal;
		TokensOnScreen.Add(t);

		//ForceSelection?.Invoke(this, t);
		Update();
	}

	public Token GenerateTokenFromPeople(ICharacter dude)
	{
		return new Token
		{
			ID = VTTTokens.FromICharacter,
			Character = dude as PbtACharacter,
			ComesFromImageName = dude.Name,
			X = 50,
			Y = 50,
			Status = TokenStatus.Hidden
		};
	}

	public void MoveToken(Token t, double X, double Y)
	{
		if (t == null) return;

		var token = TokensOnScreen.Find(x => x.Guid == t.Guid);
		if (token != null)
		{
			token.X = (int)X - Token.BasicSize / 2;
			token.Y = (int)Y - Token.BasicSize / 2;
		}
		Save();
		Update();
	}

	public Token? SelectToken(double x, double y)
	{
		double minDist = 100;
		Token? SelectedToken = null;

		foreach (var t in TokensOnScreen)
		{
			var d = Math.Abs(t.X - x) + Math.Abs(t.Y - y);
			if (d < minDist)
			{
				if (d < 100)
				{
					minDist = d;
					SelectedToken = t;
				}
			}
		}

		return SelectedToken;
	}

	public Annotation? SelectAnnotation(double x, double y)
	{
		double minDist = 100;
		Annotation? SelectedAnnotation = null;

		foreach (var t in Annotations)
		{
			var d = Math.Abs(t.X - x) + Math.Abs(t.Y - y);
			if (d < minDist)
			{
				if (d < 100)
				{
					minDist = d;
					SelectedAnnotation = t;
				}
			}
		}

		return SelectedAnnotation;
	}

	public void Save()
	{
		var Folder = $"wwwroot/GameImages/{Game.SessionID.ToString()}";
		var path = $"{Folder}/CityMap.json";

		ToStore toStore = new ToStore();
		toStore.Tokens = TokensOnScreen;
		toStore.ImageName = BackgroundImageName;
		toStore.drawnLines = drawnLines;
		toStore.Annotations = Annotations;

		var json = System.Text.Json.JsonSerializer.Serialize(toStore);

		System.IO.File.WriteAllText(path, json);
	}

	public async Task Load()
	{
		var Folder = $"wwwroot/GameImages/{Game.SessionID.ToString()}";
		var path = $"{Folder}/CityMap.json";

		if (File.Exists(path))
		{
			var json = await System.IO.File.ReadAllTextAsync(path);
			var loaded = System.Text.Json.JsonSerializer.Deserialize<ToStore>(json);
			if(loaded is not null && loaded.Tokens is not null)
			{
				foreach (var t in loaded.Tokens)
					AddToken(t);
				BackgroundImageName = loaded.ImageName;
				drawnLines = loaded.drawnLines;
				Annotations = loaded.Annotations;
			}			
		}
	}

	public void AddAnnotation(Annotation note)
	{
		Annotations.Add(note);
		Update();
		Save();
	}
	public void RemoveAnnotation(Annotation note)
	{
		if(Annotations.Contains(note))
		{
			Annotations.Remove(note);
			Update();
			Save();
		}
	}

	public class Annotation
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		public int X { get; set; } = 0; 
		public int Y { get; set; } = 0;
		public string Text { get; set; } = "";
	}

	private class ToStore
	{
		public List<Token> Tokens { get; set; } = new List<Token>();
		public string ImageName { get; set; } = string.Empty;
		public List<DrawnLine> drawnLines { get; set; } = new();
		public List<Annotation> Annotations { get; set; } = new();
	}


	private List<DrawnLine> drawnLines = new();
	public List<DrawnLine> GetLines() => drawnLines;
	public void AddDrawnLine(DrawnLine line)
	{
		drawnLines.Add(line);

		Save();
		Update();
	}
	public void Clear()
	{
		drawnLines = new();
		Save();
		Update();
	}

	public void TryDelete(Point click)
	{
		if (drawnLines.Count == 0) return;

		DrawnLine SelectedLine = drawnLines[0];
		var minDistance = click.DistanceTo(drawnLines[0].AnchorPoint);
		for (int i = 1; i < drawnLines.Count; i++)
		{
			var dist = click.DistanceTo(drawnLines[i].AnchorPoint);
			if (dist < minDistance)
			{
				minDistance = dist;
				SelectedLine = drawnLines[i];
			}
		}

		if (minDistance < 30)
		{
			drawnLines.Remove(SelectedLine);

			Save();
			Update();
		}
	}
}
