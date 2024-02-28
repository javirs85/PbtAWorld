using PbtALib;
using PbtALib.ifaces;
using PbtaWorldRazonCommonComponents;
using System.Text.Json;
using SixLabors.ImageSharp;

namespace WhiteBoard;

public class WhiteBoardService
{
	public event EventHandler UpdateUI;
	public event EventHandler<Tuple<DWClasses, Point>> FlashAttentionMarker;
	public event EventHandler<Guid> StoreChangesInCharacterSheet;
	public List<Token> Tokens = new();
	public List<Prop> Props = new();
	public static IGameController? Game;

	private string _mapurl = string.Empty;

	public string MapImageURL
	{
		get { return _mapurl; }
		set { 
			_mapurl = value;
			LoadMap(_mapurl);
		}
	}

	public int BattleMapWidth = 0;
	public int BattleMapHeight = 0;




	public List<DrawnLine> Walls = new();

	private List<DrawnLine> drawnLines = new();
	public string VisibilityArea = "";

	public List<Marker> MarkerPositions = new();
	public class Marker
	{
		public DWClasses Color;
		public Point Position = new();
		public bool IsFlashing = false;
	}


	public List<DrawnLine> GetLines() => drawnLines;
	public List<DrawnLine> GetWalls() => Walls;

	public List<DrawnLine> debugLines = new();

	public void AddDrawnLine(DrawnLine line)
	{
		drawnLines.Add(line);
		Update();
	}

	public void AddWall(DrawnLine wall)
	{
		Walls.Add(wall);
		Update();
	}

	public void Clear()
	{
		Walls = new();
		drawnLines = new();
		Update();
	}

	public void LoadMap(string mapName)
	{
		var path = "./wwwroot/imgs/VTT/BattleMaps/" + mapName;
		using (var image = Image.Load(path))
		{
			BattleMapWidth = image.Width; 
			BattleMapHeight = image.Height;
		}
	}

	public List<string> GetMaps()
	{
		var rest = from file in Directory.GetFiles("./wwwroot/imgs/VTT/BattleMaps")
			   select file.Substring(file.LastIndexOf("\\")+1);
		return rest.ToList();
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
		}
	}

	public async Task ShowPlayerAttention(DWClasses color, Point p)
	{
		var marker = MarkerPositions.Find(x => x.Color == color);
		if (marker is not null)
		{
			marker.Position = p;
			marker.IsFlashing = true;
		}
		else
		{
			marker = new Marker { Color = color, Position = p, IsFlashing = true };
			MarkerPositions.Add(marker);
		}

		Update();

		await Task.Delay(3000);

		marker.IsFlashing = false;
		Update();
	}


	public async Task LoadJson()
	{
		try
		{
			var Filename = "TestFile";
			string newFilePath = $"./wwwroot/{Filename}.json";
			var encoded = await File.ReadAllTextAsync(newFilePath);

			Walls = JsonSerializer.Deserialize<List<DrawnLine>>(encoded);
			Update();

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

		Update();
	}
	public async Task SaveToJson()
	{
		try
		{
			var Filename = "TestFile";
			string newFilePath = $"./wwwroot/{Filename}.json";
			await File.WriteAllTextAsync(newFilePath, JsonSerializer.Serialize(Walls));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	void Update(object? sender, EventArgs e) => Update();
	private void Update() => UpdateUI?.Invoke(this, EventArgs.Empty);

	public async Task<Token> StartForPlayer(PbtACharacter character)
	{
		if (Walls.Count == 0)
		{
			await LoadJson();
		}

		var TheToken = Tokens.Find(x => x.Guid == character.ID);
		if (TheToken == null)
		{
			TheToken = new Token { Character = character, X = 100, Y = 100 };
			Tokens.Add(TheToken);
			TheToken.StoreChangesInCharacterSheet += StoreChangesInCharacterSheet;
			character.UpdateVTT += Update;
		}

		

		return TheToken;
	}


	public void MoveToken(Token t, double X, double Y)
	{
		if (t == null) return;

		var token = Tokens.Find(x => x.Guid == t.Guid);
		if (token != null)
		{
			token.X = (int)X - Token.BasicSize / 2;
			token.Y = (int)Y - Token.BasicSize / 2;
		}
		else
		{
			var prop = Props.Find(x => x.Guid == t.Guid);
			if (prop is not null)
			{
				prop.X = (int)X;
				prop.Y = (int)Y;
			}
		}
		Update();
	}
	public void DeleteToken(Token t)
	{
		Tokens.Remove(t);
		Update();
	}

	public void DeleteProp(Prop p)
	{
		Props.Remove(p);
		Update();
	}

	public Token AddToken(VTTTokens TokenType)
	{
		var t = new Token { ID = TokenType, X = 50, Y = 50, Status = TokenStatus.Hidden };
		t.UpdateNeeeded -= Update;
		t.UpdateNeeeded += Update;
		Tokens.Add(t);

		return t;
	}


	public Token? SelectToken(double x, double y)
	{
		double minDist = 100000;
		Token? SelectedToken = null;

		foreach (var t in Tokens.Where(x => x.ID != VTTTokens.FogOfWar))
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

		if (SelectedToken == null)
		{
			foreach (var fog in Tokens.Where(x => x.ID == VTTTokens.FogOfWar))
			{
				if (x > fog.X && x <= fog.X + fog.FowWidth && y > fog.Y && y <= fog.Y + fog.FowHeight)
					return fog;
			}
		}

		if (SelectedToken == null)
		{
			foreach (var prop in Props)
			{
				var d = Math.Abs(prop.X - x) + Math.Abs(prop.Y - y);
				if (d < minDist)
				{
					if (d < 250)
					{
						minDist = d;
						SelectedToken = prop;
					}
				}
			}
		}

		return SelectedToken;
	}


}
