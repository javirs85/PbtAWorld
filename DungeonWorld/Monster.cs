using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PbtALib.BaseTextBook;

namespace DungeonWorld;

public class Monster
{
    public string Name { get; set; } = "Name not set";
    public TagIDs Organization { get; set; } = TagIDs.Solitario;
    public TagIDs Size { get; set; }
    public List<AttackDef> Attacks { get; set; } = new();
    public AttackDef Attack=> Attacks?[0] ?? new AttackDef ();
    public int Armor { get;set; }
    public List<TagIDs> Tags { get; set; } = new();
    public List<MasterMove> Moves { get; set; } = new();
    public List<string> Special { get; set;} = new();
    public int MaxHP { get; set; }
    public int CurrentHP { get; set; }
	public string Definition { get; internal set; }
	public string Instinct { get; internal set; }
}

public class AttackDef
{
    public string AttackName { get; set; } = "Name not set";
    public DiceTypes Dice { get; set; }
    public int Bonus { get; set; }
    public int Piercing { get; set; }
    public bool IgnoresArmor { get; set; }
}

