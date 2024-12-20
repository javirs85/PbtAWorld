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
			d += ExtraDices;
			if (UsedAGambit) d++;
			if (UsedDevilsBargain) d++;
			return d;
		}
	}

	public bool HasBeenNegotiated { get; set; } = false;

	public SVPositions Position { get; set; } = SVPositions.Risky;
	public SVRollResult Result { get; set; } = SVRollResult.NotSet;
	public bool EffectSet { get; set; } = false;
	public SVEffect BaseEffect = SVEffect.Standard;

	public SVEffect Effect
	{
		get {
			if (BaseEffect == SVEffect.NotSet) return BaseEffect;
			else
			{
				var toReturn = BaseEffect;
				if (AffectedPerHealth1A) toReturn = toReturn.MinusOne();
				if (AffectedPerHealth1B) toReturn = toReturn.MinusOne();
				
				return toReturn;
			}
		}
		set { BaseEffect = value; }
	}

	public SVCharacter Player { get; set; } = new SVCharacter();
	public SVCharacter? HelperPlayer { get; set; }
	public bool UsedAGambit { get; set; } = false;
	public int ExtraDices { get; set; } = 0;
	public bool UsedPYForLevel { get; set; } = false;
	public bool UsedPYForDice { get; set; } = false;
	public bool UsedPYIncapacitate { get; set; } = false;
	public bool AffectedPerHealth1A { get; set; } = false;
	public bool AffectedPerHealth1B { get; set; } = false;
	public bool UsedPushYourself
	{
		get
		{
			return UsedPYForDice || UsedPYForLevel || UsedPYIncapacitate;
		}
	}
	public bool UsedDevilsBargain { get; set; } = false;

	public bool IsResisting { get; set; } = false;
	public List<int> ResistanceDices { get; set; } = new();
	public SVStats ResistanceStat { get; set; } = SVStats.NotSet;
	public bool HasResisted { get; set; } = false;
	public bool WasTooMuchStress { get; set; } = false;

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
