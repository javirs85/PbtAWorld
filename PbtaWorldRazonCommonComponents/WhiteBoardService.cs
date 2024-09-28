using PbtALib;
using PbtALib.ifaces;
using PbtaWorldRazonCommonComponents;
using System.Text.Json;
using SixLabors.ImageSharp;

namespace WhiteBoard;

public class WhiteBoardService
{
	public event EventHandler UpdateUI;
	public event EventHandler OpenClocksTryForAllClients;
	public event EventHandler<Tuple<DWClasses, Point>> FlashAttentionMarker;
	public event EventHandler<Guid> StoreChangesInCharacterSheet;
	public event EventHandler<Token> ForceSelection;
	public List<Token> Tokens = new();
	public List<Prop> Props = new();
	public static IGameController? Game;

	public List<Clock> Clocks = new();


	string RootBattleMapsURL = "./wwwroot/imgs/VTT/BattleMaps/";
	public string MapImagePATH => RootBattleMapsURL + MapImageName;
	public string MapImageURL => "/imgs/VTT/BattleMaps/" + MapImageName;
	public string WallsJasonFile => RootBattleMapsURL + MapImageName.Substring(0, MapImageName.IndexOf('.'))+".json";

	private AvailableGames _currentGame = AvailableGames.DW;
	public AvailableGames CurrentGame
	{
		get => _currentGame;
		set
		{
			_currentGame = value;
			if (_currentGame == AvailableGames.DW) MapImageName = "UDT_DungeonRectificed.jpg";
			else if (_currentGame == AvailableGames.US) MapImageName = "USDarkAsphalt.jpg";
		}
	}


	private string _mapImageName;
	public string MapImageName
	{
		get { return _mapImageName; }
		set { _mapImageName = value;
			LoadMap(_mapImageName);
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
		public string EncodedClass = "DW_Bard";
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


	public async Task LoadMap(string mapName)
	{
		using (var image = Image.Load(MapImagePATH))
		{
			BattleMapWidth = image.Width; 
			BattleMapHeight = image.Height;
		}

		await LoadJson();
	}

	public List<string> GetMaps()
	{
		var rest =	from file in Directory.GetFiles(RootBattleMapsURL).Where(x=> x.Contains(".png") || x.Contains(".jpg"))
					select file.Substring(file.LastIndexOf("/")+1);
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
			Update();
		}
	}

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


	public async Task LoadJson()
	{
		try
		{
			var encoded = await File.ReadAllTextAsync(WallsJasonFile);

			Walls = JsonSerializer.Deserialize<List<DrawnLine>>(encoded);
			Update();

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			Walls.Clear();
		}

		Update();
	}
	public async Task SaveToJson()
	{
		try
		{
			await File.WriteAllTextAsync(WallsJasonFile, JsonSerializer.Serialize(Walls));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public void ForzeUpdateInAllClients()
	{
		foreach (var c in Clocks) c.UpdateUI();
		Update();
		OpenClocksTryForAllClients(this, EventArgs.Empty);
	}
	void Update(object? sender, EventArgs e) => Update();
	private void Update() => UpdateUI?.Invoke(this, EventArgs.Empty);

	public void OpenClocksInPlayers() => OpenClocksTryForAllClients.Invoke(this, EventArgs.Empty);

	public async Task<Token> StartForPlayer(PbtACharacter character)
	{
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

		ForceSelection?.Invoke(this, t);
		Update();

		return t;
	}

	public void AddTokenFromPeople(ICharacter dude)
	{
		var t = new Token { 
			ID = VTTTokens.FromICharacter, 
			ComesFromImageName = dude.Name,
			X = 50, Y = 50, 
			Status = TokenStatus.Hidden };
		t.UpdateNeeeded -= Update;
		t.UpdateNeeeded += Update;
		Tokens.Add(t);

		ForceSelection?.Invoke(this, t);
		Update();
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
