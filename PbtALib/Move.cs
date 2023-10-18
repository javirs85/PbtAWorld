using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public interface IMove
{
	bool IsSelected { get; set; }
	bool HasRoll();
	string ToUI();
	string Tittle { get; set; }
	Consequences PreCondition { get; set; }
	Consequences ConsequencesOn79 { get; set; }
	Consequences ConsequencesOn10 { get; set; }
	Consequences ConsequencesOn6 { get; set; }
	Consequences AdvancedConsequences { get; set; }
	public bool IsInList<T>(IEnumerable<T> list);
	public void AddIDToList<T>(List<T> list);
	public void RemoveIDFromList<T>(List<T> list);

	public string IDText { get; }

	public string ClosingText { get; set; }


	public int NumUsedTimes { get; set; }
	public HowOftenUsed HowOften { get; }
	bool IsImproved { get; set; }

}

public abstract class BaseMove<TIDPack, TStatsPack> : IMove
{
	protected TStatsPack _roll;
	protected TIDPack _me;
	protected BaseMove(TIDPack IDpack, TStatsPack roll)
	{
		_me = IDpack;
		_roll = roll;
	}

	public string IDText => ID.ToString() ?? "ID not set";

	public string ClosingText { get; set; }
	public TIDPack ID => _me;
	public TStatsPack Roll => _roll;
	public bool IsSelected { get; set; }
	public string Tittle { get; set; } = "";
	public Consequences PreCondition { get; set; } = new();
	public Consequences ConsequencesOn79 { get; set; } = new();
	public Consequences ConsequencesOn10 { get; set; } = new();
	public Consequences ConsequencesOn6 { get; set; } = new();
	public Consequences AdvancedConsequences { get; set; } = new();

	public bool IsImproved { get; set; } = false;

	public abstract bool HasRoll();
	public abstract string ToUI();
	public bool IsInList<T>(IEnumerable<T> list)
	{
		if (typeof(T) != typeof(TIDPack)) return false;
		if (list is not null && list.Any())
			return list.Cast<TIDPack>().Contains(_me);
		return false;
	}

	public void AddIDToList<T>(List<T> list)
	{
		var casted = (T)(object)ID;
		list.Add(casted);
	}

	public void RemoveIDFromList<T>(List<T> list)
	{
		var casted = (T)(object)ID;
		list.Remove(casted);
	}

	public int NumUsedTimes { get; set; } = 0;

	HowOftenUsed IMove.HowOften
	{
		get
		{
			if (NumUsedTimes == 0) return HowOftenUsed.NeverUsed;
			else if (NumUsedTimes < 2) return HowOftenUsed.FewUses;
			else if (NumUsedTimes < 5) return HowOftenUsed.LotsOfUses;
			else return HowOftenUsed.ToMuch;
		}
	}
}

public class Consequences
{
    public string MainText { get; set; } = string.Empty;
    public List<string>? Options { get; set; } = null;
}
