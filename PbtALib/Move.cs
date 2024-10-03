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
	string Title { get; set; }
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
	protected TStatsPack _roll
	{
		get
		{
			if (_rolls.Count > 0)
				return _rolls[0];
			else
				return DefaultStat;
		}
	}
	protected TStatsPack DefaultStat { get; set; }
	protected List<TStatsPack> _rolls { get; set; } = new();
	protected TIDPack _me;
	protected BaseMove(TIDPack IDpack, TStatsPack roll)
	{
		_me = IDpack;
		_rolls.Add(roll);
	}

	public List<RollExtras> AvailableExtras = new();
	public string IDText => ID.ToString() ?? "ID not set";

	public string ClosingText { get; set; }
	public TIDPack ID => _me;
	public TStatsPack Roll
	{
		get { return _roll; }
	}
	public List<TStatsPack> Rolls => _rolls;
	public void FixRolls()
	{
		_rolls = Rolls.Distinct().ToList().OrderBy(x=> Enum.GetName(typeof(TStatsPack), x)).ToList();
		AvailableExtras = AvailableExtras.Distinct().ToList();
	}
	public bool IsSelected { get; set; }
	public string Title { get; set; } = "";
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

	public void CopyContentFrom(BaseMove<TIDPack, TStatsPack> move)
	{
		this.Title = move.Title;
		this.PreCondition = CloneConsequence(move.PreCondition);
		this.ConsequencesOn10 = CloneConsequence(move.ConsequencesOn10);
		this.ConsequencesOn6 = CloneConsequence(move.ConsequencesOn6);
		this.ConsequencesOn79 = CloneConsequence(move.ConsequencesOn79);
		this.AdvancedConsequences = CloneConsequence(move.AdvancedConsequences);
		this.ClosingText = move.ClosingText;
		this.NumUsedTimes = move.NumUsedTimes;
		CopyContentFromInternal(move);
	}

	private Consequences CloneConsequence(Consequences con)
	{
		Consequences consequences = new Consequences();

		consequences.MainText = con.MainText;
		if(con.Options is not null)
		{
			consequences.Options = new List<string>();
			foreach (var c in con.Options!)
				consequences.Options.Add(c.ToString());
		}
		else
			consequences.Options = new List<string>();

		return consequences;
	}

	protected virtual void CopyContentFromInternal<M>(M move)
	{

	}
}

public class Consequences
{
    public string MainText { get; set; } = string.Empty;
    public List<string>? Options { get; set; } = null;
}
