using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;


public interface IPeopleCast
{
	List<Circle> Circles { get; }

	IPbtAFaction AddNewFactionToCircle(Circle c);

    void AddFactionToCircle(IPbtAFaction f, Circle c);
	void AddCharacterToFaction(ICharacter ch, IPbtAFaction f);
	ICharacter GetCharacterByID(Guid id);


	Task DeleteFaction(IPbtAFaction f);
    Task DeleteCharacter(ICharacter ch);

	Task SaveChangesOnFaction(IPbtAFaction f);
	Task SaveChangesOnCharacter(ICharacter ch);
	
}

public class People : IPeopleCast
{
	public List<Circle> _circles = new();
	public List<Circle> Circles => _circles;
	IDataBaseController DB;


    public People(IDataBaseController _db)
    {
		DB= _db;

		Circles.Add(new Circle("Casting", new PbtAFaction { Name = "Personajes"}));
    }

	public ICharacter GetCharacterByID(Guid id)
	{
		foreach(var circle in Circles)
		{
			foreach(var fac in circle.Factions)
			{
				foreach(var ch in fac.Members)
					if(ch.ID == id) return ch;
			}
		}

		return new PbtACharacter { Name = "Character not found" };
	}


	public void AddFactionToCircle(IPbtAFaction f, Circle c)
    {
		Circles.Find(ci => ci.Name == c.Name)?.Factions.Add(f);
    }

	public void AddCharacterToFaction(ICharacter ch, IPbtAFaction f)
	{
		var c = Circles.Find(x => x.Factions.Contains(f));
		if(c is not null)
		{
			var fac = c.Factions.Find(x => x.Name == f.Name);
			if (fac is not null)
				fac.Members.Add(ch);
		}
	}

	public async Task DeleteFaction(IPbtAFaction f)
	{
        var c = Circles.Find(x => x.Factions.Contains(f));
        if (c is not null)
		{
			c.Factions.Remove(f);
		}
    }
    public async Task DeleteCharacter(ICharacter ch)
    {
		foreach (Circle c in Circles) c.DeleteCharacter(ch);
    }

    public async Task SaveChangesOnFaction(IPbtAFaction f)
    {
		await Task.CompletedTask;
    }

    public async Task SaveChangesOnCharacter(ICharacter ch)
    {
        await Task.CompletedTask;
    }

    public virtual IPbtAFaction AddNewFactionToCircle(Circle c)
    {
		PbtAFaction newF = new PbtAFaction();
		c.Factions.Add(newF);
		return newF;
    }
}

public class Circle
{
    public Circle(string _name, IPbtAFaction _defaultFaction)
    {
		Name = _name;
		Factions.Add(_defaultFaction);
		DefaultFaction = _defaultFaction;
    }

    public Guid ID { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = string.Empty;
	public List<IPbtAFaction> Factions { get; set; } = new();
	public IPbtAFaction DefaultFaction { get; set; }
	public void DeleteCharacter(ICharacter ch)
	{
		foreach (var f in Factions) f.DeleteCharacter(ch);
    }
	public void DeleteFaction(IPbtAFaction fac)
	{
		var f = Factions.Find(x => x.Name == fac.Name);
		if(f is not null)
			Factions.Remove(f);
	}
}

public interface IPbtAFaction
{
    public Guid ID { get; set; }
    public string Name { get; set; }
	public List<ICharacter> Members { get; set; }
	public void DeleteCharacter(ICharacter ch);
}

public class PbtAFaction : IPbtAFaction
{
	public Guid ID { get; set; }
	public string Name { get; set; }
	public List<ICharacter> Members { get; set; } = new();

	public void DeleteCharacter(ICharacter ch)
	{
		throw new NotImplementedException();
	}
}


