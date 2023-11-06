using PbtADBConnector.Data;
using PbtALib;

namespace PbtAWorldApp;

public class MetaController
{
	private readonly IUserData users;
	public readonly ISeasonsData seasons;
	public readonly ICharacterData characters;

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
			foreach(var s in Seasons)
				await LoadPlayerNamesForSeason(s);
		}
		OnUpdateRequested?.Invoke(this, EventArgs.Empty);
	}

	public async Task DeleteSelectedCharacter()
	{
        if (SelectedSeason is not null &&  SelectedPlayer is not null)
        {
			await characters.DeleteCharacter(SelectedPlayer);
            var p = SelectedSeason.Players.Find(x => x.ID == SelectedPlayer.ID);
            if (p != null)
            {
                SelectedSeason.Players.Remove(p);
            }

            OnUpdateRequested?.Invoke(this, EventArgs.Empty);
        }
    }


    public async Task LoadPlayerNamesForSeason(Season season)
	{
		season.Players.Clear();
		var summaries =  await characters.GetAllCharactersOfSeason(season.CampaignGuid);
		foreach(var s in summaries)
		{
			season.Players.Add(new PbtACharacter { 
				ID = s.Guid, 
				Name = s.Name,
				EncodedClass = s.ClassCode
			});
		}
	}

	public async Task Start()
	{
		if (SelectedPlayer is not null)
		{
			throw new NotImplementedException();
		}
	}

	public string FromClassIDToUI(int classID)
	{
		if (SelectedGame == AvailableGames.DI)
		{
			return DinoIsland.Extensions.ToUIString((DinoIsland.DinoClasses)classID);
		}
		else if (SelectedGame == AvailableGames.DW)
		{
			return ((DungeonWorld.DWClasses)classID).ToString();
		}
		else
			return "Wrong SelectedGame at FromClassIDToUI";
	}



	public async Task DeleteSelectedSeason()
	{
		if (SelectedSeason is not null)
		{
			foreach (var p in SelectedSeason.Players)
				await characters.DeleteCharacter(p);

			await seasons.DeleteSeason(SelectedSeason.CampaignGuid);
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


