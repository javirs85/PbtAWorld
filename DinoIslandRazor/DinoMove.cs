using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;





public class DinoMove : BaseMove<DinoMoveIDs, DinoStates>
{
    public DinoMove(DinoMoveIDs moveId, DinoStates state) : base(moveId, state) {
        Title = "Tittle not set";
    }

    public MovementType TypeOfMovement { get; set; } = MovementType.NotSet;
    public DinoClasses ForClass { get; set; } = DinoClasses.NotSet;
    public bool IsAdvancedMove { get; set; } = false;

    public bool Purchased { get; set; } = true;


	public override bool HasRoll() => Roll != DinoStates.D_NoRoll && Roll != DinoStates.D_NotSet && Roll != DinoStates.D_MC ;
	public override string ToUI() => Roll.ToUIString();
}
