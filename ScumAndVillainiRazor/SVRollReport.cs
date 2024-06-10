using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public class SVRollReport : RollReport<SVMoves, SVStats>
{
	public SVRollReport(SVMovesService _moves) : base(_moves)
	{

	}

	private string _statstring = string.Empty;
	public override string StatString
	{
		get
		{
			if (_statstring == string.Empty)
				return Stat.ToUI();
			return _statstring;
		}
		set { _statstring = value; }
	}
}
