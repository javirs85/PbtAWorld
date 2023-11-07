using PbtALib;

namespace PbtADBConnector.Data
{
	public interface ICharacterData
	{
		Task DeleteCharacter(PbtACharacter p);
		Task<IEnumerable<PlayerSummary>> GetAllCharactersOfSeason(Guid guid);
		Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID);
		Task<string> GetSerializedDateForPlayer(Guid guid);
	}
}