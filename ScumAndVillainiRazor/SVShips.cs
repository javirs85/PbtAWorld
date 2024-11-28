using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public enum ShipTypes { Stardancer, Cerberus, Firedrake, NotSet }
public enum ShipReputations { ambitious, brutal, valientes, honorables, profesionales, astutos, raros, sutiles, NotSet}
public enum CrewUpgrades { }

public static class ShipExtensions
{
	public static string ToUI(this ShipTypes shipType) => shipType switch
	{
		ShipTypes.Stardancer => "Stardancer",
		ShipTypes.Cerberus => "Querberus",
		ShipTypes.Firedrake => "Firedrake",
		_ => ""
	};

	public static string GetExplanation(this ShipTypes shipType) => shipType switch
	{
		ShipTypes.Stardancer => "Contrabandistas y escapistas. Buscan hacer trabajos ocasionales, pequeños robos y encontrar objetos perdidos",
		ShipTypes.Cerberus => "Especialistas en rescate. Se dedican a localizar personas o artículos perdidos y reclamar recompensas.",
		ShipTypes.Firedrake => "Rebeldes y criminales. Buscan proteger a los oprimidos y luchar contra el imperio.",
		_ => ""
	};
}

public enum ShipUpgradeIDs
{
	NotSet,

	//ship upgrades
	HoloEmitters,
	IntruderAlarm,
	LandRover,
	PowerReserves,
	Shuttle,
	StasisPods,
	Vault,

	//crew upgrades
	AlienPet,
	LandTransport,
	ReconDrone,
	SurvivalGear,
	Workshop,
	//auxiliary modules
	AIModule,
	Armory,
	Brig,
	Galley,
	MedicalBay,
	ScienceBay,
	Shields,
	//Hull modules
	CargoHold,
	CrewQuarters, LandingBay,
	SmugglingCompartments,
	//engine modules
	Afterburners,
	CloakingDevice,
	GraviticFieldGenerator,
	JumpDrive,
	//comms modules
	FakeTransponder,
	LongRangeScanner,
	NexusLink,
	QuantumEncryptor,
	TargetingComputer,
	//weapons modules
	CoherenceCannon,
	GrapplingHooks,
	MiningDrill,
	Missiles,
	ParticleCannons,
	//FiredrakeCrewShip
	BlackMarketContacts,
	SecretBase,
	PopularSupport,
	WayBlessed,
	Driven,
	//KerberusCrewShip
	Tracers,
	StunWeapons,
	PersonalVehicles,
	HardKnocks,
	SmoothCriminals,
	//stardancerCrewShip
	FalseShipPapers,
	DarkHyperspaceLaneMaps,
	SmugglersRigging,
	LuckyCharm,
	Thrillseekers
}
public enum SpecialAbilityIDs
{
	//stardancer
	TheGetaway,
	CargoEye,
	FieldRepairs,
	Leverage,
	JustPassingThrough,
	HomeCooking,
	ProblemSolvers,
	//cerberus
	Licensed,
	OnTheTrail,
	LightTouch,
	SnatchNGrab,
	LoadedForBear,
	PlayBothSides,
	Deadly,
	//firedrake
	OldHands,
	ForgedInFire,
	Sympathizers,
	NaturalEnemies,
	SparkOfRebellion,
	JustCause,
	HeartsMinds
}

