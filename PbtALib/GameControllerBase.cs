using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class GameControllerBase<TIDPack, TStatsPack>
{
	private readonly MovesServiceBase moves;
	private Random random = new Random();

	public GameControllerBase(MovesServiceBase moves, IDataBaseController DB)
    {
		this.moves = moves;
		this.DB = DB;
	}

	public event EventHandler OnUIUpdate;
	public event EventHandler<string> NewInfoToast;
	public event EventHandler<IRollReport> OnNewRoll;
	public event EventHandler<PbtAImage> OnMasterShowsImage;
	public event EventHandler<PNJ> OnMasterShowsPNJ;

	public void RequestUpdateToUIOnClients() => OnUIUpdate?.Invoke(this, new EventArgs());
	public void ShowToastOnAllClients(string msg) => NewInfoToast?.Invoke(this, msg);
	public void ShowImageToAllPlayers(PbtAImage img) => OnMasterShowsImage?.Invoke(this, img);
	public void ShowPNJToAllPlayers(PNJ pnj) => OnMasterShowsPNJ?.Invoke(this, pnj);


	public IRollReport LastRoll;

	public List<PbtACharacter> Players = new();

	public IDataBaseController DB { get; }

	public void RollRaw(Guid PlayerID, List<DiceTypes> dices)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			LastRoll.Roller = player.Name;
			LastRoll.Dices.Clear();

			foreach (var d in dices)
			{
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(d, random.Next(1, d.MaxValue() + 1)));
			}
			LastRoll.IsRaw = true;
			OnNewRoll?.Invoke(this, LastRoll);
		}
	}
	public void RollDamage(Guid PlayerID, DiceTypes dice , RollTypes rtype)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			LastRoll.Roller = player.Name;
			LastRoll.Dices.Clear();
			LastRoll.IsRaw = true;
			LastRoll.RollType = rtype;

			LastRoll.Dices.Add(new Tuple<DiceTypes, int>(dice, random.Next(1, dice.MaxValue() + 1)));
			if (rtype == RollTypes.Roll_Disadvantage || rtype == RollTypes.Roll_DisadvantagePlus1d6 || rtype == RollTypes.Roll_Advantage || rtype == RollTypes.Roll_AdvantagePlus1d6)
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(dice, random.Next(1, dice.MaxValue() + 1)));
			if (rtype == RollTypes.Roll_SimplePlus1d6 || rtype == RollTypes.Roll_DisadvantagePlus1d6 || rtype == RollTypes.Roll_AdvantagePlus1d6)
				LastRoll.Dices.Add(new Tuple<DiceTypes, int>(DiceTypes.d6, random.Next(1, DiceTypes.d6.MaxValue() + 1)));

			OnNewRoll?.Invoke(this, LastRoll);
		}
	}

	public void Roll(Guid PlayerID, TStatsPack stat, TIDPack moveID, int hardcodedBonus, RollTypes rtype = RollTypes.Roll_Simple)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			LastRoll.IsRaw = false;

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
		}

		OnNewRoll?.Invoke(this, LastRoll);
	}

	public void AddPlayer(PbtACharacter player)
	{
		if (Players.Find(x => x.ID == player.ID) is null)
		{
			Players.Add(player);
			RequestUpdateToUIOnClients();
		}
	}

	public virtual Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		throw new Exception("StoreChangesOnCharacter MUST be virtualized on derived GameController class");
	}
}
