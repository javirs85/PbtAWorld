using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLibrary;

public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration _config;
	public event EventHandler<Exception>? ErrorToDebug;
	public event EventHandler<string>? MessageToDebug;

	public string ConnectionStringName { get; set; } = "Default"; //"Azure"

	public SqlDataAccess(IConfiguration config)
	{
		_config = config;
	}

	public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
	{
		try
		{
			string connectionString = _config.GetConnectionString(ConnectionStringName) ?? "Not found";
			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				var data = await connection.QueryAsync<T>(sql, parameters);
				MessageToDebug?.Invoke(this, "Connected!");
				return data.ToList();
			}
		}
		catch (Exception ex)
		{
			ErrorToDebug?.Invoke(this, ex);
		}

		return new List<T> { };
	}

	public async Task SaveData<T>(string sql, T parameters)
	{
		string connectionString = _config.GetConnectionString(ConnectionStringName) ?? "Not found";
		using (IDbConnection connection = new SqlConnection(connectionString))
		{
			var data = await connection.ExecuteAsync(sql, parameters);
		}
	}
}