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

    private string _statstring = string.Empty;

	public override string StatString { 
        get { 
            if(_statstring == string.Empty)
                return Stat.ToLONG_UI(); 
            return _statstring;
        }
        set { _statstring = value; } 
    }

}
