using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;


public interface IPeopleCast
{
	List<Circle> Circles { get; }

	public void StoreInJsonFile(Guid GameID);
	public void LoadFromJsonFile(Guid GameID);
	public void LoadFromJsonString(string json, Guid GameID	);

	PbtAFaction AddNewFactionToCircle(Circle c);

    void AddFactionToCircle(PbtAFaction f, Circle c);
	void AddCharacterToFaction(PbtACharacter ch, PbtAFaction f);
	PbtACharacter GetCharacterByID(Guid id);


	Task DeleteFaction(PbtAFaction f);
    Task DeleteCharacter(PbtACharacter ch);

	Task SaveChangesOnFaction(PbtAFaction f);
	Task SaveChangesOnCharacter(PbtACharacter ch);
	
}

public class People : IPeopleCast
{
	public List<Circle> _circles = new();
	public List<Circle> Circles => _circles;
	IDataBaseController DB;

	public void StoreInJsonFile(Guid GameID)
	{
		var Folder = $"wwwroot/GameImages/{GameID.ToString()}";
		var path = $"{Folder}/People.json";
		var json = System.Text.Json.JsonSerializer.Serialize(Circles);

		System.IO.File.WriteAllText(path, json);
	}

	public void LoadFromJsonFile(Guid GameID)
	{
		var Folder = $"wwwroot/GameImages/{GameID.ToString()}";
		var path = $"{Folder}/People.json";

		if(File.Exists(path))
		{
			var json = System.IO.File.ReadAllText(path);
			_circles = System.Text.Json.JsonSerializer.Deserialize<List<Circle>>(json);
		}
	}

	public void LoadFromJsonString(string json, Guid GameID	)
	{
		_circles = System.Text.Json.JsonSerializer.Deserialize<List<Circle>>(json);
		StoreInJsonFile (GameID);
	}


	public People(IDataBaseController _db)
    {
		DB= _db;

		Circles.Add(new Circle("Casting", new PbtAFaction { Name = "Personajes"}));
    }

	public PbtACharacter GetCharacterByID(Guid id)
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


	public void AddFactionToCircle(PbtAFaction f, Circle c)
    {
		Circles.Find(ci => ci.Name == c.Name)?.Factions.Add(f);
    }

	public void AddCharacterToFaction(PbtACharacter ch, PbtAFaction f)
	{
		var c = Circles.Find(x => x.Factions.Contains(f));
		if(c is not null)
		{
			var fac = c.Factions.Find(x => x.Name == f.Name);
			if (fac is not null)
				fac.Members.Add(ch);
		}
	}

	public async Task DeleteFaction(PbtAFaction f)
	{
        var c = Circles.Find(x => x.Factions.Contains(f));
        if (c is not null)
		{
			c.Factions.Remove(f);
		}
    }
    public async Task DeleteCharacter(PbtACharacter ch)
    {
		foreach (Circle c in Circles) c.DeleteCharacter(ch);
    }

    public async Task SaveChangesOnFaction(PbtAFaction f)
    {
		await Task.CompletedTask;
    }

    public async Task SaveChangesOnCharacter(PbtACharacter ch)
    {
        await Task.CompletedTask;
    }

    public virtual PbtAFaction AddNewFactionToCircle(Circle c)
    {
		PbtAFaction newF = new PbtAFaction
		{
			ID = Guid.NewGuid(),
			Name = "New Faction"
		};
		c.Factions.Add(newF);
		return newF;
    }
}

public class Circle
{
	public Circle() { }

    public Circle(string _name, PbtAFaction _defaultFaction)
    {
		Name = _name;
		Factions.Add(_defaultFaction);
		DefaultFaction = _defaultFaction;
    }

    public Guid ID { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = string.Empty;
	public List<PbtAFaction> Factions { get; set; } = new();
	public PbtAFaction DefaultFaction { get; set; }


	public void DeleteCharacter(PbtACharacter ch)
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
	public List<PbtACharacter> Members { get; set; }
	public void DeleteCharacter(PbtACharacter ch);
}

public class PbtAFaction : IPbtAFaction
{
	public Guid ID { get; set; }
	public string Name { get; set; }
	public List<PbtACharacter> Members { get; set; } = new();

	public void DeleteCharacter(PbtACharacter ch)
	{
		throw new NotImplementedException();
	}
}


