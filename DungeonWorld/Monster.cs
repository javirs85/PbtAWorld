using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class Monster
{
    public string Name { get; set; } = "Name not set";
    public OrganizationMonsterTags Organization { get; set; } = OrganizationMonsterTags.Solitario;
    public SizeMonsterTags Size { get; set; }
    public List<AttackDef> Attacks { get; set; } = new();
    public AttackDef Attack=> Attacks?[0] ?? new AttackDef ();
    public int Armor { get;set; }
    public List<BasicMonsterTags> Tags { get; set; } = new();
}

public class AttackDef
{
    public string AttackName { get; set; } = "Name not set";
    public DiceTypes Dice { get; set; }
    public int Bonus { get; set; }
}

