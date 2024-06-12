using PbtALib;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public class SVTextBook : BaseTextBook
{
	public class SVItem
	{
		public SVItemIDs ID;
		public string Name = string.Empty;
		public string Description= string.Empty;
		public string FlavorText = string.Empty;
		public int Load = 0;
	}

	public List<SVItem> Items = new List<SVItem>
	{
		//standard
		new SVItem
		{
			ID = SVItemIDs.Armor,
			Name = "Armadura",
			Description = "Muy evidente, protección completa. Detiene unos pocos rayos. Rechaza un cuchillo sin darse cuenta. Potenciada. Ayuda en el movimiento."
		},
		new SVItem
		{
			ID = SVItemIDs.Blaster,
			Name = "Blaster",
			Description = "Dispara rayos de plasma caliente. Precisa solo a corta distancia. Hace ruidos de \"pew pew\" (obligatorio). Viene en una variedad de formas. ¿Cómo personalizas la tuya?"
		},
		new SVItem
		{
			ID = SVItemIDs.Comm,
			Name = "Comunicador",
			Description = "Tiene varias bandas, probablemente algunas cifradas. Funciona solo dentro de la órbita."
		},
		new SVItem
		{
			ID = SVItemIDs.Hacking,
			Name = "Herramientas de Hackeo",
			Description = "Cubierta, pinzas de empalme, conectores y puertos, descifradores de teclado, software especializado, chips modificados personalizados, diccionarios de arcoíris, exploits automatizados. Todo lo que un hacker en crecimiento necesita."
		},
		new SVItem
		{
			ID = SVItemIDs.Detonator,
			Name = "Detonador",
			Description = "Arma explosiva extremadamente mortal. Cabe en la palma de la mano y puede ser lanzada. Se encarga de esas puertas blindadas que las pistolas pesadas no pueden manejar. Ilegal. No deberías tener esto. No, en serio."
		},
		new SVItem
		{
			ID = SVItemIDs.HeavyBlaster,
			Name = "Blaster Pesado",
			Description = "Puede causar un considerable daño a vehículos y cosas como puertas sin blindaje. Tiene alrededor de una docena de disparos. Causará daño serio y escabroso a las personas. Ilegal."
		},
		new SVItem
		{
			ID = SVItemIDs.IllicitDrugs,
			Name = "Drogas Ilícitas",
			Description = "¿Cuál es tu veneno, vaquero del espacio? Para uso personal, atrapar una recompensa peligrosa o entretenimiento mientras viajas entre planetas."
		},
		new SVItem
		{
			ID = SVItemIDs.Medkit,
			Name = "Botiquín",
			Description = "Sangre para algunas razas comunes, gasas, inyector anti radiación, bisturí láser, antisépticos, hilo, analgésicos."
		},
		new SVItem
		{
			ID = SVItemIDs.MeleeWeapon,
			Name = "Arma de Combate Cuerpo a Cuerpo",
			Description = "Afilada. Contundente. Puntiaguda. Apuñaladora. Cortante. De diferentes tamaños. Algunas vienen con bordes láser. Algunas vibran... oh. Baterías incluidas."
		},
		new SVItem
		{
			ID = SVItemIDs.RepairTools,
			Name = "Herramientas de Reparación",
			Description = "Cosas que necesitas para arreglar motores de naves, speeders, autos voladores y similares. Herramientas para empalmar consolas y ajustar maquinaria. Martillos, soldadores, destornilladores, llaves, cargadores de baterías, pintores de aerosol."
		},
		new SVItem
		{
			ID = SVItemIDs.Spacesuit,
			Name = "Traje Espacial",
			Description = "Algo de protección contra la radiación, supervivencia en atmósferas tóxicas, EVA. Medio día de oxígeno (o cualquier otro gas, líquido o sustancia que respires)."
		},
		new SVItem
		{
			ID = SVItemIDs.SpyGear,
			Name = "Equipo de Espionaje",
			Description = "Disfraces, moduladores de voz, mini cámaras, escáneres térmicos, huellas dactilares falsas y filtros de audio."
		},
		//mechanic
		new SVItem
		{
			ID = SVItemIDs.FineHackingRig,
			Name = "Equipo fino de hackers",
			Description = "Gafas de visualización, exploits no publicados, chips fuera de mercado sobrecargados, vampiros digitales ópticos, Hackear va tanto de software como de hardware. Quien mantiene tu equipo?",
			FlavorText = "Quien mantiene tu equipo? Escribes tus propios programas o alguien te mantiene al dia? Alguna decoración en tu kit?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.FineShipRepairTools,
			Name = "Herramientas de Reparación de Naves de Calidad",
			Description = "Llaves de torsión asistidas por energía, un taladro sónico, sondas de prueba, calibradores de energía, una remachadora. ¿Es este un conjunto de elementos o los recogiste uno a uno?",
			FlavorText = "¿Es este un conjunto de elementos o los recogiste uno a uno? ¿Quién mantiene tu equipo?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.SmallDrone,
			Name = "Pequeño Dron",
			Description = "Pequeño dron controlado a distancia con cámaras. Puede que pueda llevar algo ligero. ¿Lo construiste o lo compraste? ¿Vuela, se arrastra o se desliza? ¿Qué apodo le diste? ¿Tienes varios drones en la nave, o solo un montón de chasis y piezas de repuesto que usas para reparar uno?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.VisionEnhancingGoggles,
			Name = "Gafas de Mejora de Visión",
			Description = "Gafas con configuraciones para térmicas y ultravioletas, y niveles de aumento en miles. Incluso se tintan cuando es necesario. ¿Cómo son? ",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.SpareParts,
			Name = "Piezas de Repuesto",
			Description = "Por lo general, para reparaciones de naves y electrónica. A menudo olvidadas en un bolsillo o cinturón de herramientas. Aunque por lo general no son excesivamente caras, terminas llevando piezas en las que estás trabajando y piezas para reparar naves. Si alguna vez necesitas un cable, soldadura o un trozo de cinta, lo tienes a mano. Cualquier cosa rara o más compleja podría requerir una tirada de estilo de vida (ver página 49) para tenerla contigo.",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.GeniusPet,
			Name = "Mascota Genial",
			Description = "Incapaz de hablar, pero puede entender el lenguaje y ayudar con tareas básicas. Te aprecia mucho. Muy lindo. Anticipa tus acciones. ¿Es algo familiar (como un perro o un gato) o una pequeña criatura alienígena? ¿Cuál es su nombre? ¿De quién lo conseguiste (legal o ilegalmente)?",
			Load = 0
		},
		//muscle
		new SVItem
		{
			ID = SVItemIDs.Krieger,
			Name = "Krieger, una pistola bláster fina",
			Description = "Como amigo o aliado, esta pistola característica se puede usar durante el tiempo libre para amenazar o intimidar. Como enemigo, alguien más lo posee y lleva una bala para ti.",
			FlavorText = "¿Conoces esta pistola íntimamente, de dónde o por qué?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.Vera,
			Name = "Vera, un rifle de francotirador fino",
			Description = "Un auto-bloqueo completo con gatillo personalizado, doble cartucho, medidor exhaustivo. Puede disparar municiones místicas.",
			FlavorText = "¿Lo personalizaste tú mismo, lo encargaste especialmente, lo quitaste de un cuerpo o es un regalo de alguien?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.Zmei,
			Name = "Zmei, un lanzallamas fino",
			Description = "Para aquellos momentos en que realmente necesitas calentar las cosas. Configuraciones para regular y extra crujiente. No es fácil de ocultar.",
			FlavorText = "Las complicaciones al ser disparado pueden incluir la ruptura de los tanques de combustible. ¿Qué calcomanías o marcas tiene?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.Sunder,
			Name = "Sunder, una vibro-cuchilla fina",
			Description = "Corta a través de casi cualquier material. Decorada.",
			FlavorText = "¿Cuchillo o espada de duelo? ¿Qué diseño está grabado en la hoja? ¿Lo reclamaste o lo ganaste legítimamente?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.Zarathustra,
			Name = "Zarathustra, un lanzador de detonadores",
			Description = "Dispara detonadores a alta velocidad. Los detonadores son ilegales, por lo que esto genera HEAT cuando se dispara. No sutil.",
			FlavorText = "Baterías incluidas, pero los detonadores se marcan por separado.",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.FineMartialArtsStyle,
			Name = "Estilo de artes marciales fino",
			Description = "Tu propia mezcla personalizada de técnicas de combate, única como una huella dactilar.",
			FlavorText = "¿Dónde y con quién entrenaste por primera vez? ¿Cómo se llama tu estilo? ¿Has tenido algún alumno?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.MysticAmmunition,
			Name = "Munición mística",
			Description = "Un casquillo de gran calibre, diseñado para ser disparado desde un arma especializada que libera energías místicas cuando impacta.",
			FlavorText = "¿Quién hace tus balas místicas? ¿Por qué son potentes contra las energías de la Fuerza?",
			Load = 0
		},
		//mystic
		new SVItem
		{
			ID = SVItemIDs.FineMeleeWeapon,
			Name = "Arma cuerpo a cuerpo fina",
			Description = "Un arma antigua que actúa como una extensión de tu cuerpo. En la era de los blásteres, las espadas y lanzas son vestigios pintorescos de la cultura y la costumbre en su mayor parte. Pero los poderes de La Fuerza parecen interactuar obstinadamente con la tecnología avanzada.Cada orden mística mantiene elementos anacrónicos y los usa de diferentes maneras.",
			FlavorText = "¿Tienes tal arma? Si es así, ¿qué entrenamiento has tenido con ella y cómo la usas?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.Offerings,
			Name = "Ofrendas",
			Description = "Una vela, lámpara de aceite, flores, comida, agua, incienso, guijarros de tu viaje.",
			FlavorText = "¿Fueron regalos, dejados en un santuario para que cualquier místico los tome mientras vagan, o dados a cambio de un trabajo?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.TrappingsOfReligion,
			Name = "Accesorios religiosos",
			Description = "Pergaminos, textos, íconos, copas y cuencos, campanas.",
			FlavorText = "¿Qué objetos sagrados lleva tu orden mística en particular? ¿Qué tan reconocibles serían?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.OutdatedReligiousOutfit,
			Name = "Atuendo religioso anticuado",
			Description = "Túnicas, capas gastadas, sandalias, etc. Los participantes y practicantes de los Cultos Hegemónicos populares y sancionados a menudo llevan insignias bien conocidas de fabricación moderna.",
			FlavorText = "¿Fue tu atuendo heredado? ¿Nunca reemplazado? ¿Hecho a mano?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.MementoOfYourTravels,
			Name = "Recuerdo de tus viajes",
			Description = "Una pequeña estatua, moneda anticuada, un mechón de cabello, una foto.",
			FlavorText = "¿Quién te dio esto y por qué lo aprecias? ¿Es un recordatorio de un buen o mal recuerdo?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.PrecursorArtifact,
			Name = "Artefacto de Precursores",
			Description = "Un pequeño objeto hecho de materiales antiguos. Tecnología de Precursores.",
			FlavorText = "¿Te lo dieron los místicos que te entrenaron, lo encontraste cuando eras niño, o lo recogiste en tus viajes? ¿Qué hace? Discute sus poderes, costos y efectos secundarios con tu grupo (para más información sobre los artefactos de Precursores, consulta la página 268).",
			Load = 1
		},
		//pilot
		new SVItem
		{
			ID = SVItemIDs.FineCustomizedSpacesuit,
			Name = "Traje espacial personalizado fino",
			Description = "Decals geniales, baliza de emergencia, algo de empuje. Te mantendrá vivo en el espacio o cuando tu cabina reciba un disparo. Te permite moverte un poco e incluso puede extender los saltos en la atmósfera.",
			FlavorText = "¿Qué parches o arte personalizado tienes en el tuyo, y qué significa?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.FineSmallUrbot,
			Name = "Urbot pequeño fino",
			Description = "Un pequeño Urbot que apoya la pilotaje y puede transportar algunas cosas. Parece inquietantemente consciente. Se supone que los Urbots deben ser borrados aproximadamente una vez al año. ¿Cuánto tiempo ha pasado desde que llevaste el tuyo al Gremio de Ingenieros para tal procedimiento? ¿Cuál es su designación y qué peculiaridades de personalidad tiene? ¿Cómo es su chasis y cómo te ayuda a pilotar?",
			FlavorText = "¿Te lo dieron los místicos que te entrenaron, lo encontraste cuando eras niño, o lo recogiste en tus viajes? ¿Qué hace? Discute sus poderes, costos y efectos secundarios con tu grupo (para más información sobre los artefactos de Precursores, consulta la página 268).",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.FineMechanicsKit,
			Name = "Kit de mecánica fino",
			Description = "Escáneres de mano, kit de parches de casco, surtido de herramientas de mano. Todo lo que necesitas para parchear un vehículo y hacerlo volar de nuevo. ¿Qué herramienta acabas de recoger? ¿Cuál has personalizado?",
			FlavorText = " ",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.GrapplingHook,
			Name = "Gancho de agarre",
			Description = "Pequeño, pero mecanizado. Puede jalarlo hacia arriba. Se ajusta a tu cinturón. Te hace ver audaz cuando te balanceas para el rescate.",
			FlavorText = "¿Cuándo se rompió por última vez?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.GuildLicense,
			Name = "Licencia de Gremio",
			Description = "Certificación de piloto legítima (aunque puede que no sea tuya). Permitirá tu paso a través de una compuerta de salto. ¿Cómo conseguiste la tuya?",
			FlavorText = " ",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.VictoryCigars,
			Name = "Cigarros de la victoria",
			Description = "Suficientes para compartir con unas pocas personas seleccionadas. ¿Cuál es el punto de hacer acrobacias increíbles si no puedes celebrar? Sin garantía de que el resto de tu tripulación aprecie el olor, o no aumente los filtros de aire. ¿De dónde sacas estos, y cuántos te quedan? ¿Qué tan raros son?",
			FlavorText = " ",
			Load = 0
		},
		//scoundrel
		new SVItem
		{
			ID = SVItemIDs.FineBlasterPistol,
			Name = "Pistola bláster fino",
			Description = "Personalizado o extraño. Puede disparar munición mística. ¿Qué disparan? ¿Dónde los conseguiste en tus viajes? ¿Les pusiste nombre?",
			FlavorText = " ",
			Load = 1 // or 2 if it's a matching pair
		},
		new SVItem
		{
			ID = SVItemIDs.FineBlasterPistolPair,
			Name = "Par de bláster fino",
			Description = "Personalizado o extraño. Puede disparar munición mística. ¿Qué disparan? ¿Dónde los conseguiste en tus viajes? ¿Les pusiste nombre?",
			FlavorText = " ",
			Load = 2 // or 2 if it's a matching pair
		},
		new SVItem
		{
			ID = SVItemIDs.FineCoat,
			Name = "Abrigo fino",
			Description = "Pesado pero bien hecho y bien cuidado. Distintivo y con historia. ¿Dónde conseguiste este abrigo? ¿Fue un regalo, una compra impulsiva o algo que ganaste en una apuesta? ¿Está decorado con algún emblema o logotipo?",
			FlavorText = "Asegúrate de que tenga un aspecto o color memorable.",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.LoadedDice,
			Name = "Dados cargados o cartas de holo-trucos",
			Description = "Accesorios de juego sutilmente alterados para favorecer resultados particulares. La suerte es una de tus muchas habilidades. A veces solo necesita un poco de ayuda. ¿Cuándo fue la última vez que estos te metieron en problemas?",
			FlavorText = " ",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.ForgedDocuments,
			Name = "Documentos falsificados",
			Description = "Facsimilares razonablemente bien hechos de documentos que nunca se entregarían realmente a alguien como tú. ¿Quién los hizo para ti? ¿Todavía le debes a alguien por ellos? ¿O los robaste de alguien?",
			FlavorText = " ",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.PersonalMemento,
			Name = "Recuerdo personal",
			Description = "Un recuerdo que aprecias. Un medallón, un pequeño holo, música de tu mundo natal. Para alguien tan ligado a las vías espaciales, ¿qué hace que este recuerdo sea tan importante? ¿De quién te recuerda? ¿Por qué todavía lo conservas?",
			FlavorText = " ",
			Load = 0
		},
		//Speaker
		new SVItem
		{
			ID = SVItemIDs.FineClothes,
			Name = "Ropa fina",
			Description = "Sarongs de seda, trajes, finas capas azules. Destacas y siempre estás vestido para la ocasión. Nadie confundirá esto con un disfraz. ¿Cuál es tu conjunto favorito?",
			FlavorText = " ",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.LegitimateID,
			Name = "Identificación legítima",
			Description = "Una identificación de la Hegemonía codificada adecuadamente que indica tu estación legítima en la Hegemonía. ¿Quién notará cuando uses esto?",
			FlavorText = " ",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.LuxuryItemSmall,
			Name = "Artículo de lujo",
			Description = "Brandies finos, pequeños pero pensativos regalos, especias y perfumes, instrumentos finos, juegos populares, etc. Estos pueden tener tamaños variados. Cada vez que lleves uno de estos en el trabajo, explica qué es y por qué es lujoso.",
			FlavorText = " ",
			Load = 0 // or 1 or 2 depending on size
		},
		new SVItem
		{
			ID = SVItemIDs.LuxuryItemMedium,
			Name = "Artículo de lujo",
			Description = "Brandies finos, pequeños pero pensativos regalos, especias y perfumes, instrumentos finos, juegos populares, etc. Estos pueden tener tamaños variados. Cada vez que lleves uno de estos en el trabajo, explica qué es y por qué es lujoso.",
			FlavorText = " ",
			Load = 1 // or 1 or 2 depending on size
		},
		new SVItem
		{
			ID = SVItemIDs.LuxuryItemLarge,
			Name = "Artículo de lujo",
			Description = "Brandies finos, pequeños pero pensativos regalos, especias y perfumes, instrumentos finos, juegos populares, etc. Estos pueden tener tamaños variados. Cada vez que lleves uno de estos en el trabajo, explica qué es y por qué es lujoso.",
			FlavorText = " ",
			Load = 2 // or 1 or 2 depending on size
		},
		new SVItem
		{
			ID = SVItemIDs.MementoOfPastEncounter,
			Name = "Recuerdo de un encuentro pasado",
			Description = "Una pieza distintiva de joyería, una fina hoja con un escudo de armas de una Casa, un anillo de sello, una pequeña estatua. ¿De quién son estos y por qué los conservas?",
			FlavorText = " ",
			Load = 0
		},
		//stitch
		new SVItem
		{
			ID = SVItemIDs.FineMedkit,
			Name = "Equipo médico fino",
			Description = "Mejor surtido que el estándar. Grapas para la piel, escáneres de mano para diagnóstico, sinteflesh, estabilizadores óseos, hipos en spray, antídoto (para bestias alienígenas peligrosas) y una selección más amplia de medicamentos.",
			FlavorText = "¿Hay marcas distintivas en tu equipo médico?",
			Load = 2
		},
		new SVItem
		{
			ID = SVItemIDs.FineBedsideManner,
			Name = "Manera de tratar a los pacientes fina",
			Description = "Encanto que tranquiliza a los pacientes. Algunos curanderos nunca se molestan en traer esto.",
			FlavorText = "¿Sabes cómo relacionarte con mucha gente? ¿Compartes muchas anécdotas? ¿Proyectas una actitud de habilidad segura?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.FineClothing,
			Name = "Ropa fina",
			Description = "Un traje o atuendo para cenas elegantes y la alta sociedad. ",
			FlavorText = "¿Es esto un vestigio de tu pasado o algo que has adquirido para cuando necesitas asegurar financiamiento para tu trabajo de médico?",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.RecognizableMedicGarb,
			Name = "Vestimenta médica reconocible",
			Description = "El común traje médico rojo que lleva el sello médico blanco oficial de la Hegemonía. Reconocible desde la distancia. ",
			FlavorText = "¿Cuáles son las reglas sobre cómo deben ser tratados los médicos en combate? ¿Tienen los médicos obligaciones legales mientras están vestidos así?",
			Load = 0
		},
		new SVItem
		{
			ID = SVItemIDs.CandiesAndTreats,
			Name = "Caramelos y golosinas",
			Description = "Para esos clientes extra valientes. ",
			FlavorText = "¿También te indulges en ellos? ¿Alguna vez has disfrazado un sedante como uno para someter a alguien? ",
			Load = 1
		},
		new SVItem
		{
			ID = SVItemIDs.SyringesAndApplicators,
			Name = "Jeringas y aplicadores",
			Description = "Jeringas, inyectores, aplicadores de parches. Muchos pueden ser fáciles de ocultar en la palma de la mano. A veces, tener medicamentos a mano también significa tener que administrarlos sutilmente. ",
			FlavorText = "¿Alguno de estos no es para fines médicos?",
			Load = 0
		}

	};
	public List<SVItemIDs> StandardItems = new List<SVItemIDs> { SVItemIDs.Armor, SVItemIDs.Blaster, SVItemIDs.Comm, SVItemIDs.Detonator, SVItemIDs.Hacking, SVItemIDs.HeavyBlaster, SVItemIDs.IllicitDrugs, SVItemIDs.Medkit, SVItemIDs.MeleeWeapon, SVItemIDs.RepairTools, SVItemIDs.Spacesuit, SVItemIDs.SpyGear };



	public List<string> DevilsBargainOptions = new List<string>
	{
		"Daño colateral, daño no intencionado.",
		"Sacrificar créditos o un objeto.",
		"Traicionar a un amigo o ser querido.",
		"Ofender o enojar a una facción.",
		"Iniciar y/o avanzar un reloj problemático.",
		"Aumentar la presión sobre la tripulación a través de evidencia o testigos.",
		"Sufrir daño."
	};


	public string GetResultsOfRoll(ActionRollPositions poss, int result)
	{
		if (poss == ActionRollPositions.Controlled)
		{
			if (result <= 3) return "Estás bloqueado o vacilas. Sigue adelante aprovechando una oportunidad arriesgada, o retírate y prueba un enfoque diferente.";
			else if (result <= 5) return "Vacilas. Retírate y prueba un enfoque diferente, o de lo contrario, hazlo pero con una consecuencia menor: ocurre una *complicación menor**, tienes un *efecto reducido**, sufres un *daño menor**, o terminas en una *posición arriesgada**.";
			else if (result <= 6) return "Lo haces";
			else return "Lo haces con *efecto mejorado*";
		}
		else if(poss == ActionRollPositions.Risky)
		{
			if (result <= 3) return "Las cosas salen mal. Sufres *daño**, ocurre una *complicación**, terminas en una *posición desesperada**, *pierdes esta oportunidad**.";
			else if (result <= 5) return "Lo logras pero hay una consecuencia: sufres *daño**, ocurre una *complicación**, tienes un *efecto reducido**, terminas en una *posición desesperada.**";
			else if (result <= 6) return " Lo logras. Añade un *gambito** a tu tripulación.";
			else return "Lo haces con *efecto aumentado** y añades un *gambito** si no has gastado uno en esta tirada.";
		}
		else if (poss == ActionRollPositions.Desperate)
		{
			if (result <= 3) return "Es el peor resultado. Sufres un *daño grave**, ocurre una *complicación, pierdes esta oportunidad**.";
			else if (result <= 5) return "Lo logras, pero hay una consecuencia: sufres un *daño grave**, ocurre una *complicación seria**.";
			else if (result <= 6) return "Lo haces";
			else return "Lo haces con *efecto mejorado*";
		}
		else return "";
	}
}



