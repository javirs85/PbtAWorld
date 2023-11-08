using System;
using System.Collections.Generic;
using System.Linq;
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
		LastRoll = new(moves);
	}

	public event EventHandler OnUIUpdate;
	public event EventHandler<string> NewInfoToast;
	public event EventHandler<RollReport<TIDPack, TStatsPack>> OnNewRoll;
	public event EventHandler<PbtAImage> OnMasterShowsImage;
	public event EventHandler<PNJ> OnMasterShowsPNJ;

	public void RequestUpdateToUIOnClients() => OnUIUpdate?.Invoke(this, new EventArgs());
	public void ShowToastOnAllClients(string msg) => NewInfoToast?.Invoke(this, msg);
	public void ShowImageToAllPlayers(PbtAImage img) => OnMasterShowsImage?.Invoke(this, img);
	public void ShowPNJToAllPlayers(PNJ pnj) => OnMasterShowsPNJ?.Invoke(this, pnj);


	public RollReport<TIDPack, TStatsPack> LastRoll;

	public List<PbtACharacter> Players = new();

	public void Roll(Guid PlayerID, TStatsPack stat, TIDPack moveID, int hardcodedBonus, RollTypes rtype = RollTypes.Roll_Simple)
	{
		var player = Players.Find(x => x.ID == PlayerID);
		if (player is not null)
		{
			LastRoll.d1 = random.Next(1, 7);
			LastRoll.d2 = random.Next(1, 7);
			LastRoll.d3 = random.Next(1, 7);
			LastRoll.bonus = hardcodedBonus;

			if (rtype == RollTypes.Roll_Simple)
				LastRoll.Total = LastRoll.d1 + LastRoll.d2 + LastRoll.bonus;
			else if(rtype == RollTypes.Roll_Disadvantage)
			{
				var l = new List<int> { LastRoll.d1, LastRoll.d2, LastRoll.d3 };
				l.Sort();
				LastRoll.d1 = l[0];
				LastRoll.d2 = l[1];
				LastRoll.d3 = l[2];
				LastRoll.Total = l[0] + l[1];
			}
			else if(rtype == RollTypes.Roll_Advantage)
			{
				var l = new List<int> { LastRoll.d1, LastRoll.d2, LastRoll.d3 };
				l.Sort();
				LastRoll.d1 = l[0];
				LastRoll.d2 = l[1];
				LastRoll.d3 = l[2];
				LastRoll.Total = l[1] + l[2];
			}

			LastRoll.Roller = player.Name;
			LastRoll.MoveId = moveID;
			LastRoll.Stat = stat;
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
}
