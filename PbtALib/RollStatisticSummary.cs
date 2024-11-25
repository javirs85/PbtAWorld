using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class RollStatisticSummary
{
	public DateTime Date { get; set; } = DateTime.Now;
	public string MoveTittle { get; set; } = string.Empty;
	public string PlayerName { get; set; } = string.Empty;
	public int d1 { get; set; } = 0;
	public int d2 { get; set; } = 0;
	public int d3 { get; set; } = 0;
	public int Stat { get; set; } = 0;	
	public int Bonus { get; set; } = 0;
	public int Extra { get; set; } = 0;
	public int Total { get; set; } = 0;

    public RollStatisticSummary()
    {
        
    }

    public RollStatisticSummary(IRollReport roll)
    {
        MoveTittle = roll.MoveIDString;
		PlayerName = roll.Roller;
		d1 = roll.d1;
		d2 = roll.d2;
		d3 = roll.d3;
		Bonus = roll.bonus;
		Date = roll.Date;
		Stat = roll.StatValue;

		Extra = 0;
		foreach (var e in roll.Extras)
			Extra += e;

		Total = roll.Total;
    }

}
