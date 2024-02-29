using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class MasterMovePack
{
	public string Title { get; set; } = string.Empty;
	public List<MasterMove> Moves { get; set; } = new();
}

public class MasterMove
{
	public string Tittle { get; set; } = string.Empty;
	public string Detail { get; set; } = string.Empty;
	public HowOftenUsed HowOften = HowOftenUsed.NeverUsed;

	public MasterMove(string txt) => Tittle = txt;
	public MasterMove() { }

	public void Use()
	{
		if (HowOften == HowOftenUsed.NeverUsed) HowOften = HowOftenUsed.FewUses;
		else if (HowOften == HowOftenUsed.FewUses) HowOften = HowOftenUsed.LotsOfUses;
		else if (HowOften == HowOftenUsed.LotsOfUses) HowOften = HowOftenUsed.ToMuch;
		else if (HowOften == HowOftenUsed.ToMuch) HowOften = HowOftenUsed.NeverUsed;
	}

	public int Order
	{
		get
		{
			if (HowOften == HowOftenUsed.NeverUsed) return 0;
			else if (HowOften == HowOftenUsed.FewUses) return 1;
			else if (HowOften == HowOftenUsed.LotsOfUses) return 2;
			else return 3;
		}
	}
}