public class ShipUpgrade
{
	public ShipUpgradeIDs ID { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public int Cost { get; set; } = 1;
	public bool IsTicked { get; set; } = false;
}

public class ShipSpecialAbility
{
	public SpecialAbilityIDs ID { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string FlavorText { get; set; } = string.Empty;
}


public class SVShip
{
	public List<ShipUpgrade> AllUpgrades = new List<ShipUpgrade>
	{
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.HoloEmitters,
			Title = "Emisores Holo",
			Description = "Usados para holo-conferencias y exhibiciones llamativas. Las imágenes generalmente no resisten un escrutinio cercano, pero pueden ser convincentes por un corto tiempo. Incluye juegos y videos geniales."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.IntruderAlarm,
			Title = "Alarma de Intrusos",
			Description = "Un conjunto completo de sensores en la nave, incluyendo sensores de movimiento, códigos de puertas y botones de pánico que pueden activar una sirena y luces rojas intermitentes si algo está fuera de lugar."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.LandRover,
			Title = "Vehículo Todoterreno",
			Description = "Un vehículo todoterreno blindado para transportar carga pesada y personas por tierra. Incluye un cabrestante de alta potencia y pegatinas decorativas de serie."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.PowerReserves,
			Title = "Reservas de Energía",
			Description = "Baterías y suministros de energía que pueden alimentar la nave independientemente del motor. Suficiente para unas pocas horas de operación a uso mínimo o unos minutos a plena potencia. Actúa como armadura contra percances relacionados con la energía en la nave."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Shuttle,
			Title = "Transbordador",
			Description = "Una pequeña nave espacial capaz de transportar a unas pocas personas desde el planeta a la órbita. Capacidad de sistemas limitada: trata cualquier sistema como de calidad cero frente a naves reales. Puede acoplarse a esclusas, pero es mejor guardarlo en una bahía de aterrizaje si no quieres que asteroides errantes o disparos de cañones de partículas lo dañen."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.StasisPods,
			Title = "Cápsulas de Estasis",
			Description = "Cápsulas de última generación que proporcionan espacio para un invitado gravemente herido, mortalmente enfermo o inconsciente cada una. No previene sueños."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Vault,
			Title = "Bóveda",
			Description = "Muy útil para asegurar objetos valiosos durante los viajes espaciales. Cerradura programable que permite códigos de seguridad personalizados, códigos de un solo uso y registros de acceso. Usa la calificación del casco cuando es disputada."
		}
	};
	public List<ShipUpgrade> AllCrewUpgrades = new List<ShipUpgrade>
	{
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.AlienPet,
			Title = "Mascota Alienígena",
			Description = "Truhán adorable o guardián leal, estas criaturas suelen ser más problemáticas de lo que valen. ¿Dónde la conseguiste?"
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.LandTransport,
			Title = "Transporte Terrestre",
			Description = "Suficiente transporte terrestre para toda la tripulación. Ruedas o hover cercano al suelo. Pueden ser bicicletas motorizadas, deslizadores terrestres, botes o autos muy pequeños."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.ReconDrone,
			Title = "Dron de Reconocimiento",
			Description = "Un pequeño dron para vigilancia, mapeo y recopilación de inteligencia en el espacio y en la atmósfera. Puede recibir instrucciones simples. \"Busca firmas de calor en la mina.\" Usa la calidad de comunicaciones cuando es disputado."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.SurvivalGear,
			Title = "Equipo de Supervivencia",
			Description = "Equipo de campamento, rebreathers, equipo de escalada, equipo de buceo. Todo lo que una tripulación emprendedora necesita para sobrevivir en una roca inhóspita, pero no inhabitable. Trajes destiladores incluidos."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Workshop,
			Title = "Taller",
			Description = "Cortadores de plasma, un nano-ensamblador, un stock de componentes metálicos y eléctricos, una forja: todo lo necesario para construir, modificar o desmontar máquinas, armas y herramientas complejas. Añade +1 de calidad a las tiradas de creación."
		}
	};
	public List<ShipUpgrade> AuxiliaryModules = new List<ShipUpgrade>
	{
		 new ShipUpgrade
		{
			ID = ShipUpgradeIDs.AIModule,
			Title = "Módulo de IA",
			Description = "Software conectado a un núcleo de IA Ur, con filamentos de fibra óptica que recorren toda la nave. Puede automatizar tareas o de otro modo operar la nave en nombre de la tripulación. Módulo de personalidad sarcástica disponible gratis."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Armory,
			Title = "Armería",
			Description = "Una sala segura que contiene las armas y armaduras de la tripulación. Todas las armas y armaduras de la tripulación se consideran finas si no lo son ya."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Brig,
			Title = "Celda",
			Description = "Cárcel espacial. No está destinada a encarcelamientos a largo plazo. Previene la mayoría de los intentos de escape."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Galley,
			Title = "Cocina",
			Description = "Una cocina combinada y área de servicio para comidas. Facilita en gran medida los viajes largos. Incluye almacenamiento de alimentos frescos."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.MedicalBay,
			Title = "Bahía Médica",
			Description = "Una sala limpia con equipo médico. No es un hospital real, pero suficiente para curar la mayoría de las heridas. Almacenamiento para medicamentos y escáneres médicos. Añade +1d a todas las tiradas de recuperación de la tripulación."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.ScienceBay,
			Title = "Bahía de Ciencia",
			Description = "Laboratorio que puede ser usado para analizar anomalías y artefactos Precursores. Almacenamiento seguro para cosas que puedan reaccionar de manera extraña con el resto de la nave (o la física)."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Shields,
			Cost=2,
			Title = "Escudos",
			Description = "Sumideros de partículas y deflectores EM. Pueden ser abrumados con fuego concentrado. Cuenta como armadura contra armas de naves y descargas de energía. Absorbe completamente disparos de bláster. Cuesta dos mejoras en lugar de solo una."
		}
	};
	public List<ShipUpgrade> AllHullModules = new List<ShipUpgrade>
	{
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.CargoHold,
			Title = "Bodega de Carga",
			Description = "Suficiente espacio en una nave para llevar un cargamento moderado (que genere créditos). Una bodega de carga es evidente cuando se aborda la nave, y no se toman precauciones especiales para ocultar su contenido."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.CrewQuarters,
			Title = "Camarotes",
			Description = "Puedes dormir en cualquier lugar, pero los camarotes están diseñados para eso. Los camarotes ofrecen privacidad y comodidad en un dominio donde tales cosas son lujos. Además, no tienes que compartir, y sabes que el primer oficial ronca."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.LandingBay,
			Title = "Bahía de Aterrizaje",
			Description = "Compuertas, puertas de bahía y rampas de despegue para acomodar transbordadores y pequeñas naves de combate de un solo piloto tanto para despegue en tierra como en el espacio."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.SmugglingCompartments,
			Title = "Compartimientos de Contrabando",
			Description = "Como una bodega de carga (puede llevar un pequeño cargamento), pero no aparecerá en escaneos rutinarios o inspecciones visuales de la nave. Con una calificación de casco de 3 o más, tiene soporte vital para contrabandear personas también."
		}
	};
	public List<ShipUpgrade> AllEngineModules = new List<ShipUpgrade>
	{
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.Afterburners,
			Title = "Postquemadores",
			Description = "Inyectan combustible directamente en los motores para un breve aumento de velocidad. Puede tratar los motores como si tuvieran una calificación superior para una tirada, pero podría dañarlos."
		},
		new ShipUpgrade
		{
			ID = ShipUpgradeIDs.CloakingDevice,
			Title = "Dispositivo de Camuflaje",
			Description = "No necesariamente hace que la nave sea invisible a simple vista, pero enmascara la firma de calor y eléctrica de la nave, haciendo muy difícil detectarla o identificarla. Súper ilegal."
		},
		new ShipUpgrade { ID = ShipUpgradeIDs.GraviticFieldGenerator, Title = "Gravitic Field Generator", Description = "Creates a large gravitic field extending ship to ship. Can be used to grapple or tow. Temperamental and dangerous. Guild prototype only. Not legal." },
		new ShipUpgrade { ID = ShipUpgradeIDs.JumpDrive, Title = "Jump Drive", Description = "A special engine that can activate the Ur gates that connect systems and translate ships into hyperspace lanes." }
	};
	public List<ShipUpgrade> AllWeaponsModules = new List<ShipUpgrade>
	{
		new ShipUpgrade { ID = ShipUpgradeIDs.CoherenceCannon, Title = "Cañón de Coherencia", Description = "Un arma capital. Un solo disparo hasta que sea reparado o recargado en naves más pequeñas que los acorazados. Puede quemar sistemas. Increíblemente mortal. Super no legal." },
		new ShipUpgrade { ID = ShipUpgradeIDs.GrapplingHooks, Title = "Ganchos de Abordaje", Description = "Oficialmente para engancharse a asteroides y asegurar la carga, es una serie de redes, líneas de agarre y brazos que pueden unir dos naves para remolcarlas o abordarlas. Legal." },
		new ShipUpgrade { ID = ShipUpgradeIDs.MiningDrill, Title = "Taladro Minero", Description = "Taladro de energía de alta potencia, vicioso y de corto alcance. Vaporiza rocas. Fácilmente modificable para perforar cascos. Legal." },
		new ShipUpgrade { ID = ShipUpgradeIDs.Missiles, Title = "Misiles", Description = "Proyectiles con motor montado. No legales." },
		new ShipUpgrade { ID = ShipUpgradeIDs.ParticleCannons, Title = "Cañones de Partículas", Description = "¡Piu! ¡Piu! Normalmente fijados en una dirección en naves personales. A menudo interconectados. No legales sin licencia." }
	};
	public List<ShipUpgrade> AllCommsModules = new List<ShipUpgrade>
	{
		new ShipUpgrade { ID = ShipUpgradeIDs.FakeTransponder, Title = "Transpondedor Falso", Description = "Transmite la señal de una nave diferente o reproduce una grabación potente de ecos de sensores (o actúa como una baliza). Utilizable de forma remota." },
		new ShipUpgrade { ID = ShipUpgradeIDs.LongRangeScanner, Title = "Escáner de Largo Alcance", Description = "Proporciona una variedad de lecturas del espectro electromagnético y gravimétrico, dando a la tripulación advertencia avanzada hasta una docena de minutos luz de distancia." },
		new ShipUpgrade { ID = ShipUpgradeIDs.NexusLink, Title = "Enlace Nexus", Description = "Una conexión a la Red del Sistema Hegemónico. Permite actualizaciones de noticias, mensajes intra-sistema en tiempo real y acceso a las redes de sensores de todo el sistema. Inseguro." },
		new ShipUpgrade { ID = ShipUpgradeIDs.QuantumEncryptor, Title = "Cifrador Cuántico", Description = "Cifra las comunicaciones y el almacenamiento de datos. Concede armadura contra la interceptación de comunicaciones digitales. Los datos en la nave se almacenan de forma segura hasta que se desbloquean." },
		new ShipUpgrade { ID = ShipUpgradeIDs.TargetingComputer, Title = "Computadora de Apuntamiento", Description = "Maneja los cálculos y el apuntamiento para sistemas de armas sin que un miembro de la tripulación real lo haga. Tira con la puntuación de comunicaciones al disparar." }
	};
	public List<ShipUpgrade> AllFireDrakeCrewShipUpgrades = new List<ShipUpgrade>
	{
		new ShipUpgrade { ID = ShipUpgradeIDs.BlackMarketContacts, Title = "Contactos del Mercado Negro", Description = "Capaz de conseguirte todos los módulos (incluso los ilegales) que tu nave necesita, incluso cuando estás buscado. Ingenioso. Móvil. Los módulos ilegales (como de costumbre) pueden requerir que realices un trabajo para adquirirlos. Tu contacto puede saber dónde encontrarlos y darte una ventaja, pero depende de ti obtener cosas que simplemente no están disponibles a cualquier precio (prototipos, dispositivos raros y cosas increíblemente ilegales como los cañones de coherencia)." },
		new ShipUpgrade { ID = ShipUpgradeIDs.SecretBase, Title = "Base Secreta", Description = "Podría estar dentro de ruinas antiguas de Ur en un planeta. Tal vez edificios dentro de un asteroide masivo. Posiblemente una estación vieja y olvidada, abandonada hace mucho pero ahora reutilizada. Has encontrado y comisionado un lugar de escondite lejos de la mirada malévola de la Hegemonía donde tú y tus aliados pueden reunirse, esconderse, lamerse las heridas y planificar tus trabajos, todo sin que la Hegemonía lo descubra. Es secreto... por ahora." },
		new ShipUpgrade { ID = ShipUpgradeIDs.PopularSupport, Cost=3, Title = "Apoyo Popular", Description = "Se necesita trabajo para ganarse los corazones y las mentes, pero tu causa tiene partidarios entre la gente común. Cuando te acerques a un planeta o una estación, pregunta al GM quién podría ser un simpatizante allí. Esto puede facilitar las escapadas, y simplemente caminar mientras eres buscado, mucho más fácil. Cuesta tres mejoras desbloquear esto en lugar de una." },
		new ShipUpgrade { ID = ShipUpgradeIDs.WayBlessed,  Cost=2, Title = "Bendecido por el Camino", Description = "Algunas personas simplemente tienen suerte. La gente común piensa que esto es algún tipo de señal. No te adentres demasiado en ello. Comienzas con +1 gambito al inicio de cada trabajo. Cuesta dos mejoras desbloquear esto en lugar de una." },
		new ShipUpgrade { ID = ShipUpgradeIDs.Driven, Cost=3, Title = "Impulsado", Description = "Cada PC recibe +1 casilla de trauma. Esto puede devolver a un PC con 4 traumas al juego si lo deseas. Cuesta tres mejoras desbloquear esto en lugar de una." }
	};
	public List<ShipUpgrade> AllCerberusCrewShipUpgrades = new List<ShipUpgrade>
	{
		new ShipUpgrade { ID = ShipUpgradeIDs.Tracers, Title = "Rastreadores", Description = "Una amplia variedad de formas de rastrear a tus objetivos. Incluye pequeños dispositivos que pueden ocultarse en la ropa con una palmadita elegante en la espalda, balizas que pueden sujetarse a cascos e incluso clonadores de transmisiones para comunicaciones. La legalidad varía (a menudo por la importancia del objetivo), pero una licencia lo hace todo legal." },
		new ShipUpgrade { ID = ShipUpgradeIDs.StunWeapons, Title = "Armas Aturdidoras", Description = "Una amplia variedad de armas para capturar y asegurar prisioneros sin causar (graves) daños. Incluye, pero no se limita a: Grilletes, Bastones aturdidores, Ajustes de aturdimiento en blásters. No del tipo pesado, Granadas aturdidoras. Reemplaza el detonador en la hoja, Medicamentos sedantes. Puede que no funcionen en algunos xenos. No es necesario llevarlos en trabajos, pero útiles si quieres reclamar recompensas. Generalmente legales." },
		new ShipUpgrade { ID = ShipUpgradeIDs.PersonalVehicles, Cost=2, Title = "Vehículos Personales", Description = "Tu tripulación tiene unos pocos (quizás uno por miembro de la tripulación) vehículos de un solo asiento elegantes que pueden plegarse lo suficientemente apretados como para caber en un espacio de estacionamiento razonable. Combustible limitado, pero puede romper la atmósfera. Pueden llevar armas básicas, aunque no pueden dañar seriamente nada del tamaño de un carguero o más grande. Es posible que desees un hangar de aterrizaje en tu nave. Cuesta dos mejoras desbloquear esto en lugar de una." },
		new ShipUpgrade { ID = ShipUpgradeIDs.HardKnocks, Cost=2, Title = "Golpes Duros", Description = "A veces la suerte es simplemente experiencia ganada a pulso. Tu tripulación comienza cada trabajo con +1 gambito. Cuesta dos mejoras desbloquear esto en lugar de una." },
		new ShipUpgrade { ID = ShipUpgradeIDs.SmoothCriminals, Cost=3, Title = "Delincuentes Suaves", Description = "A veces la legalidad es solo una cuestión de quién tiene el arma. Cada miembro de la tripulación obtiene +1 casilla de estrés (total 10). Cuesta tres mejoras desbloquear esto en lugar de una." }
	};
	public List<ShipUpgrade> AllStarDancerCrewShipUpgrades = new List<ShipUpgrade>
	{
		new ShipUpgrade { ID = ShipUpgradeIDs.FalseShipPapers, Title = "Documentos Falsos de la Nave", Description = "Todo contrabandista necesita algunos documentos bien falsificados, dando a la tripulación y a la nave identidades menos buscadas en cualquier sistema dado. Estos papeles a menudo simplifican el viaje a través de las puertas si el transpondedor y la nave coinciden. Tienes un par de juegos diferentes que puedes intercambiar, incluso si tienes que practicar para responder a un nuevo nombre en cada punto de control. Puede dificultar que las facciones enemigas te sigan y te rastreen." },
		new ShipUpgrade { ID = ShipUpgradeIDs.DarkHyperspaceLaneMaps, Title = "Mapas de Rutas de Hiperespacio Oscuro", Description = "Estas son rutas a través de sistemas que no están oficialmente mantenidas. A veces son más rápidas. Siempre están menos patrulladas. A menudo están llenas de criaturas del Camino, piratas y otros bribones. El viaje nunca es tan suave como lo es a lo largo de las rutas mantenidas por los Maestros Estelares. No querrás pensar demasiado en los pobres tontos que murieron o se perdieron para siempre mapeando estas rutas." },
		new ShipUpgrade { ID = ShipUpgradeIDs.SmugglersRigging, Title = "Rigging del Contrabandista", Description = "Tejidos o piel falsa utilizada para sostener objetos pequeños cerca del cuerpo, y una excelente manera de pasarlos de contrabando ante la seguridad. Añade un poco de espacio de transporte manos libres mientras trabajas en el exterior de la nave, y te permite pasar un bláster a una reunión bien custodiada mientras mantienes el elegante corte de tu abrigo. Solo puedes llevar/esconder un objeto de un máximo de 1 carga de esta manera." },
		new ShipUpgrade { ID = ShipUpgradeIDs.LuckyCharm, Cost=2, Title = "Amuleto de la Suerte", Description = "Ya sea un artefacto de Ur o unos recuerdos exhibidos prominentemente en el puente, a veces la suerte solo se trata de creer en algo. La tripulación comienza con +1 gambito en cada trabajo. Cuesta dos mejoras desbloquear esto en lugar de solo una." },
		new ShipUpgrade { ID = ShipUpgradeIDs.Thrillseekers, Cost=3, Title = "Buscadores de Emociones", Description = "Cada PC recibe una casilla de estrés adicional (aumenta el máximo de estrés a 10). Cuesta tres mejoras desbloquearlo, no solo una." }
	};
	


	public string Name { get; set; } = "El nombre de la nave";
	public int CrewXP { get; set; } = 0;
	public int CrewQuality { get; set; } = 3;

	public int UpkeepCost 
	{ 
		get 
		{
			int cost = 0;
			foreach (var s in Systems)
				cost += s.Level;

			cost += CrewQuality;
			cost = (int)Math.Round((float)cost / 4.0);
			return cost;
		} 
	}

	public int SkippedUpkeeps { get; set; } = 0;
	public int MaxShields { get; set; } = 1;
	public int UsedShields { get; set; } = 0;
	public string Notes { get; set; } = string.Empty;
	public int Gambits { get; set; } = 2;
	public int Cred { get; set; } = 0;
	public int Debt { get; set; } = 0;
	public List<string> HowToXp = new();
	

	public ShipReputations Reputation { get; set; } = ShipReputations.NotSet;
	private ShipTypes _shipType = ShipTypes.NotSet;

	public List<SVMoveIDs> AvailableSpecialAbilities { get; set; } = new List<SVMoveIDs>();
	public List<SVMoveIDs> SelectedSpecialAbilities { get; set; } = new List<SVMoveIDs>();

	public List<ShipSystem> Systems { get; set; } = new List<ShipSystem>();
	public List<ShipUpgradeIDs> Upgrades
	{
		get {
			if (ShipType == ShipTypes.Firedrake) return AllFireDrakeCrewShipUpgrades.Select(x=>x.ID).ToList();
			else if (ShipType == ShipTypes.Cerberus) return AllCerberusCrewShipUpgrades.Select(x=>x.ID).ToList();
			else return AllStarDancerCrewShipUpgrades.Select(x=>x.ID).ToList();
		}
	}

	public ShipTypes ShipType
	{
		get { return _shipType; }
		set { 
			_shipType = value;
			InitShip();
		}
	}

	private void InitShip()
	{
		if (ShipType == ShipTypes.Stardancer)
		{
			AvailableSpecialAbilities = new List<SVMoveIDs> { SVMoveIDs.Getaway, SVMoveIDs.CargoEye, SVMoveIDs.FieldRepairs, SVMoveIDs.Leverage, SVMoveIDs.JustPassingThrough, SVMoveIDs.HomeCooking, SVMoveIDs.ProblemSolvers };
			HowToXp = new List<string>
			{
				"Ejecutaste con éxito una operación de transporte o contrabando.",
				"Te enfrentaste a desafíos superiores a tu situación actual.",
				"Reforzaste la reputación de tu tripulación o desarrollaste una nueva.",
				"Expresaste los objetivos, las motivaciones, el conflicto interno o la naturaleza esencial de la tripulación."
			};
			Systems = new List<ShipSystem>
			{
				new ShipSystem
				{
					System = ShipSystems.Hull,
					MaxLevel = 4,
					Level = 2,
					MaxHealth = 2,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.SmugglingCompartments, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.CargoHold, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Engines,
					MaxLevel = 4,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.JumpDrive, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.Afterburners, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Comms,
					MaxLevel = 3,
					Level = 0,
					MaxHealth = 0,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.FakeTransponder, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.QuantumEncryptor, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Weapons,
					MaxLevel = 2,
					Level = 0,
					MaxHealth = 0,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				}
			};
		}
		else if (ShipType == ShipTypes.Cerberus)
		{
			AvailableSpecialAbilities = new List<SVMoveIDs> { SVMoveIDs.Licensed, SVMoveIDs.OnTheTrail, SVMoveIDs.LightTouch, SVMoveIDs.SnatchNGrab, SVMoveIDs.LoadedForBear, SVMoveIDs.PlayBothSides, SVMoveIDs.Deadly };
			HowToXp = new List<string>
			{
				"Ejecutaste con éxito una operación de extracción o capturaste una recompensa.",
				"Te enfrentaste a desafíos superiores a tu situación actual.",
				"Reforzaste la reputación de tu tripulación o desarrollaste una nueva.",
				"Expresaste los objetivos, las motivaciones, el conflicto interno o la naturaleza esencial de la tripulación."
			};
			Systems = new List<ShipSystem>
			{
				new ShipSystem
				{
					System = ShipSystems.Hull,
					MaxLevel = 2,
					Level = 0,
					MaxHealth = 0,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Engines,
					MaxLevel = 3,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.JumpDrive, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Comms,
					MaxLevel = 4,
					Level = 2,
					MaxHealth = 2,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.LongRangeScanner, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NexusLink, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Weapons,
					MaxLevel = 3,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.GrapplingHooks, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.ParticleCannons, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				}
			};
		}
		else if (ShipType == ShipTypes.Firedrake)
		{
			AvailableSpecialAbilities = new List<SVMoveIDs> { SVMoveIDs.OldHands, SVMoveIDs.ForgedInFire, SVMoveIDs.Sympathisers, SVMoveIDs.NaturalEnemies, SVMoveIDs.SparkOfRebellion, SVMoveIDs.JustCause, SVMoveIDs.HeartsAndMinds };
			HowToXp = new List<string>
			{
				"Ejecutaste con éxito un trabajo que se opone al dominio de la Hegemonía.",
				"Te enfrentaste a desafíos superiores a tu posición actual.",
				"Reforzaste la reputación de tu tripulación o desarrollaste una nueva.",
				"Expresaste los objetivos, las motivaciones, el conflicto interno o la naturaleza esencial de la tripulación."
			};
			Systems = new List<ShipSystem>
			{
				new ShipSystem
				{
					System = ShipSystems.Hull,
					MaxLevel = 2,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.CrewQuarters, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.LandingBay, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Engines,
					MaxLevel = 3,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.JumpDrive, IsTicked = true },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Comms,
					MaxLevel = 4,
					Level = 0,
					MaxHealth = 0,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.TargetingComputer, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.FakeTransponder, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false },
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				},
				new ShipSystem
				{
					System = ShipSystems.Weapons,
					MaxLevel = 3,
					Level = 1,
					MaxHealth = 1,
					Health = 0,
					Upgrades = new List<UpgradeInSystem>
					{
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.ParticleCannons, IsTicked =  true},
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.CoherenceCannon, IsTicked =  false},
						new UpgradeInSystem{ UpgradeID = ShipUpgradeIDs.NotSet, IsTicked = false }
					}
				}
			};
		}
	}



	public List<string> PayingMethods = new List<string>
	{
		"Pagar: Les das 1CRED a cambio de su trabajo, Sin historias, sin deudas",
		"Deberles 1: Prometes que les devolverás el favor cuando lo necesiten, ganas *status +1**. Solo pudes pagar así si compras *Calidad de la tripulación**",
		"Timarlos: Para qué pagar a alguien que no cobra por adelantado? Apunta *status -1** con esa facción"
	};

}

public class ShipSystem
{
	public ShipSystems System { get; set; } = ShipSystems.NotSet;
	public int Level { get; set; } = 0;
	public int MaxLevel { get; set; } = 0;
	public int MaxHealth { get; set; } = 0;
	public int Health { get; set; } = 0;
	public int Size { get; set; } = 0;
	public List<UpgradeInSystem> Upgrades { get; set; } = new List<UpgradeInSystem>();

}

public class UpgradeInSystem
{
	public ShipUpgradeIDs UpgradeID { get; set; } = ShipUpgradeIDs.NotSet;
	public bool IsTicked { get; set; } = false;
}

