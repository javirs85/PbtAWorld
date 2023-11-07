using DungeonWorld.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;

namespace DungeonWorld;

public class DWGameController
{
	public event EventHandler<RollReport<DWMovementIDs, DWStats>> OnNewRoll;

	public async Task StoreChangesOn(DWCharacter p, string details)
	{

	}

	public async Task RequestRawRol(DWCharacter Player, List<DiceTypes> dices)
	{

	}
}
