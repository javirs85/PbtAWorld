using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanShadows;

public class USPeople : People
{
    public USPeople(IDataBaseController _db) : base(_db)
    {
        Circles.Clear();
        Circles.Add(new Circle(UrbanShadows.Circles.Mortalis.ToString(), new USFaction { Name = "Autónomos en Mortales" }));
        Circles.Add(new Circle(UrbanShadows.Circles.Noche.ToString(), new USFaction { Name = "Autónomos en Noche" }));
        Circles.Add(new Circle(UrbanShadows.Circles.Poder.ToString(), new USFaction { Name = "Autónomos en Poder" }));
        Circles.Add(new Circle(UrbanShadows.Circles.Velo.ToString(), new USFaction { Name = "Autónomos en Velo" }));
    }
    public override PbtAFaction AddNewFactionToCircle(Circle c)
    {
        USFaction faction = new USFaction();
		c.Factions.Add(faction);
		return faction;
    }
}
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
