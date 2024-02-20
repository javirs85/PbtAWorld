using DungeonWorld.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;
using PbtADBConnector;
using PbtALib.ifaces;

namespace DungeonWorld;

public class DWGameController  : GameControllerBase<DWMovementIDs, DWStats>, IGameController
{
	
	public DWGameController(DWMovesService moves, IDataBaseController _db) : base(moves, _db)
	{
		LastRoll = new DWRollReport(moves);
	}

	public DWTextBook Book = new DWTextBook();

	public SquareMap SquareMap = new SquareMap();


	public override async Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		if (ch is DWCharacter)
		{
			var DWChar = (DWCharacter)ch;
			if(newName != null) { DWChar.Name = newName; }

			await DB.StoreChangesinCharacter(ch.ID,ch.Name, System.Text.Json.JsonSerializer.Serialize(DWChar));
			if(!string.IsNullOrEmpty(notification) )
				ShowToastOnAllClients(notification);
		}
		else
			throw new Exception("tried to store a character that is not DWCharacter at DWGameController");
	}

}
