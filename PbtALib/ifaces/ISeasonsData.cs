using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib.ifaces;

public interface ISeasonsData
{
	Task DeleteSeason(Guid id);
	Task<Season?> GetSeason(Guid id);
	Task<IEnumerable<Season>> GetAllSeasonsOfGame(AvailableGames game);
	Task InsertSeason(Season season);
	Task UpdateSeason(Season season);
}
