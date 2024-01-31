using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;

namespace PbtADBConnector.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{
	private readonly IConfiguration _config;
	public event EventHandler<Exception> OnNewSQLError;

	public SqlDataAccess(IConfiguration config)
	{
		_config = config;
	}

	public async Task<IEnumerable<T>> LoadData<T, U>(
		string storedProcedure,
		U parameters,
		string connectionId = "Default")
	{
		
		try
		{	
			using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
			var r = await connection.QueryAsync<T>(
				storedProcedure,
				parameters,
				commandType: CommandType.StoredProcedure);
			return r;
		}
		catch (Exception ex) 
		{
			OnNewSQLError?.Invoke(this, ex);
			return Enumerable.Empty<T>();
			throw;
		}
		
	}

	public async Task SaveData<T>(
		string storedProcedure,
		T parameters,
		string connectionId = "Default")
	{
		try
		{
			using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
			await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
		}
		catch (Exception ex)
		{
			OnNewSQLError?.Invoke(this, ex);
			throw;
		}
		
	}
}
