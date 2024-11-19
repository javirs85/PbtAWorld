using PbtADBConnector;
using PbtALib;
using System.ComponentModel;

namespace DinoIsland;

public class DinoGameController : GameControllerBase<DinoMoveIDs, DinoStates>
{
	DinoMovesService moves;

	public DinoGameController(DinoMovesService _moves, IDataBaseController _db, LastRollViewerService _lastrollviewer) : base(_moves, _db, _lastrollviewer)
	{
		LastRoll = new DinoRollReport(_moves);
		moves = _moves;
	}


	protected override void CreateNewRollReport()
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
			base.Roll(PlayerID, Move, Roll, Move.ID, player.GetBonus(Roll), RollTypes.Roll_Simple);
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

	public override async Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		if (ch is DinoCharacter)
		{
			var character = (DinoCharacter)ch;
			await DB.StoreChangesinCharacter(character.ID, character.Name, System.Text.Json.JsonSerializer.Serialize(character));
		}
		else
			throw new Exception("tried to store a character that is not DinoCharacter from DInoGameController");
	}

}
