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
	Roll_Simple, Roll_Advantage, Roll_Disadvantage
}
public enum DiceTypes
{
	d4, d6, d8, d10, d12, d20
}

public static class UIExtensions
{
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
