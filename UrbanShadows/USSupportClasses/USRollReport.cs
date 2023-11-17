using PbtALib;

namespace UrbanShadows;

public class USRollReport : RollReport<USMoveIDs, USAttributes>
{
	public USRollReport(USMovesService _moves) : base(_moves)
	{

	}
	public override string StatString => Stat.ToUI();
}
