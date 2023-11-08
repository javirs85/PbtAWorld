using PbtADBConnector.DbAccess;
using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtADBConnector.Data;

public class SeasonData : ISeasonsData
{
	private readonly ISqlDataAccess _db;
	public SeasonData(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task DeleteSeason(Guid id) =>
		_db.SaveData("dbo.spCampaigns_DeleteCampaign", new { Guid = id });

	public Task<IEnumerable<Season>> GetAllSeasonsOfGame(AvailableGames game)
	{
		byte i = (byte)game;
		return GetAllSeasonsOfGame(i);
	}

	public async Task<Season?> GetSeason(Guid SeasonID) =>
		(await _db.LoadData<Season, dynamic>("dbo.spCampaigns_GetCampaign", new { SeasonID = SeasonID })).FirstOrDefault();

public Task<IEnumerable<Season>> GetAllSeasonsOfGame(byte gamecode) =>
		_db.LoadData<Season, dynamic>("dbo.spCampaigns_GetCampaignsOfGame", new { GameID = gamecode });

	public Task InsertSeason(Season season) =>
		_db.SaveData("dbo.spCampaigns_AddCampaign", new { season.CampaignGuid, season.Name, season.GameID });

	public Task UpdateSeason(Season season) =>
		_db.SaveData("dbo.spCampaigns_Update", new { season.CampaignGuid, season.Name, season.GameID });
}

public class CharacterData : ICharacterData
{
	private readonly ISqlDataAccess _db;
	public CharacterData(ISqlDataAccess db)
	{
		_db = db;
	}

	public async Task<string> GetSerializedDateForPlayer(Guid guid) =>
		(await _db.LoadData<string, dynamic>("dbo.spCharacter_GetSerializedDateForPlayer", new { Guid = guid })).FirstOrDefault();

	public Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID) =>
		_db.SaveData("dbo.spCharacter_Insert", new
		{
			GameID = GameID,
			CampaignID = CampaignID,
			serializedData = serializedData,
			Name = Name,
			classCode = classCode,
			Guid = CharacterID
		});

	public Task<IEnumerable<PlayerSummary>> GetAllCharactersOfSeason(Guid guid) =>
		_db.LoadData<PlayerSummary, dynamic>("dbo.spCharacter_GetAllCharactersInSeason", 
			new { SesionID = guid });

	public Task DeleteCharacter(PbtACharacter p) =>
		_db.SaveData("dbo.spCharacter_Delete", new { Guid = p.ID });
}


