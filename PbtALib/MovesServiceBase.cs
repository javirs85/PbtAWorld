using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;


public abstract class MovesServiceBase
{
	public abstract IMove GetMovement<TMovIDs, TClases>(TMovIDs ID, TClases archetype);
	public abstract IMove GetMovement<TMovIDs>(TMovIDs ID);
}
