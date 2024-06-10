namespace ScumAndVillainy;

public enum SVClasses { Mechanic, muscle, mystic, pilot, scoundrel, speaker, stitch, NotSet, All }

public static class Extensions
{
	public static string ToUI(this SVClasses c) => c switch
	{
		SVClasses.Mechanic => "Mecánico",
		SVClasses.muscle => "Músculo",
		SVClasses.mystic => "Místico",
		SVClasses.pilot => "Piloto",
		SVClasses.scoundrel => "Granuja",
		SVClasses.speaker => "Mediador",
		SVClasses.stitch => "Paramédico",
		_ => "Not Set"
	};
}
