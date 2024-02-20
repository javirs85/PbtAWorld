using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;

namespace DungeonWorld;

public class DWCharacter : PbtALib.PbtACharacter
{
	public string PhysicialDescription { get; set; } = "Physicial description";

	private DWClasses _profession = DWClasses.DW_NotSet;

	public DWClasses Profession
	{
		get { return _profession; }
		set {
            if (value != _profession)
			{
				_profession = value;
				ClassString = _profession.ToString();
				Init();
			}
		}
	}

	private int _hp = 0;
	public override int HP
	{
		get => _hp;
		set
		{
			if(value != _hp) _hp = Math.Min(value, MaxHP); 
			OnUpdateUI();
			OnVTTUpdate();
		}
	}

	public Equipment Equip { get; set; } = new();

	public string Motivation { get; set; } = "";
	private Background? _background = null;
	public Background? Background
	{
		get { return _background; }
		set
		{
			_background = value;
			if (_background is not null && this.Equip is not null && _background.Title == "Veterano de las guerras")
			{
				this.Equip.Things.MaxUses = 4;
				this.Equip.MoreThings.MaxUses = 4;
			}
		}
	}
	public List<DWMovementIDs> ClassMovments { get; set; } = new List<DWMovementIDs>();
	public List<DWMovementIDs> ClassAdvancedMovments { get; set; } = new List<DWMovementIDs>();

	public bool IsWeak { get; set; }
	public bool IsStun { get; set; }
	public bool IsMiserable { get; set; }

	public int Armor { get; set; } = 0;

	public int Load => Equip?.CurrentLoad ?? 0;
	public int MaxLoadBase { get; set; } = 3;
	public int UsesPerSupply
	{
		get
		{
			if (Background is not null)
				if (Background.Title == "Veterano de las guerras")
					return 4;
			return 3;
		}
	}

	public DiceTypes Damage { get; set; }

	public int STR { get; set; }
	public int DEX { get; set; }
	public int CON { get; set; }
	public int WIS { get; set; }
	public int INT { get; set; }
	public int CHA { get; set; }

	public int PX { get; set; }

	public List<Points> Tracks { get; set; } = new();

	public static List<string> ProvideAvailableMotivations(DWClasses profession)
	{
		List<string> availableMotivations = new List<string>();
		switch (profession)
		{
			case DWClasses.DW_Barbarian:
				availableMotivations = new List<string> {
						"Desprecio: Ofende a un NPC con tus formas brutales",
						"Melancolía: Deja que un problema se intensifique mientras reflexionas",
						"Alegría: Causar problemas al excederse",
						"Honor: Cumplir una promesa hecha a un NPC",
						"Orgullo: Rechazar una solicitud o orden que está por debajo de ti "
					};
				break;
			case DWClasses.DW_Bard:
				availableMotivations = new List<string> {
						"Fama: Asegurarte de que otros difundan tu nombre",
						"Teatro: Provocar conflictos entre otros.",
						"Romance: Compartir un momento apasionado con otr@",
						"Sabiduría: Un PNJ actúa según tu consejo honesto."
					};
				break;
			case DWClasses.DW_Cleric:
				availableMotivations = new List<string> {
						"Ambición: Obtener reconocimiento o mantener influencia sobre un PNJ",
						"Evangelismo: Instruye a otro en los principios de tu fe",
						"Inquisición: Revelar las fallas o falsedades de otro.",
						"Ortodoxia: Causar problemas (para usted mismo o para otros) al\r\napegarse estrictamente a la doctrina.\r\n"
					};
				break;
			case DWClasses.DW_Druid:
				availableMotivations = new List<string> {
						"Cultivo: Ayudar a alguien a crecer, aprender o mejorar",
						"Desapego: Actuar de una manera que perjudique a un aliado",
						"Patrimonio: Molesta a otro con tus extraños caminos/ritos",
						"Conservación: Convencer a otros para proteger la naturaleza",
						"Recuperación: destruir/enterrar un artificio de la civilización"
					};
				break;
			case DWClasses.DW_Explorer:
				availableMotivations = new List<string> {
						"Misericordia: Terminar con el sufrimiento de alguien o algo",
						"Tenacidad: Negarse a rendirse a pesar de la objeción o el desastre.",
						"La caza: Derribar presas de gran poderío o astucia",
						"Maravilla: Mostrar a alguien un lugar/cosa de gran belleza"
					};
				break;
			case DWClasses.DW_Fighter:
				availableMotivations = new List<string> {
						"Desafío: participa en una pelea que no estás seguro de poder ganar",
						"Gloria: Presume frente a los NPC que pueden contar tu historia",
						"Paz: Resolver un conflicto o disputa sin derramamiento de sangre",
						"Orgullo: Poner a alguien en su lugar por faltarte el respeto"
					};
				break;
			case DWClasses.DW_Thief:
				availableMotivations = new List<string> {
						"Desafiante: Parar los pies a un matón o tirano",
						"Consciente: Traer confort o ayudar a hacer lo correcto",
						"Sobreexcitado: Crear problemas entre tus aliados por tomar un riesgo innecesario",
						"Tramposo: Conseguir que alguien actúe en base a información falsa"
					};
				break;
			case DWClasses.DW_Mage:
				availableMotivations = new List<string> {
						"Curiosidad: Causar problemas al tocar, abrir o jugar con algo",
						"Astucia: Establece una estratagema y luego aprovéchala",
						"Excentricidad: Volver loco a otro con tu extraño comportamiento",
						"Misterio: Desviar o evadir una investigación sobre tus actos"
					};
				break;
			case DWClasses.DW_Paladin:
				availableMotivations = new List<string> {
						"Coraje: Llevar a otro a actuar a pesar del miedo o la duda.",
						"Duda: Cuestiona tu fe, tus juramentos o tu orden",
						"Sacrificio: Sufrir penalidades para que otro no tenga que sufrir",
						"Celo: Causa problemas a tus aliados adhiriéndose estrictamente a tus juramentos"
					};
				break;
			case DWClasses.DW_Wielder:
				availableMotivations = new List<string> {
						"Dominación: Coaccionar a alguien a través de amenazas o violencia.",
						"Emoción: Causa problemas a tus aliados actuando precipitadamente",
						"Misterio: Sal de tu camino para aprender algo secreto.",
						"Victoria: Derrota a un enemigo digno en combate singular"
					};
				break;
			default:
				break;
		}
		return availableMotivations;
	}

