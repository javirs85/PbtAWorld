using PbtADBConnector.DbAccess;
using PbtADBConnector.Models;
using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtADBConnector.Data;

public class UserData : IUserData
{
	private readonly ISqlDataAccess _db;

	public UserData(ISqlDataAccess db)
	{
		_db = db;
	}

	public Task<IEnumerable<UserModel>> GetUsers() =>
		_db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { });

	public async Task<UserModel?> GetUser(int id) =>
		(await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id })).FirstOrDefault();


	public Task InsertUser(UserModel user) =>
		_db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName });

	public Task UpdateUser(UserModel user) =>
		_db.SaveData("dbo.spUser_Update", user);

	public Task DeleteUser(int id) =>
		_db.SaveData("dbo.spUser_Delete", new { Id = id });
}

public class SeasonData : ISeasonsData
{
	private readonly ISqlDataAccess _db;
	public SeasonData(ISqlDataAccess db)
	{
		_db = db;
	}

    public Task DeleteSeason(Guid id) =>
		_db.SaveData("dbo.spCampaigns_DeleteCampaign", new { Id = id });

	public Task<IEnumerable<Season>> GetAllSeasonsAlGame(AvailableGames game) =>
		_db.LoadData<Season, dynamic>("dbo.spCampaigns_GetCampaignsOfGame", new { game });

	public Task InsertSeason(Season season) =>
		_db.SaveData("dbo.spCampaigns_AddCampaign", new { season.Guid, season.Name, season.GameID });

	public Task UpdateSeason(Season season) =>
		_db.SaveData("dbo.spCampaigns_UpdateName", season);
}
