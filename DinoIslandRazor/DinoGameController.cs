using PbtADBConnector;
using PbtALib;

namespace DinoIsland;

public class DinoGameController : GameControllerBase<DinoMoveIDs, DinoStates>
{
	DataBaseController DB;
	public DinoGameController(DinoMovesService moves, DataBaseController _db) : base(moves, _db)
	{
		LastRoll = new DinoRollReport(moves);
	}

	public event EventHandler OnShowLastMoveToPlayers;

	public void ShowLastMoveToPlayers() => OnShowLastMoveToPlayers?.Invoke(this, EventArgs.Empty);

	public DinoTextBook TextBook = new DinoTextBook();

	public List<MapItem> MapTokens { get; set; } = new List<MapItem>();

	public string WhereAreYou { get; set; } = string.Empty;
	public string _obstaclePlayers = string.Empty;
	public string ObstaclePlayers 
	{ 
		get { return _obstaclePlayers; } 
		set {
		_obstaclePlayers = value;
			RequestUpdateToUIOnClients();
		} 
	}

	public string _obstacleMC = string.Empty;
	public string ObstacleMC
	{
		get { return _obstacleMC; }
		set
		{
			_obstacleMC = value;
			RequestUpdateToUIOnClients();
		}
	}


	public string TheWayOut { get; set; } = string.Empty;
	public string GimmickSelected { get; set; } = string.Empty;
	
	public string NPCGoalsSelected { get; set; } = string.Empty;
	public string NPCOffersSelected { get; set; } = string.Empty;
	

	private string _whyComing =string.Empty;

	public string WhyComing
	{
		get { return _whyComing; }
		set { _whyComing = value; RequestUpdateToUIOnClients(); }
	}



	public Mystery? SelectedMystery { get; set; }	
	public MysterySolution? SelectedSolution { get;set; }
	public ExtinctionEvent? SelectedExtinctionEvent { get; set; }
	
	public void SomeoneRolled(RollReport<DinoMoveIDs, DinoStates> roll)
	{
		LastRoll = roll;
		RequestUpdateToUIOnClients();
	}

	public List<PNJ> PNJs { get; set; } = new();

	public void Roll(Guid PlayerID, DinoStates Roll, DinoMove Move)
	{
		var player = Players.Find(x => x.ID == PlayerID) as DinoCharacter;
		if (player is not null)
		{
			base.Roll(PlayerID, Roll, Move.ID, player.GetBonus(Roll), RollTypes.Roll_Simple);
		}
		else
			ShowToastOnAllClients("player with id " + PlayerID + "cannot be found");
	}

	public void SetRumor(Guid ID, string Rumor)
	{
		var player = Players.Find(x => x.ID == ID) as DinoCharacter;

		if (player is not null) player.Rumor = Rumor;
		RequestUpdateToUIOnClients();
	}

	public void UpdateMap(MapItem UpdateInMap)
	{
		if (UpdateInMap.Action == MapActions.Add)
			MapTokens.Add(UpdateInMap);
		else if (UpdateInMap.Action == MapActions.Remove)
		{
			var item = MapTokens.Find(x => x.ID == UpdateInMap.ID);
			if(item is not null) MapTokens.Remove(item);
		}
		RequestUpdateToUIOnClients();
	}
}
