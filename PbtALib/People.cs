using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;


public interface IPeopleCast
{
	List<Circle> Circles { get; }
}

public class People : IPeopleCast
{
	public List<Circle> _circles = new();
	public List<Circle> Circles => _circles;

    public People()
    {
        Circles.Add(new Circle
		{
			Name = "Casting",
			Factions = new List<Faction>
			{
				new Faction
				{
					Name = "Jugadores"
				}
			}
		});
    }

}

public class Circle
{
	public string Name { get; set; } = string.Empty;
	public List<Faction> Factions { get; set; } = new();
}

public class Faction
{
	public string Name { get; set; } = string.Empty;
	public List<ICharacter> Members { get; set; } = new();
}


