using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class DWTextBook : BaseTextBook
{
	public List<MasterMove> MasterMoves = new List<MasterMove>{ 
		new MasterMove("Usa un movimiento de monstruo, peligro o localización"),
		new MasterMove("Revela una verdad incomoda"),
		new MasterMove("Muestra signos de una amenaza que se aproxima"),
		new MasterMove("Hazles daño"),
		new MasterMove("Gasta sus recursos"),
		new MasterMove("Usa su movimiento en su contra"),
		new MasterMove("Sepáralos"),
		new MasterMove("Ofrece una oportunidad que se ajuste a las habilidades de una clase"),
		new MasterMove("Muestra una desventaja de su clase, raza o equipo"),
		new MasterMove("Ofrece una oportunidad con un coste"),
		new MasterMove("Pon a alguien en una situación complicada"),
		new MasterMove("Diles los requerimientos o las consecuencias, y pregunta.")
	};
	
	public List<MasterMove> MasterDungeonMoves = new List<MasterMove>{ 
		new MasterMove("Cambia el entorno"),
		new MasterMove("Señala a una amenaza inminente"),
		new MasterMove("Introduce una nueva facción o tipo de criatura"),
		new MasterMove("Usa una característica de una facción que ya exista"),
		new MasterMove("Barra el paso, hazlos retroceder"),
		new MasterMove("Presenta riquezas con su precio"),
		new MasterMove("Presenta un desafío a uno de los PJ")
	};
	public List<MasterMove> MasterFightMotivations = new List<MasterMove>{
		new MasterMove("Matar"),
		new MasterMove("Robar"),
		new MasterMove("Defender"),
		new MasterMove("Capturar"),
		new MasterMove("Retrasar"),
	};

	//https://www.dungeonworldsrd.com/monsters/

	public List<Monster> CaveMonsters = new List<Monster>
	{
		new Monster
		{
			Name = "Ankeg",
			Organization = TagIDs.Grupo,
			Size = TagIDs.Grande,
			MaxHP = 10, CurrentHP = 10,
			Armor = 3,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Acaparador},
			Special = new List<string>{"Excavador"},
			Instinct = "Socavar",
			Definition = "Una armadura de placas parecida a la piel y grandes mandíbulas aplastantes son problemáticas. Un estómago lleno de ácido que puede hacer un agujero en un muro de piedra los empeora aún más. Serían bastante malos si tuvieran el tamaño adecuado de un insecto, pero estas cosas tienen el descaro de ser tan largas como cualquier caballo. ¡Simplemente no es natural! ¿Qué bueno que tienden a quedarse en un solo lugar? Es fácil para ti decirlo: no tienes un ankheg viviendo debajo de tu campo de maíz.",
			Moves = new List<MasterMove>
			{
				new MasterMove("Cavar la tierra"),
				new MasterMove("Irrumpir desde el subsuelo"),
				new MasterMove("Rociar ácido, devorando el metal y la carne")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef {
					AttackName = "Mordisco",
					Dice = DiceTypes.d8,
					Bonus = +1
				}
			}
		},
		new Monster
		{
			Name = "Rata de la Cueva",
			Organization = TagIDs.Horda,
			Size = TagIDs.Pequeño,
			MaxHP = 7, CurrentHP = 7,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.escabroso },
			Instinct = "Devorar",
			Definition = "¿Quién no ha visto una rata antes? Es como esa, pero desagradable y grande y ya no te tiene miedo. Tal vez esta sea prima de aquella que atrapaste en una trampa o la que mataste con un cuchillo en esa taberna sucia en Darrow. Tal vez esté buscando un poco de venganza rata. ",
			Moves = new List<MasterMove>
			{
				new MasterMove("Enjambre"),
				new MasterMove("Desgarrar algo (o alguien)")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef {
					AttackName = "Roer",
					Dice = DiceTypes.d6,
					Piercing = 1
				}
			} 
		},
		new Monster
		{
			Name = "Estrangulador",
			Organization = TagIDs.Solitario,
			Size = TagIDs.Pequeño | TagIDs.Inteligente, // Combinación de tags Stealthy e Intelligent
			MaxHP = 15, CurrentHP = 15,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Sigiloso, TagIDs.Inteligente },
			Special = new List<string> { "Flexible" },
			Instinct = "Negar la luz",
			Definition = "Algunos dicen que estas criaturas descendieron de la familia de un mago cruel que las obligó a vivir sus vidas bajo tierra. Dicen que sus experimentos lo llevaron a temer al sol y pasaron las eras mientras descendía a la no-vida, arrastrando a su gente con él. Estas cosas se asemejan a los hombres, de alguna manera. Cabeza, cuatro extremidades y todo eso. Solo que su piel está húmeda y gomosa y sus brazos son largos y dedos agarradores. Odian toda vida que lleve el olor del toque del sol, como era de esperar. La envidia, arraigada desde hace mucho tiempo, es difícil de sacudir.",
			Moves = new List<MasterMove>
			{
				new MasterMove("Sujetar a alguien, exprimiendo su aliento"),
				new MasterMove("Arrojar a una criatura sujetada")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Estrangular",
					Dice = DiceTypes.d10
				}
			}
		},
		new Monster
		{
			Name = "Encubridor",
			Organization = TagIDs.Solitario,
			Size = TagIDs.Pequeño,
			MaxHP = 12, CurrentHP = 12,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Sigiloso },
			Special = new List<string> { "Parece una capa" },
			Instinct = "Envolver",
			Definition = "No te pongas esa capa, Gareth. No lo hagas. No sabes de dónde ha venido. Te lo digo, no es buena. ¡Mira! ¡Se movió! No estoy loco, Gareth, ¡se movió! ¡No lo hagas! ¡No! ¡GARETH!",
			Moves = new List<MasterMove>
			{
				new MasterMove("Envolver al desprevenido")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Estrangular",
					Dice = DiceTypes.d10,
					IgnoresArmor = true
				}
			}
		},
		new Monster
		{
			Name = "Guerrero Enano",
			Organization = TagIDs.Horda,
			Size = TagIDs.Pequeño,
			MaxHP = 7, CurrentHP = 7,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Organizado },
			Instinct = "Defender",
			Definition = "Durante siglos, los hombres creyeron que todos los enanos eran masculinos y que todos eran de esta estirpe: guerreros estoicos y orgullosos. Armados con hacha y vistiendo armadura. Enanos fornidos, barbudos y hambrientos de batalla que los empujarían, una y otra vez, fuera de sus minas y túneles con ferocidad. Solo demuestra cuánto saben los hombres sobre las razas más antiguas. Estos individuos son simplemente una vanguardia, y valientemente cumplen con su deber de proteger las riquezas del reino enano. Gánate su confianza y tendrás un aliado de por vida. Gánate su ira y es probable que no te arrepientas durante mucho tiempo.",
			Moves = new List<MasterMove>
			{
				new MasterMove("Rechazarlos"),
				new MasterMove("Llamar refuerzos")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Hacha",
					Dice = DiceTypes.d6
				}
			}
		},
		new Monster
		{
			Name = "Elemental de Tierra",
			Organization = TagIDs.Solitario,
			Size = TagIDs.Enorme,
			MaxHP = 27, CurrentHP = 27,
			Armor = 4,
			Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente },
			Special = new List<string> { "Hecho de piedra" },
			Instinct = "Mostrar la fuerza de la tierra",
			Definition = "Nuestro chamán dice que todas las cosas del mundo tienen un espíritu. Piedras, árboles, un arroyo. Ahora que he visto la tierra agitarse bajo mis pies y los puños de piedra golpear a mis amigos hasta dejarlos medio muertos, me gustaría creer en ese viejo loco. El que vi era enorme, ¡tan grande como una casa! Surgió hirviente de un derrumbe de rocas de la nada y tenía una voz como una avalancha. Ahora rindo mis respetos, con razón. Instinto: Mostrar la fuerza de la tierra",
			Moves = new List<MasterMove>
			{
				new MasterMove("Convertir el suelo en un arma"),
				new MasterMove("Fundirse en la piedra")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Aplastar",
					Dice = DiceTypes.d10,
					Bonus = 5
				}
			}
		},
		new Monster
		{
			Name = "Escarabajo de Fuego",
			Organization = TagIDs.Horda,
			Size = TagIDs.Pequeño,
			MaxHP = 3, CurrentHP = 3,
			Armor = 3,
			Tags = new List<TagIDs> { TagIDs.Cerca },
			Special = new List<string> { "Lleno de llamas" },
			Instinct = "Inflamar",
			Definition = "¡Scarabaeus pyractomena! Qué criatura tan encantadora. ¿Ves cómo su caparazón brilla a la luz de nuestras antorchas? No te acerques demasiado ahora, son temperamentales, ya ves. El fuego en sus entrañas no es solo metafórico, no. Observa cómo incito a la bestia. ¡Ajá! ¡Un chorro de llamas! Inesperado, ¿verdad? Una de estas criaturas sola, si surge desde abajo, puede ser una molestia infernal para una granja o aldea. ¿Un enjambre entero? Hay una razón por la que lo llaman una conflagración de escarabajos de fuego. Instinto: Inflamar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Socavar el suelo"),
				new MasterMove("Brotar desde la tierra"),
				new MasterMove("Rociar llamas")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Llamaradas",
					Dice = DiceTypes.d6,
					IgnoresArmor = true
				}
			}
		},
		new Monster
		{
			Name = "Gárgola",
			Organization = TagIDs.Horda,
			Size = TagIDs.Cerca,
			MaxHP = 3, CurrentHP = 3,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Acaparador, TagIDs.Cerca }, 
			Special = new List<string> { "Alas" },
			Instinct = "Guardar",
			Definition = "Es algo triste, en realidad. Guardianes criados por magos del pasado sin más castillos que proteger. La tarea sagrada de sus ancestros, transmitida en su sangre, los lleva a encontrar un lugar, principalmente ruinas, pero a veces una cueva, colina o acantilado de montaña, y protegerlo como si sus amos aún vivieran debajo. Son famosos por encontrar objetos de valor enterrados bajo la tierra, sin embargo. Encuentra uno de estos reptiles alados y encontrarás un tesoro cercano. Solo ten cuidado, son difíciles de ver y tienden a moverse en grupos. Instinto: Guardar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Atacar con el elemento de sorpresa"),
				new MasterMove("Elevarse al aire"),
				new MasterMove("Fundirse en la piedra")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Garra",
					Dice = DiceTypes.d6
				}
			}
		},
		new Monster
		{
			Name = "Cubo Gelatinoso",
			Organization = TagIDs.Solitario,
			Size = TagIDs.Grande, // Combinación de tags Grande, Sigiloso y Amorphous
			MaxHP = 20, CurrentHP = 20,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.tocar, TagIDs.Sigiloso, TagIDs.Amorfo}, // Cambiado a Manual en lugar de Hand
			Special = new List<string> { "Transparente" },
			Instinct = "Limpiar",
			Definition = "¿Cuántos últimos pensamientos de aventureros fueron 'extraño, este túnel parece más limpio que la mayoría'? Demasiados, y todo por esta amenaza transparente. Una gran masa ácida que se expande para llenar una pequeña cámara o pasillo y luego se desliza, muy lentamente, devorando todo a su paso. No puede comer piedra ni metal y a menudo los tendrá flotando en su masa gelatinosa. Blech. Instinto: Limpiar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Llenar un espacio aparentemente vacío"),
				new MasterMove("Disolver")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Engullir",
					Dice = DiceTypes.d10,
					Bonus = +1,
					IgnoresArmor = true
				}
			}
		},
		new Monster
		{
			Name = "Goblin",
			Organization = TagIDs.Horda, // Combinación de tags Horda y Organizado
			Size = TagIDs.Pequeño,
			MaxHP = 3, CurrentHP = 3,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Organizado}, // Añadido Cerca y Alcance a la lista de Tags
			Special = new List<string>(),
			Instinct = "Multiplicarse",
			Definition = "Nadie parece saber de dónde vinieron estas cosas. Los elfos dicen que son culpa de los enanos, desenterrados de un lugar oculto bajo la tierra. Los enanos dicen que son hijos malos de los elfos, llevados al nacer y criados en la oscuridad. La verdad del asunto es que los goblins siempre han estado aquí y estarán aquí una vez que todas las razas civilizadas hayan caído y desaparecido. Los goblins nunca desaparecen. Simplemente hay demasiados malditos. Instinto: Multiplicarse",
			Moves = new List<MasterMove>
			{
				new MasterMove("¡Cargar!"),
				new MasterMove("Llamar a más goblins"),
				new MasterMove("Retirarse y volver con (muchos) más")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Lanza",
					Dice = DiceTypes.d6
				}
			}
		},
		new Monster
		{
			Name = "Goblin Orkaster",
			Organization = TagIDs.Solitario,
			Size = TagIDs.Pequeño, // Combinación de tags Pequeño, Mágico, Inteligente y Organizado
			MaxHP = 12, CurrentHP = 12,
			Armor = 0,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.lejos, TagIDs.Magico , TagIDs.Inteligente , TagIDs.Organizado }, // Movidos a la lista de Tags
			Special = new List<string>(),
			Instinct = "Aprovechar el poder más allá de su estatura",
			Definition = "Oh señor, ¿quién les enseñó magia? Instinto: Aprovechar el poder más allá de su estatura",
			Moves = new List<MasterMove>
			{
				new MasterMove("Liberar un hechizo mal comprendido"),
				new MasterMove("Derramar el caos mágico"),
				new MasterMove("Usar a otros goblins como escudos")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Orbe de Ácido",
					Dice = DiceTypes.d10,
					Bonus = +1,
					IgnoresArmor = true
				}
			}
		},

		new Monster
		{
			Name = "Goliath",
			Organization = TagIDs.Grupo,
			Size = TagIDs.Grande, 
			MaxHP = 14, CurrentHP = 14,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado, TagIDs.Alcance, TagIDs.Contundente }, 
			Special = new List<string>(),
			Instinct = "Recuperar",
			Definition = "Habitan bajo la tierra porque ya no pertenecen más a la superficie. Una raza inmortal de poderosos titanes huyó de las llanuras y montañas en eras pasadas, expulsados por los hombres y sus héroes. Dejados para esperar en la oscuridad, el odio y la ira calentados por las piscinas de lava en lo más profundo. Se dice que un terremoto es el llanto de nacimiento de un goliath. Algún día recuperarán lo que es suyo.",
			Moves = new List<MasterMove>
			{
				new MasterMove("Sacudir la tierra"),
				new MasterMove("Retirarse, solo para regresar más fuerte")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Maza",
					Dice = DiceTypes.d8,
					Bonus = +7
				}
			}
		},

		new Monster
		{
			Name = "Otyugh",
			Organization = TagIDs.Solitario, 
			Size = TagIDs.Grande,
			MaxHP = 20, CurrentHP = 20,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente }, 
			Special = new List<string> { "Fiebre de Suciedad" },
			Instinct = "Contaminar",
			Definition = "El canto de apareamiento del otyugh es un grito horrible y estridente que suena como una mezcla entre un elefante muriendo y un buitre demasiado entusiasta. El otyugh pasa gran parte de su tiempo parcialmente sumergido en agua sucia y prefiere comer basura sobre cualquier otra comida. Como resultado, a menudo crece gordo y fuerte con los despojos de orcos, goblins y otros subhumanos que viven en cuevas. Sin embargo, acércate demasiado y tendrás uno de sus tentáculos barbados arrastrándote hacia esa mandíbula húmeda y llena de dientes de sierra. Si escapas con vida, será mejor que vayas a un médico, o tu victoria puede ser de corta duración.",
			Moves = new List<MasterMove>
			{
				new MasterMove("Infectar a alguien con fiebre de suciedad"),
				new MasterMove("Lanzar a alguien o algo")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Tentáculos",
					Dice = DiceTypes.d10,
					Bonus = +3
				}
			}
		},

		new Monster
		{
			Name = "Maggot-Squid",
			Organization = TagIDs.Horda, 
			Size = TagIDs.Pequeño,
			MaxHP = 3, CurrentHP = 3,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca }, 
			Special = new List<string> { "Anfibio", "Tentáculos Paralizantes" }, // Agregado a la lista de Special Qualities
			Instinct = "Comer",
			Definition = "Los dioses que crearon esta cosa estaban jugando una broma cruel con la gente civilizada del mundo. El maggot-squid empuña una cara llena de tentáculos horribles y retorcidos que, si te tocan, se siente como ser golpeado por un rayo. Te paralizarán y te masticarán lentamente mientras estás indefenso. Lo mejor es no dejar que llegue a eso. Instinto: Comer",
			Moves = new List<MasterMove>
			{
				new MasterMove("Paralizar con un toque")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Masticar",
					Dice = DiceTypes.d6
				}
			}
		},
		new Monster
		{
			Name = "Purple Worm",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Solo un tag en Size
			MaxHP = 20, CurrentHP = 20,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Excavador" }, // Agregado a la lista de Special Qualities
			Instinct = "Consumir",
			Definition = "¡Iä! ¡Iä! ¡El Gusano Púrpura! ¡Bendita sea su sagrada babosidad! Caminamos, indignos, en sus millas de túneles masivos. Somos solo sombras bajo su gloria violeta y devoradora. Meros acólitos, nosotros que esperamos algún día volver al gran abrazo de su mandíbula con dientes. ¡Que nos consuma! ¡Que devore nuestros hogares y aldeas para que podamos ser llevados! ¡Iä! ¡Iä! ¡El Gusano Púrpura! Instinto: Consumir",
			Moves = new List<MasterMove>
			{
				new MasterMove("Tragar entero"),
				new MasterMove("Tunelar a través de piedra y tierra")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mordisco",
					Dice = DiceTypes.d10,
					Bonus = +5
				}
			}
		},
		new Monster
		{
			Name = "Roper",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Combinación de tags Grande, Sigiloso e Inteligente en Size
			MaxHP = 16, CurrentHP = 16,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance,TagIDs.Sigiloso,TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Piel Similar a Roca" }, // Agregado a la lista de Special Qualities
			Instinct = "Emboscar",
			Definition = "La casualidad evolutiva ha creado un astuto depredador subterráneo. Disfrazado como una formación rocosa, más a menudo una estalactita o estalagmita, el roper espera a que su presa pase por allí. Cuando lo hace, ya sea una rata, un duende o un aventurero imprudente, una masa de tentáculos delgados y azotadores irrumpe desde la piel de la criatura. Cien latigazos en un abrir y cerrar de ojos y la presa aturdida es arrastrada hacia la boca del roper. Sorprendentemente efectivo para algo que parece una roca. Instinto: Emboscar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Atrapar a los desprevenidos"),
				new MasterMove("Desarmar a un enemigo"),
				new MasterMove("Masticar a alguien")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mordisco",
					Dice = DiceTypes.d10,
					Bonus = +1
				}
			}
		},
		new Monster
		{
			Name = "Rot Grub",
			Organization = TagIDs.Horda, // Solo un tag en Organización
			Size = TagIDs.Minusculo, // Solo un tag en Size
			MaxHP = 3, CurrentHP = 3,
			Armor = 0,
			Tags = new List<TagIDs> { TagIDs.tocar }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Excavar en la carne" }, // Agregado a la lista de Special Qualities
			Instinct = "Infectar",
			Definition = "Viven en tu piel. O en tu carne. O en tus globos oculares. Crecen allí y luego, en una exhibición sangrienta y horripilante, se abren camino hacia afuera. Asqueroso. Instinto: Infectar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Excavar bajo la piel"),
				new MasterMove("Poner huevos"),
				new MasterMove("Irrumpir desde una criatura infectada")
			}
		},
		new Monster
		{
			Name = "Spiderlord",
			Organization = TagIDs.Solitario, 
			Size = TagIDs.Grande, 
			MaxHP = 16, CurrentHP = 16,
			Armor = 3,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance,TagIDs.Astuto,TagIDs.Inteligente }, 
			Special = new List<string> { "Excavador" }, 
			Instinct = "Tejer redes (literal y metafóricamente)",
			Definition = "Incluso las arañas tienen sus dioses, susurrados en telarañas con pequeños brazos rezando. Instinto: Tejer redes (literal y metafóricamente)",
			Moves = new List<MasterMove>
			{
				new MasterMove("Atrapar en redes"),
				new MasterMove("Poner un plan en marcha")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mandíbulas",
					Dice = DiceTypes.d8,
					Bonus = +4
				}
			}
		},
		new Monster
		{
			Name = "Troglodyte",
			Organization = TagIDs.Grupo, // Combinación de tags Grupo y Organizado en Organización
			Size = TagIDs.tocar, // Solo un tag en Size
			MaxHP = 10, CurrentHP = 10,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
			Instinct = "Acechar la civilización",
			Definition = "Olvidados hace mucho tiempo, nuestros últimos ancestros restantes habitan en cuevas en las partes salvajes del mundo. Alejados por nuestras ciudades y pueblos, nuestras espadas de hierro y nuestro fuego, estos hombres-simio comen su carne cruda con manos con uñas afiladas y dientes dentados. Atacan a los pueblos de la frontera empuñando garrotes y en números abrumadores para apoderarse de ganado, herramientas y pobres prisioneros para arrastrarlos a las colinas. Conocidos por su ferocidad y su hedor, son una raza antigua y moribunda que todos preferiríamos olvidar que existe. Instinto: Acechar la civilización",
			Moves = new List<MasterMove>
			{
				new MasterMove("Asaltar y retirarse"),
				new MasterMove("Usar armas o magia recuperadas")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Garrote",
					Dice = DiceTypes.d8
				}
			}
		}



	};

	public List<Monster> LowerDeeps = new List<Monster>
	{
		new Monster
		{
			Name = "Aboleth",
			Organization = TagIDs.Grupo, // Solo un tag en Organización
			Size = TagIDs.Grande, // Combinación de tags Grande e Inteligente en Size
			MaxHP = 18, CurrentHP = 18,
			Armor = 0,
			Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Inteligente}, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Telepatía" }, // Agregado a la lista de Special Qualities
			Instinct = "Ordenar",
			Definition = "En lo más profundo bajo la superficie del mundo, en mares de agua dulce intocados por el sol, habitan los aboleth. Peces del tamaño de ballenas, con extraños crecimientos de tentáculos gelatinosos utilizados para explorar las costas sin luz. Son servidos por esclavos: víctimas ciegas y albinas de cualquier raza lo suficientemente desafortunada como para tropezar con ellos, drenadas de pensamiento y vida por los poderes de la mente alienígena de los aboleth. En las profundidades, conspiran entre ellos, cultistas pez construyendo y cavando hacia arriba hacia la superficie hasta que algún día, la atravesarán. Por ahora, duermen y sueñan y guían a sus pálidos secuaces para hacer su voluntad. Instinto: Ordenar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Invadir una mente"),
				new MasterMove("Voltear a los secuaces contra ellos"),
				new MasterMove("Poner un plan en marcha")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Tentáculo",
					Dice = DiceTypes.d10,
					Bonus = +3
				}
			}
		},
		new Monster
		{
			Name = "Dragón del Apocalipsis",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Solo un tag en Size
			MaxHP = 26, CurrentHP = 26,
			Armor = 5,
			Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Divino, TagIDs.Alcance, TagIDs.Contundente, TagIDs.escabroso }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Piel de metal de un grosor de pulgada", "Conocimiento sobrenatural", "Alas" }, // Agregado a la lista de Special Qualities
			Instinct = "Terminar el mundo",
			Definition = "El fin de todas las cosas será un ardor: de árboles, tierra y del aire mismo. Vendrá sobre las llanuras y montañas no desde más allá de este mundo, sino desde su interior. Nacido del seno de la tierra más profunda vendrá el Dragón que Terminará el Mundo. En su paso, todo se convertirá en cenizas y bilis, y el Mundo de Mazmorras, como algo moribundo, se deslizará a través del espacio plano desprovisto de vida. Dicen que adorar al Dragón del Apocalipsis es invitar a la locura. Dicen que amarlo es conocer la nada. El despertar se acerca. Instinto: Terminar el mundo",
			Moves = new List<MasterMove>
			{
				new MasterMove("Poner en marcha un desastre"),
				new MasterMove("Exhalar los elementos"),
				new MasterMove("Actuar con previsión perfecta")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mordisco",
					Dice = DiceTypes.d12,
					Bonus = +9,
					Piercing = 4,
				}
			}
		},
		new Monster
		{
			Name = "Engendro del Caos",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Pequeño, // Solo un tag en Size
			MaxHP = 19, CurrentHP = 19,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente, TagIDs.Amorfo }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Forma de Caos" }, // Agregado a la lista de Special Qualities
			Instinct = "Socavar el orden establecido",
			Definition = "Expulsado de la ciudad, un cultista encuentra refugio en pueblos y aldeas. Descubierto allí, huye a las colinas y rasca su devoción en las paredes de la cueva. Descubierto nuevamente, es perseguido con cuchillo y antorcha hacia las profundidades, arrastrándose cada vez más profundo hasta que, en los lugares más profundos, pierde su camino. Primero olvida su nombre. Luego olvida su forma. Sus dioses del caos, los más amados, lo bendicen con uno nuevo. Instinto: Socavar el orden establecido",		Moves = new List<MasterMove>
			{
				new MasterMove("Reescribir la realidad"),
				new MasterMove("Desatar el caos de su contención")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Toque Caótico",
					Dice = DiceTypes.d10,
					Piercing = 0 // No hay piercing en este ataque
				}
			}
		},
		new Monster
		{
			Name = "Chuul",
			Organization = TagIDs.Grupo, // Solo un tag en Organización
			Size = TagIDs.Grande, // Combinación de tags Grande y Cauteloso en Size
			MaxHP = 10, CurrentHP = 10,
			Armor = 4,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.escabroso, TagIDs.Cauteloso }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Anfibio" }, // Agregado a la lista de Special Qualities
			Instinct = "Dividir",
			Definition = "Tu peor pesadilla de mariscos hecha realidad. Una especie de hombre cangrejo, maldito con inteligencia primordial y bendito con un par de garras afiladas como navajas. Cosas extrañas acechan en las pestilentes pozas en cavernas mejor olvidadas y el chuul es una de ellas. Si ves uno, tu mejor esperanza es una maza pesada para romper su caparazón y tal vez un poco de mantequilla de ajo. Mmmm. Instinto: Dividir",
			Moves = new List<MasterMove>
			{
				new MasterMove("Dividir algo en dos con garras poderosas"),
				new MasterMove("Retirarse al agua")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Garras",
					Dice = DiceTypes.d8,
					Bonus = +1,
					Piercing = 3
				}
			}
		},

		// Deep Elf Assassin
		new Monster
		{
			Name = "Asesino Elfo Profundo",
			Organization = TagIDs.Grupo, // Solo un tag en Organización
			Size = TagIDs.Pequeño, // Combinación de tags Inteligente y Organizado en Size
			MaxHP = 6, CurrentHP = 6,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
			Instinct = "Despreciar a las razas de la superficie",
			Definition = "No fue tan simple como una guerra por religión o territorio. Ninguna disputa entre reinas llevó a la gran separación de los elfos. Fue tristeza. Fue la disminución misma del mundo por las razas menores. La gloria que todos los elfos habían construido se resquebrajaba y se volvía vidrio. Algunos, entonces, eligieron separarse del mundo; llenos de lágrimas, dieron la espalda a hombres y enanos. Sin embargo, hubo otros que fueron dominados por algo nuevo. Un sentimiento que ningún elfo había sentido antes. Rencor. El odio llenó a estos elfos, los retorció y se volvieron contra sus primos más débiles. Algunos todavía permanecen después de la gran exodus hacia abajo. Algunos se esconden entre nosotros con cuchillas envenenadas de araña, impartiendo esa extraña de las penas: la venganza élfica. Instinto: Despreciar a las razas de la superficie",
			Moves = new List<MasterMove>
			{
				new MasterMove("Envenenarlos"),
				new MasterMove("Desatar un hechizo antiguo"),
				new MasterMove("Llamar refuerzos")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Hoja Envenenada",
					Dice = DiceTypes.d8,
					Piercing = 1
				}
			}
		},

		// Deep Elf Swordmaster
		new Monster
		{
			Name = "Maestro de la espada Elfo Profundo",
			Organization = TagIDs.Grupo, // Solo un tag en Organización
			Size = TagIDs.Pequeño, // Combinación de tags Inteligente y Organizado en Size
			MaxHP = 6, CurrentHP = 6,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
			Instinct = "Castigar a los incrédulos",
			Definition = "Los elfos oscuros perdieron la dulzura y la paz suave de sus brillantes primos hace siglos, pero no abandonaron la gracia. Se mueven con una rapidez y belleza que haría brotar una lágrima en el ojo de cualquier guerrero. En la oscuridad, practicaron. Una crueldad ha infectado su esgrima, una maldad que sale a la luz. Hojas con púas y látigos reemplazan las relucientes lanzas-estandarte de las batallas élficas en la superficie. Los maestros de la espada de los clanes elfos oscuros no buscan simplemente matar, sino castigar con cada golpe de sus cuchillas. Maldad y dolor son su moneda. Instinto: Castigar a los incrédulos",
			Moves = new List<MasterMove>
			{
				new MasterMove("Infligir dolor más allá de la medida"),
				new MasterMove("Usar la oscuridad a su favor")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Hoja con Púas",
					Dice = DiceTypes.d8,
					Bonus = +2,
					Piercing = 1
				}
			}
		},
		new Monster
		{
			Name = "Sacerdote Elfo Profundo",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Pequeño, // Combinación de tags Divino, Inteligente y Organizado en Size
			MaxHP = 14, CurrentHP = 14,
			Armor = 0,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Divino, TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Conexión Divina" }, // Agregado a la lista de Special Qualities
			Instinct = "Transmitir la venganza divina",
			Definition = "Los espíritus de los árboles y la dama del sol están lejos, muy lejos de casa en las profundidades donde habitan los elfos oscuros. Nuevos dioses fueron encontrados allí, esperando a que sus hijos regresaran. Dioses de las arañas, los bosques fúngicos y cosas que susurran en las cuevas prohibidas. Los elfos oscuros, siempre sintonizados con el mundo que los rodea, escucharon con intención odiosa a sus nuevos dioses y encontraron una nueva fuente de poder. El odio llama al odio y se hicieron sombrías alianzas. Incluso entre estas filas resentidas, la piedad encuentra una forma de expresarse. Instinto: Transmitir la venganza divina",
			Moves = new List<MasterMove>
			{
				new MasterMove("Tejer hechizos de odio y malicia"),
				new MasterMove("Movilizar a los elfos oscuros"),
				new MasterMove("Transmitir conocimiento divino")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Golpe Divino",
					Dice = DiceTypes.d10,
					Bonus = +2
				}
			}
		},

		// Dragon
		new Monster
		{
			Name = "Dragón",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Combinación de tags Grande, Aterrador y Acaparador en Size
			MaxHP = 16, CurrentHP = 16,
			Armor = 5,
			Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.escabroso, TagIDs.Aterrador, TagIDs.Cauteloso, TagIDs.Acaparador }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Sangre Elemental", "Alas" }, // Agregado a la lista de Special Qualities
			Instinct = "Gobernar",
			Definition = "Son las cosas más grandes y terribles que este mundo jamás tendrá que ofrecer. Instinto: Gobernar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Doblegar un elemento a su voluntad"),
				new MasterMove("Exigir tributo"),
				new MasterMove("Actuar con desprecio")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mordisco",
					Dice = DiceTypes.d12,
					Piercing = 4
				}
			}
		},

		// Gray Render
		new Monster
		{
			Name = "Devorador Gris",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Solo un tag en Size
			MaxHP = 16, CurrentHP = 16,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente }, // Todos los tags adicionales en la lista de Tags
			Instinct = "Servir",
			Definition = "Por sí mismo, el render es una fuerza de destrucción total. Enorme y coriáceo, con una mandíbula de dientes irrompibles y garras a juego, el render parece disfrutar poco más que desgarrar cosas. Piedra, carne o acero, poco importa. Sin embargo, el devorador gris rara vez se encuentra solo. Se vinculan con otras criaturas. Algunas al nacer, otras como criaturas completamente desarrolladas, y un devorador gris seguirá a su amo vinculado a donde quiera que vaya, llevándoles ofrendas de carne y protegiéndoles mientras duermen. Encontrar un render no vinculado significa riquezas seguras, si sobrevives para venderlo. Instinto: Servir",
			Moves = new List<MasterMove>
			{
				new MasterMove("Desgarrar algo en pedazos"),
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Garras Desgarradoras",
					Dice = DiceTypes.d10,
					Bonus = +3,
					Piercing = 3
				}
			}
		},
		new Monster
		{
			Name = "Magmin",
			Organization = TagIDs.Horda, // Solo un tag en Organización
			Size = TagIDs.Inteligente, // Combinación de tags Inteligente, Organizado y Acaparador en Size
			MaxHP = 7, CurrentHP = 7,
			Armor = 4,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Organizado, TagIDs.Acaparador}, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Sangre Ardiente" }, // Agregado a la lista de Special Qualities
			Instinct = "Forjar",
			Definition = "Con forma de enano e industrioso, los magmin se encuentran entre los habitantes más profundos del Mundo de las Mazmorras. Encontrados en ciudades de latón y obsidiana construidas más cerca del núcleo fundido del planeta, los magmin viven una vida dedicada a la artesanía, especialmente la relacionada con el fuego y los objetos mágicos relacionados. Malhumorados y extraños, rara vez se dignan a hablar con solicitantes que aparecen en sus puertas, incluso aquellos que de alguna manera han encontrado una manera de sobrevivir al calor infernal. Aun así, respetan poco más que un artículo finamente hecho y aprender a forjar de un artesano magmin significa desbloquear secretos desconocidos para los herreros de la superficie. Como muchas otras cosas, visitar a los magmin es un juego de riesgo y recompensa. Instinto: Forjar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Ofrecer un intercambio o trato"),
				new MasterMove("Golpear con fuego o magia"),
				new MasterMove("Proporcionar el artículo justo, a un precio")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Martillo Llameante",
					Dice = DiceTypes.d6,
					Bonus = +2
				}
			}
		},

		// Minotaur
		new Monster
		{
			Name = "Minotauro",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Solo un tag en Size
			MaxHP = 16, CurrentHP = 16,
			Armor = 1,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }, // Todos los tags adicionales en la lista de Tags
			Special = new List<string> { "Sentido de dirección infalible" }, // Agregado a la lista de Special Qualities
			Instinct = "Contener",
			Definition = "\"Cabeza de un hombre, cuerpo de un toro. No, espera, tengo eso al revés. Es la cabeza de toro y el cuerpo de un hombre. ¿Pezuñas a veces? ¿Es así? Recuerdo que el viejo rey dijo algo sobre un laberinto. ¡Maldición! Sabes que no puedo pensar bajo esta presión. ¿Qué fue eso? ¡Oh dioses, creo que viene!\" Instinto: Contener",
			Moves = new List<MasterMove>
			{
				new MasterMove("Confundirlos"),
				new MasterMove("Hacer que se pierdan")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Hacha",
					Dice = DiceTypes.d10,
					Bonus = +1
				}
			}
		},

		// Naga
		new Monster
		{
			Name = "Naga",
			Organization = TagIDs.Solitario, // Solo un tag en Organización
			Size = TagIDs.Grande, // Solo un tag en Size
			MaxHP = 12, CurrentHP = 12,
			Armor = 2,
			Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Organizado, TagIDs.Acaparador, TagIDs.Magico }, // Todos los tags adicionales en la lista de Tags
			Instinct = "Liderar",
			Definition = "Ambiciosos y territoriales por encima de casi todo, las nagas rara vez se encuentran sin un culto bien formado e insidioso de seguidores. Lo verás en muchas ciudades de montaña: un símbolo de serpiente garabateado en la pared de una taberna o una iglesia local quemada hasta el suelo. Gente desapareciendo en las minas. Hombres y mujeres que llevan la marca de la serpiente. En el núcleo de todo esto yace una naga: una antigua raza ahora caída en el olvido, aún pavoneándose con la cabeza de un hombre sobre su cuerpo enrollado de serpiente. Existen variaciones de estas criaturas según su linaje y su propósito original, pero todas son maestras manipuladoras y fuerzas mágicas a tener en cuenta. Instinto: Liderar",
			Moves = new List<MasterMove>
			{
				new MasterMove("Enviar a un seguidor a su muerte"),
				new MasterMove("Usar magia antigua"),
				new MasterMove("Ofrecer un trato o pacto")
			},
			Attacks = new List<AttackDef>
			{
				new AttackDef
				{
					AttackName = "Mordida",
					Dice = DiceTypes.d10
				}
			}
		},
		new Monster
{
	Name = "Salamandra",
	Organization = TagIDs.Horda, // Solo un tag en Organización
    Size = TagIDs.Grande, // Combinación de tags Grande, Inteligente, Organizado y Planar en Size
    MaxHP = 7, CurrentHP = 7,
	Armor = 3,
	Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Organizado, TagIDs.Planar }, // Todos los tags adicionales en la lista de Tags
    Special = new List<string> { "Excavación" }, // Agregado a la lista de Special Qualities
    Instinct = "Consumir en llamas",
	Definition = "\"La excavación descubrió lo que los informes llamaban una puerta de basalto. Piedra negra tallada con runas fundidas. Cuando la desenterraron, los magos declararon que estaba inerte, pero evidencia adicional indica que fue una afirmación incorrecta. El equipo entero desapareció. Cuando llegamos, la puerta brillaba. Su luz llenaba toda la caverna. Podíamos ver desde la entrada que la zona se había llenado de estas criaturas, como hombres con piel roja y naranja, altos como un ogro pero con una cola de serpiente donde deberían estar sus piernas. También estaban vestidos, algunos tenían armaduras de cristal negro. Hablaban entre ellos en una lengua que sonaba como grasa en el fuego. Quería irme, pero el sargento no escuchó. Ya has leído lo que pasó después, señor. Sé que soy el único que regresó, pero lo que dije es verdad. La puerta está abierta, ahora. ¡Esto es solo el principio!\" Instinto: Consumir en llamas",
	Moves = new List<MasterMove>
	{
		new MasterMove("Convocar fuego elemental"),
		new MasterMove("Derretir engaños")
	},
	Attacks = new List<AttackDef>
	{
		new AttackDef
		{
			AttackName = "Lanza Llameante",
			Dice = DiceTypes.d6,
			Bonus = +3
		}
	}
}
	};

}
