using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public interface IRollReport
{
	IMove? Movement { get; set; }
	bool IsRaw { get; set; }
	bool IsNoRolMove { get; set; }
	List<Tuple<DiceTypes, int>> Dices { get; set; }
	string Roller { get; set; }
	RollTypes RollType { get; set; }
	int d1 { get; set; }
	int d2 { get; set; }
	int d3 { get; set; }
	int StatValue { get; set; }
	int bonus { get; set; }
	int Total { get; set; }
	string MoveTittle { get; }
	string StatString { get; set; }
	void SetID<T>(T id);
	T GetID<T>();
	void SetStat<T>(T id);
	T GetStat<T>();

}

public abstract class RollReport<T_ID, T_Stats> : IRollReport
{
	MovesServiceBase? Moves;

	public RollReport()
	{

	}
	public RollReport(MovesServiceBase moves)
	{
		Moves = moves;
	}
	public RollReport(MovesServiceBase moves, T_ID MoveID, T_Stats stat)
	{
		Moves = moves;
		MoveId = MoveID;
		Stat = stat;
	}
	public RollReport(T_ID MoveID, T_Stats stat, string MoveTittle, string _iDofTheRoller, RollTypes type = RollTypes.Roll_Simple)
	{
		MoveId = MoveID;
		Stat = stat;
		LocalTittle = MoveTittle;
		Roller = _iDofTheRoller;
		RollType = type;
	}


	public RollTypes RollType { get; set; } = RollTypes.Roll_Simple;
	public string Roller { get; set; } = string.Empty;
	public int d1 { get; set; } = 0;
	public int d2 { get; set; } = 0;
	public int d3 { get; set; } = 0;
	public int StatValue { get; set; } = 0;
	public int bonus { get; set; } = 0;
	public int Total { get; set; } = 0;
	public T_ID MoveId { get; set; }
	
	public T_Stats Stat { get; set; }
	public string LocalTittle { get; set; } = "";
	public string MoveTittle
	{
		get
		{
			if (!string.IsNullOrEmpty(LocalTittle)) return LocalTittle;
			return Moves?.GetMovement<T_ID>(MoveId).Tittle ?? $"Cannot find move's tittle {MoveId} @ RollReport::MoveTittle";
		}
	}
	public abstract string StatString { get; set; }
	public bool IsRaw { get; set; } = false;
	public IMove? Movement { get; set; } = null;
	public bool IsNoRolMove { get; set; } 
	public List<Tuple<DiceTypes, int>> Dices { get; set; } = new();

	public void SetID<T>(T id)
	{
		MoveId = (T_ID)(object)id;
	}

	public T GetID<T>()
	{
		return (T)(object)MoveId;
	}

	public void SetStat<T>(T stat)
	{
		Stat = (T_Stats)(object)stat; ;
	}

	public T GetStat<T>()
	{
		return (T)(object)Stat;
	}
}

