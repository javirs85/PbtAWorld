using PbtADBConnector.Models;
using PbtALib;

namespace PbtADBConnector.Data;

public interface IUserData
{
	Task DeleteUser(int id);
	Task<UserModel?> GetUser(int id);
	Task<IEnumerable<UserModel>> GetUsers();
	Task InsertUser(UserModel user);
	Task UpdateUser(UserModel user);
}

public interface ISeasonsData
{
	Task DeleteSeason(Guid id);
	Task<IEnumerable<Season>> GetAllSeasonsAlGame(AvailableGames game);
	Task InsertSeason(Season season);
	Task UpdateSeason(Season season);
}