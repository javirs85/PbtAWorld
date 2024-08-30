using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace PbtALib;

public enum AvailableGames { DW, US, DI, SV, NotSet}

public enum HowOftenUsed { NeverUsed, FewUses, LotsOfUses, ToMuch };

public static class Extensions
{
	private static readonly Random random = new Random();
	public static T GetOneRandom<T>(this List<T> list)
	{
		return list[random.Next(0, list.Count)];
	}
}

public enum RollTypes
{
	Roll_Simple, Roll_Advantage, Roll_Disadvantage, Roll_SimplePlus1d6, Roll_AdvantagePlus1d6, Roll_DisadvantagePlus1d6, JustShowMoveWithNoRoll,
	FitD_Action, FitD_Resistance
}



public enum DiceTypes
{
	d4, d6, d8, d10, d12, d20
}

public enum VTTTokens
{
	WhiteLady1,WhiteLady2, WhiteLady3,
	WhiteMale1, WhiteMale2, WhiteMale3,
	BoxGray, BoxRed,BoxBlue,
	Black1, Black2,Black3, Black4,Black5, Black6, Black7, Black8, BlackBoss,
	Red1, Red2, Red3, Red4, Red5, Red6,Red7,Red8,RedBoss,
	Blue1, Blue2, Blue3, Blue4, Blue5, Blue6, Blue7, Blue8, BlueBoss,
	Green1, Green2, Green3, Green4, Green5, Green6,Green7, SpikeTrap,GreenBoss,
	Barbarian, Bard, Cleric, Druid, Ranger, Fighter, Thief, Mage, Paladin, Wielder,
	Gold, RedPotion,GreenPotion, FogOfWar, Bultos, Bush1, Bush2, Bush3, Bush4, BushMini1, BushMini2, BushMini3, Firepit,
	FirepitOff, Outcrop, Rock1, Rock2, Rock3, Rock4, Stomp1, Stomp2, Tent, Tent2, Tent3,
	Tree1, Tree2, Corner, Door_Round, Door_Square, DoorSmall, PilarRound, PilarSquare, Door_Big,
	Chest, Throne, Crate_Small, Barrel, Storage, Statue_Hands, Statue_Shield, Stairs
}

public enum DWClasses
{
	DW_Barbarian, DW_Bard, DW_Cleric, DW_Druid, DW_Explorer, DW_Fighter, DW_Thief, DW_Mage, DW_Paladin, DW_Wielder,
	DW_NotSet, DW_Master
}

public enum US_Classes { NotSet, Hunter, Awaken, Veteran, Vampire, Wolf, Spectre, Sworn, Mage, Oracle, Fair, Corrupted, Imp, All, Master }


public static class ExtensionsEnum
{
	public static bool IsProp(this VTTTokens t)
	{
		List<VTTTokens> props = new List<VTTTokens> {
			VTTTokens.Bultos,VTTTokens.Bush1,VTTTokens.Bush2, VTTTokens.Bush3, VTTTokens.Bush4,VTTTokens.BushMini1, VTTTokens.BushMini2,VTTTokens.BushMini3,VTTTokens.Firepit,
			VTTTokens.FirepitOff,VTTTokens.Outcrop,VTTTokens.Rock1, VTTTokens.Rock2,VTTTokens.Rock3,VTTTokens.Rock4,VTTTokens.Stomp1,VTTTokens.Stomp2,VTTTokens.Tent,VTTTokens.Tent2,VTTTokens.Tent3,
			VTTTokens.Tree1,VTTTokens.Tree2, VTTTokens.Door_Big
		};
		return props.Contains(t);
	}

	public static bool IsForest(this VTTTokens t)
	{
		List<VTTTokens> props = new List<VTTTokens> {
			VTTTokens.Bultos,VTTTokens.Bush1,VTTTokens.Bush2, VTTTokens.Bush3, VTTTokens.Bush4,VTTTokens.BushMini1, VTTTokens.BushMini2,VTTTokens.BushMini3,VTTTokens.Firepit,
			VTTTokens.FirepitOff,VTTTokens.Outcrop,VTTTokens.Rock1, VTTTokens.Rock2,VTTTokens.Rock3,VTTTokens.Rock4,VTTTokens.Stomp1,VTTTokens.Stomp2,VTTTokens.Tent,VTTTokens.Tent2,VTTTokens.Tent3,
			VTTTokens.Tree1,VTTTokens.Tree2
		};
		return props.Contains(t);
	}
	public static bool IsDungeonProp(this VTTTokens t)
	{
		List<VTTTokens> props = new List<VTTTokens> {
			VTTTokens.Barrel, VTTTokens.Chest, VTTTokens.Corner, VTTTokens.Crate_Small, VTTTokens.DoorSmall, VTTTokens.Door_Big,
			VTTTokens.Door_Round, VTTTokens.Door_Square, VTTTokens.PilarRound, VTTTokens.PilarSquare, VTTTokens.Stairs,
			VTTTokens.Statue_Hands, VTTTokens.Statue_Shield, VTTTokens.Storage, VTTTokens.Throne
		};
		return props.Contains(t);
	}

}

public enum TokenStatus
{
	Normal, Dead, Hidden, Poisoned, InFlame
}

public static class UIExtensions
{

	public static string ToImagePath(this DiceTypes dice)
	{
		return dice switch
		{
			DiceTypes.d4 => "d4.svg",
			DiceTypes.d6 => "d6.svg",
			DiceTypes.d8 => "d8.svg",
			DiceTypes.d10 => "d10.svg",
			DiceTypes.d12 => "d12.svg",
			DiceTypes.d20 => "d20.svg",
			_ => "error"
		};
	}

	public static int MaxValue(this DiceTypes dice)
	{
		return dice switch
		{
			DiceTypes.d4 => 4,
			DiceTypes.d6 => 6,
			DiceTypes.d8 => 8,
			DiceTypes.d10 => 10,
			DiceTypes.d12 => 12,
			DiceTypes.d20 => 20,
			_ => 0
		};
	}

	public static string ToUI(this AvailableGames game)
	{
		return game switch
		{
			AvailableGames.DI => "Escape from dino island",
			AvailableGames.DW => "Dungeon World",
			AvailableGames.US => "Urban shadows",
			AvailableGames.SV => "Scum and Villainy",
			_ => "Game not selected"
		};
	}

	public static string ToUI(this AvailableGames? game)
	{
		if (game is not null) return ((AvailableGames)game).ToUI();
		else return "null";
	}

	public static string ToNiceUIStat(this int val)
	{
		if (val < 0)
			return val.ToString();
		else
			return "+" + val.ToString();
	}
}
