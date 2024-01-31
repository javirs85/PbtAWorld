using PbtADBConnector.Data;
using PbtALib;
using PbtALib.ifaces;

namespace PbtADBConnector;

public class DataBaseController : IDataBaseController
{
	public event EventHandler<Exception> OnNewDataBaseError;
	public ISeasonsData SeasonsDB { get; set; }
	public ICharacterData CharactersDB { get; set; }

	public DataBaseController(ISeasonsData _seasons, ICharacterData _characters)
	{
		SeasonsDB = _seasons;
		CharactersDB = _characters;
		SeasonsDB.OnNewSeasonDataError -= PropagateError;
		SeasonsDB.OnNewSeasonDataError += PropagateError;
		CharactersDB.OnNewError -= PropagateError;
		CharactersDB.OnNewError += PropagateError;
	}

	void PropagateError(object? sender, Exception e) => OnNewDataBaseError(sender, e);

	public event EventHandler OnUpdateRequested;

	public AvailableGames? SelectedGame { get; set; } = null;
	public Season? SelectedSeason { get; set; } = null;
	public ICharacter? SelectedPlayer { get; set; } = null;
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
			Seasons = await SeasonsDB.GetAllSeasonsOfGame((AvailableGames)SelectedGame);
			foreach (var s in Seasons)
				await LoadPlayerNamesForSeason(s);
		}
		OnUpdateRequested?.Invoke(this, EventArgs.Empty);
	}

	public async Task DeleteSelectedCharacter()
	{
		if (SelectedSeason is not null && SelectedPlayer is not null)
		{
			await CharactersDB.DeleteCharacter(SelectedPlayer);
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
		var summaries = await CharactersDB.GetAllCharactersOfSeason(season.CampaignGuid);
		foreach (var s in summaries)
		{
			season.Players.Add(new PbtACharacter
			{
				ID = s.Guid,
				Name = s.Name,
				EncodedClass = s.ClassCode
			});
		}
	}

	public async Task<string> GetSerializedDataOfSelectedPlayer()
	{
		if (SelectedPlayer is not null)
		{
			return await CharactersDB.GetSerializedDateForPlayer(SelectedPlayer.ID);
		}
		else
			return "";
	}





	public async Task DeleteSelectedSeason()
	{
		if (SelectedSeason is not null)
		{
			foreach (var p in SelectedSeason.Players)
				await CharactersDB.DeleteCharacter(p);

			await SeasonsDB.DeleteSeason(SelectedSeason.CampaignGuid);
			SelectedSeason = null;
		}
	}

	public async Task StoreSeasonAsNewSeason(Season newSeason)
	{
		await SeasonsDB.InsertSeason(newSeason);
		await LoadAllSessionsOfSelectedGame();
		OnUpdateRequested?.Invoke(this, EventArgs.Empty);
	}

	public async Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID)
	{
		await CharactersDB.InsertNewCharacter(GameID, CampaignID, serializedData, Name, classCode, CharacterID);
	}

	public async Task StoreChangesinCharacter(Guid CharacterID, string newName, string serializedData)
	{
		await CharactersDB.UpadteCharacter(CharacterID, newName, serializedData);
	}
}


