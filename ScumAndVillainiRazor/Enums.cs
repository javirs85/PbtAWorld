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
public enum SVConsequences { ReducedEffect, Comlpication, LostOportunity, WorsePosition, Harm};

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

    public static string ToUI(this SVConsequences consequence) => consequence switch
    {
        SVConsequences.ReducedEffect => "Efecto reducido",
        SVConsequences.Comlpication => "Complicación",
        SVConsequences.LostOportunity => "Oportunidad perdida",
        SVConsequences.WorsePosition => "Peor posición",
        SVConsequences.Harm => "Daño",
        _ => ""
    };
    public static string GetDescription(this SVConsequences consequence) => consequence switch {
        SVConsequences.ReducedEffect => @"Esta consecuencia representa un rendimiento limitado. |\nLa acción del PJ no es tan efectiva como se esperaba. \n\nLo golpeas, pero solo logras una herida superficial. \nElla acepta la invitación falsificada, pero mantendrá un ojo en ti durante toda la noche. \nLogras escalar el muro, pero el avance es lento: apenas llegas a la mitad.|| \n\nEsta consecuencia reduce el nivel de efecto de la acción del PJ en un grado, después de haber considerado todos los demás factores.",
        SVConsequences.Comlpication => @"Esta consecuencia representa problemas, un peligro creciente o una nueva amenaza. 
El GM puede introducir un problema inmediato como resultado de la acción: la habitación se incendia, te desarman, el equipo acumula +1 de atención por testigos, pierdes estatus con una facción, el objetivo se escapa y ahora es una persecución, llegan refuerzos, etc.

Alternativamente, el GM podría avanzar un reloj relacionado con la complicación. Por ejemplo, puede haber un reloj que mide el nivel de alerta de los guardias en el puerto espacial.
O el GM podría crear un nuevo reloj para la sospecha de la Legión en el punto de control y avanzarlo una casilla.
Marca una casilla en un reloj para una complicación menor o dos casillas para una complicación estándar.

Una *complicación grave** es más severa: la habitación se incendia y vigas caídas bloquean la salida, tu arma se rompe, el equipo acumula *+2 de atención**, tu objetivo desaparece de la vista, los refuerzos te rodean y te atrapan, etc. Marca *tres** casillas en un reloj para una complicación grave.

*No impongas una complicación que invalide una tirada exitosa.**
Si un PJ intenta acorralar a un enemigo y obtiene un 4/5, no digas que el enemigo escapa. La tirada del jugador tuvo éxito, así que el enemigo está acorralado, pero tal vez el PJ deba forcejear con él para mantenerlo en posición, y durante la lucha el enemigo podría arrebatarle su arma.",
        SVConsequences.LostOportunity => @"Esta consecuencia representa un cambio en las circunstancias. Tenías una oportunidad de lograr tu objetivo con esta acción, pero se te escapó. Para intentarlo de nuevo, necesitas un enfoque diferente, generalmente un nuevo tipo de acción o un cambio en la situación.\n\n Tal vez intentaste enfrentarte a tu objetivo en una pelea para atraparla en el balcón, pero ella evade tu maniobra y salta fuera de tu alcance hacia otro balcón. Si ahora quieres alcanzarla, tendrás que intentarlo de otra manera, quizá trepando tú mismo para cruzar el hueco.",
        SVConsequences.WorsePosition => @"Esta consecuencia representa perder el control de la situación: la acción te lleva a una posición más peligrosa. Tal vez logres saltar al siguiente balcón, pero terminas colgando solo con las yemas de los dedos. No has fallado, pero tampoco has tenido éxito todavía. Puedes intentarlo de nuevo, lanzando de nuevo los dados en esta nueva posición más desfavorable.

Es una buena consecuencia para mostrar cómo la tensión va en aumento. Una situación podría pasar de estar controlada, a ser arriesgada, y finalmente desesperada, mientras la acción se desarrolla y el PJ se mete cada vez más en problemas.",
        SVConsequences.Harm => @"Esta consecuencia representa una debilidad prolongada (o la muerte).
Cuando sufres daño, anota la lesión específica en tu hoja de personaje según el nivel de daño recibido:

Daño menor: Regístralo en la fila inferior.
Daño moderado: Escríbelo en la fila del medio.
Daño grave: Regístralo en la fila superior.

Consulta los ejemplos de daño y el rastreador de daño en la siguiente página.
Tu personaje sufrirá la penalización indicada al final de la fila si el daño registrado en esa fila aplica a la situación actual. Por ejemplo, si tienes 'Cansado' en la fila inferior, sufrirás un efecto reducido al intentar huir de los guardias de la Legión. Si estás afectado por daño grave en la fila superior (nivel 3), tu personaje estará incapacitado y no podrá hacer nada a menos que alguien te ayude o te esfuerces para realizar la acción.

Si necesitas registrar un nivel de daño pero la fila correspondiente ya está llena, el daño se desplaza a la siguiente fila disponible. Por ejemplo, si sufres daño moderado (nivel 2) pero no tienes espacios libres en la segunda fila, deberás anotarlo como daño grave (nivel 3). Si la fila superior está llena y necesitas registrar daño allí, tu personaje sufrirá una consecuencia catastrófica y permanente (como la pérdida de un miembro o la muerte repentina, dependiendo de las circunstancias).

*DAÑO NO FÍSICO**
El daño no siempre tiene que ser costillas rotas o heridas de cuchillo. Puedes sufrir daño como 'Rechazado' en una elegante cena del Gobernador. Si sintonizas mal con un artefacto, podrías recibir daño de nivel 2 como 'Voces que Gritan en Tu Mente'. Esto aplicaría un -1d (según el daño de nivel 2) cada vez que realices una acción en la que las voces gritando en tu cabeza puedan influir.

El daño se elimina mediante la acción de recuperación durante el tiempo de inactividad (ver página 187), pero también puede desaparecer narrativamente. Al aplicar daño inusual, informa al grupo cómo pueden eliminarlo. Si no estás seguro, como en el caso de las voces gritando, discute con tu mesa qué tipo de proyecto a largo plazo podría resolverlo.

Esta es una forma de destacar a oponentes poderosos sin matar a los personajes. Por ejemplo, un cazarrecompensas fuerte podría golpearte en el estómago, dejándote con daño de nivel 3 'No Puedes Respirar'. Este daño se aclara después de 10 minutos de descanso, pero te deja incapacitado durante el resto de la escena.
",
        _ => "" 
	};
}

