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
    /// <summary>
    /// Only one tag, can only be TagIDs.Solitario, TagIDs.Horda, TagIDs.Grupo
    /// </summary>
    public TagIDs Organization { get; set; } = TagIDs.Solitario;
    /// <summary>
    /// Only One Tag, Can only be TagIDs.Pequeño, TagIDs.Minusculo, TagIDs.Grande, TagIDs.Enorme
    /// </summary>
    public TagIDs Size { get; set; } = TagIDs.Pequeño;
    /// <summary>
    /// Attack must include its own tags, dices to roll, armor piercing capabilities and others
    /// </summary>
    public List<AttackDef> Attacks { get; set; } = new();
    public AttackDef Attack=> Attacks?[0] ?? new AttackDef ();
    public int Armor { get;set; }
    /// <summary>
    /// All other tags defining the monster that are not size or organization go here.
    /// </summary>
    public List<TagIDs> Tags { get; set; } = new();
    public List<MasterMove> Moves { get; set; } = new();
    public List<string> Special { get; set;} = new();
    private int _maxHp;

    public int MaxHP
    {
        get { return _maxHp; }
        set { _maxHp = value; 
            CurrentHP = value;
            }
    }

    public int CurrentHP { get; set; }
	public string Definition { get; internal set; }
	public string Instinct { get; internal set; }
}

public class AttackDef
{
    public string AttackName { get; set; } = "Name not set";
    public List<DiceTypes> Dices { get; set; } = new List<DiceTypes>();
    public int Bonus { get; set; }
    public int Piercing { get; set; }
    public bool IgnoresArmor { get; set; }
    public List<TagIDs> Tags { get;set; } = new();
    public RollTypes RollType { get; set; } = RollTypes.Roll_Simple;
}

