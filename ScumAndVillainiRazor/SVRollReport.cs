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
	public int TotalDices
	{
		get
		{
			int d = 0;
			d += Player.GetBonus(Stat);
			if (HelperPlayer is not null) d++;
			if (UsedPYForDice) d++;
			if (UsedAGambit) d++;
			if (UsedDevilsBargain) d++;
			return d;
		}
	}
	public SVPositions Position { get; set; } = SVPositions.Risky;
	public SVEffect Effect { get; set; } = SVEffect.Standard;

	public SVCharacter Player { get; set; } = new SVCharacter();
	public SVCharacter? HelperPlayer { get; set; }
	public bool UsedAGambit { get; set; } = false;
	public bool UsedPYForLevel { get; set; } = false;
	public bool UsedPYForDice { get; set; } = false;
	public bool UsedPYIncapacitate { get; set; } = false;
	public bool UsedPushYourself
	{
		get
		{
			return UsedPYForDice || UsedPYForLevel || UsedPYIncapacitate;
		}
	}
	public bool UsedDevilsBargain { get; set; } = false;

	public int NumDices { get; set; } = 1;

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
