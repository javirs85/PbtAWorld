using PbtADBConnector.Data;
using PbtALib;

namespace PbtAWorldApp;

public class MetaController
{
	private readonly IUserData users;
	private readonly ISeasonsData seasons;
	private readonly ICharacterData characters;

	public MetaController(IUserData _users, ISeasonsData _seasons, ICharacterData _characters)
	{
		this.users = _users;
		seasons = _seasons;
		characters = _characters;
	}

	public event EventHandler OnUpdateRequested;

	public AvailableGames? SelectedGame { get; set; } = null;
	public Season? SelectedSeason { get; set; } = null;
	public PbtACharacter? SelectedPlayer { get; set; } = null;
	public IEnumerable<Season> Seasons { get; set; } = Enumerable.Empty<Season>();

	public string SelectedGameCover
	{
		get
		{
			return SelectedGame switch
			{
				AvailableGames.DI => "imgs/GameCovers/DinoIsland.png",
				AvailableGames.DW => "imgs/GameCovers/DungeonWorld.png",
				AvailableGames.US => "imgs/GameCovers/UrbanShadows.png",
				_ => ""
			};
		}
	}

	public async Task LoadAllSessionsOfSelectedGame()
	{
		if (SelectedGame != null)
		{
			Seasons = await seasons.GetAllSeasonsOfGame((AvailableGames)SelectedGame);
		}
	}

	public async Task DeleteSelectedSeason()
	{
		if (SelectedSeason is not null)
		{
			await seasons.DeleteSeason(SelectedSeason.Guid);
			SelectedSeason = null;
		}
	}

	public async Task StoreSeasonAsNewSeason(Season newSeason)
	{
		await seasons.InsertSeason(newSeason);
		await LoadAllSessionsOfSelectedGame();
		OnUpdateRequested?.Invoke(this, EventArgs.Empty);
	}

	public async Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID)
	{
		await characters.InsertNewCharacter(GameID, CampaignID, serializedData, Name, classCode, CharacterID);
	}

	public string debug = "";
	public async Task Test()
	{

	}
}


