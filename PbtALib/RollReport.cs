using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class RollReport<T_ID, T_Stats>
{
	MovesServiceBase? Moves;

	public RollReport()
	{

	}

	public RollReport(MovesServiceBase moves, T_ID MoveID, T_Stats stat)
	{
		Moves = moves;
		MoveId = MoveID;
		Stat = stat;
	}

	public RollReport(T_ID MoveID, T_Stats stat, string MoveTittle, string _iDofTheRoller, RollTypes type = RollTypes.DW_Simple)
	{
		MoveId = MoveID;
		Stat = stat;
		LocalTittle = MoveTittle;
		Roller = _iDofTheRoller;
		RollType = type;
	}


	public RollTypes RollType { get; set; } = RollTypes.DW_Simple;
	public string Roller { get; set; } = string.Empty;
	public int d1 { get; set; } = 0;
	public int d2 { get; set; } = 0;
	public int StatValue { get; set; } = 0;
	public int bonus { get; set; } = 0;
	public int Total => d1 + d2 + bonus;
	public T_ID MoveId { get; set; }
	public T_Stats Stat { get; set; }
	public string LocalTittle { get; set; } = "";
	public string MoveTittle { 
		get { 
			if(!string.IsNullOrEmpty(LocalTittle)) return LocalTittle;
			return Moves?.GetMovement<T_ID>(MoveId).Tittle ?? "Cannot find move's tittle @ RollReport::MoveTittle"; 
		} 
	}
}
