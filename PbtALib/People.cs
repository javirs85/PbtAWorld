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
	public Task StoreMasterHints(Guid GameID);
	public void LoadFromJsonFile(Guid GameID);
	public Task LoadMasterHints(Guid GameID);
	public void LoadFromJsonString(string json, Guid GameID	);


	public List<MasterHint> MasterHints { get; set; }

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
	public List<MasterHint> MasterHints { get; set; } = new List<MasterHint>();

	public List<Circle> _circles = new();
	public List<Circle> Circles => _circles;
	public event EventHandler<string> SendToastToClients;
	IDataBaseController DB;

	public void StoreInJsonFile(Guid GameID)
	{
		var Folder = $"wwwroot/GameImages/{GameID.ToString()}";
		var path = $"{Folder}/People.json";
		var json = System.Text.Json.JsonSerializer.Serialize(Circles);

		System.IO.File.WriteAllText(path, json);
		SendToastToClients?.Invoke(this, "People's data stored");

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

	public async Task StoreMasterHints(Guid GameID)
	{
		var Folder = $"wwwroot/GameImages/{GameID.ToString()}";
		var path = $"{Folder}/MasterHints.json";
		var json = System.Text.Json.JsonSerializer.Serialize(MasterHints);

		await System.IO.File.WriteAllTextAsync(path, json);
		SendToastToClients?.Invoke(this, "MasterHints stored");

	}

	public async Task LoadMasterHints(Guid GameID)
	{
		var Folder = $"wwwroot/GameImages/{GameID.ToString()}";
		var path = $"{Folder}/MasterHints.json";

		if (File.Exists(path))
		{
			var json = await File.ReadAllTextAsync(path);
			MasterHints = System.Text.Json.JsonSerializer.Deserialize<List<MasterHint>>(json);
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
	public string Assets { get; set; } = "Assets";
	public string CurrentlyWorkingOn { get; set; } = "en que están ahora mismo";
	public string MasterSecrets { get; set; } = "";
	public int Size { get; set; }
	public int SizeTemp { get; set; }
	public int Strength { get; set; }
	public int StrengthTemp { get; set; }
	public bool IsDebilitated { get; set; } = false;
	public string SizeExplanation { get; set; } = "por que";
	public string StrengthExplanation { get; set; } = "por que";
	public FactionStatuses Status { get; set; } = FactionStatuses.NotSet;

	public void DeleteCharacter(PbtACharacter ch)
	{
		throw new NotImplementedException();
	}


}

public class MasterHint
{
	public Guid Id { get; set; } = Guid.NewGuid();
	public string Text { get; set; } = string.Empty;
	public bool IsTicked { get; set; } = false;

	private int _order;

	public int Order
	{
		get { 
			if (IsTicked) return _order;
			else return _order + 100;
		}
		set 
		{
			if (IsTicked) _order = value;
			else _order = value -100;
		}
	}

	public void MoveUp() => Order -= 1;
	public void MoveDown() => Order += 1;


	public void Toggle() => IsTicked = !IsTicked;
}


