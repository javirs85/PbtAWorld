using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class DWRollReport : RollReport<DWMovementIDs, DWStats>
{
    public DWRollReport(DWMovesService _moves) : base(_moves)
    {
        
    }
    public override string StatString => Stat.ToLONG_UI();
}
