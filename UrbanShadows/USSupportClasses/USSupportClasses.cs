using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanShadows;

public class Rumor
{
	public int ID { get; set; }
	public string Content { get; set; } = "";
	public bool IsSeparator { get; set; } = false;
}

public class QandA
{
	public string Question { get; set; } = "";
	public string Answer { get; set; } = "";
}
public class Debt
{
	public Debt() { ID = Guid.NewGuid(); }
	public int Amount { get; set; } = 1;
	public string Reason { get; set; } = "";
	public Guid ID { get; set; }
	public Guid PayingID { get; set; }
	public Guid ReceivingID { get; set; }
}
