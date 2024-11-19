using DungeonWorld.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;
using PbtADBConnector;
using PbtALib.ifaces;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace DungeonWorld;

public class DWGameController  : GameControllerBase<DWMovementIDs, DWStats>, IGameController
{
	private DWMovesService movesService;
	public DWGameController(DWMovesService moves, IDataBaseController _db , LastRollViewerService _lastRollViewerService) : base(moves, _db, _lastRollViewerService)
	{
		movesService = moves;
		LastRoll = new DWRollReport(moves);
		TextBook = new DWTextBook();
	}



	public override async Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		if (ch is DWCharacter)
		{
			var DWChar = (DWCharacter)ch;
			if(newName != null) { DWChar.Name = newName; }

			await DB.StoreChangesinCharacter(ch.ID,ch.Name, System.Text.Json.JsonSerializer.Serialize(DWChar));
			if(!string.IsNullOrEmpty(notification) )
				ShowToastOnAllClients(ch.Name +": "+ notification);
		}
		else
			throw new Exception("tried to store a character that is not DWCharacter at DWGameController");
	}

	protected override void CreateNewRollReport()
	{
		LastRoll = new DWRollReport(movesService);
	}

}
