
namespace PbtALib;

public interface ICharacterData
{
	event EventHandler<Exception> OnNewError;
	Task DeleteCharacter(ICharacter p);
	Task<IEnumerable<PlayerSummary>> GetAllCharactersOfSeason(Guid guid);
	Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID);
	Task<string> GetSerializedDateForPlayer(Guid guid);
	Task UpadteCharacter(Guid CharacterID, string newName, string newSerializedData);
}


public class PlayerSummary
{
	public string Name { get; set; } = string.Empty;
	public Guid CampaignID { get; set; }
	public byte ClassCode { get; set; }
	public byte GameCode { get; set; }
	public Guid Guid { get; set; }
}