using System.Runtime.CompilerServices;

namespace PbtALib;

public enum DinoClasses { Hunter, Doctor, Engineer, Kid, Paleontologist,Soldier, Survivor,NotSet }
public enum DinoStats { Fit, Mind, Cold, NotSet }
public enum DinoDangerMoves { Run, Hide, DoIt, HoldOnToYourButt, LookThere, TakeMyHand, Fight, NotSet }
public enum DinoSafetyMoves { LayOfTheLand, Instruct, Scavenge, TheBestLaidPlan, Casualty, NotSet }
public enum DinoMapTokens { Airstrip, Building, Docks, Hatchery, Lake, NativeSettlement, Road, TemporalAnomaly, Aviary, Clifs, Fence, Helipad, Mountain, RadioTower, LAboratory, Tunnel, Beach, Nest, Forest, Grass, Ruins, River, Swamp, Volcano, NotSet }

public enum HowOftenUsed { NeverUsed, FewUses, LotsOfUses, ToMuch };

public static class Extensions
{

	public static DinoClasses ToDinoClass(this string str)
	{
		foreach(DinoClasses op in Enum.GetValues(typeof(DinoClasses)))
		{
			if (op.ToUIString() == str)
				return op;
		}
		return DinoClasses.NotSet;
	}
	public static string ToUIString(this DinoClasses c)
	{
		return c switch
		{
			DinoClasses.Engineer => "Ingeniero",
			DinoClasses.Survivor => "Superviviente",
			DinoClasses.Soldier => "Soldado",
			DinoClasses.Paleontologist => "Paleontólogo",
			DinoClasses.Hunter => "Cazador",
			DinoClasses.Kid => "Niño",
			DinoClasses.Doctor => "Doctor",
			_ => "Desconocida"
		};
	}
	public static string ToPNGPath(this DinoClasses c)
	{
		return c switch
		{
			DinoClasses.Engineer => "imgs/Icons/Engineer.png",
			DinoClasses.Survivor => "imgs/Icons/survivor.png",
			DinoClasses.Soldier => "imgs/Icons/Soldier.png",
			DinoClasses.Paleontologist => "imgs/Icons/Paleontologist.png",
			DinoClasses.Hunter => "imgs/Icons/Hunter.png",
			DinoClasses.Kid => "imgs/Icons/Kid.png",
			DinoClasses.Doctor => "imgs/Icons/Doctor.png",
			_ => "Desconocida"
		};
	}

	public static string ToUIString(this DinoStats c)
	{
		return c switch
		{
			DinoStats.Fit => "Forma física",
			DinoStats.Mind => "Inteligencia",
			DinoStats.Cold => "Calma",
			_ => "Desconocida"
		};
	}
}