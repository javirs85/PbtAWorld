using System.Runtime.CompilerServices;

namespace PbtALib;

public enum AvailableGames { DW, US, DI, NotSet}

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
	Roll_Simple, Roll_Advantage, Roll_Disadvantage, Roll_SimplePlus1d6, Roll_AdvantagePlus1d6, Roll_DisadvantagePlus1d6
}
public enum DiceTypes
{
	d4, d6, d8, d10, d12, d20
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