	public static List<Background> ProvideAvailableBackgrounds(DWClasses profession)
	{
		List<Background> availableBackgrounds = new();
		switch (profession)
		{
			case DWClasses.DW_Barbarian:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Vagabundo lejano",
							Movements = new List<string>
							{
								"Cuando *dices conocimientos** al recordar tus muchos viajes, tienes ventaja.",
								"Cuando *tienes lo que necesitas**, puedes producir elementos inusuales de procedencia lejana, pero debes contamos en qué parte de tus viajes los adquiriste."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros ha viajado lejos conmigo?",
								"¿Quién de vosotros disfruta más de mis historias?",
								"¿Quién de vosotros no entiende mi cultura?",
								"¿Quién de vosotros me debe algo desde la última vez que estuve por aquí?"
							}
						},
						new Background
						{
							Title = "De una Tierra Sombría y Oscura",
							Movements = new List<string>
							{
								"Cuando *desafías el peligro o luchas como uno para superar un obstáculo físico**, tienes ventaja.",
								"Cuando te aventuras a través de situaciones difíciles o terreno peligroso, dinos cómo niegas o fácilmente superas una consecuencia del viaje.",
								"Cuando el grupo *acampa en la naturaleza**, puedes tira +INT: con 10+, creas o encuentras 1d4 de usos de Cosas; en un 7-9, algún tipo de problema\r\nte sigue hasta el campamento."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros ha estado en mi patria?",
								"¿Quién piensa que no soy más que un salvaje?",
								"¿Quién es simplemente un urbanita blando?",
								"¿Quién me encuentra extrañamente atractivo?"
							}
						},
						new Background
						{
							Title = "Último de la Raza Moribunda",
							Movements = new List<string>
							{
								"Tu gente era conocida desde hace mucho tiempo por su... (elige 3)\r\n artificios, belleza, oscuros pactos, decadencia, codicia, ferocidad, longevidad, magia, nobleza, maldad, destreza, tamaño, canciones, fuerza",
								"Cuando aprovechas la reputación de tu gente, obtienes ventaja al Parlamentar. Cuando dices conocimiento sobre ellos, trate un 6- como un 7-9",
								"Cuando *tienes lo que necesitas**, puedes producir artículos de tu gente, evocando los rasgos anteriores"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros también conoce gran pérdida?",
								"¿Con quién de vosotros tengo una deuda de vida?",
								"¿Quién de vosotros ha prometido ayudarme?",
								"¿Quién de vosotros tiene la llave de lo que busco?"
							}
						},
						new Background
						{
							Title = "Pueblo que sólo conoce la guerra",
							Movements = new List<string>
							{
								"Cuando *evalúes por primera vez** a un enemigo o aliado, pregúntale al DJ 1:\r\n• ¿Cuál es el mayor peligro que representan?\r\n• ¿En que forma son débiles o vulnerables?",
								"Cuando *sorprendes a un enemigo con un arma pequeña oculta**, gasta 1 uso de Cosas y obtén ventaja en tu primera tirada contra ellos.\r\n"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros ha luchado contra mi pueblo?",
								"¿En cuál de ustedes puedo confiar a mi espalda?",
								"¿Quién no ha visto un derramamiento de sangre?",
								"¿A quién de vosotros he marcado como cobarde?"
							}
						}
					};
				break;
			case DWClasses.DW_Bard:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Académico",
							Movements = new List<string>
							{
								"Cuando obtienes un 7+ en *Decir conocimientos**, puedes pedirle al GM una pregunta para profundizar; responderá con la verdad.",
								"Cuando *tienes lo que necesitas**, puedes producir artículos caros/improbables/raros sólo útiles para un erudito (papel, vasos de precipitados, astrolabios, espejos, lentes, etc.)."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de ustedes está empleado en el colegio?",
								"¿Quién de ustedes piensa que soy un lastre?",
								"¿Quién es un viejo compañero de copas?",
								"¿Cuál de ustedes es el tema de mis estudios?"
							}
						},
						new Background
						{
							Title = "Prodigio",
							Movements = new List<string>
							{
								"Cuando usas *Fascinación**, con un 7+ puedes también nombrar a alguien en tu público y elegir 1:\r\n• Quieren conocerte, en privado\r\n• Desean mucho tus servicios\r\n• Intuyes un secreto sobre ellos\r\n",
								"Cuando *tienes lo que necesitas**, puedes producir un artículo costoso, fino o inusual, pero debe decirnos quién te lo regaló y por qué."
							},
							InitialQuestions = new List<string>
							{
								"¿Sobre quién había cantado antes de conocernos?",
								"¿Sobre quién estoy componiendo una canción?",
								"¿Quién se preocupa por mí, no por mi talento?",
								"¿Quién de ustedes busca explotar mis dones?"
							}
						},
						new Background
						{
							Title = "Nómadas",
							Movements = new List<string>
							{
								"Tu gente es conocida por su... elija 1 de cada fila\r\nvestido elaborado, belleza exótica, rasgos sobrenaturales\r\ndanzas seductoras, música inquietante, obras de teatro sublimes\r\nmaldiciones y maleficios, sangre de hadas, métodos de robo",
								"Al comienzo del juego, ponte 1 punto de Herencia. Cuando haces un movimiento que aproveche uno de los rasgos de su gente, borra herencia para ganar ventaja. Cuando los rasgos de tu gente os metan en problemas, gana Herencia."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros es amigo de mi pueblo?",
								"¿Quién cree las historias que cuentan de nosotros?",
								"¿Quién ha viajado mucho tiempo conmigo?",
								"¿Quién de ustedes también es un paria?"
							}
						},
						new Background
						{
							Title = "Cortesana/o",
							Movements = new List<string>
							{
								"Cuando el *DJ establece por primera vez** un noble, famoso o PNJ influyente, puedes preguntarle al DJ uno de los siguiente:\r\n• ¿Cuál es su virtud o vicio más notable?\r\n• ¿Por qué gran hazaña son conocidos?\r\n• ¿Qué gran vergüenza tratan de vivir?",
								"Cuando *conoces por primera vez** a un noble, famoso o influyente PNJ en juego, puedes gastar Cosas para presentarte a ellos con un regalo apropiado (descríbalo); si lo haces, obtén ventaja en su próximo movimiento contra ellos."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién también sirve a mi señor o casa?",
								"¿Quién está empeñado en una casa rival?",
								"¿Con quién comparto un pasado tórrido?",
								"¿Quién tiene una deuda con mi señor?"
							}
						}
					};
				break;
			case DWClasses.DW_Cleric:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Cultista de Zeth",
							Movements = new List<string>
							{
								"Eres un discípulo de Eso Que Yace Debajo. *Cuando entierres una ofrenda ritual a Zeth**, obtén Favor si aún no lo tienes",
								"Cuando *tienes lo que necesitas**, puedes producir ofrendas agradables para Zeth. Cuando lanzas un hechizo, agrega esto a tus opciones para cuando obtengas un 7-9:\r\n• Gastar 1 uso de Suministro"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros me ha confiado un secreto?",
								"¿Quién es un verdadero discípulo de Zeth?",
								"¿Quién de ustedes no cree que Zeth existe?",
								"¿Quién de ustedes le teme a los lugares oscuros?"
							}
						},
						new Background
						{
							Title = "Místico Itinerante del Sol",
							Movements = new List<string>
							{
								"Sigues a Sol, dios de la Luz y el Conocimiento. *Cuando expones un secreto o un engaño**, ganas Favor si aún no lo tienes.",
								"Cuando *tienes lo que necesitas**, puede producir artículos inusuales de procedencia lejana, pero debes decirnos en qué parte de sus viajes los adquiriste",
								"Cuando *lanzas el hechizo Luz**, afecta a las criaturas de la oscuridad como si fuera luz solar natural."

							},
							InitialQuestions = new List<string>
							{
								"¿Quién es un verdadero discípulo de Sol?",
								"¿Quién ha viajado más tiempo conmigo?",
								"¿Quién no pudo ocultarme un secreto?,",
								"¿Quién comparte mi hambre de verdad?"
							}
						},
						new Background
						{
							Title = "Siervo de Mitra",
							Movements = new List<string>
							{
								"Sirves a Mitra, dios de los oprimidos. Cuando *alivias el sufrimiento** de un PNJ, o cuando *soportas un sufrimiento ritual que inflige una debilidad**, obtienes Favor si aún no lo tienes",
								"Cuando *ayudes a alguien a recuperarse mientras invoca a Mitra**, agregua tu SAB a los PG que recuperan.",
								"Cuando *lanzas Curar heridas**, tienes ventaja"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién es un verdadero discípulo de Mitra?",
								"¿Quién es un alma mejor de lo que dejan ver?",
								"¿Quién tiene una maldad en su corazón?",
								"¿Quién de vosotros quiere saber más de Mitra?"
							}
						},
						new Background
						{
							Title = "Templario de Indara",
							Movements = new List<string>
							{
								"Eres un legislador de Indara. Cuando *derrotes a un agente del caos**, obtén Favor si aún no lo tienes.",
								"Cuando *tienes lo que necesitas**, puedes producir artículos de mano de obra excepcional, los mejores ejemplos de su oficio",
								"Cuando *invoques tu autoridad divina**, trata un 6- a *Parlamentar** como un 7-9"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién es un verdadero discípulo de Indara?",
								"¿Quién es un agente del caos y la lucha?",
								"¿Quién ha luchado contra el caos a mi lado?",
								"¿Quién de ustedes me guarda secretos?"
							}
						}
					};
				break;
			case DWClasses.DW_Druid:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Guardián de la Antigua Fe",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento** sobre el mundo natural o cosas que la civilización ha olvidado, tienes ventaja.",
								"Cuando te *recuperas en la naturaleza y tienes tiempo para forrajear**, no necesitas gastar Cosas"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién también venera a los dioses antiguos?",
								"¿Quién me trata como a un primitivo?",
								"¿Quién de vosotros ignora el orden natural?",
								"¿Quién de vosotros requiere mi guía?"
							}
						},
						new Background
						{
							Title = "Iniciado del Primer Círculo",
							Movements = new List<string>
							{
								"Perteneces a una secta remota dedicada al equilibrio y el orden natural. Cuando *envías un mensaje a tu secta pidiendo ayuda**, tira +CAR: con 10+, ellos lo atienden a toda prisa; en un 7-9, la ayuda se retrasará o vendrá con problemas o deberes.",
								"Cuando *gastas Cosas y marcas un área con símbolos sagrados**, el área está protegida contra una de las siguientes amenazas mientras permanezcan los símbolos:\r\n• Espíritus inmundos y perversiones de la naturaleza\r\n• Bestias naturales y espíritus de la naturaleza"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién también es seguidor de mi secta?",
								"¿A quién de vosotros se me ordena proteger?",
								"¿Quién está siendo vigilado por mi secta?",
								"¿Quién de vosotros tiene motivos para desconfiar de mi secta?"
							}
						},
						new Background
						{
							Title = "Espíritu Tótem",
							Movements = new List<string>
							{
								"Elige una bestia natural nativa de tu tierra natal. *Cuando tomes prestada la forma de tu tótem**, no tires para cambiar de forma; obtienes automáticamente un 10+.\r\nSin embargo, cuando actúas en contra de los instintos de tu tótem, desafías el peligro con desventaja",
								"Cuando *gastas Cosas para fabricar una efigie de tu tótem**, configúralo para vigilar un lugar o una persona.\r\nTe avisará la próxima vez que se acerque un peligro.\r\n"
							},
							InitialQuestions = new List<string>
							{
								"¿Sobre cuál de ustedes susurran los espíritus?",
								"¿Quién es seguido por una presencia oscura?",
								"¿Quién piensa que me considera un comediante?",
								"¿Quién también ha visto el reino de los espíritus?"
							}
						},
						new Background
						{
							Title = "Tramposo/Héroe local",
							Movements = new List<string>
							{
								"Cuando *desafías el peligro** o *parlamentas** usando halagos o engaño, tienes ventaja.",
								"Cuando *tienes lo que necesitas**, puedes producir algo extraño y mágico. Di cómo robaste/conseguiste y cómo es útil en este momento, pero pregúntele al DJ cómo es limitado y problemático."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros ha compartido mis aventuras?",
								"¿Quién es a menudo el blanco de mis bromas?",
								"¿Quién de ustedes disfruta más de mis cuentos?",
								"¿Quién piensa que solo estoy lleno de tonterías?"
							}
						}
					};
				break;
			case DWClasses.DW_Explorer:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Explorador",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento sobre un lugar en el que has estado o un lugar que estás tratando de explorar**, tienes ventaja.",
								"Cuando *tienes lo que necesitas**, puedes producir artículos especializados, costosos o incluso únicos que son especialmente útiles para esta expedición, pero debe decirnos cómo supo que serían útiles."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién estuvo conmigo en mi última misión?",
								"¿Quién está financiando esta expedición?",
								"¿Quién tiene el mapa de nuestro destino?",
								"¿Quién miente acerca de por qué está aquí?"
							}
						},
						new Background
						{
							Title = "Guardabosques",
							Movements = new List<string>
							{
								"Cuando te *escondes en un entorno natural**, los enemigos Nunca te ven hasta que hagas algo para revelar tu posición (como atacar o moverse rápidamente).",
								"Cuando busques comida mientras acampáis, tira +SAB: con 10+, ambos; en un 7-9, elige 1:\r\n• El grupo no necesita gastar Cosas\r\n• Un miembro del grupo puede hacer un extra"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros hace más ruido?",
								"¿Quién de vosotros me contrató como guía?",
								"¿Quién de vosotros no tiene por qué estar aquí?",
								"¿Quién de vosotros necesitaba que yo limpiara un poco de sus miserias?"
							}
						},
						new Background
						{
							Title = "Criado por Lobos",
							Movements = new List<string>
							{
								"Empiezas con el avance Parientes y amigos",
								"Cuando le *muestres a una bestia natural quién es el jefe**, tira +CAR: en un 7+, debe elegir uno:\r\n• Luchar por el dominio\r\n• Escabullirse o huir, luego evitarlo\r\n• Acepta tu autoridad hasta que muestres debilidad.\r\nCon 10+, también obtienes ventaja en tu próximo movimiento en su contra."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros es el alfa de la manada?",
								"¿Quién de vosotros se parece más a una presa?",
								"¿Quién de vosotros es amable con los animales?",
								"¿Quién de vosotros huele mejor?"
							}
						},
						new Background
						{
							Title = "Lo oculto",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento** acerca de monstruos, demonios o practicantes de magia negra, tenéis ventaja",
								"Cuando *sabes de un objeto mundano que hace daño, repele, o es de otra manera útil contra su misión actual**, puedes tener lo que necesitas para producir eso."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién ha luchado contra el mal a mi lado?",
								"¿Quién aceptó unirse a mí en esta cacería?",
								"¿Quién está demasiado dispuesto a ceder?",
								"¿Quién ha perdido a alguien en la oscuridad?"
							}
						}
					};
				break;
			case DWClasses.DW_Fighter:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Gladiador",
							Movements = new List<string>
							{
								"Cuando *eliminas a un enemigo de forma llamativa o brutal**, elige 1:\r\n• Nombra un testigo; difundirá cuentos sobre ti\r\n• Nombra un enemigo; tienes su atención\r\n• Nombra un aliado; les das una oportunidad y obtienen ventaja si actúan en consecuencia",
								"Cuando *recibes daño**, puedes gastar 1 uso de Cosas para reducir a la mitad el daño y los efectos del golpe; cuéntanos cómo tu equipo se lleva la peor parte de eso"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros se ha enfrentado a mí en la batalla?",
								"¿Quién de vosotros es el más divertido?",
								"¿Quién de vosotros me tiene miedo?",
								"¿En quién de vosotros confío más?"
							}
						},
						new Background
						{
							Title = "Vástago noble",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento sobre la nobleza, la realeza o sus preocupaciones**, tienes ventaja.",
								"Empiezas con *una muestra del favor de algún noble**.",
								"Cuando uses *Tengo lo que necesito**, puedes producir artículos finos y caros (aunque no elementos únicos, oscuros o demasiado específicos)."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros me ha hecho juramento?",
								"¿Quién de vosotros es mi pariente?",
								"¿Quién de vosotros busca explotarme?",
								"¿Quién de vosotros no respeta mi rango?"
							}
						},
						new Background
						{
							Title = "Guarda juramentado",
							Movements = new List<string>
							{
								"Cuando *tienes puntos del movimiento Defender**, siempre puedes sufrir el daño/efectos de un ataque en lugar de tu defendido; no hay necesidad de gastar puntos",
								"Cuando ayudes a alguien a recuperarse, agrega tu SAB (min 1) a los PG que recupere tu paciente"
							},
							InitialQuestions = new List<string>
							{
								"¿A quién de vosotros he jurado proteger?",
								"¿Quién de vosotros me preocupa más?",
								"¿Quién de vosotros me cubre las espaldas?",
								"¿Quién de vosotros me ha estado coqueteando?"
							}
						},
						new Background
						{
							Title = "Veterano de las guerras",
							Movements = new List<string>
							{
								"Sabes cómo hacer una mochila; comienzas con un ◆ extra, tu carga máxima es ◆x7 (en lugar de x6) y obtienes un uso extra de Cosas y Más Cosas en la sección Equipo.",
								"Cuando *haces un campamento**, no necesitas quitarte la armadura y despertarás completamente alerta al menor indicio de problemas"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros sirvió conmigo?",
								"¿Quién de vosotros luchó del otro lado?",
								"¿Quién de vosotros está a cargo?",
								"¿Quién de vosotros hará que nos maten a todos?"
							}
						}
					};
				break;
			case DWClasses.DW_Thief:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Asesino",
							Movements = new List<string>
							{
								"Elige un veneno (ver Algunos venenos); tienes inmunidad a él y comienzas con un vial de ese veneno gratis. Cuando *tienes lo que necesitas**, puedes gastar 1 uso de Cosas para producir un vial de cualquier veneno (a tu elección, 2 usos, peligroso, pequeño).",
								"Cuando *dices conocimiento** sobre venenos, venenos o antídotos, tienes ventaja."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros me contrató para esta misión?",
								"¿Quién de vosotros es el único que confía en mí?",
								"¿Quién de vosotros está dispuesto a hacer lo que sea necesario?",
								"¿Quién de vosotros me debe la vida?"
							}
						},
						new Background
						{
							Title = "Operaciones",
							Movements = new List<string>
							{
								"Cuando *declaras que tienes un contacto en el área**, nómbralo y tira +CAR: con 10+, seguro, puede ayudar (dinos por qué está dispuesto); en un 7-9, elige 1:\r\n• Todavía guardan rencor\r\n• Renunciaron a este tipo de cosas hace\r\n mucho tiempo\r\n• No puedes exactamente, ya sabes… “confiar “en ellos",
								"Cuando *tienes lo que necesitas**, puede producir artículos específicos, justo lo que necesita para la misión"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién también es parte de mi misión?",
								"¿Quién de vosotros no sabe de mi misión?",
								"¿A quién de ustedes estoy tratando de reclutar?",
								"¿Quién de nosotros tiene un pasado “complicado”?"
							}
						},
						new Background
						{
							Title = "Rata callejera",
							Movements = new List<string>
							{
								"Cuando *tienes un momento de distracción y cobertura disponible**, puedes desaparecer de la vista y esconderte, así de simple",
								"Cuando *tengas lo que necesitas**, puede gastar 1 XP en lugar de 1 Cosas para producir un artículo pequeño, pero solo si puedes decirnos de qué PNJ lo sacaste y cuándo"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién piensa que soy una rata sin valor?",
								"¿Quién está demasiado familiarizado con el hambre?",
								"¿Quién de vosotros me cubre las espaldas?",
								"¿Quién me muestra una amabilidad sorprendente?"
							}
						},
						new Background
						{
							Title = "Saqueador de tumbas",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento sobre tumbas, ruinas antiguas y las cosas que uno encuentra allí**, tienes ventaja",
								"Cuando *tienes lo que necesitas**, puedes producir artículos extraños, oscuros e incluso ligeramente mágicos, pero solo si nos dices dónde los obtuviste"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros montó este trabajo?",
								"¿Con quién de vosotros he trabajado antes?",
								"¿Quién piensa que solo soy un ladrón de tumbas?",
								"¿Quién de vosotros suele ser el blanco de mis bromas?"
							}
						}
					};
				break;
			case DWClasses.DW_Mage:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Entrenado formalmente",
							Movements = new List<string>
							{
								"Cuando *tienes lo que necesitas**, puedes producir reactivos y químicos crudos arcanos, como polvo de plomo u ojo de tritón. Cuando *lances un hechizo**, agrega esto a la lista de opciones para cuando saques un 7-9:\r\n• Gastar 1 uso de Cosas",
								"Cuando *dices conocimiento** sobre otros lanzadores de hechizos, tienes ventaja."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién trabajó alguna vez con mi mentor?",
								"¿Quién de vosotros me buscó por mi experiencia?",
								"¿Quién de vosotros es un aprendiz fracasado?",
								"¿Quién ha sufrido uno de mis pequeños experimentos?"
							}
						},
						new Background
						{
							Title = "Tocado por hadas",
							Movements = new List<string>
							{
								"Siempre puedes preguntarle al DJ \"¿qué está escondido aquí por magia o ilusión?\" y obtener una respuesta honesta. Por desgracia, el hierro frio es un anatema para ti: te quema la piel y contrarresta tu magia por completo.",
								"Cuando *tienes lo que necesitas**, puedes producir cosas maravillosas, imposibles y poco prácticas como una botella que contiene una canción, el último recuerdo de un niño de su madre, un colibrí vivo, etc.",
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros tiene el alma más hermosa?",
								"¿Quién de vosotros me ha hecho una promesa?",
								"¿Quién es más cruel con sus inferiores?",
								"¿Quién de vosotros se siente irresistiblemente atraído hacia mí?"
							}
						},
						new Background
						{
							Title = "Pacto",
							Movements = new List<string>
							{
								"Aprendiste magia de una entidad peligrosa. *Comienzas con un token de favor de tu patrón** (pequeño, mágico). Cuando rompas el token, tu patrón se manifestará y considerará tu solicitud. Si está satisfecho con los resultados, reemplazará el token",
								"Cuando *haces campamento**, puedes gastar 1 suministro para usar Contactar espíritus como si hubieras sacado un 10+."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién conoce el secreto de mi poder?",
								"¿Con quién he sellado un juramento de sangre?",
								"¿Quién ha atraído el interés de mi patrón?",
								"¿Cuál de tus oscuros destinos he previsto?"
							}
						},
						new Background
						{
							Title = "Impregnado de sabiduría",
							Movements = new List<string>
							{
								"Cuando inspeccionas por primera vez una obra de magia o artificio, puedes preguntarle al DJ 2 lo siguiente:\r\n• ¿Quién hizo esto y hace cuánto tiempo?\r\n• ¿Qué hace?\r\n• ¿Cómo puedo activarlo o repararlo?\r\n• ¿Qué pasa aquí que no es lo que parece?\r\n",
								"Puedes gastar 1 uso de Cosas para producir un mapa, libro, pergamino u otra fuente de conocimiento relevante; trátelo como si hubiera sacado 10+ en decir conocimiento."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros me guarda un secreto?",
								"¿Quién de vosotros me está mostrando el camino?",
								"¿De quién de vosotros se habla en las profecías?",
								"¿Quién de vosotros es un recipiente esperando ser llenado?"
							}
						}
					};
				break;
			case DWClasses.DW_Paladin:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Ungido por los dioses",
							Movements = new List<string>
							{
								"Cuando *invocas tu autoridad divina para emitir una orden o una advertencia**, tira +CAR: con un 7-9, ellos deben elegir 1; con un 10+, sabes qué van a hacer y actuas primero y con con ventaja.\r\n• Hacen lo que dices\r\n• Retroceden lentamente, luego huyen\r\n• Te atacan",
								"Cuando le *impones las manos a alguien mientras se recupera**, ellos recuperan PG extra igual a tu CAR y tú puedes marcar una debilidad en lugar de usar Cosas."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién me conocía antes de que me llamaran?",
								"¿Quién de vosotros comparte mi fe?",
								"¿Quién de vosotros me encuentra desconcertante?",
								"¿Quién de vosotros se burla o duda de mi fe?"
							}
						},
						new Background
						{
							Title = "Héroe renacido",
							Movements = new List<string>
							{
								"Cuando *dices conocimiento** consultando los recuerdos de tu vida o vidas pasadas, tienes ventaja",
								"Cuando *haces campamento y sueñas tus proféticos sueños**, hazle una pregunta al DJ sobre los peligros a los   que te enfrentas. Ellos te darán una respuesta honesta en tus sueños, aunque pueda ser nublada o críptica"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién me conoció en una vida anterior?",
								"¿Quién de vosotros es mi pariente en esta vida?",
								"¿Quién duda que soy quien afirmo ser?",
								"¿Quién de vosotros se ha comprometido a seguirme?"
							}
						},
						new Background
						{
							Title = "Modelo de Virtud",
							Movements = new List<string>
							{
								"Cuando te acercas a un enemigo para negociar de buena Fe, al menos te escucharán. Incluso el enemigo más degradado y salvaje retrasará la violencia hasta que hayas tenido tu opción\r\n",
								"Cuando pasas la noche en oración y vigilia, no necesitas dormir para obtener los beneficios de Acampar"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién es un alma mejor de lo que dejan ver?",
								"¿Quién de vosotros me sigue en mi búsqueda?",
								"¿Cuál de vosotros me llena de tentación?",
								"¿Quién de vosotros me convenció de que esta tontería valió la pena?"
							}
						},
						new Background
						{
							Title = "Orden Sagrada",
							Movements = new List<string>
							{
								"¿Por qué es conocida su orden? (elige 3)\r\ncapítulos por doquier, celo fanático, santas reliquias, honor, influencia, ritos místicos, popularidad, guerreros hábiles, tesoros de sabiduría, riqueza",
								"Cuando *aprovecha la reputación de tu orden**, obtienes ventaja para *Parlamentar**.",
								"Cuando *dices conocimiento sobre tu orden**, trata un 6- como un 7-9.",
								"Cuando *tienes lo que necesitas**, puedes producir artículos que reflejan las características de tu orden"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros también sirve en mi orden?",
								"¿A quién de vosotros se me ha ordenado servir?",
								"¿Quién de vosotros sabe de mi misión secreta?",
								"¿A quién de vosotros estoy vigilando de cerca?"
							}
						}
					};
				break;
			case DWClasses.DW_Wielder:
				availableBackgrounds = new List<Background>
					{
						new Background
						{
							Title = "Maldito",
							Movements = new List<string>
							{
								"Cuando *desenvaines tu arma**, tira +SAB: con 10+, nombra un PNJ que morirá; con 7-9, nombra dos PNJ: uno morirá y el otro vivirá, pero no está claro cuál es cuál; con 6-, alguien seguramente morirá, pero ¿quién? Sea como sea, el DJ se asegurará de que tu visión se haga realidad",
								"Cuando *haces un campamento y recuerdes a alguien a quien te arrepientas de haber matado con tu arma…** marca PX"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros detuvo una vez mi mano?",
								"¿Quién ha fallado en detener mi mano?",
								"¿Quién sabe cómo levantar la maldición?",
								"¿Quién se ha quedado conmigo a pesar de todo?"
							}
						},
						new Background
						{
							Title = "Forjado con tus propias manos",
							Movements = new List<string>
							{
								"Cuando *tienes acceso a una forja**, puedes transferir los poderes mágicos y las propiedades de otra arma a Tu Arma (añadiéndolos a los que ya tiene). La otra arma es destruida",
								"Cuando *tienes tiempo para trabajar y Tienes lo que necesitas**, puede producir objetos específicos, finamente elaborados, incluso artículos mágicos menores que satisfagan unas necesidades específicas"
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros me ayudó a forjar Mi Arma?",
								"¿Quién de vosotros tiene mucho que enseñarme?",
								"¿Quién se ha mantenido valientemente a mi lado?",
								"¿Quién de vosotros busca robar mis secretos?"
							}
						},
						new Background
						{
							Title = "Legado",
							Movements = new List<string>
							{
								"Cuando *dices conocimientos sobre tu arma o los muchos héroes honorables que la empuñaron antes tú**, tienes ventaja",
								"Cuando *obsequias a un aliado con un cuento del pasado de tu arma mientras se recuperan**, tu aliado recupera PG extra igual a tu CAR.\r\n"
							},
							InitialQuestions = new List<string>
							{
								"¿Cuál de sus familias ha servido durante mucho tiempo a la mía?",
								"¿Quién de vosotros me reclutó para esta misión?",
								"¿Quién se preocupa por mí, no por mi deber?",
								"¿A quién de vosotros he jurado proteger?"
							}
						},
						new Background
						{
							Title = "Recipiente",
							Movements = new List<string>
							{
								"Crea puntos de RECIPIENTE\r\nCuando *mates a un enemigo vivo con tu arma**, mantén 1 punto (máximo 3). Cuando te *recuperas o quieres una selección extra de hacer un campamento**, debes gastar 1 punto en lugar de gastar 1 Cosas.",
								"Cuando te *estés muriendo**, tira +Recipiente (en lugar de último aliento): con 10+, sobrevives y recuperas 1d6 PG; con 7-9, sobrevives y recuperas 1 PG pero pierdes tus puntos; con un 6-, mueres. O más bien, este recipiente muere, pero tú persistes. El siguiente PNJ mortal que te esgrima se convierte en tu recipiente."
							},
							InitialQuestions = new List<string>
							{
								"¿Quién de vosotros conocía este recipiente antes?",
								"¿Quién me conoció en un recipiente anterior?",
								"¿Quién me ha alimentado con vuestra sangre cuando estaba desesperado y hambriento?",
								"¿Quién de vosotros confía en mí, a pesar de la verdad?"
							}
						}
					};
				break;
			default:
				break;
		}
		return availableBackgrounds;
	}


	public void Init(DWClasses? clas = null)
	{
		if(clas is not null)
			this.Profession = (DWClasses)clas;

		Tracks.Add(new Points { Tittle = "Experiencia", Value = 0 });
		Tracks.Add(new Points { Tittle = "Defender", Value = 0 });
		
		switch (this.Profession)
		{
			case DWClasses.DW_Barbarian:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Barbarian_InitialChoose, DWMovementIDs.DW_Barbarian_Forastero, DWMovementIDs.DW_Barbarian_Formidable, DWMovementIDs.DW_Barbarian_Hunger, DWMovementIDs.DW_Barbarian_UpperHand });
				MaxHP = 20;
				Damage = DiceTypes.d10;
				HP = MaxHP;
				MaxLoadBase = 3;
				Equip = new Equipment()
				{
					GoodWeapons = new List<EquipmentItem>{
							new EquipmentItem{Name="Espada"},
							new EquipmentItem{Name="Hacha"},
							new EquipmentItem{Name="Maza"},
							new EquipmentItem{Name="Martillo"},
							new EquipmentItem{Name="Mangual"},
							new EquipmentItem{Name="Asta", Weight=2} },
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="Pieles o coraza de cuero", ArmorValue=1, Explanation="armadura1" },
							new EquipmentItem { Name="Escudo", Weight=2, ArmorAddition=1, Explanation="+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Par de espadas"},
							new EquipmentItem{Name="Par de hachuelas" },
							new EquipmentItem{Name="par de lanzas"},
							new EquipmentItem{Name="Arco corto", IsAmunitionWeapon = true}
						},
					SmallThings = "Recuerdo de tu tierra\r\n\r\nElije una:\r\nCuchillo o daga\r\nbolsa de monedas\r\nPellejo de licor fino"
				};
				break;
			case DWClasses.DW_Bard:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Barb_Works, DWMovementIDs.DW_Barb_DoWorks, DWMovementIDs.DW_Barb_Reputation, DWMovementIDs.DW_Barb_Knowledge, DWMovementIDs.DW_Barb_Smart, DWMovementIDs.DW_Bard_Works_Fascination });
				MaxHP = 16;
				Damage = DiceTypes.d6;
				HP = MaxHP;
				MaxLoadBase = 4;
				Equip = new Equipment()
				{

					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="cuero o tabardo elegante", ArmorValue=1, Explanation="armadura1" }
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Espada", Explanation="daño +1"},
							new EquipmentItem{Name="E.Ropera", Explanation="DES en lugar de FUE" },
							new EquipmentItem{Name="Lanza"},
							new EquipmentItem{Name="Bastón"},
							new EquipmentItem{Name="Espada corta"},
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Laud"},
							new EquipmentItem{Name="Violín"},
							new EquipmentItem{Name="Tambor"},
							new EquipmentItem{Name="Arpa"},
							new EquipmentItem{Name="Trompeta"},
							new EquipmentItem{Name="Decoraciones", Explanation="Sedas, adornos, ropa fashion"},
						},
					SmallThings = "Cuchillo o daga\r\nFlauta o cancionero\r\nElije una:\r\nBolsa de dinero\r\nCarta para entregar\r\nMuestra de favor de un noble",
				};
				break;
			case DWClasses.DW_Cleric:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Cleric_CastSpell, DWMovementIDs.DW_Cleric_Favor, DWMovementIDs.DW_Cleric_PrepareSpell, DWMovementIDs.DW_Cleric_Spells });
				MaxHP = 18;
				Damage = DiceTypes.d6;
				HP = MaxHP;
				MaxLoadBase = 5;
				Equip = new Equipment()
				{
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name = "Cuero o mallas", ArmorValue = 1, Explanation = "armadura1" },
							new EquipmentItem { Name = "Vestimentas benditas", Weight = 1, ArmorAddition = 1, Explanation = "+1 armadura contra enemigos de la fé" },
							new EquipmentItem { Name = "Escudo", Weight = 2, ArmorAddition = 1, Explanation = "+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem { Name = "Lanza" },
							new EquipmentItem { Name = "Espada corta" },
							new EquipmentItem { Name = "Garrote" },
							new EquipmentItem { Name = "Bastón" },
						},
					Misc = new() {
							new EquipmentItem {Name="Reliquiario", MaxUses=1, Explanation="Se puede gastar en lugar de un favor"},
							new EquipmentItem {Name="Parafernalia", MaxUses=2, Explanation="LENTO, Ventaja a lanzar un hechizo"},
							new EquipmentItem {Name="Textos sagrados", MaxUses=2, Explanation="LENTO Lanza un hechizo no preparado"},
						},
					SmallThings = "Simbolo de tu dios\r\nCuchillo o daga\r\n\r\nElije una:\r\nBolsa de dinero\r\nAceite sagrado (quema lo impío)\r\nElixir +10PG o devilidad",
				};
				break;
			case DWClasses.DW_Druid:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Druid_Comunion, DWMovementIDs.DW_Druid_SecretLanguage, DWMovementIDs.DW_Druid_ShapeShifter, DWMovementIDs.DW_Druid_TouchedBySpirit });
				MaxHP = 16;
				Damage = DiceTypes.d6;
				HP = MaxHP;
				MaxLoadBase = 4;
				Equip = new Equipment()
				{
					GoodWeapons = new List<EquipmentItem> {
							new EquipmentItem { Name = "Lanza" },
							new EquipmentItem { Name = "Bastón" },
							new EquipmentItem { Name = "garrote" },
							new EquipmentItem { Name = "Hacuela" },
							new EquipmentItem { Name = "Hoz" },
							new EquipmentItem{Name="Arco largo", IsAmunitionWeapon = true}
						},
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="Pieles y pelos", ArmorValue=1, Explanation="armadura1" },
							new EquipmentItem { Name="Escudo", Weight=2, ArmorAddition=1, Explanation="+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Ofrendas", Explanation="ventaja Hablar con espiritus", MaxUses = 2},
							new EquipmentItem{Name="Bolsa sagrada", Explanation="ningún mal dentro puede escapar o afectar"},
							new EquipmentItem{Name="Talisman", Explanation="contiene un espiritu menor que puede ayudar"}
						},
					SmallThings = "Cuchillo o daga\r\nToken de la naturaleza\r\nElije una:\r\nPoción de curación +10PG\r\nMadera sagrada (humo repele el mal)\r\nFango (cura cualqueir veneno)",
				};
				break;
			case DWClasses.DW_Explorer:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Ranger_FollowMe, DWMovementIDs.DW_Ranger_Friend, DWMovementIDs.DW_Ranger_Hunt, DWMovementIDs.DW_Ranger_Shoot, DWMovementIDs.DW_Ranger_Stealthy });
				MaxHP = 18;
				Damage = DiceTypes.d8;
				HP = MaxHP;
				MaxLoadBase = 3;
				Equip = new Equipment()
				{
					GoodWeapons = new List<EquipmentItem> {
							new EquipmentItem { Name = "Espada" },
							new EquipmentItem { Name = "Otra espada" },
							new EquipmentItem { Name = "hacha" },
							new EquipmentItem{Name="Arco largo", IsAmunitionWeapon = true}
						},
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="Pieles o coraza de cuero", ArmorValue=1, Explanation="armadura1" },
							new EquipmentItem { Name="Escudo", Weight=2, ArmorAddition=1, Explanation="+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Lanza"},
							new EquipmentItem{Name="Bastón" },
							new EquipmentItem{Name="Hachuela"},
							new EquipmentItem{Name="Espada corta"},
							new EquipmentItem{Name= "Munición extra", MaxUses=3}
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Trampas y lazos", MaxUses = 3}
						},
					SmallThings = "Elije una:\r\nCuchillo o daga\r\nmapa de donde estais\r\nCuchillo de plata",
				};
				break;
			case DWClasses.DW_Fighter:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Fighter_Bend, DWMovementIDs.DW_Fighter_Blind, DWMovementIDs.DW_Fighter_Expert, DWMovementIDs.DW_Fighter_Fright, DWMovementIDs.DW_Fighter_Hard });
				MaxHP = 20;
				Damage = DiceTypes.d10;
				HP = MaxHP;
				MaxLoadBase = 6;
				Equip = new Equipment()
				{
					GoodWeapons = new()
						{
							new EquipmentItem { Name = "Espada" },
							new EquipmentItem { Name = "Mangual" },
							new EquipmentItem { Name = "Hacha" },
							new EquipmentItem { Name = "Maza" },
							new EquipmentItem { Name = "Martillo" },
							new EquipmentItem { Name = "Asta", Weight=2 },
							new EquipmentItem { Name = "Ballesta", IsAmunitionWeapon=true },
						},
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name = "Cuero o mallas", ArmorValue = 1, Explanation = "armadura1" },
							new EquipmentItem { Name = "Breastplate", Weight=2 ,ArmorValue = 2, Explanation = "armadura2, Molesto" },
							new EquipmentItem { Name="Escudo", Weight=2, ArmorAddition=1, Explanation="+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem { Name = "Lanza" },
							new EquipmentItem { Name = "Espada corta" },
							new EquipmentItem { Name = "Garrote" },
							new EquipmentItem { Name = "Bastón" },
						},
					SmallThings = "Cuchillo o daga\r\n\r\nElije una:\r\nBolsa de dinero\r\nToken de favor de un noble\r\nElixir +10PG o devilidad",
				};
				break;
			case DWClasses.DW_Thief:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Thief_Backstab, DWMovementIDs.DW_Thief_DangerSense, DWMovementIDs.DW_Thief_Poison, DWMovementIDs.DW_Thief_Stealth, DWMovementIDs.DW_Thief_Tricks });
				MaxHP = 16;
				Damage = DiceTypes.d8;
				HP = MaxHP;
				MaxLoadBase = 3;
				Equip = new Equipment()
				{
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name = "cuero o mallas", ArmorValue = 1, Explanation = "armadura1" }
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem { Name = "Espada ropera", Explanation="DES en vez de FUE" },
							new EquipmentItem { Name = "Lanza" },
							new EquipmentItem { Name = "Espada corta" },
							new EquipmentItem { Name = "Garrote" },
							new EquipmentItem { Name = "Bastón" },
							new EquipmentItem{Name="Arco corto", IsAmunitionWeapon = true},
							new EquipmentItem{Name="Cuchillos arrojadizos", IsAmunitionWeapon = true},
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Kit disfraz", MaxUses=3}
						},
					SmallThings = "Cuchillo o daga\r\n\r\nElije una:\r\nBolsa de dinero\r\nGema valiosa\r\nVial de veneno, 2 usos, peligroso",
				};
				break;
			case DWClasses.DW_Mage:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Wizard_CastSpell, DWMovementIDs.DW_Wizard_PrepareSpell, DWMovementIDs.DW_Wizard_Ritual, DWMovementIDs.DW_Wizard_Spells });
				MaxHP = 14;
				Damage = DiceTypes.d4;
				HP = MaxHP;
				MaxLoadBase = 3;
				Equip = new Equipment()
				{

					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name = "Ropas encantadas o cuero", ArmorValue = 1, Explanation = "armadura1" }
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem { Name = "Espada corta" },
							new EquipmentItem { Name = "Lanza" },
							new EquipmentItem { Name = "Bastón" },
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Libro de hechizos", Explanation="No cuenta como carga"},
							new EquipmentItem{Name="Grimorio", MaxUses=1, Explanation="veta 1 condición para un ritual"},
							new EquipmentItem{Name="Amuletos y talismanes", MaxUses=1, Explanation="niega un ataque mágico"},
							new EquipmentItem{Name="Parafernalia", MaxUses=2, Explanation="LENTO, ventaja a lanzar un hechizo"},
							new EquipmentItem{Name="Varita", MaxUses=-1, Explanation="ignora un -1 a lanzar hechizos"},
						},
					SmallThings = "Cuchillo o daga\r\n\r\nElije una:\r\nBolsa de dinero\r\nGema fulgurante\r\nVial de sangre o plata líquida",
				};
				break;
			case DWClasses.DW_Paladin:
				MaxHP = 20;
				Damage = DiceTypes.d10;
				HP = MaxHP;
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Paladin_Eyes, DWMovementIDs.DW_Fighter_Blind, DWMovementIDs.DW_Paladin_Grace, DWMovementIDs.DW_Paladin_Hurt, DWMovementIDs.DW_Paladin_NoFear, DWMovementIDs.DW_Paladin_Obliged });
				MaxLoadBase = 6;
				Equip = new Equipment()
				{
					GoodWeapons = new List<EquipmentItem> {
							new EquipmentItem{Name="Espada"},
							new EquipmentItem{Name="Hacha"},
							new EquipmentItem{Name="Mangual"},
							new EquipmentItem{Name="Maza"},
							new EquipmentItem{Name="Martillo"},
							new EquipmentItem{Name="Asta"},
							new EquipmentItem{Name="Ballesta", IsAmunitionWeapon = true}
						},
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="cuero o tabardo elegante", ArmorValue=1, Explanation="armadura1" },
							new EquipmentItem { Name="Pecho de metal",Weight=2, ArmorValue=2, Explanation="armadura2, Molesto" },
							new EquipmentItem { Name="Escudo",Weight=2, ArmorAddition=1, Explanation="+1 armadura, Molesta" },
							new EquipmentItem { Name="Tabardo sagrado",Weight=1, ArmorAddition=1, Explanation="+1 armadura contra demonios y no-muertos" },
						},
					SmallThings = "Cuchillo o daga\r\nSimbolo de tu dios o orden\r\n\r\nElije una:\r\nBolsa de dinero\r\nAceite sagrado (quema al mal)\r\nMuestra de favor de un noble",
				};
				break;
			case DWClasses.DW_Wielder:
				this.ClassMovments.AddRange(new List<DWMovementIDs> { DWMovementIDs.DW_Wielder_Measure, DWMovementIDs.DW_Wielder_Valor, DWMovementIDs.DW_Wielder_Weapon });
				MaxHP = 20;
				Damage = DiceTypes.d10;
				HP = MaxHP;
				MaxLoadBase = 5;
				Equip = new Equipment()
				{
					GoodWeapons = new List<EquipmentItem>{
							new EquipmentItem{Name="Espada"},
							new EquipmentItem{Name="Hacha"},
							new EquipmentItem{Name="Maza"},
							new EquipmentItem{Name="Martillo"},
							new EquipmentItem{Name="Mangual"},
							new EquipmentItem{Name="Asta"},
							new EquipmentItem{Name="Arco corto", IsAmunitionWeapon = true}
						},
					ArmorItems = new List<EquipmentItem> {
							new EquipmentItem { Name="cuero o mayas", ArmorValue=1, Explanation="armadura1" },
							new EquipmentItem { Name="Tabardo o placa de pecho", ArmorValue=2, Explanation="armadura2, Molesto" },
							new EquipmentItem { Name="Escudo", Weight=2, ArmorAddition=1, Explanation="+1 armadura, +1 punto cuando defiendes con un 7+" },
						},
					OtherItems = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Lanza"},
							new EquipmentItem{Name="Espada corta"},
							new EquipmentItem{Name="Garrote"},
							new EquipmentItem{Name="Bastón"},
						},
					Misc = new List<EquipmentItem>
						{
							new EquipmentItem{Name="Ofrendas", Explanation="ventaja Hablar con espiritus", MaxUses = 2},
							new EquipmentItem{Name="Bolsa sagrada", Explanation="ningún mal dentro puede escapar o afectar"},
							new EquipmentItem{Name="Talisman", Explanation="contiene un espiritu menor que puede ayudar"}
						},
					SmallThings = "Cuchillo o daga\r\n\r\nElije una:\r\nBolsa de dinero\r\nToken del favor de un noble\r\nElixir +10PG o debilidad",
				};
				break;
			default:
				break;
		}
	}

	public int MaxLoad
	{
		get
		{
			int bonus = 0;
			if (ClassAdvancedMovments.Contains(DWMovementIDs.DW_Barbarian_Adv_Muscle))
				bonus += 2;
			if (ClassAdvancedMovments.Contains(DWMovementIDs.DW_Ranger_Adv_Horse))
				bonus += 2;
			if (Background is not null && Background.Title == "Veterano de las guerras")
				bonus += 1;

			return MaxLoadBase + bonus;
		}
	}


	public void StatMinusOne(DWStats stat)
	{
		switch (stat)
		{
			case DWStats.DW_STR:
				STR--;
				break;
			case DWStats.DW_DEX:
				DEX--;
				break;
			case DWStats.DW_CON:
				CON--;
				break;
			case DWStats.DW_INT:
				INT--;
				break;
			case DWStats.DW_WIS:
				WIS--;
				break;
			case DWStats.DW_CHA:
				CHA--;
				break;
			default:
				break;
		}
	}
	public void StatPlusOne(DWStats stat)
	{
		switch (stat)
		{
			case DWStats.DW_STR:
				STR++;
				break;
			case DWStats.DW_DEX:
				DEX++;
				break;
			case DWStats.DW_CON:
				CON++;
				break;
			case DWStats.DW_INT:
				INT++;
				break;
			case DWStats.DW_WIS:
				WIS++;
				break;
			case DWStats.DW_CHA:
				CHA++;
				break;
			default:
				break;
		}
	}

	public override int GetBonus<T>(T statsEnum)
	{
		if (typeof(T) == typeof(DWStats))
		{
			DWStats stat = (DWStats)(object)statsEnum;
			return getBonus(stat);
		}
		else
			return 0;
	}

	public int getBonus(IMove mov)
	{
		if (mov is DWMove)
			return getBonus((mov as DWMove).Roll);
		else
			return 0;
	}

	public int getBonus(DWStats stat)
	{
		return stat switch
		{
			DWStats.DW_STR => this.STR,
			DWStats.DW_DEX => this.DEX,
			DWStats.DW_CON => this.CON,
			DWStats.DW_WIS => this.WIS,
			DWStats.DW_INT => this.INT,
			DWStats.DW_CHA => this.CHA,
			_ => throw new Exception("cannot calculate the bonus of " + stat.ToString())
		};
	}
}
