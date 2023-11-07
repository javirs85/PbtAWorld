using PbtALib;

namespace PbtADBConnector.Data;


public interface ISeasonsData
{
	Task DeleteSeason(Guid id);
	Task<Season?> GetSeason(Guid id);
	Task<IEnumerable<Season>> GetAllSeasonsOfGame(AvailableGames game);
	Task InsertSeason(Season season);
	Task UpdateSeason(Season season);
}