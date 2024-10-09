using PbtALib.ifaces;
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

	void Update(object? sender, EventArgs e) => Update();
	void Update() => UpdateUI.Invoke(this, EventArgs.Empty);

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

	public void Save()
	{
		var Folder = $"wwwroot/GameImages/{Game.SessionID.ToString()}";
		var path = $"{Folder}/CityMap.json";

		ToStore toStore = new ToStore();
		toStore.Tokens = TokensOnScreen;
		toStore.ImageName = BackgroundImageName;

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
			}			
		}
	}

	private class ToStore
	{
		public List<Token> Tokens { get; set; } = new List<Token>();
		public string ImageName { get; set; } = string.Empty;
	}

}
