using PbtALib;

namespace UrbanShadows;

public class USRollReport : RollReport<USMoveIDs, USAttributes>
{
	public USRollReport(USMovesService _moves) : base(_moves)
	{

	}
	private string _statstring =string.Empty;

	public override string StatString
	{
		get { 
			if(_statstring == string.Empty)	
				return Stat.ToUI();
			else
				return _statstring;		
		}
		set { _statstring = value; }
	}

}
