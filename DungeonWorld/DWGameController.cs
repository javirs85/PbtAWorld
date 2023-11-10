using DungeonWorld.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;
using PbtADBConnector;

namespace DungeonWorld;

public class DWGameController  : GameControllerBase<DWMovementIDs, DWStats>
{
	DataBaseController DB;
	
	public DWGameController(DWMovesService moves, DataBaseController _db) : base(moves, _db)
	{
		LastRoll = new DWRollReport(moves);
	}

	public async Task StoreChangesOn(DWCharacter p, string details)
	{

	}
}
