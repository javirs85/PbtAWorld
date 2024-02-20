using Microsoft.AspNetCore.Components.Web;
using PbtALib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PbtaWorldRazonCommonComponents;

public class VTTService
{
	public event EventHandler UpdateUI;
	public event EventHandler<Guid> StoreChangesInCharacterSheet;
	public List<Token> Tokens = new();
	public List<Prop> Props = new();
	public List<Monster> MonsterDefinitions = new();
	public bool IsOpen = false;

	public enum VTTMaps { farm, Bandit1, Swamp, UDTBasic, UDT_Forest};

	private VTTMaps _currentMap;

	public VTTMaps CurrentMap
	{
		get { return _currentMap; }
		set { 
			if(_currentMap == value ) return;
			_currentMap = value;
			Update();
		}
	}


	public void StartForPlayer(PbtACharacter character)
	{
		if(Tokens.Find(x=>x.Guid == character.ID) == null) 
		{
			var t = new Token { Character = character, X = 100, Y = 100 };
			Tokens.Add(t);
			t.StoreChangesInCharacterSheet += StoreChangesInCharacterSheet;
			character.UpdateVTT += Update;
		}
	}

	
	public Token? SelectToken(double x, double y)
	{
		double minDist = 100000;
		Token? SelectedToken = null;

		foreach(var t in Tokens.Where(x=>x.ID != VTTTokens.FogOfWar))
		{
			var d =  Math.Abs(t.X - x) + Math.Abs(t.Y - y);
			if (d < minDist)
			{
				if(d< 100)
				{
					minDist = d;
					SelectedToken = t;
				}
			}
		}

		if(SelectedToken == null)
		{
			foreach(var fog in Tokens.Where(x=>x.ID == VTTTokens.FogOfWar))
			{
				if (x > fog.X && x <= fog.X + fog.FowWidth && y > fog.Y && y <= fog.Y + fog.FowHeight)
					return fog;
			}
		}

		if(SelectedToken == null)
		{
			foreach(var prop in Props)
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

	public void MoveToken(Token t,double X, double Y)
	{
		if (t == null) return;

		var token = Tokens.Find(x=>x.Guid == t.Guid);
		if(token != null)
		{
			token.X = (int)X - Token.BasicSize / 2;
			token.Y = (int)Y - Token.BasicSize / 2;
		}
		else
		{
			var prop = Props.Find(x => x.Guid == t.Guid);
			if(prop is not null)
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

	void Update()=> UpdateUI?.Invoke(this, EventArgs.Empty);
	void Update(object? sender, EventArgs e)=> Update();


	public List<PbtACharacter> Players { get; set; } = new();
	public string ImageName { get; set; } = "farm.jpg";

	public void GenerateFOWJSON()
	{
		var FOWs = from t in Tokens where t.ID == VTTTokens.FogOfWar select t;
		string str = System.Text.Json.JsonSerializer.Serialize(FOWs);
		//return str;
	}

	public void AddPropToMap(VTTTokens t)
	{
		var p = new Prop { ID = t, X = 750, Y = 750 };
		Props.Add(p);
		p.UpdateNeeeded -= Update;
		p.UpdateNeeeded += Update;
		Update();
	}

	public void LoadFOW()
	{
		Tokens.RemoveAll(x=>x.ID == VTTTokens.FogOfWar);

		string str = "";
		if (CurrentMap == VTTMaps.Swamp)
			str = "[{\"ID\":58,\"Status\":0,\"Guid\":\"10665f66-cd9a-4d87-9215-2235c760ca28\",\"HP\":0,\"maxHP\":0,\"IsRound\":true,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":190,\"Y\":131,\"FowWidth\":288,\"FowHeight\":268},{\"ID\":58,\"Status\":0,\"Guid\":\"b51bd3f9-388f-4409-858f-8c0493fdc9db\",\"HP\":0,\"maxHP\":0,\"IsRound\":true,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1050,\"Y\":256,\"FowWidth\":317,\"FowHeight\":328},{\"ID\":58,\"Status\":0,\"Guid\":\"1c52cdb2-c6af-4d12-8f4d-4205db885078\",\"HP\":0,\"maxHP\":0,\"IsRound\":true,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":761,\"Y\":1046,\"FowWidth\":276,\"FowHeight\":275},{\"ID\":58,\"Status\":0,\"Guid\":\"af5c1567-7b3c-450d-9c40-3c00854a4ebb\",\"HP\":0,\"maxHP\":0,\"IsRound\":true,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":215,\"Y\":1472,\"FowWidth\":285,\"FowHeight\":271}]";
		else if (CurrentMap == VTTMaps.Bandit1)
			str = "[{\"ID\":58,\"Status\":0,\"Guid\":\"3372466a-9550-466e-a58e-b4eac49b4f06\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1052,\"Y\":15,\"FowWidth\":320,\"FowHeight\":283},{\"ID\":58,\"Status\":0,\"Guid\":\"63c0300d-c666-4b0c-a538-f5016e27f39b\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":185,\"Y\":452,\"FowWidth\":493,\"FowHeight\":404},{\"ID\":58,\"Status\":0,\"Guid\":\"adc6e318-327f-4c55-aaae-1399119ff529\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":743,\"Y\":371,\"FowWidth\":753,\"FowHeight\":396},{\"ID\":58,\"Status\":0,\"Guid\":\"dbd76659-c29d-4dc9-a3c3-8c661ccca5f4\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":203,\"Y\":889,\"FowWidth\":609,\"FowHeight\":197},{\"ID\":58,\"Status\":0,\"Guid\":\"d848bcb9-1243-4962-b490-06aeddd681cc\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":610,\"Y\":1087,\"FowWidth\":208,\"FowHeight\":140},{\"ID\":58,\"Status\":0,\"Guid\":\"f7be5574-0f59-4f3b-a31d-e1271d89c83b\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":475,\"Y\":1087,\"FowWidth\":137,\"FowHeight\":139},{\"ID\":58,\"Status\":0,\"Guid\":\"e0362d5c-a2f5-4178-b12b-2bba7a6cfcea\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":338,\"Y\":1094,\"FowWidth\":134,\"FowHeight\":268},{\"ID\":58,\"Status\":0,\"Guid\":\"5257fa55-03aa-4009-956b-3d78a6c57cc7\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":818,\"Y\":812,\"FowWidth\":203,\"FowHeight\":483},{\"ID\":58,\"Status\":0,\"Guid\":\"09fd2354-a2b1-4189-9cfe-51c3edf8d1b9\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1023,\"Y\":816,\"FowWidth\":207,\"FowHeight\":205},{\"ID\":58,\"Status\":0,\"Guid\":\"595e907b-ac0f-4668-9d42-762ccce01b67\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1023,\"Y\":1023,\"FowWidth\":207,\"FowHeight\":66},{\"ID\":58,\"Status\":0,\"Guid\":\"177805b8-6023-4037-a8f5-f787ab7339d1\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1023,\"Y\":1090,\"FowWidth\":205,\"FowHeight\":73},{\"ID\":58,\"Status\":0,\"Guid\":\"67c78166-7906-43e2-aaf3-6091c66a13e5\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":18,\"Y\":699,\"FowWidth\":308,\"FowHeight\":846},{\"ID\":58,\"Status\":0,\"Guid\":\"777265fe-aad3-412a-bda0-ed65201da425\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":469,\"Y\":1230,\"FowWidth\":212,\"FowHeight\":273},{\"ID\":58,\"Status\":0,\"Guid\":\"ce8e2bd0-cf22-47b7-b145-665938dadb7b\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":403,\"Y\":1362,\"FowWidth\":61,\"FowHeight\":139},{\"ID\":58,\"Status\":0,\"Guid\":\"2d3bcdfd-4018-4220-9d29-5c5163709ebc\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":685,\"Y\":1233,\"FowWidth\":124,\"FowHeight\":271},{\"ID\":58,\"Status\":0,\"Guid\":\"6b00d6c8-b002-4c19-bcd6-bc3e3b9b3e5e\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":818,\"Y\":1298,\"FowWidth\":132,\"FowHeight\":333},{\"ID\":58,\"Status\":0,\"Guid\":\"594fbc3b-808a-4a9d-a3df-1adb0792d811\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":959,\"Y\":1428,\"FowWidth\":203,\"FowHeight\":552},{\"ID\":58,\"Status\":0,\"Guid\":\"b4391c45-818f-4b3e-bed3-d3889bd7d9de\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":886,\"Y\":1637,\"FowWidth\":81,\"FowHeight\":344},{\"ID\":58,\"Status\":0,\"Guid\":\"7dfd158c-260f-4600-865e-a9a93b5d5701\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":473,\"Y\":1633,\"FowWidth\":407,\"FowHeight\":349},{\"ID\":58,\"Status\":0,\"Guid\":\"4ed92c84-ce39-4a0d-afb7-5523fdb23880\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":5,\"Y\":1544,\"FowWidth\":409,\"FowHeight\":227},{\"ID\":58,\"Status\":0,\"Guid\":\"6a9b4e24-4f0d-465c-8683-c8d8c95072d5\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1,\"Y\":1773,\"FowWidth\":485,\"FowHeight\":474},{\"ID\":58,\"Status\":0,\"Guid\":\"cec78558-f1e2-4839-a784-1209bc363c2a\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":487,\"Y\":1982,\"FowWidth\":546,\"FowHeight\":199},{\"ID\":58,\"Status\":0,\"Guid\":\"6fc17bc0-7971-406a-89b1-b7938b979f00\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1237,\"Y\":776,\"FowWidth\":256,\"FowHeight\":623},{\"ID\":58,\"Status\":0,\"Guid\":\"ae9c2d89-00c1-4d36-9482-98ae34528601\",\"HP\":0,\"maxHP\":0,\"IsRound\":false,\"Character\":null,\"ImgX\":0,\"ImgY\":0,\"X\":1024,\"Y\":1170,\"FowWidth\":216,\"FowHeight\":248}]";
		else
			return;

		List<Token> fows = System.Text.Json.JsonSerializer.Deserialize<List<Token>>(str);
		foreach (var t in fows)
			Tokens.Add(t);

		Update();
	}

}

public class Token
{
	private VTTTokens _id;

	public VTTTokens ID
	{
		get { return _id; }
		set { 
			if( _id == value ) return;
			_id = value;
			UpdateNeeeded?.Invoke(this, EventArgs.Empty);
		}
	}


	private TokenStatus _status = TokenStatus.Normal;
	public event EventHandler UpdateNeeeded;

	public enum Sizes { human, troll, dragon}

	private Sizes _size = Sizes.human;
	public Sizes Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			UpdateNeeeded?.Invoke(this, EventArgs.Empty);
		}
	}

	public int SizePixels
	{
		get
		{
			if (Size == Sizes.human) return 60;
			else if (Size == Sizes.troll) return 107;
			else return 213;
		}
	}

	public TokenStatus Status
	{
		get { return _status; }
		set { 
			_status = value; 
			UpdateNeeeded?.Invoke(this, EventArgs.Empty);
		}
	}

	public static int BasicSize = 60;
	private Guid _guid; 
	private int _hp;
	private int _maxHp;

	public event EventHandler<Guid> StoreChangesInCharacterSheet;

	public Guid Guid
	{
		get 
		{
			if (_character is not null) return _character.ID;
			else return _guid;
		}
		set
		{
			if (_character is not null) _character.ID = value;
			else _guid = value;
		}
	}
	public int HP {
		get
		{
			if (_character is not null) return _character.HP;
			else return _hp;
		}
		set
		{
			if (_character is not null) { 
				_character.HP = value;
				StoreChangesInCharacterSheet?.Invoke(this, _character.ID);
			}
			else _hp = value;
			UpdateNeeeded?.Invoke(this, EventArgs.Empty);
		}
	}
	public int maxHP
	{
		get
		{
			if (_character is not null) return _character.MaxHP;
			else return _maxHp;
		}
		set
		{
			if (_character is not null)
			{
				_character.MaxHP = value;
			}
			else
			{
				_maxHp = value;
				_hp = value;
			}
		}
	}

	public bool IsRound { get; set; } = false;

	PbtACharacter? _character;
	public Monster Monster { get; set; }

	public PbtACharacter? Character { 
		get => _character;
		set
		{
			if(value is not null && value != _character)
			{
				_character = value;
				if(!string.IsNullOrEmpty(_character.ClassString))
				{
					var str = _character.ClassString;
					if (str == "DW_Barbarian") ID = VTTTokens.Barbarian;
					else if (str == "DW_Bard") ID = VTTTokens.Bard;
					else if (str == "DW_Cleric") ID = VTTTokens.Cleric;
					else if (str == "DW_Druid") ID = VTTTokens.Druid;
					else if (str == "DW_Explorer") ID = VTTTokens.Ranger;
					else if (str == "DW_Fighter") ID = VTTTokens.Fighter;
					else if (str == "DW_Thief") ID = VTTTokens.Thief;
					else if (str == "DW_Mage") ID = VTTTokens.Mage;
					else if (str == "DW_Paladin") ID = VTTTokens.Paladin;
					else if (str == "DW_Wielder") ID = VTTTokens.Wielder;
				}
			}
		}
	}

	[JsonIgnore]
	public int PercentageLife
	{
		get
		{
			return int.Min(100, (int)((float)HP * 100.0 / (float)maxHP));
		}
	}

	[JsonIgnore]
	public string LifeBarColor
	{
		get
		{
			if (PercentageLife <= 25) return "red";
			else if (PercentageLife <= 50) return "orange";
			else if (PercentageLife <= 75) return "yellow";
			else return "green";
		}		
	}

	public Token()
    {
        Guid = Guid.NewGuid();
    }


	public int ImgX
	{
		get
		{
			return ID switch
			{
				VTTTokens.WhiteLady1 => -SizePixels * 0,
				VTTTokens.WhiteLady2 => -SizePixels * 1,
				VTTTokens.WhiteLady3 => -SizePixels * 2,
				VTTTokens.WhiteMale1 => -SizePixels * 3,
				VTTTokens.WhiteMale2 => -SizePixels * 4,
				VTTTokens.WhiteMale3 => -SizePixels * 5,
				VTTTokens.BoxGray => -SizePixels * 6,
				VTTTokens.BoxRed => -SizePixels * 0,
				VTTTokens.BoxBlue => -SizePixels * 1,
				VTTTokens.Black1 => -SizePixels * 2,
				VTTTokens.Black2 => -SizePixels * 3,
				VTTTokens.Black3 => -SizePixels * 4,
				VTTTokens.Black4 => -SizePixels * 5,
				VTTTokens.Black5 => -SizePixels * 6,
				VTTTokens.Black6 => -SizePixels * 0,
				VTTTokens.Black7 => -SizePixels * 1,
				VTTTokens.Black8 => -SizePixels * 2,
				VTTTokens.BlackBoss => -SizePixels * 3,

				VTTTokens.Red8 => -SizePixels * 5,
				VTTTokens.Red7 => -SizePixels * 6,
				VTTTokens.Red6 => -SizePixels * 0,
				VTTTokens.Red5 => -SizePixels * 1,
				VTTTokens.Red4 => -SizePixels * 2,
				VTTTokens.Red3 => -SizePixels * 3,
				VTTTokens.Red2 => -SizePixels * 4,
				VTTTokens.Red1 => -SizePixels * 5,
				VTTTokens.RedBoss => -SizePixels * 6,

				VTTTokens.Green1 => -SizePixels * 1,
				VTTTokens.Green2 => -SizePixels * 2,
				VTTTokens.Green3 => -SizePixels * 3,
				VTTTokens.Green4 => -SizePixels * 4,
				VTTTokens.Green5 => -SizePixels * 5,
				VTTTokens.Green6 => -SizePixels * 6,
				VTTTokens.Green7 => -SizePixels * 0,
				VTTTokens.Green8 => -SizePixels * 1,
				VTTTokens.GreenBoss => -SizePixels * 2,
				VTTTokens.Cleric => -SizePixels * 3,
				VTTTokens.Druid => -SizePixels * 4,
				VTTTokens.Barbarian => -SizePixels * 5,
				//VTTTokens.Green6 => -SizePixels * 6,
				VTTTokens.Paladin => -SizePixels * 0,
				VTTTokens.Ranger => -SizePixels * 1,
				VTTTokens.Thief => -SizePixels * 2,
				VTTTokens.Fighter => -SizePixels * 3,
				VTTTokens.Bard => -SizePixels * 4,
				VTTTokens.Mage => -SizePixels * 5,
				VTTTokens.Wielder => -SizePixels * 6,
				//VTTTokens.Paladin => -SizePixels * 0,
				VTTTokens.Blue8 => -SizePixels * 1,
				VTTTokens.Blue7 => -SizePixels * 2,
				VTTTokens.Blue6 => -SizePixels * 3,
				VTTTokens.Blue5 => -SizePixels * 4,
				VTTTokens.Blue4 => -SizePixels * 5,
				VTTTokens.Blue3 => -SizePixels * 6,
				VTTTokens.Blue2 => -SizePixels * 0,
				VTTTokens.Blue1 => -SizePixels * 1,
				VTTTokens.BlueBoss => -SizePixels * 2,
				//VTTTokens.Blue6 => -SizePixels * 3,
				VTTTokens.Gold => -SizePixels * 4,
				VTTTokens.RedPotion => -SizePixels * 5,
				VTTTokens.GreenPotion => -SizePixels * 6,
				_ => 0
			};
		}
	}
	public int ImgY
	{
		get
		{
			return ID switch
			{
				VTTTokens.WhiteLady1 => -SizePixels * 0,
				VTTTokens.WhiteLady2 => -SizePixels * 0,
				VTTTokens.WhiteLady3 => -SizePixels * 0,
				VTTTokens.WhiteMale1 => -SizePixels * 0,
				VTTTokens.WhiteMale2 => -SizePixels * 0,
				VTTTokens.WhiteMale3 => -SizePixels * 0,
				VTTTokens.BoxGray => -SizePixels * 0,
				VTTTokens.BoxRed => -SizePixels * 1,
				VTTTokens.BoxBlue => -SizePixels * 1,
				VTTTokens.Black1 => -SizePixels * 1,
				VTTTokens.Black2 => -SizePixels * 1,
				VTTTokens.Black3 => -SizePixels * 1,
				VTTTokens.Black4 => -SizePixels * 1,
				VTTTokens.Black5 => -SizePixels * 1,
				VTTTokens.Black6 => -SizePixels * 2,
				VTTTokens.Black7 => -SizePixels * 2,
				VTTTokens.Black8 => -SizePixels * 2,
				VTTTokens.BlackBoss => -SizePixels * 2,

				VTTTokens.Red8 => -SizePixels * 2,
				VTTTokens.Red7 => -SizePixels * 2,
				VTTTokens.Red6 => -SizePixels * 3,
				VTTTokens.Red5 => -SizePixels * 3,
				VTTTokens.Red4 => -SizePixels * 3,
				VTTTokens.Red3 => -SizePixels * 3,
				VTTTokens.Red2 => -SizePixels * 3,
				VTTTokens.Red1 => -SizePixels * 3,
				VTTTokens.RedBoss => -SizePixels * 3,

				VTTTokens.Green1 => -SizePixels * 4,
				VTTTokens.Green2 => -SizePixels * 4,
				VTTTokens.Green3 => -SizePixels * 4,
				VTTTokens.Green4 => -SizePixels * 4,
				VTTTokens.Green5 => -SizePixels * 4,
				VTTTokens.Green6 => -SizePixels * 4,
				VTTTokens.Green7 => -SizePixels * 5,
				VTTTokens.Green8 => -SizePixels * 5,
				VTTTokens.GreenBoss => -SizePixels * 5,
				VTTTokens.Cleric => -SizePixels * 5,
				VTTTokens.Druid => -SizePixels * 5,
				VTTTokens.Barbarian => -SizePixels * 5,
				//VTTTokens.Green6 => -SizePixels * 6,
				VTTTokens.Paladin => -SizePixels * 6,
				VTTTokens.Ranger => -SizePixels * 6,
				VTTTokens.Thief => -SizePixels * 6,
				VTTTokens.Fighter => -SizePixels * 6,
				VTTTokens.Bard => -SizePixels * 6,
				VTTTokens.Mage => -SizePixels * 6,
				VTTTokens.Wielder => -SizePixels * 6,
				//VTTTokens.Paladin => -SizePixels * 0,
				VTTTokens.Blue8 => -SizePixels * 7,
				VTTTokens.Blue7 => -SizePixels * 7,
				VTTTokens.Blue6 => -SizePixels * 7,
				VTTTokens.Blue5 => -SizePixels * 7,
				VTTTokens.Blue4 => -SizePixels * 7,
				VTTTokens.Blue3 => -SizePixels * 7,
				VTTTokens.Blue2 => -SizePixels * 8,
				VTTTokens.Blue1 => -SizePixels * 8,
				VTTTokens.BlueBoss => -SizePixels * 8,
				//VTTTokens.Blue6 => -SizePixels * 3,
				VTTTokens.Gold => -SizePixels * 8,
				VTTTokens.RedPotion => -SizePixels * 8,
				VTTTokens.GreenPotion => -SizePixels * 8,
				_ => 0
			};
		}
	}

	public int X { get; set; }
	public int Y { get; set; }

	public int FowWidth { get; set; }
	public int FowHeight { get; set; }	
}


public class Prop : Token
{
	private TokenStatus _status = TokenStatus.Normal;
	private VTTTokens _id;
	public new VTTTokens ID
	{
		get
		{
			return _id;
		}
		set
		{
			_id = value;
			if (_id == VTTTokens.Door_Big || _id == VTTTokens.Door_Round || _id == VTTTokens.Door_Square || 
				_id == VTTTokens.DoorSmall)
			{
				DoorState = DoorStates.Open;
			}
			else if(_id == VTTTokens.Chest)
				DoorState = DoorStates.Gate;
			else
				DoorState = DoorStates.NotADoor;
		}
	}
	public static string GetImagePath(VTTTokens t) => new Prop { ID = t }.imgURL;
	public string imgURL
	{
		get
		{
			string path = "";

			if (ID.IsForest())
				path = "_content/PbtaWorldRazonCommonComponents/imgs/Maps/Props/";
			else
				path = "_content/PbtaWorldRazonCommonComponents/imgs/Maps/DungeonProps/";

			if (ID == VTTTokens.Door_Square)
			{
				if (DoorState == DoorStates.Open) path += "Door_Square_Open";
				else if (DoorState == DoorStates.Wood) path += "Door_Square_Closed_Door";
				else path += "Door_Square_Closed_Gated";
			}
			else if (ID == VTTTokens.Door_Round)
			{
				if (DoorState == DoorStates.Open) path += "Door_Round_Opened";
				else if (DoorState == DoorStates.Wood) path += "Door_Round_Closed_Wood";
				else path += "Door_Round_Closed_Gated";
			}
			else if (ID == VTTTokens.DoorSmall)
			{
				if (DoorState == DoorStates.Open) path += "Door_Small_Opened";
				else if (DoorState == DoorStates.Wood) path += "Door_Small_Gated";
				else path += "Door_Small_Gated";
			}
			else if (ID == VTTTokens.Door_Big)
			{
				if (DoorState == DoorStates.Open) path += "Door_BIG_Open";
				else if (DoorState == DoorStates.Wood) path += "Door_BIG_Closed";
				else path += "Door_BIG_Gated";
			}
			else if (ID == VTTTokens.Chest)
			{
				if (DoorState == DoorStates.Open) path += "Chest_Opened";
				else if (DoorState == DoorStates.Wood) path += "Chest_Closed";
				else path += "Chest_Closed";
			}
			else
				path += ID.ToString();

			path += ".png";

			return path;
		}
	}
	public int rotation { get; set; } = 0;
	public bool IsDoor => DoorState != DoorStates.NotADoor;
	public enum DoorStates { NotADoor, Open, Wood, Gate };
	public DoorStates DoorState { get; set; } = DoorStates.NotADoor;
	public void RotateRight()
	{
		rotation += 90;
		if (rotation >= 360) rotation -= 360;
	}

	public void OpenDoor() => DoorState = DoorStates.Open;
	public void CloseDoor() => DoorState = DoorStates.Wood;
	public void GateDoor() => DoorState = DoorStates.Gate;
}

