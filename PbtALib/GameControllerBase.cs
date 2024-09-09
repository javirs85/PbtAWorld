using PbtALib.ifaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public abstract class GameControllerBase<TIDPack, TStatsPack> : IGameController
{
	private Guid _sessionID;

	public Guid SessionID
	{
		get { return _sessionID; }
		set { _sessionID = value; 
			SquareMap.GameID = value;
			Clocks.GameID = value;
		}
	}

    public SquareMap SquareMap = new SquareMap();
	public ClocksManager Clocks = new();

	public People People { get; set; }
	public event EventHandler UpdatePeopleViewerInAllClientsEvent;

	private Random random = new Random();
	private LastRollViewerService lastRollViewer;

	public GameControllerBase(MovesServiceBase moves, IDataBaseController DB, LastRollViewerService LastRoll)
    {
		this.DB = DB;
		lastRollViewer = LastRoll;
		if (People is null) People = new People(null);
	}

	public event EventHandler UpdateUI;
	public event EventHandler<string> NewInfoToast;
	public event EventHandler<IRollReport> OnNewRoll;
	public event EventHandler<PbtAImage> OnMasterShowsImage;
	public event EventHandler<PNJ> OnMasterShowsPNJ;
	public event EventHandler<string> ImageToShowToAllPlayers;

	public ICharacter GetCharacterByID(Guid id)
	{
		var p = Players?.Find(x => x.ID == id);
		if (p is not null) return p;

		var ch = People.GetCharacterByID(id);
		if (ch is not null) return ch;

		return new PNJ { Name = "Character not found" };
	}

	public void RequestUpdateToUIOnClients() => UpdateUI?.Invoke(this, new EventArgs());
	public void ShowToastOnAllClients(string msg) => NewInfoToast?.Invoke(this, msg);
	public void ShowImageToAllPlayers(PbtAImage img) => OnMasterShowsImage?.Invoke(this, img);
	public void ShowPNJToAllPlayers(PNJ pnj) => OnMasterShowsPNJ?.Invoke(this, pnj);


	public IRollReport LastRoll;

	private List<PbtACharacter> _players = new();

	public List<PbtACharacter> Players
	{
		get { return _players; }
		set { _players = value; }
	}

	public IDataBaseController DB { get; }
	public List<Monster> MonsterDefinitionsInCurrentScene { get; set; } = new();
	public List<Monster> CurrentSceneEnemies { get; set; } = new();
	public BaseTextBook TextBook { get; set; }

	protected abstract void CreateNewRollReport();

	public void RollRaw(Guid PlayerID, List<DiceTypes> dices, RollTypes rtype = RollTypes.Roll_Simple)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			CreateNewRollReport();

			LastRoll.Roller = player.Name;
			LastRoll.Dices.Clear();
			LastRoll.RollType = rtype;

			foreach (var d in dices)
			{
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(d, random.Next(1, d.MaxValue() + 1)));
			}
			LastRoll.IsRaw = true;

			lastRollViewer.Show(LastRoll);
			//OnNewRoll?.Invoke(this, LastRoll);
		}
	}

	public void RollMonsterDamage(Monster m)
	{
		CreateNewRollReport();

		LastRoll.Roller = m.Name;
        LastRoll.Dices.Clear();
        LastRoll.IsRaw = true;
		if (m.Attack is not null)
		{
			LastRoll.RollType = m.Attack.RollType;
			LastRoll.IgnoresArmor = m.Attack.IgnoresArmor;
			LastRoll.ArmorPiercing = m.Attack.Piercing;

            foreach (var dice in m.Attack.Dices)
            {
                LastRoll.Dices.Add(new Tuple<DiceTypes, int>(dice, random.Next(1, dice.MaxValue() + 1)));
            }

			if(m.Attack.RollType == RollTypes.Roll_Disadvantage || m.Attack.RollType == RollTypes.Roll_Advantage)
			{
				if(m.Attack.Dices.Count == 1) {
					LastRoll.Dices.Add(new Tuple<DiceTypes, int>(m.Attack.Dices[0], random.Next(1, m.Attack.Dices[0].MaxValue() + 1)));
				}
			}
        }

		lastRollViewer.Show(LastRoll);
		OnNewRoll?.Invoke(this, LastRoll);
    }

	public void RollDamage(Guid PlayerID, DiceTypes dice , RollTypes rtype)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			CreateNewRollReport();

			LastRoll.Roller = player.Name;
			LastRoll.Dices.Clear();
			LastRoll.IsRaw = true;
			LastRoll.RollType = rtype;
			LastRoll.ArmorPiercing = 0;
			LastRoll.IgnoresArmor = false;

			LastRoll.Dices.Add(new Tuple<DiceTypes, int>(dice, random.Next(1, dice.MaxValue() + 1)));
			if (rtype == RollTypes.Roll_Disadvantage || rtype == RollTypes.Roll_DisadvantagePlus1d6 || rtype == RollTypes.Roll_Advantage || rtype == RollTypes.Roll_AdvantagePlus1d6)
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(dice, random.Next(1, dice.MaxValue() + 1)));
			if (rtype == RollTypes.Roll_SimplePlus1d6 || rtype == RollTypes.Roll_DisadvantagePlus1d6 || rtype == RollTypes.Roll_AdvantagePlus1d6)
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(DiceTypes.d6, random.Next(1, DiceTypes.d6.MaxValue() + 1)));

			lastRollViewer.Show(LastRoll);
			OnNewRoll?.Invoke(this, LastRoll);
		}
	}

	public void Roll(Guid PlayerID, IMove move, TStatsPack stat, TIDPack moveID, int hardcodedBonus, RollTypes rtype = RollTypes.Roll_Simple, string hardcodedRolledStatName = "")
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			CreateNewRollReport();

			LastRoll.IsRaw = false;
			LastRoll.Movement = move;

			LastRoll.d1 = random.Next(1, 7);
			LastRoll.d2 = random.Next(1, 7);
			LastRoll.d3 = random.Next(1, 7);
			LastRoll.bonus = hardcodedBonus;
			LastRoll.RollType = rtype;

			if (rtype == RollTypes.Roll_Simple)
				LastRoll.Total = LastRoll.d1 + LastRoll.d2 + LastRoll.bonus;
			else if(rtype == RollTypes.Roll_Disadvantage)
			{
				var l = new List<int> { LastRoll.d1, LastRoll.d2, LastRoll.d3 };
				l.Sort();
				LastRoll.d1 = l[0];
				LastRoll.d2 = l[1];
				LastRoll.d3 = l[2];
				LastRoll.Total = l[0] + l[1] + LastRoll.bonus;
			}
			else if(rtype == RollTypes.Roll_Advantage)
			{
				var l = new List<int> { LastRoll.d1, LastRoll.d2, LastRoll.d3 };
				l.Sort();
				LastRoll.d1 = l[0];
				LastRoll.d2 = l[1];
				LastRoll.d3 = l[2];
				LastRoll.Total = l[1] + l[2] + LastRoll.bonus;
			}

			LastRoll.Roller = player.Name;
			LastRoll.SetID(moveID);
			LastRoll.SetStat(stat);
			LastRoll.Movement = move;

			if(hardcodedRolledStatName != "")
				LastRoll.StatString = hardcodedRolledStatName;
		}

		lastRollViewer.Show(LastRoll);
		OnNewRoll?.Invoke(this, LastRoll);
	}

	public void AddPlayer(PbtACharacter player)
	{
		if (Players.Find(x => x.ID == player.ID) is null)
		{
			Players.Add(player);
			AddPlayerToPeople(player);
			RequestUpdateToUIOnClients();
		}
	}

	public virtual void AddPlayerToPeople(PbtACharacter ch) { }

	public virtual Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		throw new Exception("StoreChangesOnCharacter MUST be virtualized on derived GameController class");
	}

	public void Update()
	{
		RequestUpdateToUIOnClients();
	}

	public event EventHandler UpdateMasterMoveListRequested;
	public void UpdateMasterMoveList() => UpdateMasterMoveListRequested?.Invoke(this, EventArgs.Empty);

    public void AddMonsterDefinition(Monster monster)
    {
        MonsterDefinitionsInCurrentScene.Add(monster);
		Update();
		monster.Game = this;
    }
    public void RemoveMonsterDefinition(Monster monster)
    {
        MonsterDefinitionsInCurrentScene.Remove(monster);
        Update();
    }
    public void ShowImageToAllPlayers(string url)
	{
		ImageToShowToAllPlayers?.Invoke(this, url);
	}

	public void UpdatePeopleViewerInAllClients()
	{
		UpdatePeopleViewerInAllClientsEvent?.Invoke(this, EventArgs.Empty);
	}
}
