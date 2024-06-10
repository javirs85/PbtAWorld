using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class DWMove : BaseMove<DWMovementIDs, DWStats>
{
	public DWMove(DWMovementIDs IDs, DWStats roll) : base(IDs, roll)
	{
		Title = "Not Set";
	}

	public List<SubMovement> SelectableOptions = new List<SubMovement>();

	public bool HasSubMovements { get; internal set; }
	public DWClasses Classes { get; internal set; } = DWClasses.DW_NotSet;
	public bool IsAdvancedMovement { get; internal set; } = false;
	public bool IsSelectedByDefault { get; internal set; } = false;
	

	public override bool HasRoll()
	{
		List<DWStats> rollableStats = new List<DWStats> {
				DWStats.DW_STR, DWStats.DW_DEX, DWStats.DW_CON, DWStats.DW_INT, DWStats.DW_WIS, DWStats.DW_CHA
			};
		return rollableStats.Contains(Roll);
	}

	public override string ToUI() => Roll.ToUI();

}

public class SubMovement
{
	public DWMovementIDs ID { get; set; }
	public string Description { get; set; } = "";
	public string Tittle { get; set; } = "";
}