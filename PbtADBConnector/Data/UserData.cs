﻿using PbtADBConnector.DbAccess;
using PbtALib;
using PbtALib.ifaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtADBConnector.Data;

public class SeasonData : ISeasonsData
{
	private ISqlDataAccess _db;
	public event EventHandler<Exception> OnNewSeasonDataError;
	public SeasonData(ISqlDataAccess db)
	{
		_db = db;
		_db.OnNewSQLError -= PropagateError;
		_db.OnNewSQLError += PropagateError;
	}

	void PropagateError(object? sender, Exception e) => OnNewSeasonDataError(sender, e);

	public Task DeleteSeason(Guid id) =>
		_db.SaveData("dbo.TestCamp_DeleteCampaign", new { Guid = id });

	public Task<IEnumerable<Season>> GetAllSeasonsOfGame(AvailableGames game)
	{
		byte i = (byte)game;
		return GetAllSeasonsOfGame(i);
	}

	public async Task<Season?> GetSeason(Guid SeasonID) =>
		(await _db.LoadData<Season, dynamic>("dbo.TestCamp_GetCampaign", new { SeasonID = SeasonID })).FirstOrDefault();

	public Task<IEnumerable<Season>> GetAllSeasonsOfGame(byte gamecode) =>
		_db.LoadData<Season, dynamic>("dbo.TestCamp_GetCampaignsOfGame", new { GameID = gamecode });

	public Task InsertSeason(Season season) =>
		_db.SaveData("dbo.TestCamp_AddCampaign", new { season.CampaignGuid, season.Name, season.GameID });

	public Task UpdateSeason(Season season) =>
		_db.SaveData("dbo.TestCamp_Update", new { season.CampaignGuid, season.Name, season.GameID });
}

public class CharacterData : ICharacterData
{
	private readonly ISqlDataAccess _db;
	public event EventHandler<Exception> OnNewError;
	public CharacterData(ISqlDataAccess db)
	{
		_db = db;
		_db.OnNewSQLError -= OnNewError;
		_db.OnNewSQLError += OnNewError;
	}

	public async Task<string> GetSerializedDateForPlayer(Guid guid) =>
		(await _db.LoadData<string, dynamic>("dbo.TestChar_GetSerializedDateForPlayer", new { Guid = guid })).FirstOrDefault();

	public Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID) =>
		_db.SaveData("dbo.TestChar_Insert", new
		{
			GameID = GameID,
			CampaignID = CampaignID,
			serializedData = serializedData,
			Name = Name,
			classCode = classCode,
			Guid = CharacterID
		});

	public Task UpadteCharacter(Guid CharacterID, string newName, string newSerializedData) =>
		_db.SaveData("dbo.TestChar_Update", new {Guid = CharacterID, newName = newName, SerializedData = newSerializedData });

	public Task DeleteCharacter(ICharacter p) =>
		_db.SaveData("dbo.TestChar_Delete", new { Guid = p.ID });

	public Task<IEnumerable<PlayerSummary>> GetAllCharactersOfSeason(Guid guid) =>
		_db.LoadData<PlayerSummary, dynamic>("dbo.TestChar_GetAllCharactersInSeason",
			new { SesionID = guid });
		
}


