﻿using PbtALib.ifaces;

namespace PbtALib;

public interface IDataBaseController
{
	event EventHandler<Exception> OnNewDataBaseError;

	ISeasonsData SeasonsDB { get; set; }
	ICharacterData CharactersDB { get; set; }

	IEnumerable<Season> Seasons { get; set; }
	AvailableGames? SelectedGame { get; set; }
	string SelectedGameCover { get; }
	ICharacter? SelectedPlayer { get; set; }
	Season? SelectedSeason { get; set; }

	event EventHandler OnUpdateRequested;

	Task DeleteSelectedCharacter();
	Task DeleteSelectedSeason();
	Task<string> GetSerializedDataOfSelectedPlayer();
	Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID);
	Task LoadAllSessionsOfSelectedGame();
	Task LoadPlayerNamesForSeason(Season season);
	Task StoreSeasonAsNewSeason(Season newSeason);
	Task StoreChangesinCharacter(Guid CharacterID, string newName, string serializedData);
}