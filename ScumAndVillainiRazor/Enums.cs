using System.Data;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Runtime.ConstrainedExecution;

namespace ScumAndVillainy;

public enum SVMoves { }
public enum SVClasses { Mechanic, muscle, mystic, pilot, scoundrel, speaker, stitch, NotSet, All }
public enum SVStats { Attune, Command, Consort, Doctor, Hack, Helm, Rig, Scramble, Scrap, Skulk, Study, Sway, Insight, Prowess, Resolve, NotSet }
public enum SVItemIDs
{
	Armor, Blaster, Comm, Detonator, Hacking, HeavyBlaster, IllicitDrugs, Medkit, MeleeWeapon, RepairTools, Spacesuit, SpyGear,
	FineHackingRig, FineShipRepairTools, GeniusPet, SpareParts, VisionEnhancingGoggles, SmallDrone,
	Krieger, Vera, Zmei, Sunder, Zarathustra, FineMartialArtsStyle, MysticAmmunition, 
	FineMeleeWeapon, Offerings, TrappingsOfReligion, OutdatedReligiousOutfit, MementoOfYourTravels, PrecursorArtifact,
	FineCustomizedSpacesuit,FineSmallUrbot,FineMechanicsKit,GrapplingHook,	GuildLicense,	VictoryCigars,
	FineBlasterPistol, 	FineCoat,	LoadedDice,	ForgedDocuments,	PersonalMemento,
	FineClothes,	LegitimateID,	LuxuryItemSmall, LuxuryItemMedium, LuxuryItemLarge,	MementoOfPastEncounter,
	FineBlasterPistolPair,	FineMedkit,	FineBedsideManner,	FineClothing,	RecognizableMedicGarb,	CandiesAndTreats,	SyringesAndApplicators,
};

public enum SVPositions { Controlled, Risky, Desperate};
public enum SVEffect { Limited, Standard, Great, Extreme, Zero};

public enum SVMoveIDs {
	NotSet, 
	Tinker, BailandoWireAndMechTape, ConstructWhisperer, JunkyardHunter, Hacker, Fixed, MechanicsHeart, Overclock, Analyst,
	Unstoppable, WreckingCrew, Backup, Battleborn, Bodyguard, FleshWound, Predator, ReadyForAnything, Scary,
	TheWay, Kinetics, PsyBlade, Center, WayShield, Warded, PsyDancing, Visions, Sundering,
	AcePilot, KeenEye, SideJob, ExceedSpecs, LeafOnTheWind, Hedonist, Commander, Traveler, PunchIt,
	ImADoctorNotA, Physicker, Patch, WelcomeAnywhere, UnderPressure, CombatMedic, MoralCompass, DrStrange, BookLearning,
	AirOfRespectability,FavorsOwed,Player, Infiltrator, Subterfuge, HeartToHeart, OldFriends, Disarming, Purpose,
	Serendipitous, NeverTellMeTheOdds, IKnowAGuy, Tenacious, WhenTheChipsAreDown, DevilsOwnLuck, Daredevil, ShootFirst, AskQuestionsLater,


	//stardancer
	TheGetaway,	CargoEye,	FieldRepairs,	Leverage,	JustPassingThrough,	HomeCooking,	ProblemSolvers,
	//cerberus
	Licensed,	OnTheTrail,	LightTouch,	SnatchNGrab,	LoadedForBear,	PlayBothSides,	Deadly,
	//firedrake
	OldHands,	ForgedInFire,	Sympathizers,	NaturalEnemies,	SparkOfRebellion,	JustCause,	HeartsMinds,
	Skulk,
	Scramble,
	Scrap,
	Helm,
	Doctor,
	Hack,
	Rig,
	Study,
	Attune,
	Command,
	Consort,
	Sway
}

public enum Heritages { Imperial, Spacer, Colonist, Manufactured, Wanderer, Xeno, NotSet}
public enum Backgrounds { Academic, Labor, Cult, Guilder, Military, Noble, Syndicate, NotSet}
public enum Vices { Faith, Gambling, Luxury, Obligation, Pleasure, Stupor, Weird, NotSet}
public enum MaxLoads { Light, Normal, Heavy, NotSet}
public enum Traumas { NoTrauma, Cold, haunted, Obsessed, Paranoid, Reckless, Soft, Unstable, Vicious}

public enum ShipSystems { Comms, Weapons, Engines, Hull, NotSet}



public enum ActionRollPositions { Controlled, Risky, Desperate};
public enum ActionRollEffects { Limited, Standard, Great};

public static class Ex
{
	public static string ToUI(this ShipSystems system) => system switch
	{
		ShipSystems.Hull => "Casco",
		ShipSystems.Comms => "Comms",
		ShipSystems.Weapons => "Armas",
		ShipSystems.Engines => "Motor",
		ShipSystems.NotSet => "NotSet",
		_ => ""
	};

	public static string ToUI(this SVEffect system) => system switch
	{
		SVEffect.Great => "Enorme",
		SVEffect.Limited => "Limitada",
		SVEffect.Standard => "Estandard",
		_ => ""
	};
	public static string ToUI(this SVPositions system) => system switch
	{
		SVPositions.Controlled => "Bajo control",
		SVPositions.Desperate => "Desesperada",
		SVPositions.Risky => "Arriesgada",
		_ => ""
	};
	public static string GetDescription(this SVPositions system) => system switch
	{
		SVPositions.Controlled => "Todo está listo para tu éxito, estás explotando una posición ventajosa",
		SVPositions.Desperate => "Te estás pasando. Estas en problemas, una maniobra muy arriesgada",
		SVPositions.Risky => "Estás ahí-ahí, estás bajo presión y te estás arriesgando",
		_ => ""
	};
}

