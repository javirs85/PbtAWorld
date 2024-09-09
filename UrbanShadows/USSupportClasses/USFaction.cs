using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using PbtALib;

namespace UrbanShadows;


public class USFaction : PbtAFaction
{
	


	public string Description { get; set; } = "descripción";
	public string Kind { get; set; } = "Tipo";
	
	public Circles Circle { get; set; } = Circles.NotSet;
	public string MasterSeeds { get; set; } = "notas secretas";
	
	
	
	public List<MasterMove> CustomMoves { get; set; } = new();

	
	

	public Guid ID { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = string.Empty;
	public List<PbtACharacter> Members { get; set; } = new();

	public void DeleteCharacter(ICharacter ch)
	{
		var c = Members.Find(x => x.Name == ch.Name);
		if (c is not null)
			Members.Remove(c);
	}

	public USFaction Duplicate()
	{
		string str = System.Text.Json.JsonSerializer.Serialize(this);
		return System.Text.Json.JsonSerializer.Deserialize<USFaction>(str);
	}
}