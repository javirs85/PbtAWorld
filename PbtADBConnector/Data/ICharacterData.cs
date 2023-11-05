namespace PbtADBConnector.Data
{
	public interface ICharacterData
	{
		Task InsertNewCharacter(byte GameID, Guid CampaignID, string serializedData, string Name, int classCode, Guid CharacterID);
	}
}