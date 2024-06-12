using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public class SVMove : BaseMove<SVMoveIDs, SVStats>
{
	public SVMove(SVMoveIDs ID, SVStats stat) : base(ID, stat) {
		
	}

	public string Description { get; set; } = string.Empty;
	public string Details { get; set; } = string.Empty;

	public override bool HasRoll()
	{
		return false;
	}

	public override string ToUI()
	{
		return Roll.ToUI();
	}
}

public class SVMovesService : MovesServiceBase
{

	public List<SVMove> AllMoves = new List<SVMove> {
		new SVMove(SVMoveIDs.Tinker, SVStats.NotSet)
		{
			Title = "Manitas",
			Description =  "Cuando trabajas en un mecanismo con *Trastear** o *Hackear** o cuando *Estudias** unos planos, llena +1 segmento",
			Details = "Obtienes este segmento extra sin importar si es una actividad de 'tiempo libre' o no. Esto quire decir que superar seguridad en un trabajo o hacer un arreglo rápido mientras escapamos es más fácil para tí que para cualquier otro."
		},
		new SVMove(SVMoveIDs.BailandoWireAndMechTape, SVStats.NotSet)
		{
			Title = "Cinta americana y tres en uno",
			Description = "Obtienes una actividad extra durante el tiempo libre para reparar, y la actividad de reparación no te cuesta NADA DE CRÉDITOS.",
			Details = "La actividad de reparación normalmente cuesta 1 CRÉDITO. Con esta habilidad, puedes realizar la actividad sin costo alguno de CRÉDITOS. Las reparaciones gratuitas no se pueden 'acumular'. Obtienes una por cada periodo de tiempo libre."
		},
		new SVMove(SVMoveIDs.ConstructWhisperer, SVStats.NotSet)
		{
			Title = "Susurrador de Constructos",
			Description = "Las máquinas te hablan cuando las *Estudias**. La primera vez que sacas un crítico mientras reparas o construyes una máquina en particular, puedes agregarle una modificación simple (ver Creación, página 282).",
			Details = "¿Cómo te susurran las máquinas sus secretos? ¿Es intuitivo? ¿Sientes lo que sienten ellas? No obtienes la modificación si mejoras el resultado con CRÉDITOS."
		},
		new SVMove(SVMoveIDs.JunkyardHunter, SVStats.NotSet)
		{
			Title = "Señor de la basura",
			Description = "Cuando adquieres piezas o equipos durante el tiempo libre, puedes obtener dos activos o un activo de calidad +1.",
			Details = "Tus contactos en el desguace pueden conseguir lo que necesitas restaurado o en oferta especial. Si obtienes dos activos, ambos tienen la misma calidad que tu tirada."
		},
		new SVMove(SVMoveIDs.Hacker, SVStats.NotSet)
		{
			Title = "Pirata Informático",
			Description = "Puedes gastar tu armadura especial para resistir las consecuencias de *Hackear**, o para potenciarte cuando hackeas o recopilas información electrónicamente.",
			Details = "Cuando uses esta habilidad, marca la casilla de armadura especial en tu hoja de personaje. Si usas esta habilidad para potenciarte, obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de una lesión grave), pero no recibes 2 puntos de estrés. Tu armadura especial se restaura cuando seleccionas tu equipo al comienzo de un trabajo."
		},
		new SVMove(SVMoveIDs.Fixed, SVStats.NotSet)
		{
			Title = "Arreglado",
			Description = "Puedes gastar tu armadura especial para resistir una consecuencia cuando las máquinas se rompen o se dañan, o para potenciarte al reparar o construir una máquina.",
			Details = "Cuando uses esta habilidad, marca la casilla de armadura especial en tu hoja de personaje. Las máquinas pueden incluir tu nave, así que puedes usar esto como armadura especial para tu nave si estás a bordo lidiando con el daño. Si usas esta habilidad para potenciarte, obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de una lesión grave), pero no recibes 2 puntos de estrés. Tu armadura especial se restaura cuando seleccionas tu equipo al comienzo de un trabajo."
		},
		new SVMove(SVMoveIDs.MechanicsHeart, SVStats.NotSet)
		{
			Title = "Corazón de Mecánico",
			Description = "Cuando hablas desde el corazón, tus palabras pueden llegar incluso al criminal más endurecido, y ganas potencia.",
			Details = "Esta habilidad funciona en todas las situaciones sin restricciones. Mientras hables genuina y sinceramente, tus palabras serán escuchadas."
		},
		new SVMove(SVMoveIDs.Overclock, SVStats.NotSet)
		{
			Title = "Sobrecarga",
			Description = "Cuando gastas un gambito en una tirada de *Trastear** para reparar o mejorar, trata el sistema en el que trabajaste como si tuviera 1 calidad más alta durante el resto del trabajo.",
			Details = "Puedes hacer una tirada de *Trastear** durante un trabajo simplemente para obtener más de un sistema, pero tales mejoras temporales son solo situacionales y deben deshacerse la próxima vez que vayas al dique seco. Puedes hacer overclock a sistemas que no sean naves, mejorando la calidad del sistema."
		},
		new SVMove(SVMoveIDs.Analyst, SVStats.NotSet)
		{
			Title = "Analista",
			Description = "Cuando *HACKEAS** un sistema, también puedes hacer una pregunta sobre el propietario o la ubicación del sistema como si hubieras sacado un 6 en recopilar información. Cuando resistes las consecuencias de HACKEAR, tira +1d. Independientemente del propósito para el que estés HACKEANDO, aprendes algo sobre los sistemas que estás manipulando. Si estabas recopilando información, puedes tirar para aprender una segunda cosa, o simplemente aceptar el 6 para lo que querías saber.",
			Details = "A veces, los números pueden decirte más de lo que piensas, ¿verdad? ¡Ahora tu análisis te llevará más allá de lo esperado!"
		},
		new SVMove(SVMoveIDs.Unstoppable, SVStats.NotSet)
		{
			Title = "Imparable",
			Description = "Puedes *potenciarte** para hacer una de las siguientes acciones: realizar un acto de fuerza física que roce lo sobrehumano, o enfrentarte a una pequeña pandilla en igualdad de condiciones en combate cuerpo a cuerpo.",
			Details = "Cuando *te potencias** para activar esta habilidad, aún obtienes uno de los beneficios normales de potenciarte (+1d, +1 efecto, etc.) además de la habilidad especial.\n\n Un acto sobrehumano es uno que una persona común no podría hacer sin ayuda, como romper esposas de metal. Si te enfrentas a una pequeña pandilla en igualdad de condiciones, tienes igual escala."
		},
		new SVMove(SVMoveIDs.WreckingCrew, SVStats.NotSet)
		{
			Title = "Cuerpo de demolición",
			Description = "Tu fuerza y ferocidad son infames. Cuando golpeas en combate cuerpo a cuerpo, obtienes +1d. Siempre que gastes un gambito en combate, también obtienes +1 efecto en esa acción.",
			Details = "Ya seas un maestro de artes marciales, o criado por místicos para luchar con armas antiguas, tu destreza marcial en combate cuerpo a cuerpo es legendaria (y puede atraer a aquellos que deseen aprender de ti o desafiarte). Si gastas un gambito en combate, toma +1 efecto en esa acción."
		},
		new SVMove(SVMoveIDs.Backup, SVStats.NotSet)
		{
			Title = "Respaldo",
			Description = "El empuje de un aliado cuesta 1 estrés (no 2) en cualquier acción que prepares o asistas. Las acciones de preparación y asistencia (ver página 158) aún otorgan sus dados o efecto de bonificación como de costumbre.",
			Details = ""
		},
		new SVMove(SVMoveIDs.Battleborn, SVStats.NotSet)
		{
			Title = "Nacido en Batalla",
			Description = "Puedes gastar tu armadura especial para reducir el daño de un ataque en combate, o para potenciarte durante una pelea.",
			Details = "Cuando uses esta habilidad, marca la casilla de armadura especial en tu hoja de personaje. \"Reducir el daño\" significa reducir el daño en un nivel. Si usas esta habilidad para potenciarte, obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de una lesión grave) pero no recibes 2 puntos de estrés. Tu armadura especial se restaura cuando seleccionas tu equipo al comienzo de un trabajo."
		},
		new SVMove(SVMoveIDs.Bodyguard, SVStats.NotSet)
		{
			Title = "Guardaespaldas",
			Description = "Cuando *proteges** a un compañero de tripulación, *resiste** con *+1d**. Cuando recibes *daño**, elimina *1 estrés**.",
			Details = "La maniobra de equipo 'proteger' (ver página 158) te permite enfrentar una consecuencia por un compañero de equipo."
		},
		new SVMove(SVMoveIDs.FleshWound, SVStats.NotSet)
		{
			Title = "Herida Superficial",
			Description = "Si estás herido al comienzo del tiempo libre, marca *+3 segmentos** en tu reloj de curación. Cuando te *potencias** para ignorar las penalizaciones de heridas, solo cuesta *1 estrés** (no 2). ",
			Details = "Ya sea naturalmente resistente o mejorado de alguna manera, las heridas no te mantienen abajo. Ver Recuperar en la página 187 para más información."
		},
		new SVMove(SVMoveIDs.Predator, SVStats.NotSet)
		{
			Title = "Depredador",
			Description = "Toma *+1d** en tiradas contra objetivos debilitados o vulnerables. Siempre que *recopiles información** sobre una debilidad o vulnerabilidad, lo peor que puedes obtener es un resultado de *4/5**. ",
			Details = "Sabes cómo aprovechar el miedo, el dolor y la vulnerabilidad para salirte con la tuya. Cuando intentas averiguar tales cosas en una persona, generalmente descubres algo, incluso si la información no es inmediatamente útil o está incompleta. Alguien en un estado vulnerable podría estar drogado, confiado, gravemente herido o asustado."
		},
		new SVMove(SVMoveIDs.ReadyForAnything, SVStats.NotSet)
		{
			Title = "Listo para Cualquier Cosa",
			Description = "Cuando te están emboscando, ganas *potencia** en todas las acciones durante un flashback, y tu primer flashback cuesta *0 estrés**. ",
			Details = "Siempre esperas emboscadas y te preparas para ellas. Retrocede a tal preparación cuando ocurra una emboscada. Si tu preparación requiere tiradas de acción, obtienes potencia en ellas."
		},
		new SVMove(SVMoveIDs.Scary, SVStats.NotSet)
		{
			Title = "Atemorizante",
			Description = "Tienes un aire de amenaza y peligro obvio incluso para el más descuidado. Obtienes *potencia** cuando intentas intimidar a alguien. Si se hace inmediatamente después de una demostración de fuerza, también toma *+1d**. ",
			Details = "Infundes miedo en los que te rodean, especialmente cuando te vuelves violento. Cómo reaccionen depende de ellos. Algunos huirán de ti, algunos estarán impresionados, algunos se volverán violentos a cambio. El GM juzga la respuesta de un NPC dado. La intimidación generalmente se maneja con una tirada de COMANDO, y tus esfuerzos para hacerlo son más exitosos si muestras que te estás tomando en serio."
		},
		new SVMove(SVMoveIDs.TheWay, SVStats.NotSet)
		{
			Title = "La Fuerza",
			Description = "Puedes gastar un gambito en lugar de pagar cualquier costo de estrés.",
			Details = "Cada vez que necesites gastar estrés, puedes gastar un gambito en su lugar. Esto incluye resistencias y costos de empuje.\nPara habilidades que tienen un costo variable, como Desgarrar, esos costos adicionales son todos parte de la misma activación, por lo que el empuje y todas las características adicionales juntas solo cuestan un gambito."
		},
		 new SVMove(SVMoveIDs.Kinetics, SVStats.NotSet)
		{
			Title = "Cinetica",
			Description = "Puedes *empujarte a ti** mismo para hacer una de las siguientes: usar La Fuerza para lanzar un objeto del tamaño de una mesa con fuerza peligrosa, o impulsarte brevemente con velocidad sobrehumana.",
			Details = "Fuerza peligrosa significa lo suficientemente rápida como para herir gravemente a una persona normal. Velocidad sobrehumana significa lo suficientemente rápida como para ser apenas más que una mancha borrosa. Tu alcance es aproximadamente el tamaño de una gran sala. Sí, las personas pueden contar como objetos."
		},
		new SVMove(SVMoveIDs.PsyBlade, SVStats.NotSet)
		{
			Title = "Hoja Psíquica",
			Description = "Puedes enfocar la energía de La Fuerza en tu arma cuerpo a cuerpo. Mientras esté cargada, el arma puede cortar materiales no blindados con facilidad, y ganas *potencia** en tus ataques cuerpo a cuerpo.",
			Details = "Las placas de metal pesado no están blindadas, por lo que puedes cortar la mayoría de las puertas sin problemas. Los constructos blindados son raros, pero ofrecen suficiente protección para que este ataque pierda su potencia. No puedes infundir tus puños con la energía de La Fuerza (ni guantes, nudillos de bronce, etc.)."
		},
		new SVMove(SVMoveIDs.Center, SVStats.NotSet)
		{
			Title = "Centro",
			Description = "Ganas 'Meditación' como un *vicio**. Cuando te entregas a este vicio, eliminas *+1 estrés** y agregas Visiones Oscuras como una posible *sobreindulgencia.**",
			Details = "La contemplación del universo no está exenta de peligros. Cuando eliges Visiones Oscuras como una sobreindulgencia, La Fuerza te muestra a un ser querido, contacto o amigo en gran peligro."
		},
		new SVMove(SVMoveIDs.WayShield, SVStats.NotSet)
		{
			Title = "Escudo de La Fuerza",
			Description = "Puedes bloquear rayos láser con La Fuerza (resiste con *resolución**). Si resistes un ataque de láser, puedes gastar *1 estrés** para redirigir el fuego y hacer un ataque propio con él.",
			Details = "Resistir rayos láser de esta manera generalmente reduce el daño a cero."
		},
		new SVMove(SVMoveIDs.Warded, SVStats.NotSet)
		{
			Title = "Protegido",
			Description = "Puedes gastar tu *armadura especial** para resistir las consecuencias de un ataque de La Fuerza o el uso de un artefacto, o *empujarte a ti mismo** cuando uses poderes místicos.",
			Details = "Cuando uses esta habilidad, marca la casilla de armadura especial en tu hoja de personaje. Si usas esta habilidad para *empujarte**, obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de un daño severo) pero no tomas 2 de estrés. Tu armadura especial se restaura cuando seleccionas tu carga al comienzo de un trabajo."
		},
		new SVMove(SVMoveIDs.PsyDancing, SVStats.NotSet)
		{
			Title = "Danza Psíquica",
			Description = "Puedes *empujarte a ti mismo** para nublar la mente de un objetivo y *persuadirlo** a pesar de la evidencia contradictoria. “Debes hacer lo que digo. Soy el embajador.” Gasta *1 estrés** por cada característica adicional: tienen solo vagos recuerdos del evento, funciona en un pequeño grupo.",
			Details = "Estas confusiones no persisten indefinidamente, aunque aquellos con recuerdos vagos a menudo llenan los detalles faltantes con suposiciones. “Debí haber verificado su identificación. Siempre lo hago.”"
		},
		new SVMove(SVMoveIDs.Visions, SVStats.NotSet)
		{
			Title = "Visiones",
			Description = "Gasta *1 estrés** para ver a distancia un lugar o persona lejanos vinculados a ti de manera íntima. Gasta *1 estrés** por cada característica adicional: dura un minuto en lugar de un momento, tu objetivo también puede verte y oírte, puedes ver algo solo familiar para ti, no íntimo.",
			Details = "Gastar un gambito con tu habilidad inicial (“La Fuerza”) cubre todos los costos. Cuando tu objetivo también puede verte y oírte, ambos están dentro de la misma “área”, para propósitos de otras habilidades."
		},
		new SVMove(SVMoveIDs.Sundering, SVStats.NotSet)
		{
			Title = "Desgarrar",
			Description = "Puedes *empujarte a ti mismo** para *sintonizarte** con La Fuerza y retorcerla, causando daño psíquico a cualquiera en el área vulnerable a tu asalto. Puedes gastar *1 estrés** por cada característica adicional: daña en lugar de aturdir, tú y cualquiera que elijas obtienen +2d para resistir los efectos.",
			Details = "Deformas La Fuerza dentro de ti y, por extensión, deformas La Fuerza en otros, una proposición arriesgada en el mejor de los casos. Desgarrar no puede dañar objetos inanimados. Al causar daño, los síntomas pueden incluir convulsiones a corto plazo y vasos sanguíneos rotos. Aquellos especialmente entrenados para resistir ataques psíquicos o de alguna manera protegidos pueden reducir tu efecto."
		},
		new SVMove(SVMoveIDs.AcePilot, SVStats.NotSet)
		{
			Title = "Piloto experto",
			Description = "Tienes *potencia** en todas las tiradas relacionados con la velocidad. Cuando tires para *resistir** las consecuencias de pilotar, obtén *+1**d.",
			Details = "Tu efectividad podría ser contrarrestada por su mejor calidad (si, por ejemplo, los motores de su nave son mejores que los tuyos). Recuerda que las consecuencias de pilotar no siempre son daños a la nave, pero a menudo se pueden resistir de igual manera."
		},
		new SVMove(SVMoveIDs.KeenEye, SVStats.NotSet)
		{
			Title = "Buen ojo",
			Description = "Tienes una vista aguda y notas pequeños detalles que muchos podrían pasar por alto. Obtienes *+1d** al disparar armas de nave o hacer tiros ingeniosos.",
			Details = "Esto se puede usar como base para *tiradas de resistencia** para actuar primero.\"No, quiero actuar antes que él, lo habría visto alcanzar el arma.\" Además, los tiros ingeniosos se pueden realizar con casi cualquier tipo de arma de largo alcance, no solo con armas de nave."
		},

		new SVMove(SVMoveIDs.SideJob, SVStats.NotSet)
		{
			Title = "Trabajo Secundario",
			Description = "Puedes pasar una actividad en puerto haciendo trabajos extraños. Ganas *1 crédito**. Si hay rumores flotando, el GM te informará de ellos.",
			Details = "Es posible que no haya rumores flotando, pero el GM debería tratar esto como una tirada para obtener información, donde sacas un *6** para enterarte de lo que está en las noticias y chismes en ese puerto."
		},

		new SVMove(SVMoveIDs.ExceedSpecs, SVStats.NotSet)
		{
			Title = "Exceder Especificaciones",
			Description = "Mientras estés a bordo de una nave, puedes dañar un sistema de la nave al que tengas acceso para obtener *+1d** o *+1 efecto** en una tirada.",
			Details = "Sobrecarga un sistema para obtener un impulso a corto plazo. La calidad del sistema sigue siendo la misma para la única tirada que estás mejorando. Después de la tirada, el sistema se quema y la calidad se reduce."
		},

		new SVMove(SVMoveIDs.LeafOnTheWind, SVStats.NotSet)
		{
			Title = "Hoja en el Viento",
			Description = "Cuando te *exprimes a ti mismo**, puedes gastar *+1 estrés** (3 estrés en total) para obtener tanto *+1 efecto** como *+1d** en lugar de uno u otro.",
			Details = "Normalmente se necesitan dos impulsos separados (4 estrés en total) para lograr el mismo efecto. Esto se puede usar en cualquier tirada."
		},

		new SVMove(SVMoveIDs.Hedonist, SVStats.NotSet)
		{
			Title = "Hedonista",
			Description = "Cuando te entregas a tu *vicio**, puedes ajustar el resultado de los dados en +/-2. Un aliado que se una a ti puede hacer lo mismo.",
			Details = "Cualquier aliado debe unirse a ti en el vicio en el que te estás entregando (o puedes hacerlo a través de una habilidad de la tripulación, como la Cocina Casera del Stardancer). Puedes ajustar el resultado por menos de 2, o no ajustarlo en absoluto."
		},

		new SVMove(SVMoveIDs.Commander, SVStats.NotSet)
		{
			Title = "Comandante",
			Description = "Siempre que lideres una acción grupal, ganas *+1 escala**. Si *lideras** una acción grupal en combate, puedes contar *varios 6** de diferentes tiradas como un *crítico**.",
			Details = "Si ya tienes escala sobre tu oponente, ganas una escala adicional (y, por lo tanto, un nivel de efecto adicional). Si dos o más jugadores sacan un 6, entonces el resultado de la tirada para todos es un crítico."
		},

		new SVMove(SVMoveIDs.Traveler, SVStats.NotSet)
		{
			Title = "Viajero",
			Description = "Te sientes cómodo con culturas xenos inusuales. Obtienes *potencia** cuando intentas *Conversar* o *Persuadirlos**.",
			Details = "Esta habilidad representa una amplia gama de experiencias y comprensión. Ya sea que parezcas profundamente respetuoso o simplemente sepas qué botones presionar, eres más efectivo de lo que se esperaría."
		},

		new SVMove(SVMoveIDs.PunchIt, SVStats.NotSet)
		{
			Title = "¡Dale Caña!",
			Description = "Cuando gastas un *gambito** en una tirada *desesperada**, cuenta como *arriesgada** en su lugar.",
			Details = "Debido a que gastaste un gambito en la tirada, aunque cuente como arriesgada, la tirada en sí misma puede no generar un gambito (a menos que tengas otra habilidad que diga que puede)."
		},
		new SVMove(SVMoveIDs.ImADoctorNotA, SVStats.NotSet)
		{
			Title = "Soy un doctor, no un...",
			Description = "Puedes *esforzarte** para tirar *Sanar** mientras realizas una acción diferente. Indica qué paciente, investigación o puesto te enseñó este truco.",
			Details = "Cada vez que usas esta habilidad, aprendemos un poco más sobre tu pasado. Considera presentar a tus contactos en estos descubrimientos, si es apropiado."
		},
		new SVMove(SVMoveIDs.Physicker, SVStats.NotSet)
		{
			Title = "Doctor",
			Description = "Puedes *estudiar** una enfermedad, heridas o un cadáver, y *recopilar información** de una escena del crimen. Además, tu tripulación obtiene *+1d** en *tiradas de recuperación**. Esta habilidad a menudo representa una formación formal, que te brinda una manera de entender forensemente un cadáver o deconstruir científicamente una enfermedad. El bono a la recuperación para tu tripulación solo se aplica si ayudas a tratar heridas o lesiones en algún momento durante la recuperación.",
			Details = "Esta habilidad a menudo representa una formación formal, que te brinda una manera de entender forensemente un cadáver o deconstruir científicamente una enfermedad. El bono a la recuperación para tu tripulación solo se aplica si ayudas a tratar heridas o lesiones en algún momento durante la recuperación."
		},
		new SVMove(SVMoveIDs.Patch, SVStats.NotSet)
		{
			Title = "Parche",
			Description = "Puedes *Sanar** a alguien durante una misión para permitirles ignorar los efectos de una penalización por *daño**. Un éxito en la tirada dura toda la misión. Si bien tu paciente puede ignorar los efectos de la penalización por daño, no la elimina; todavía hay menos casillas para heridas adicionales.",
			Details = "Un éxito en la tirada dura toda la misión. Si bien tu paciente puede ignorar los efectos de la penalización por daño, no la elimina; todavía hay menos casillas para heridas adicionales."
		},
		new SVMove(SVMoveIDs.WelcomeAnywhere, SVStats.NotSet)
		{
			Title = "Bienvenido en cualquier lugar",
			Description = "Mientras uses tu uniforme de médico, eres bienvenido incluso en lugares peligrosos. Obtienes *+1d** para *conversar** y *persuadir** cuando ofreces ayudar a cualquier persona necesitada.",
			Details = "Cuando elijas estar, eres reconocible como médico y de valor para aquellos que viven la dura vida de Procyon."
		},
		new SVMove(SVMoveIDs.UnderPressure, SVStats.NotSet)
		{
			Title = "Bajo presión",
			Description = "Agrega un *gambito** al grupo cada vez que tú o un miembro de la tripulación sufra un daño de nivel 2 o superior.",
			Details = "En orden para obtener el comodín, la consecuencia aplicada resultante debe ser de nivel 2 o superior. Si se resiste o se reduce por debajo de ese nivel, no ganas el comodín."
		},
		new SVMove(SVMoveIDs.CombatMedic, SVStats.NotSet)
		{
			Title = "Médico de combate",
			Description = "Puedes usar tu *armadura especial** para resistir cualquier consecuencia mientras atiendes a un paciente. Cuando *Sanas** a alguien en combate, eliminas *1 estrés.**",
			Details = "Cuando uses esta habilidad, marca la casilla de armadura especial en tu hoja de personaje. Cuando resistes consecuencias, pueden ser para ti, como resultado de uno de tus lanzamientos, o para proteger al paciente. Tu armadura especial se restaura cuando seleccionas tu carga al inicio de una misión."
		},
		new SVMove(SVMoveIDs.MoralCompass, SVStats.NotSet)
		{
			Title = "Brújula moral",
			Description = "Cuando haces lo correcto a costa de ti mismo, marca *xp** (cualquier categoría).",
			Details = "El costo para ti mismo debe ser real, aunque no necesariamente devastador. Perder una oportunidad significativa, experimentar un contratiempo con un proyecto o meterse en una discusión acalorada con un amigo podrían contar."
		},
		new SVMove(SVMoveIDs.DrStrange, SVStats.NotSet)
		{
			Title = "Dr. Strange",
			Description = "Tus investigaciones y campos de estudio son marginales, esotéricos y se centran en lo místico. Siempre puedes manipular artefactos de Precursores de manera segura. Cuando estudias un artefacto o atiendes una sustancia extraña, puedes hacer una pregunta: ¿qué podría hacer esto?—¿por qué podría ser peligroso?",
			Details = "Normalmente haría falta una tirada de *Sintonizar** para manejar un artefacto precursor de manera segura. Cuando haces tu pregunta, puedes hacerlo además de cualquier otra cosa que estuvieras haciendo con el artefacto o substancia. Trata esto como una tirada de reunir información donde sacaste un 6."
		},
		new SVMove(SVMoveIDs.BookLearning, SVStats.NotSet)
		{
			Title = "Aprendizaje del libro",
			Description = "Hablas una multitud de idiomas y estás ampliamente educado. Obtienes *+1d** al usar *estudiar** durante una actividad de *tiempo libre**.",
			Details = "La comunicación casi nunca es un problema para ti. Además, tienes experiencia en casi todas las materias académicas que puedan surgir y puedes usar las tiradas de reunir información para descubrir que aprendiste en tus estudios",
		},
		new SVMove(SVMoveIDs.AirOfRespectability, SVStats.NotSet)
		{
			Title = "Aire de respetabilidad",
			Description = "Obtienes una actividad adicional de *tiempo libre** para *adquirir activos** o *pasar desapercibido**. Tus conexiones te proporcionan un flujo continuo de material y personas que puedes usar para calmar las cosas después de tus escapadas.",
			Details = "Tus conexiones te proporcionan un flujo continuo de material y personas que puedes usar para calmar las cosas después de tus escapadas."
		},
		new SVMove(SVMoveIDs.FavorsOwed, SVStats.NotSet)
		{
			Title = "Favores adeudados",
			Description = "Durante el tiempo libre, obtienes *+1d** cuando *adquieres activos** o *pasas desapercibido**. Cada vez que *reúnes información**, toma *+1d.**",
			Details = "Usando tu autoridad, conexiones o información privilegiada, obtienes mejor información y acceso a mejores recursos."
		},
		new SVMove(SVMoveIDs.Player, SVStats.NotSet)
		{
			Title = "Jugador",
			Description = "Siempre sabes cuándo alguien te está mintiendo. Esta habilidad funciona en todas las situaciones sin restricciones. Es muy poderosa, pero también un poco de maldición. Ves a través de cada mentira, incluso las amables.",
			Details = "Esta habilidad funciona en todas las situaciones sin restricciones. Es muy poderosa, pero también un poco de maldición. Ves a través de cada mentira, incluso las amables."
		},
		new SVMove(SVMoveIDs.Infiltrator, SVStats.NotSet)
		{
			Title = "Infiltrador",
			Description = "No te afecta la *calidad** o el* Tier** cuando evitas medidas de seguridad. Esta habilidad te permite enfrentarte a enemigos de mayor Tier en igualdad de condiciones.",
			Details = "Cuando hackeas un sistema de seguridad electrónico, eliges una cerradura o te escabulles entre guardias de élite, tu nivel de efecto nunca se reduce debido al Tier superior o al nivel de calidad de tu oposición."
		},
		new SVMove(SVMoveIDs.Subterfuge, SVStats.NotSet)
		{
			Title = "Subterfugio",
			Description = "Puedes gastar tu *armadura especial** para *resistir** una consecuencia de persuasión o suspicacia. Cuando *resistes* con *perspicacia**, obtienes *+1d**.",
			Details = "Folks que dudan de tus mentiras, historias, cubiertas, etc., todos cuentan a los fines de la sospecha o persuasión."
		},
		new SVMove(SVMoveIDs.HeartToHeart, SVStats.NotSet)
		{
			Title = "Corazón a corazón",
			Description = "Cuando ofreces una idea significativa o un consejo sincero que un compañero de tripulación sigue, ambos eliminan *1 estrés**.",
			Details = "Si hay una pregunta sobre qué constituye un consejo significativo o sincero, discútelo en grupo y decidan juntos."
		},
		new SVMove(SVMoveIDs.OldFriends, SVStats.NotSet)
		{
			Title = "Viejos amigos",
			Description = "Siempre que llegues a un lugar nuevo, escribe un amigo que conozcas allí (bajo Amigos influyentes en tu hoja de personaje).",
			Details = "Siempre que llegues a un lugar nuevo, escribe un amigo que conozcas allí (bajo Amigos influyentes en tu hoja de personaje)."
		},
		new SVMove(SVMoveIDs.Disarming, SVStats.NotSet)
		{
			Title = "Desarmar",
			Description = "Siempre que uses un *gambito** al hablar, las hostilidades y el peligro también se detienen mientras hablas.",
			Details = "Aún ganas +1d para cualquier tirada que necesites hacer para explicarte, probablemente *conversar**, *persuadir** o *comandar**."
		},
		new SVMove(SVMoveIDs.Purpose, SVStats.NotSet)
		{
			Title = "Propósito",
			Description = "Puedes gastar tu *armadura especial** para *empujarte** cuando estás superado por tu oposición o cuando estás bajo los efectos de heridas. Cuando *resistes** con *resolución**, obtienes *+1d**.",
			Details = "Si usas esta habilidad para *impulsarte**, obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de una herida grave) pero no recibes 2 estrés."
		},
		new SVMove(SVMoveIDs.Serendipitous, SVStats.NotSet)
		{
			Title = "Serendipity",
			Description = "Tu tripulación comienza con *+1 gambito** cuando se reinicia el pool.",
			Details = "Esto aumenta los comodines iniciales de la tripulación en un trabajo. Eres simplemente más afortunado que otras personas."
		},
		new SVMove(SVMoveIDs.NeverTellMeTheOdds, SVStats.NotSet)
		{
			Title = "Nunca me digas las probabilidades",
			Description = "Generas *gambitos** en tiradas *desesperadas**. También puedes generar comodines incluso si has gastado un comodín.",
			Details = "Normalmente solo generas comodines en tiradas arriesgadas para las que no has gastado un comodín. Tu capacidad para 'estirar' comodines, regenerándolos en tiradas en las que ya los has gastado, te da la capacidad de meterte en situaciones que otros ni siquiera querrían considerar."
		},
		new SVMove(SVMoveIDs.IKnowAGuy, SVStats.NotSet)
		{
			Title = "Conozco a un tipo",
			Description = "Cuando atracas por primera vez en un puerto después de estar ausente, elige uno y pregunta al GM sobre un trabajo: no es mortal, paga lo suficientemente bien, no es un trabajo urgente, proviene de una facción en la que confías, apunta a un enemigo que tienes. Puedes gastar *1 cred** por cada característica adicional.",
			Details = "Aunque mantienes la oreja pegada al suelo, tiene que pasar suficiente tiempo para que aparezcan nuevos trabajos en un puerto (generalmente uno o dos tiempos libres). El GM te dirá cómo te enteras del trabajo; podría ser una recompensa disponible públicamente o algo de lo que un contacto se entera."
		},
		new SVMove(SVMoveIDs.Tenacious, SVStats.NotSet)
		{
			Title = "Tenaz",
			Description = "Las penalizaciones por *daño** son un nivel menos graves (aunque la herida de nivel 4 sigue siendo mortal).",
			Details = "Cuando se aplican penalizaciones por heridas a las tiradas de acción, trátalas como un nivel menos de lo que esperarías, por lo que la herida de nivel 1 se ignora y la herida de nivel 3 es -1d. La herida de nivel 4, también llamada herida letal, sigue siendo letal a menos que puedas usar armadura o una tirada de resistencia para reducirla primero."
		},
		new SVMove(SVMoveIDs.WhenTheChipsAreDown, SVStats.NotSet)
		{
			Title = "Cuando las cosas se ponen difíciles",
			Description = "Obtienes un segundo uso de la *armadura especial** entre cada *tiempo libre**.",
			Details = "Esto te permite usar una segunda armadura especial O usar la misma armadura especial dos veces."
		},
		new SVMove(SVMoveIDs.DevilsOwnLuck, SVStats.NotSet)
		{
			Title = "Suerte del diablo",
			Description = "Puedes gastar tu *armadura especial** para *resistir** las consecuencias del fuego de blaster o para *empujarte** cuando hablas (o corres) para salir de problemas.",
			Details = "Si usas esta habilidad marca la casilla armadura espacial en tu libreto. Fuego de blaster se refiere a cualquier disparo y tanto si corres como si vuelas o lo que sea. Si usas esta habilidad para *empujarte** obtienes uno de los beneficios (+1d, +1 efecto, actuar a pesar de una herida grave) pero no recibes 2 estrés. Tu armadura especial se renueva cuando eliges carga para una misión nueva."
		},
		new SVMove(SVMoveIDs.Daredevil, SVStats.NotSet)
		{
			Title = "Temerario",
			Description = "Cuando haces una tirada desesperada, puedes tomar *+1d**. Si lo haces, no marques *xp** en el atributo de esa acción.",
			Details = "Necesitas tomar la decisión antes de tu tirada. Solo puedes tomar este dado extra si la posición final de la tirada es desesperada, por lo que si usas una preparación para cambiar la posición a arriesgada, por ejemplo, no puedes tomar el dado extra."
		},
		new SVMove(SVMoveIDs.ShootFirst, SVStats.NotSet)
		{
			Title = "Dispara primero",
			Description = "Cuando atacas desde el escondite o activas una trampa, toma *+1d**. Cuando haya una pregunta sobre quién actúa primero, la respuesta eres tú (dos personajes con Dispara primero actúan simultáneamente).",
			Details = "Para atacar desde el escondite, tu objetivo debe estar inconsciente de ti. Si estás activando una trampa, tu objetivo debe estar inconsciente de la trampa."
		},
		new SVMove(SVMoveIDs.AskQuestionsLater, SVStats.NotSet)
		{
			Title = "Haz preguntas después",
			Description = "Cuando consientes para reunir información, obtienes *+1 efecto** y, además, puedes preguntar: ¿A quién podría beneficiar esto?",
			Details = "Cuando hagas tu propia pregunta, aprenderás la"
		}
	};

	public override IMove GetMovement<TMovIDs, TClases>(TMovIDs _ID, TClases _class)
	{
		SVMoveIDs ID = (SVMoveIDs)(object)_ID;
		var m = AllMoves.Find(x=>x.ID == ID) ?? new SVMove(SVMoveIDs.NotSet, SVStats.NotSet) { Title = "Unknown movement" };
		return m;
	}

	public override IMove GetMovement<TMovIDs>(TMovIDs _ID)
	{
		SVMoveIDs ID = (SVMoveIDs)(object)_ID;
		return AllMoves.Find(x => x.ID == ID) ?? new SVMove(SVMoveIDs.NotSet, SVStats.NotSet) { Title = "Unknown movement" };
	}

}
