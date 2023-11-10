using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;

public class DinoRollReport : RollReport<DinoMoveIDs, DinoStates>
{
    public DinoRollReport(DinoMovesService _moves) : base(_moves)
    {

    }
    public override string StatString => GetStat<DinoStates>().ToUIString();
}