public static class SVExtensions
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

	public static string ToUI(this SVStats c, bool Simplify = false)
	{
		var txt = c switch
		{
			SVStats.Attune => "Sintonizar",
			SVStats.Command => "Comandar",
			SVStats.Consort => "Conversar",
			SVStats.Doctor => "Sanar",
			SVStats.Hack => "Hackear",
			SVStats.Helm => "Pilotar",
			SVStats.Rig => "Trastear",
			SVStats.Scramble => "Maniobrar",
			SVStats.Scrap => "Luchar",
			SVStats.Skulk => "Acechar",
			SVStats.Study => "Estudiar",
			SVStats.Sway => "Persuadir",
			SVStats.Insight => "Perspicacia",
			SVStats.Prowess => "Fisicalidad",
			SVStats.Resolve => "Resolución",
			_ => "Not set"
		};
		if (Simplify)
		{
			txt = txt.Replace('á', 'a');
			txt = txt.Replace('é', 'e');
			txt = txt.Replace('í', 'i');
			txt = txt.Replace('ó', 'o');
			txt = txt.Replace('ú', 'u');
		}

		return txt;
	}

	public static string ToDefinition(this SVStats c) => c switch
	{
		SVStats.Attune => "Cuando *Sintonizas** con *la Fuerza**, abres tu mente a las energías galácticas que subyacen en toda la existencia.\\nPodrías comunicarte con una especie no - sapiente o un robot. Podrías manipular de forma segura artefactos o restos de los Precursores que se conectan directamente con la Fuerza.Podrías percibir peligros ocultos o intenciones asesinas(aunque *Estudiar** podría ser mejor).\"",
		SVStats.Command => "Cuando *Comandas**, impones obediencia con tu fuerza de personalidad.\r\nPodrías intimidar o amenazar para conseguir lo que deseas. Podrías liderar una acción con PNJs. Podrías ordenar a la gente que haga lo que quieres (aunque *Persuadir** podría ser mejor).",
		SVStats.Consort => "Cuando *Conversas**, socializas con amigos y contactos. Podrías obtener acceso a recursos, información, personas o lugares. Podrías causar una buena impresión o ganarte a alguien con tu encanto y estilo. Podrías hacer nuevos amigos o conectar con tu herencia o antecedentes. Podrías intentar dirigir a tus amigos con presión social (aunque *Comandar** podría ser mejor).",
		SVStats.Doctor => "Cuando *Sanas**, atiendes las necesidades de otro ofreciendo ayuda y consuelo, o examinas el mundo de manera científica.\r\nPodrías tratar las heridas de alguien. Podrías analizar la composición de una sustancia para aprender cómo funciona. Podrías reconfortar a alguien en angustia (pero *Socializar** podría ser mejor).",
		SVStats.Hack => "Cuando *Hackeas**, violas los sistemas de seguridad de las computadoras o anulas sus controles.\r\nPodrías acceder a una consola de datos para encontrar a un ser cautivo en alguna parte de la estación. Podrías desordenar los sistemas de control de un dron para evitar que dispare contra ti. Podrías anular los controles de una puerta para que se abra (aunque *Trastear** podría ser mejor).",
		SVStats.Helm => "Cuando *Pilotar**, pilotas un vehículo o utilizas sus armas. Podrías trazar un salto a través de un oscuro corredor del hiperespacio. Podrías zambullirte por un cañón para escapar de una nave perseguidora. Podrías disparar cuádruple láser a piratas hostiles. Podrías redirigir la energía de la nave para resistir al fuego (aunque *Trastear** podría ser mejor).",
		SVStats.Rig => "Cuando *Trasteas** mecanismos, modificas cómo funciona un mecanismo existente o creas uno nuevo.\r\nPodrías desactivar una trampa. Podrías reparar un sistema dañado de una nave. Podrías abrir una caja fuerte. Podrías sobrealimentar un motor. Podrías programar una bomba para que detone más tarde. Podrías forzar una puerta abierta (aunque *Hackear** podría ser mejor).",
		SVStats.Scramble => "Cuando *Maniobras**, levantas, trepas, saltas, corres o nadas, usualmente ya sea para alejarte o acercarte al peligro.\r\nPodrías saltar sobre un torno al escapar de las autoridades. Podrías escalar el lado de un acantilado para acercarte a una base secreta. Podrías esquivar disparos de bláster mientras cruzas el hangar para llegar a tu nave. Podrías perseguir a un objetivo que estás siguiendo (aunque *Acechar** podría ser mejor).",
		SVStats.Scrap => "Cuando *Luchas**, te enfrentas en combate cuerpo a cuerpo con la intención de dañar o neutralizar a tu oposición.\r\nPodrías pelear o luchar cuerpo a cuerpo con tu enemigo. Podrías usar un arma cuerpo a cuerpo. Podrías asaltar una barricada o mantener una posición en la batalla. Podrías abrir fuego con un bláster. Si estás utilizando un arma de vehículo o nave, deberías usar *Pilotar** en su lugar.",
		SVStats.Skulk => "Cuando *Acechas**, te mueves sigilosamente o sin ser notado. Podrías pasar desapercibido ante la seguridad o esconderte en las sombras. Podrías robar un cred-chip de un objetivo rebuscando en sus bolsillos, usando distracciones y juegos de manos. Podrías acercarte sigilosamente por detrás de alguien para atacarlo por sorpresa (pero Luchar podría ser mejor). Podrías intentar escalar por el costado de un edificio (pero Maniobrar podría ser mejor)",
		SVStats.Study => "Cuando *Estudias**, examinas detalles e interpretas evidencia.\r\nPodrías recopilar información de documentos, periódicos y libros. Podrías investigar sobre un tema esotérico. Podrías analizar detenidamente a una persona para detectar mentiras o verdaderos sentimientos. Podrías deducir la intención de una persona de matarte (pero *Sintonizar** podría ser mejor).",
		SVStats.Sway => "Cuando *Persuades**, influencias a alguien con astucia, encanto o lógica. Podrías mentir descaradamente a alguien. Podrías persuadir a un ingenuo para que te crea. Podrías discutir los hechos con un oficial. Podrías intentar engañar a las personas para que te tengan cariño u obediencia (pero *Conversar** o *Comandar** podrían ser mejores).",
		SVStats.Insight => "Perspicacia expresa el conjunto de tus aptitudes mentales",
		SVStats.Prowess => "Fisicalidad expresa el conjunto de tus aptitudes físicas",
		SVStats.Resolve => "Resolución expresa el conjunto de tus aptitudes sociales",
		_ => "Not set"
	};

	public static List<string> ExampleBuilds(this SVClasses c) => c switch
	{
		SVClasses.Mechanic => new List<string> {
			"Mecánico de naves:  Hackear +2, Maniobrar +1, Persuadir +1, *Arreglado**",
			"Genio de la informática: Hackear +2, Acechar +1, Persuadir +1, *Hacker**",
			"Constructor de droides: Hack +1, Maniobrar +1, Sintonizar +2, *Susurrador de constructos**",
			"Dueño de la nave: Pilotar +2, Luchar +1, Comandar +1, *Señor de la basura**"
		},
		SVClasses.muscle => new List<string>
		{
			"Gladiador: Maniobrar +1, Acechar +1, Comandar +1, *Cuerpo de demolición**",
			"Protector: Doctor +1, Estudiar +2, Maniobrar +1, *Guardaespaldas**",
			"Caza místicos: Sintonizar +2, Pilotar +1, Maniobrar +1, *Nacido para la batalla**",
			"Héroe de acción: Trastear +1, Pilotar +1, Maniobrar +2 *Herida superficial**",
		},
		SVClasses.mystic => new List<string>
		{
			"Guerrero vagabundo: Estudio +1, Lucha +2, Comandar +1, *Hoja Psíquica**",
			"Sanador místico: Doctor +2, Estudiar +1, Conversar +1, *Visiones**",
			"Fantasma de La Fuerza: Maniobrar +1, Acechar +2, Persuadir +1, *Cinética**",
			"Mentalista: Acechar +1, Conversar +1, Persuadir +2, *Danza psíquica**"
		},
		SVClasses.stitch => new List<string>
		{
			"Curandero: Conversar +2, persuadir +2, *Bienvenido en todas partes*",
			"Científico loco: Maniobrar +1, Sintonizar +2, Persuadir +1, *Dr. Strange**",
			"Medico de acción: Maniobrar +1, Luchar +2, Persuadir +1, *Medico de combate**",
			"Imvestogador: Estudiar +1, Acechar +1, Persuadir +2, *Aprender de los libros**"
		},
		SVClasses.pilot => new List<string>
		{
			"Busca glorias: Maniobrar +2, Luchar +1, Persuadir +1 *Exceder las expectativas**",
			"Thrillseeker: Maniobrar +2, Comandar +1, Persuadir +1 *Punch it!**",
			"Capitan: Luchar +1, Comandar +2, Conversar +1, *Comandante**",
			"Pistolero: Estudiar +1, Luchar +2, Comandar +1, **Buen ojo*"
		},
		SVClasses.scoundrel => new List<string>
		{
			"Capitan: Pilotar +2, Maniobrar +2, *nunca me digas las provabilidades**",
			"Caza reliquias: Sanar +1, Estudiar +1, Sintonizar +2, *Daredevil**",
			"Ex-detective: Sana +1, Estudiar +1, Conversar +2, *Haz preguntas luego**",
			"Veterano de las guerras: Pilotar +1, Maniobrar +1, Luchar +2, *Tenaza**",
		},
		SVClasses.speaker => new List<string>
		{
			"Susurrante: Estudiar +1, Comandar +1, Persuadir +2 *Subterfugio**",
			"Dueño de la nave: Pilotar +2, Acechar +2, persuadir +2, *Me deben favores**",
			"Espía: Hackear +1, Acechar +2, Persuadir +1, *Infiltrador**",
			"Consejero: Sanar +2, Estudiar +1, Maniobrar +1 *Corazón de corazones**"
		},
		_ => new List<string> { }
	};

	public static SVMoveIDs GetStartingAbility(this SVClasses c) => c switch
	{
		SVClasses.Mechanic => SVMoveIDs.Tinker,
		SVClasses.muscle => SVMoveIDs.Unstoppable,
		SVClasses.mystic => SVMoveIDs.TheWay,
		SVClasses.pilot => SVMoveIDs.AcePilot,
		SVClasses.scoundrel => SVMoveIDs.Serendipitous,
		SVClasses.speaker => SVMoveIDs.AirOfRespectability,
		SVClasses.stitch => SVMoveIDs.ImADoctorNotA,
		_ => SVMoveIDs.NotSet
	};
	
	public static List<SVMoveIDs> AvailableAbilities(this SVClasses c) => c switch
	{
		SVClasses.Mechanic => new List<SVMoveIDs> { SVMoveIDs.ConstructWhisperer, SVMoveIDs.JunkyardHunter, SVMoveIDs.Hacker, SVMoveIDs.Fixed, SVMoveIDs.MechanicsHeart, SVMoveIDs.Overclock, SVMoveIDs.Analyst  },
		SVClasses.muscle => new List<SVMoveIDs> { SVMoveIDs.WreckingCrew, SVMoveIDs.Backup, SVMoveIDs.Battleborn, SVMoveIDs.Bodyguard, SVMoveIDs.FleshWound, SVMoveIDs.Predator, SVMoveIDs.ReadyForAnything, SVMoveIDs.Scary, },
		SVClasses.mystic => new List<SVMoveIDs> { SVMoveIDs.Kinetics, SVMoveIDs.PsyBlade, SVMoveIDs.Center, SVMoveIDs.WayShield, SVMoveIDs.Warded, SVMoveIDs.PsyDancing, SVMoveIDs.Visions, SVMoveIDs.Sundering },
		SVClasses.pilot => new List<SVMoveIDs> { SVMoveIDs.KeenEye, SVMoveIDs.SideJob, SVMoveIDs.ExceedSpecs, SVMoveIDs.LeafOnTheWind, SVMoveIDs.Hedonist, SVMoveIDs.Commander, SVMoveIDs.Traveler, SVMoveIDs.PunchIt },
		SVClasses.scoundrel => new List<SVMoveIDs> {SVMoveIDs.NeverTellMeTheOdds, SVMoveIDs.IKnowAGuy, SVMoveIDs.Tenacious, SVMoveIDs.WhenTheChipsAreDown, SVMoveIDs.DevilsOwnLuck, SVMoveIDs.Daredevil, SVMoveIDs.ShootFirst, SVMoveIDs.AskQuestionsLater },
		SVClasses.speaker => new List<SVMoveIDs> { SVMoveIDs.FavorsOwed, SVMoveIDs.Player, SVMoveIDs.Infiltrator, SVMoveIDs.Subterfuge, SVMoveIDs.HeartToHeart, SVMoveIDs.OldFriends, SVMoveIDs.Disarming, SVMoveIDs.Purpose },
		SVClasses.stitch => new List<SVMoveIDs> { SVMoveIDs.Physicker, SVMoveIDs.Patch, SVMoveIDs.WelcomeAnywhere, SVMoveIDs.UnderPressure, SVMoveIDs.CombatMedic, SVMoveIDs.MoralCompass, SVMoveIDs.DrStrange, SVMoveIDs.BookLearning },
		_ => new List<SVMoveIDs> { }
	};

	public static List<SVItemIDs> AvailableItems(this SVClasses c) => c switch
	{
		SVClasses.Mechanic => new List<SVItemIDs> { SVItemIDs.FineHackingRig, SVItemIDs.FineShipRepairTools, SVItemIDs.GeniusPet, SVItemIDs.SpareParts, SVItemIDs.VisionEnhancingGoggles, SVItemIDs.SmallDrone  },
		SVClasses.muscle => new List<SVItemIDs> { SVItemIDs.Krieger, SVItemIDs.Vera, SVItemIDs.Zmei, SVItemIDs.Sunder, SVItemIDs.Zarathustra, SVItemIDs.FineMartialArtsStyle, SVItemIDs.MysticAmmunition},
		SVClasses.mystic => new List<SVItemIDs> { SVItemIDs.FineMeleeWeapon, SVItemIDs.Offerings, SVItemIDs.TrappingsOfReligion, SVItemIDs.OutdatedReligiousOutfit, SVItemIDs.MementoOfYourTravels, SVItemIDs.PrecursorArtifact },
		SVClasses.pilot => new List<SVItemIDs> { SVItemIDs.FineCustomizedSpacesuit, SVItemIDs.FineSmallUrbot, SVItemIDs.FineMechanicsKit, SVItemIDs.GrapplingHook, SVItemIDs.GuildLicense, SVItemIDs.VictoryCigars, },
		SVClasses.scoundrel => new List<SVItemIDs> { SVItemIDs.MysticAmmunition, SVItemIDs.FineBlasterPistol, SVItemIDs.FineBlasterPistolPair, SVItemIDs.FineCoat, SVItemIDs.LoadedDice, SVItemIDs.ForgedDocuments, SVItemIDs.PersonalMemento, },
		SVClasses.speaker => new List<SVItemIDs> { SVItemIDs.FineClothes, SVItemIDs.LegitimateID, SVItemIDs.LuxuryItemSmall, SVItemIDs.LuxuryItemMedium, SVItemIDs.LuxuryItemLarge, SVItemIDs.MementoOfPastEncounter, },
		SVClasses.stitch => new List<SVItemIDs> { SVItemIDs.FineBlasterPistolPair, SVItemIDs.FineMedkit, SVItemIDs.FineBedsideManner, SVItemIDs.FineClothing, SVItemIDs.RecognizableMedicGarb, SVItemIDs.CandiesAndTreats, SVItemIDs.SyringesAndApplicators, },
		_ => new List<SVItemIDs> { }
	};

	public static string ToUI(this Heritages heritage) => heritage switch
	{
		Heritages.Imperial => "Imperial",
		Heritages.Spacer => "Espacial",
		Heritages.Colonist => "Colono",
		Heritages.Manufactured => "Manufacturado",
		Heritages.Wanderer => "Nómada",
		Heritages.Xeno => "Xeno",
		Heritages.NotSet => "---",
		_ => ""
	};
	public static string GetDescription(this Heritages heritage) => heritage switch
	{
		Heritages.Imperial => "Aquellos con herencia imperial provienen de Warren o de los mundos del Núcleo. Fuiste educado en las formas de la Hegemonía, ya sea a través de una educación vocacional de la Guilda, las enseñanzas del Culto o los tutores de una familia noble.",
		Heritages.Spacer => "Si prefieres sentirte más en casa en una nave chirriante, podrías venir de una familia de espaciales. Mineros de hielo, mecánicos de estaciones y la mayoría de los comerciantes nacen, envejecen y mueren en el espacio, y pueden o no ver tus aventuras terrestres con sospecha.",
		Heritages.Colonist => "Las familias coloniales son todo lo contrario. Agricultores, mineros y terraformadores forman la columna vertebral de la Hegemonía. Luchando por sobrevivir en los bordes de los planetas, estos individuos enfrentan bestias alienígenas y extrañas ruinas de los Precursores más que nadie.",
		Heritages.Manufactured => "Las \"familias\" manufacturadas están fundamentalmente controladas de alguna manera por los gremios. Por ejemplo, un clon Yaru que ha escapado de una instalación o un Droide que ha evitado los borrados de memoria rutinarios. A menudo, debes ocultar tu origen e independencia.",
		Heritages.Wanderer => "Si prefieres no tener un planeta al que llamar hogar, podrías provenir de una herencia nómada. Una pequeña pero notable porción de la Hegemonía se mueve de planeta en planeta, conforme surgen oportunidades y cambian los ciclos económicos galácticos. O simplemente siguen a donde la Fuerza los lleva.",
		Heritages.Xeno => "Las familias xeno son tan diversas como las innumerables especies de xenos en la galaxia. Fuiste criado en una cultura no humana. Los xenos luchan por encontrar aceptación en la Hegemonía, y muchas de sus prácticas son vistas como extrañas o inusuales.",
		_ => ""
	};

	public static string ToUI(this Backgrounds background) => background switch
	{
		Backgrounds.Academic => "Académico",
		Backgrounds.Labor => "Obrero",
		Backgrounds.Cult => "Cultista",
		Backgrounds.Guilder => "Gremio",
		Backgrounds.Military => "Militar",
		Backgrounds.Noble => "Noble",
		Backgrounds.Syndicate => "Sindicato",
        Backgrounds.NotSet => "---",
		_ => "--"
	};
	public static string GetDescription(this Backgrounds background) => background switch
	{
		Backgrounds.Academic => "Un profesor, estudiante, investigador u otra vocación impulsada por el conocimiento.",
		Backgrounds.Labor => "Un trabajador de fábrica, conductor, estibador, minero u otro trabajador. La mayoría de la Hegemonía tiene este origen.",
		Backgrounds.Cult => "Parte de un Culto, sancionado oficialmente o no. Un guerrero santo, sacerdote o devoto religioso.",
		Backgrounds.Guilder => "Involucrado en las maquinaciones de un Gremio, como un diseñador de naves, analista financiero o oficial de logística.",
		Backgrounds.Military => "Un soldado de la Hegemonía, mercenario, operativo de inteligencia, estratega, instructor de entrenamiento, etc.",
		Backgrounds.Noble => "Viviendo la vida de lujo, como un diletante, alguien atrapado en la política de las Casas, etc.",
		Backgrounds.Syndicate => "Parte de una banda criminal organizada, desde el vigilante más bajo hasta un antiguo señor del crimen derrocado.",
		_ => "--"
	};
	public static string ToUI(this Vices vice) => vice switch
	{
		Vices.Faith => "Fe",
		Vices.Gambling => "Juego",
		Vices.Luxury => "Lujo",
		Vices.Obligation => "Obligación",
		Vices.Pleasure => "Placer",
		Vices.Stupor => "Estupor",
		Vices.Weird => "Extraño",
		Vices.NotSet => "---",
		_ => ""
	};
	public static string GetDescription(this Vices vice) => vice switch
	{
		Vices.Faith => "Eres parte de un Culto, o sigues ceremonias específicas a intervalos regulares.",
		Vices.Gambling => "Anhelas los juegos de azar, o apuestas en eventos deportivos, etc.",
		Vices.Luxury => "Buscas la vida alta con despliegues ostentosos y costosos de riqueza.",
		Vices.Obligation => "Estás dedicado a una familia, causa, organización, caridad, etc.",
		Vices.Pleasure => "Buscas gratificación hedonista de amantes, comida, bebida, drogas, arte, etc.",
		Vices.Stupor => "Entumeces los sentidos con abuso de drogas, bebida excesiva, peleas hasta la extenuación, etc.",
		Vices.Weird => "Realizas experimentos extraños, exploras la Senda, comunicas con artefactos Ur, y así sucesivamente.",
		_ => ""
	};

	public static string ToUI(this MaxLoads l) => l switch
	{
		MaxLoads.Light => "Ligero",
		MaxLoads.Normal => "Normal",
		MaxLoads.Heavy => "Pesado",
		_ => ""
	};
	public static string GetDescription(this MaxLoads l) => l switch
	{
		MaxLoads.Light => "Eres más rápido, menos llamativo; te mezclas con la gente común.",
		MaxLoads.Normal => "Pareces estar listo para problemas.",
		MaxLoads.Heavy => "Eres más lento. Pareces un sinvergüenza en una misión y listo para el peligro. Nadie te confundirá con otra cosa.",
		_ => ""
	};
	public static int GetMaxLoad(this MaxLoads l) => l switch
	{
		MaxLoads.Light => 3,
		MaxLoads.Normal => 5,
		MaxLoads.Heavy => 8,
		_ => 8
	};

	public static string ToUI(this Traumas t) => t switch
	{
		Traumas.NoTrauma => " - ",
		Traumas.Cold => "Helado",
		Traumas.haunted => "Atormentado",
		Traumas.Obsessed => "Obsesionado",
		Traumas.Paranoid => "Paranoia",
		Traumas.Reckless => "Temerario",
		Traumas.Soft => "Blando",
		Traumas.Unstable => "Volátil",
		Traumas.Vicious => "Perverso",
		_ => ""
	};
	public static string ToDescription(this Traumas t) => t switch
	{
		Traumas.NoTrauma => "Todo está en orden ... de momento ...",
		Traumas.Cold => "No te conmueven los llamamientos emocionales ni los lazos sociales.",
		Traumas.haunted => "A menudo te pierdes en ensoñaciones, reviviendo horrores pasados, viendo cosas de tu pasado o que otros pueden no ver.",
		Traumas.Obsessed => "Estás cautivado por una sola cosa: una actividad, una persona, un objetivo, una ideología.",
		Traumas.Paranoid => "Imaginas peligro en todas partes; no puedes confiar en los demás.",
		Traumas.Reckless => "Tienes poco respeto por tu propia seguridad, intereses o bienestar.",
		Traumas.Soft => "Pierdes tu agudeza; te vuelves sentimental, pasivo, amable.",
		Traumas.Unstable => "Tu estado emocional es volátil. Puedes enfurecerte instantáneamente, caer en la desesperación, actuar impulsivamente o quedarte paralizado.",
		Traumas.Vicious => "Buscas oportunidades para herir a las personas, incluso sin motivo aparente.",
		_ => ""
	};
}
