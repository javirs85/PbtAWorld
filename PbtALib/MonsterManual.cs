using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PbtALib.BaseTextBook;

namespace PbtALib;

public class MonsterManual
{//https://www.dungeonworldsrd.com/monsters/

	public List<MonsterPack> AllMonsterPacks = new List<MonsterPack>
	{
		new MonsterPack
		{
			Name = "Cavernas",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Ankeg",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					MaxHP = 10, CurrentHP = 10,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Acaparador },
					Special = new List<string> { "Excavador" },
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +1,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance}
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
					Tags = new List<TagIDs> {},
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Piercing = 1,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Escabroso}
						}
					}
				},
				new Monster
				{
					Name = "Estrangulador",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño, // Combinación de tags Stealthy e Intelligent
					MaxHP = 15, CurrentHP = 15,
					Armor = 2,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente },
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance}
						}
					}
				},
				new Monster
				{
					Name = "Manto",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					MaxHP = 12, CurrentHP = 12,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Sigiloso },
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							IgnoresArmor = true,
							Tags= new List<TagIDs>{TagIDs.Cerca}
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
					Tags = new List<TagIDs> { TagIDs.Organizado },
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags= new List<TagIDs>{TagIDs.Cerca}
						}
					}
				},
				new Monster
				{
					Name = "Elemental de Tierra",
					FavouriteToken = VTTTokens.BlackBoss,
					Organization = TagIDs.Solitario,
					Size = TagIDs.Enorme,
					MaxHP = 27, CurrentHP = 27,
					Armor = 4,
					Tags = new List<TagIDs> {  },
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = 5,
							Tags= new List<TagIDs>{TagIDs.Alcance, TagIDs.Contundente}
						}
					}
				},
				new Monster
				{
					Name = "Escarabajo de Fuego",
					FavouriteToken = VTTTokens.Red1,
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					MaxHP = 3, CurrentHP = 3,
					Armor = 3,
					Tags = new List<TagIDs> { },
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							IgnoresArmor = true,
							Tags= new List<TagIDs>{TagIDs.Cerca}
						}
					}
				},
				new Monster
				{
					Name = "Gárgola",
					Organization = TagIDs.Horda,
					FavouriteToken = VTTTokens.BlackBoss,
					Size = TagIDs.Pequeño,
					MaxHP = 3, CurrentHP = 3,
					Armor = 2,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Acaparador },
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags= new List<TagIDs>{TagIDs.Cerca}
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
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Amorfo }, // Cambiado a Manual en lugar de Hand
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							IgnoresArmor = true,
							Tags= new List<TagIDs>{TagIDs.tocar}
						}
					}
				},
				new Monster
				{
					Name = "Goblin",
					Organization = TagIDs.Horda, // Combinación de tags Horda y Organizado
					FavouriteToken = VTTTokens.Green1,
					Size = TagIDs.Pequeño,
					MaxHP = 3, CurrentHP = 3,
					Armor = 1,
					Tags = new List<TagIDs> {TagIDs.Organizado }, // Añadido Cerca y Alcance a la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance}
						}
					}
				},
				new Monster
				{
					Name = "Goblin Granadero",
					Organization = TagIDs.Grupo, // Combinación de tags Horda y Organizado
					FavouriteToken = VTTTokens.Green1,
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					Armor = 4,
					Tags = new List<TagIDs> {TagIDs.Organizado, TagIDs.Inteligente, TagIDs.Cauteloso }, // Añadido Cerca y Alcance a la lista de Tags
					Special = new List<string>(),
					Instinct = "Encender la mecha y tirarlo al 'otro' lado del escudo",
					Definition = "Los Goblin Grenadiers trabajan en conjunto con un Goblin Operative y un Bugbear Brute. Cada uno de ellos está equipado con un escudo de torre (del tamaño adecuado), una pica y algunas granadas súper locas. Son especialmente letales cuando forman un muro de escudos para acordonar un pasillo estrecho y luego lanzan explosivos sobre sus escudos. No son sordos, pero mantienen sus oídos tapados con cera y se comunican mediante gestos con la cabeza y las manos. Instinto: enciende la cuerda y colócala en el *otro* lado del escudo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Crear un muro de escudos o levantar una barricada"),
						new MasterMove("Atacar desde detrás de la cobertura"),
						new MasterMove("Tirar una granada (1d10)"),
						new MasterMove("Llamar refuerzos (Goblin Operative o Bugbear bruto)"),
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Pika",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Piercing = 2,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance, TagIDs.tocar}
						}
					}
				},
				new Monster
				{
					Name = "Goblin Operative",
					Organization = TagIDs.Solitario, // Combinación de tags Horda y Organizado
					FavouriteToken = VTTTokens.Green1,
					Size = TagIDs.Pequeño,
					MaxHP = 12,
					Armor = 0,
					Tags = new List<TagIDs> {TagIDs.Sigiloso, TagIDs.Astuto, TagIDs.Organizado, TagIDs.Inteligente }, // Añadido Cerca y Alcance a la lista de Tags
					Special = new List<string>(),
					Instinct = "Permanecer oculto hasta que llegue el momento adecuado",
					Definition = "El Operativo Goblin trabaja en conjunto con un escuadrón de Granaderos Goblin y un Bugbear Brute. El operativo es flexible y desempeña una serie de funciones en su equipo. Él/ella avanza delante del grupo, buscando trampas y emboscadas, abriendo puertas y portones, etc., o monitorea los flancos del grupo para evitar que objetos puntiagudos caigan en el lado equivocado de los escudos de las torres de los Granaderos.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Cambia las tornas a favor de su equipo"),
						new MasterMove("Llama al equipo para pedir refuerzos."),
						new MasterMove("Aplica uno de los muchos venenos a una flecha de ballesta"),
						new MasterMove("Escabullirse, esconderse en muebles, barriles, etc."),
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "ballesta ligera",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Advantage,
							Piercing = 2,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.tocar}
						}
					}
				},
				new Monster
				{
					Name = "Goblin Orkaster",
					Organization = TagIDs.Solitario,
					FavouriteToken = VTTTokens.Green1,
					Size = TagIDs.Pequeño, // Combinación de tags Pequeño, Mágico, Inteligente y Organizado
					MaxHP = 12, CurrentHP = 12,
					Armor = 0,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Inteligente, TagIDs.Organizado }, // Movidos a la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							IgnoresArmor = true,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Lejos}
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
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +7,
							Tags= new List<TagIDs>{TagIDs.Alcance, TagIDs.Contundente}
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
					Tags = new List<TagIDs> {  },
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente}
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
					Tags = new List<TagIDs> { },
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags= new List<TagIDs>{TagIDs.Cerca}
						}
					}
				},
				new Monster
				{
					Name = "Purple Worm",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Enorme, // Solo un tag en Size
					MaxHP = 20, CurrentHP = 20,
					Armor = 2,
					Tags = new List<TagIDs> {  }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							Tags= new List<TagIDs>{TagIDs.Contundente, TagIDs.Alcance}
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
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance}
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
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Enterrarse",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +1,
							Tags= new List<TagIDs>{TagIDs.tocar}
						}
					}
				},
				new Monster
				{
					Name = "Spiderlord",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					MaxHP = 16, CurrentHP = 16,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Inteligente },
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +4,
							Tags= new List<TagIDs>{TagIDs.Cerca, TagIDs.Alcance}
						}
					}
				},
				new Monster
				{
					Name = "Troglodyte",
					Organization = TagIDs.Grupo, // Combinación de tags Grupo y Organizado en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 10, CurrentHP = 10,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags= new List<TagIDs>{TagIDs.Cerca}
						}
					}
				}



			}
		},
		new MonsterPack
		{
			Name = "Lo más profundo",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Aboleth",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Enorme, // Combinación de tags Grande e Inteligente en Size
					MaxHP = 18, CurrentHP = 18,
					Armor = 0,
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					}
				},
				new Monster
				{
					Name = "Dragón del Apocalipsis",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					FavouriteToken = VTTTokens.RedBoss,
					Size = TagIDs.Grande, // Solo un tag en Size
					MaxHP = 26, CurrentHP = 26,
					Armor = 5,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Divino }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d12 },
							Bonus = +9,
							Piercing = 4,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente, TagIDs.Escabroso }
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
					Definition = "Expulsado de la ciudad, un cultista encuentra refugio en pueblos y aldeas. Descubierto allí, huye a las colinas y rasca su devoción en las paredes de la cueva. Descubierto nuevamente, es perseguido con cuchillo y antorcha hacia las profundidades, arrastrándose cada vez más profundo hasta que, en los lugares más profundos, pierde su camino. Primero olvida su nombre. Luego olvida su forma. Sus dioses del caos, los más amados, lo bendicen con uno nuevo. Instinto: Socavar el orden establecido", Moves = new List<MasterMove>
					{
						new MasterMove("Reescribir la realidad"),
						new MasterMove("Desatar el caos de su contención")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque Caótico",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance },
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
					Tags = new List<TagIDs> { TagIDs.Cauteloso }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +1,
							Piercing = 3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Escabroso}
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
					Tags = new List<TagIDs> {  TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Cerca }
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
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +2,
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Cerca }
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
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance}
						}
					}
				},

				// Dragon
				new Monster
				{
					Name = "Dragón",
					FavouriteToken = VTTTokens.RedBoss,
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Combinación de tags Grande, Aterrador y Acaparador en Size
					MaxHP = 16, CurrentHP = 16,
					Armor = 5,
					Tags = new List<TagIDs> {  TagIDs.Aterrador, TagIDs.Cauteloso, TagIDs.Acaparador }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d12 },
							Piercing = 4,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Escabroso }
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
					Tags = new List<TagIDs> { }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Piercing = 3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente }
						}
					}
				},
				new Monster
				{
					Name = "Magmin",
					FavouriteToken = VTTTokens.Red1,
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Inteligente, // Combinación de tags Inteligente, Organizado y Acaparador en Size
					MaxHP = 7, CurrentHP = 7,
					Armor = 4,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Acaparador }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
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
					Tags = new List<TagIDs> {  }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
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
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Acaparador, TagIDs.Magico }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					}
				},
				new Monster
				{
					Name = "Salamandra",
					FavouriteToken = VTTTokens.RedBoss,
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Grande, // Combinación de tags Grande, Inteligente, Organizado y Planar en Size
					MaxHP = 7, CurrentHP = 7,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado, TagIDs.Planar }, // Todos los tags adicionales en la lista de Tags
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
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.tocar }
						}
					}
				}
			}
		},
		new MonsterPack
		{
			Name = "Experimentos retorcidos",
			Monsters = new List<Monster> {
				new Monster
				{
					Name = "Bulette",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Combinación de tags Grande y Constructo en Size
					MaxHP = 20, CurrentHP = 20,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Excavación" }, // Agregado a la lista de Special Qualities
					Instinct = "Devorar",
					Definition = "Un experimentado guardia de caravanas aprende a escuchar las llamadas de un explorador o centinela con un oído agudo. Unos segundos adicionales después de que se levanta la alarma pueden significar vida o muerte. Diferentes gritos significan diferentes respuestas, también; un grito de ¡orcos! significa sacar la espada y prepararse para la batalla, pero un grito de ¡bandidos! indica que podrías negociar. Una alarma de los exploradores que siempre, siempre significa que es hora de empacar, azotar tu caballo y correr hacia las colinas es: ¡TIERRA DE TIBURONES! Instinto: Devorar",
					Moves = new List<MasterMove>
					{
						new MasterMove("Arrastrar presas hacia túneles accidentados"),
						new MasterMove("Emerger de la tierra"),
						new MasterMove("Tragar entero")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							Piercing = 3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Contundente }
						}
					}
				},

				// Chimera
				new Monster
				{
					Name = "Quimera",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size
					MaxHP = 16, CurrentHP = 16,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Hacer lo ordenado",
					Definition = "Bien conocida y categorizada, la quimera es una criatura perfeccionada. Desde los códices del Gremio de Magos hasta las famosas páginas del Compendio de Criaturas de Cullaina, no hay confusión sobre lo que significa quimera. Dos partes de leona, una parte de serpiente, cabeza de cabra hembra y toda la magia viciosa que se pueda reunir. El ritual real puede variar, al igual que algún detalle o dos; los hechiceros más creativos cambian el aliento de fuego por ácido, tal vez. Utilizada como guardiana, asesina o simplemente como un instrumento del caos desencadenado, poco importa. La quimera es el peor tipo de abominación: una afrenta intencional a toda vida natural. Instinto: Hacer lo ordenado",
					Moves = new List<MasterMove>
					{
						new MasterMove("Echar fuego"),
						new MasterMove("Atropellarlos"),
						new MasterMove("Envenenarlos")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					}
				},

				// Derro
				new Monster
				{
					Name = "Derro",
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Grande, // Combinación de tags Devious, Inteligente y Organizado en Size
					MaxHP = 3, CurrentHP = 3,
					Armor = 2,
					Tags = new List<TagIDs> { TagIDs.Constructo, TagIDs.Inteligente, TagIDs.Astuto }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Telepatía" }, // Agregado a la lista de Special Qualities
					Instinct = "Reemplazar a los enanos",
					Definition = "Es típico pensar que todos los monstruos arcanos malignos creados en este mundo son engendrados por magos, hechiceros y sus semejantes. Que los colegios y torres del Mundo de las Mazmorras son el útero de cada sombrío experimento. También se cometen errores en las profundidades de la tierra. Estos, los derro, son los errores de un alquimista enano hace mucho olvidado. Los derro no olvidan, sin embargo. Retorcidos y llenos de odio, los derro pueden ser identificados por sus cráneos hinchados, materia cerebral que ha crecido demasiado. No hablan excepto con pensamientos entre ellos y conspiran en la oscuridad silenciosa para extraer la venganza más dulce: la del creado sobre el creador. Instinto: Reemplazar a los enanos",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llenar una mente con pensamientos extraños"),
						new MasterMove("Tomar control de la mente de una bestia")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Pico",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Digestor",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size
					MaxHP = 16, CurrentHP = 16,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Secreción de ácido digestivo" }, // Agregado a la lista de Special Qualities
					Instinct = "Digestar",
					Definition = "Está bien, la experimentación mágica es una ciencia complicada. Por cada hermoso pegaso hay una criatura a medio hacer que no quedó del todo bien. Entendemos. El elefante trasgo que pensaste que era una gran idea. El Drako Gelatinoso. Solo ejemplos. Sin juicio aquí. De todos modos, tenemos algo para eso. Lo llamamos el Digestor. Sí, tal como suena. Parece extraño, lo sé, y el olor no es el mejor, pero esto, comerá magia como Svenloff el Robusto bebe cerveza. La próxima vez que ocurra uno de estos desafortunados accidentes, simplemente apunta el Digestor hacia él y todos tus problemas desaparecerán. Solo mantenlo vigilado. Maldita cosa se comió mi varita la semana pasada. Instinto: Digestar",
					Moves = new List<MasterMove>
					{
						new MasterMove("Consumir algo"),
						new MasterMove("Absorber sustento")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Ácido",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					}
				},

				// Ethereal Filcher
				new Monster
				{
					Name = "Ratero Etéreo",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Combinación de tags Devious y Planar en Size
					MaxHP = 12, CurrentHP = 12,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Planar }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Excavación" }, // Agregado a la lista de Special Qualities
					Instinct = "Robar",
					Definition = "Cosas desaparecen. Un calcetín, una cuchara de plata, los huesos de tu difunta madre. Culparemos a la criada, o a la mala suerte, o simplemente a un momento de olvido estúpido y seguimos adelante. Nunca llegamos a ver la verdadera causa de estos problemas. La criatura como una araña con manos humanas y ojos tan azules como el profundo plano Etéreo de donde proviene la criatura. Nunca vemos el nido que hace con telarañas de plata astral y objetos robados dispuestos en algún patrón loco. Nunca lo vemos reunir su colección de huesos de dedos de medianos, robados de las manos de los durmientes. Somos afortunados de esa manera. Instinto: Robar",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llevarse algo importante a su guarida planar"),
						new MasterMove("Retirarse al plano Etéreo"),
						new MasterMove("Usar un objeto de su guarida")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga Robada",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +0,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					}
				},

				new Monster
				{
					Name = "Ettin",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 16,
					CurrentHP = 16,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Dos cabezas" }, // Qualities
					Instinct = "Aplastar",
					Definition = "¿Qué podría ser mejor que un gigante de colina enojado e idiota? Uno con dos cabezas. Idea fantástica, realmente. Cosas de grado A.", // La expresión "Instinct: To smash" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar a dos enemigos a la vez"),
						new MasterMove("Defender a su creador")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Porra",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente }
						}
					}
				},

				new Monster
				{
					Name = "Girallon",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Enorme, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 20,
					CurrentHP = 20,
					Armor = 1,
					Tags = new List<TagIDs> { }, // Sin tags adicionales en la lista de Tags
					Special = new List<string> { "Muchos brazos" }, // Qualities
					Instinct = "Gobernar",
					Definition = "El resonar de los tambores de la jungla lo llama. El pedazo de carne en la piedra de sacrificio para atraer al gran simio. Girallon, lo llaman, un nombre de la lengua olvidada de los reyes que criaron a la bestia. Más alto que un edificio, dicen algunos. Envuelto en pelaje de marfil con colmillos tan largos como cimitarras. ¿Cuatro brazos? ¿Seis? Los rumores son difíciles de verificar. Cada año es lo mismo: algún explorador visita los pueblos de la jungla buscando al simio y regresa, nunca del todo igual, nunca con un trofeo. El resonar de los tambores continúa.", // La expresión "Instinct: To rule" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Responder al llamado del sacrificio"),
						new MasterMove("Expulsarlos de la jungla"),
						new MasterMove("Lanzar a alguien")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Manos desgarradoras",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					}
				},

				new Monster
				{
					Name = "Iron Golem",
					FavouriteToken = VTTTokens.BlackBoss,
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 10,
					CurrentHP = 10,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Metal" }, // Qualities
					Instinct = "Servir",
					Definition = "Un elemento básico del arte del encantador. Todo golemista y mecanoturgo en los reinos lo sabe. El hierro es un nombre equivocado, aunque. Estos guardianes están hechos de cualquier metal, en realidad: acero, cobre, o incluso oro, en algunos casos. Tanto un arte como una ciencia, la creación de un buen golem es tan respetada en los Reinos como un puente recién construido o un castillo erigido en las montañas. Vigía incansable, defensor imperturbable, el golem de hierro vive para servir, siguiendo sus órdenes eternamente. Cualquier encantador que se precie puede crear uno, si puede costear los materiales. Si no, Instinct: To serve", // La expresión "Instinct: To serve" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Seguir órdenes implacablemente"),
						new MasterMove("Usar una herramienta o adaptación especial, incorporada")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Puños de metal",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +5,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Contundente }
						}
					}
				},

				new Monster
				{
					Name = "Flesh Golem",
					FavouriteToken = VTTTokens.BlackBoss,
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeño
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 0,
					Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Contundente }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Muchas partes del cuerpo" }, // Qualities
					Instinct = "Vivir",
					Definition = "Trozos y piezas robados en la noche. Cementerios arrancados sigilosamente y tal vez esta noche un brazo, una pierna, otra cabeza (la última se desarmó demasiado pronto). Incluso el más humilde encantador de setos puede arreglárselas con lo que puede y, con un poco de creatividad, bueno, ¿no es solo el colegio el que puede dar vida, hmm? Les mostraremos.", // La expresión "Instinct: To live" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Seguir órdenes"),
						new MasterMove("Desconectar una parte del cuerpo")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Garras y dientes variados",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +2,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Contundente, TagIDs.Contundente }
						}
					}
				},

				new Monster
				{
					Name = "Kraken",
					FavouriteToken = VTTTokens.BlueBoss,
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 20,
					CurrentHP = 20,
					Armor = 2,
					Tags = new List<TagIDs> { }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Acuático" }, // Qualities
					Instinct = "Gobernar el océano",
					Definition = "\"¿Un cephalo-qué? No, chico. No \"un kraken\", sino \"el kraken\". No sé qué tonterías te enseñaron en esa escuela de la que dices que eres, pero aquí, sabemos respetar al Hambriento. Correcto, eso es lo que le llamamos, El Hambriento en las Profundidades para ser más preciso. No es ningún dios, aunque tenemos esos también. ¡Es un calamar! Un calamar poderoso con tentáculos más gruesos que un barril y ojos del tamaño de la luna llena. Inteligente, también, el Hambriento. Sabe justo cuándo atacar: cuando todos ustedes están demasiado borrachos o cansados o se quedaron sin agua limpia, ahí es cuando los atrapa. No, nunca lo he visto. Estoy vivo, ¿no?\"", // La expresión "Instinct: To rule the ocean" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Arrastrar a una persona o barco a una tumba acuática"),
						new MasterMove("Envolverlos en tentáculos")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Tentáculos gigantes",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					}
				},

				new Monster
				{
					Name = "Manticore",
					FavouriteToken = VTTTokens.RedBoss,
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 16,
					CurrentHP = 16,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Contundente, TagIDs.Alcance, TagIDs.Escabroso }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Alas" }, // Qualities
					Instinct = "Matar",
					Definition = "Si la quimera es el primer paso por un oscuro camino, el manticore es una puerta que no se puede cerrar una vez que se ha abierto. Un león, un escorpión, las alas de un draco. Todo difícil de obtener pero no imposible y solo animales, de todos modos. El último componente, la cara sibilante y odiosa de la bestia, es el ingrediente que hace a un manticore tan cruel. Joven o viejo, hombre o mujer, no importa pero que sean humanos, vivos y respirando, casados con la criatura con magia retorcida. Todo sentido de quiénes son se pierde y tal vez eso es una bendición, pero la bestia nace del sufrimiento humano. No es de extrañar, entonces, que todos estén tan ansiosos por matar.", // La expresión "Instinct: To kill" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Envenenarlos"),
						new MasterMove("Destrozar algo")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Aguijón",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance, TagIDs.Escabroso }
						}
					}
				},

				new Monster
				{
					Name = "Owlbear",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Constructo, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 2,
					Tags = new List<TagIDs> { TagIDs.Cerca }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { }, // Qualities
					Instinct = "Cazar",
					Definition = "Cuerpo de oso. Plumas de búho. Pico, garras y excelente visión nocturna. ¿Qué no amar?", // La expresión "Instinct: To hunt" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar desde la oscuridad")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Garras",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},
				new Monster
				{
					Name = "Pegasus",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 10,
					CurrentHP = 10,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Alas" }, // Qualities
					Instinct = "Elevar en el aire",
					Definition = "No pienses que cada criatura no nacida naturalmente es una horrible abominación. No imagines ni por un segundo que son todos tentáculos y gritos y sangre o lo que sea. Toma a esta noble bestia, por ejemplo. ¿No es encantadora? Un hermoso caballo blanco con las alas de un cisne. No parece que debería poder volar, pero lo hace. Los elfos obran milagros, a su manera. Se reproducen fielmente, esa es la pureza de la magia élfica en acción. Nacen de pequeños huevos de cristal y se vinculan con sus jinetes de por vida. Todavía hay algo de belleza en el mundo, tenlo por seguro.", // La expresión "Instinct: To carry aloft" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Llevar a un jinete al aire"),
						new MasterMove("Dar ventaja a su jinete")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Pezuñas afiladas",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Rust Monster",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 3,
					Tags = new List<TagIDs> { TagIDs.Constructo }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Toque corrosivo" }, // Qualities
					Instinct = "Decaer",
					Definition = "Una criatura con una apariencia muy distintiva. Algo así como un grillo rojizo, creo. Piernas largas de grillo, de todos modos. Ciego, también, según tengo entendido; se mueven por ahí con esas largas y parecidas a polillas tentáculos. Se alimentan de esa manera, también. Tamizan montones de metal en busca de las piezas más selectas. Eso es lo que comen, no importa el tipo. Su toque más mínimo lo convierte todo en fragmentos oxidados. La magia dura más, pero bajo la mirada de un monstruo de herrumbre, es una conclusión inevitable. Solo los dioses saben de dónde vinieron, pero son una maldición si valoras tus pertenencias.", // La expresión "Instinct: To decay" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Convertir metal en óxido"),
						new MasterMove("Ganar fuerza al consumir metal")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque corrosivo",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = 0,
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Xorn",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Grande, // Solo un tag en Size, si la definición no contiene ninguno será TagIDs.Pequeño
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 2,
					Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Excavación" }, // Qualities
					Instinct = "Comer",
					Definition = "Come basura hecha por los enanos. Con forma de bote de basura con un radio de brazos para alimentar exceso de roca y piedra en su boca abierta. Comen piedra y excretan luz y calor. Perfecto para operar una mina o excavar una cantera. Una vez que uno se pierde en las alcantarillas debajo de una ciudad, sin embargo, o en los cimientos de un castillo. Estás en un gran problema. Comerán y comerán hasta que no te quede más remedio que derrumbar el lugar sobre ellos y mudarte a algún otro lado. Pregúntale a Burrin, Hijo de Fjornnvald, desterrado de su clan. Apuesto a que podría contarte una historia sobre un xorn.", // La expresión "Instinct: To eat" se mueve a su propia sección.
					Moves = new List<MasterMove>
					{
						new MasterMove("Consumir piedra"),
						new MasterMove("Emitir una ráfaga de luz y calor")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mandíbula",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					}
				}
			}
		},
		new MonsterPack
		{
			Name = "Gentes del reino",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Acolyte",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 2,
					CurrentHP = 2,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Servir diligentemente" }, // Qualities
					Instinct = "Cumplir deberes con devoción",
					Definition = "\"No todos pueden ser el Sumo Sacerdote\", decían. \"No todos pueden empuñar la Torre Blanca\", decían. \"Friega el suelo\", me dijeron. El Sobregod Catónico no quiere un suelo sucio, ¿verdad? Decían que sería iluminación y magia. Bah. Son rodillas magulladas y manos en el lavadero. Si solo hubiera sido un clérigo, en cambio.\"",
					Moves = new List<MasterMove>
					{
						new MasterMove("Seguir dogma"),
						new MasterMove("Ofrecer recompensa eterna por acciones mortales")
					}
				},

				new Monster
				{
					Name = "Adventurer",
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Entusiasmo sin fin" }, // Qualities
					Instinct = "Aventurar o morir intentándolo",
					Definition = "\"Escoria de la tierra, eso son. Un grupo de hombres y mujeres armados llegan paseando al pueblo, blandiendo lo que, para todos los efectos, es suficiente poder mágico y mundano para arrasar todo el lugar. Trayendo consigo bolsas y bolsas de botín, aún goteando sangre de algún pobre desgraciado al que tuvieron que matar para conseguirlo. Un desastre económico esperando a suceder, si me preguntas. Todo el sistema queda completamente desarticulado. Asesinos errantes peligrosos e impredecibles. Oh, espera, ¿eres un aventurero? Retiro lo dicho.\"",
					Moves = new List<MasterMove>
					{
						new MasterMove("Embarcarse en una tarea absurda"),
						new MasterMove("Actuar impulsivamente"),
						new MasterMove("Compartir cuentos de hazañas pasadas")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Bandit",
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
					Special = new List<string> { "Desesperación es la consigna de la bandolería" }, // Qualities
					Instinct = "Robar",
					Definition = "La desesperación es la consigna de la bandolería. Cuando las cosas están difíciles, ¿qué más se puede hacer que buscar un arma y unirse a un clan de hombres y mujeres desagradables? Robo de carreteras, caza furtiva, estafas y timos y asesinatos más viles, pero todos tenemos que comer, ¿quién puede culparlos? Por otro lado, hay maldad en los corazones de algunos y ¿quién dice que la desesperación no es una necesidad para saciar los instintos más bajos? De todos modos, es esto o morir de hambre, a veces.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Robar algo"),
						new MasterMove("Exigir tributo")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},
				new Monster
				{
					Name = "Bandit King",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Liderar",
					Definition = "Mejor reinar en el infierno que servir en el cielo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Hacer una demanda"),
						new MasterMove("Extorsionar"),
						new MasterMove("Derrocar el poder")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Cuchillo de confianza",
							Dices = new List<DiceTypes> { DiceTypes.d10, DiceTypes.d10 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Fool",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Burlarse",
					Definition = "No hay más que una persona en toda la corte del Rey a la que se le permite hablar la verdad. La verdad real, directa y honesta sobre cualquier cosa. El bufón lo envuelve todo en campanas y saltos y pintura facial polvorienta, pero ¿quién más puede decirle al Rey qué pasa? Puedes confiar en un bufón, dicen, especialmente cuando te ha puesto rojo de vergüenza y preferirías ahogarlo en un pozo de aguas residuales.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Exponer injusticia"),
						new MasterMove("Hacer una travesura")
					}
				},

				new Monster
				{
					Name = "Guardsman",
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size, será TagIDs.Pequeno
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Hacer lo ordenado",
					Definition = "Protector noble o simple alborotador borracho, a menudo no hace ninguna diferencia para este tipo. Casi tan orgulloso como un caballero noble, la guardia de la ciudad es, no obstante, una profesión antigua. Estos individuos de la policía a menudo visten con los colores de su señor (cuando puedes verlo bajo el barro) y, dependiendo de la riqueza de ese señor, incluso podrían tener un arma decente y alguna armadura que les quede. Esos son los afortunados. Aun así, alguien tiene que estar allí para vigilar la puerta cuando se avistan a los Jinetes Negros en el bosque. Demasiados de nosotros les debemos la vida a estas almas. Recuerda eso la próxima vez que uno te insulte ebriamente a tu madre, ¿eh?",
					Moves = new List<MasterMove>
					{
						new MasterMove("Cumplir con la ley"),
						new MasterMove("Obtener ganancias")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Lanza",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					}
				},
				new Monster
				{
					Name = "Halfling Thief",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Sigiloso, TagIDs.Astuto }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Vivir una vida de lujo robado",
					Definition = "Sería absurdo sacar conclusiones sobre las personas solo porque sean buenas en una cosa u otra. Aunque, un pala es un pala, ¿verdad? O tal vez solo el tipo de mediano bueno, suave y dulce tiene la mente para quedarse en sus hogares en las colinas verdes y no son el tipo que encuentras en los suburbios y tabernas del mundo de los hombres. Quizás están allí para cortar tu bolsa por llamarte 'mediano' en primer lugar. No todos toman amablemente el título. O están jugando un juego, fingiendo ser un niño necesitado de limosnas, y tus arrogantes ojos ni siquiera pueden ver la diferencia hasta demasiado tarde. Bueno, poco importa. Se han ido con tu moneda antes de que te des cuenta de que lo merecías.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Robar"),
						new MasterMove("Aparentar amistad")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Hedge Wizard",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Magico }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Aprender",
					Definition = "No todos los que manejan las artes arcanas son magos aventureros. Ni nigromantes en mausoleos o hechiceros de sangre antigua. Algunos son solo hombres y mujeres mayores, lo suficientemente inteligentes como para haber descubierto uno o dos trucos. Podría volverlos un poco locos obtener ese conocimiento, pero si tienes una maldición que romper o un amor que demostrar, puede ser que un mago de la charca te ayude, si puedes encontrar su choza podrida en el pantano y pagar el precio que pide.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Lanzar casi el hechizo correcto (por un precio)"),
						new MasterMove("Hacer tratos más allá de su comprensión")
					},
					Attacks = new List<AttackDef> { }, // Sin ataques según la descripción
				},

				new Monster
				{
					Name = "High Priest",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Magico }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Liderar",
					Definition = "Respetados por todos los que los miran, los altos sacerdotes y abades de Dungeon World son tratados con una especie de reverencia. Ya sea que rindan homenaje a Ur-thuu-hak, el Dios de las Espadas, o murmuren oraciones silenciosas a Namiah, preciosa hija de la paz, saben algo que tú y yo nunca sabremos. Los dioses les hablan como un vendedor-de-mercancías podría hablarnos en el mercado. Por esto, por el llevar-secretos y el saber-cosas, les damos un amplio margen mientras pasan con sus ropas brillantes.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Establecer la ley divina"),
						new MasterMove("Revelar secretos divinos"),
						new MasterMove("Encargar emprendimientos divinos")
					},
					Attacks = new List<AttackDef> { }, // Sin ataques según la descripción
				},
				new Monster
				{
					Name = "Hunter",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Sobrevivir",
					Definition = "Las tierras salvajes son hogar no solo de bestias con cuerno y escama. También hay hombres y mujeres allí, aquellos que huelen la sangre en el viento y acechan las llanuras con las pieles de sus presas. Ya sea con un arco largo de confianza comprado en un raro viaje a la ciudad o con un cuchillo de hueso y tendón, estas personas tienen más en común con las cosas que rastrean y comen que con los de su propia especie. Solemnes, sombríos y silenciosos, encuentran una especie de paz en la naturaleza.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Traer noticias de las tierras salvajes"),
						new MasterMove("Matar a una bestia")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Arco desgastado",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Lejos }
						}
					}
				},

				new Monster
				{
					Name = "Knight",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 4,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado, TagIDs.Cauteloso }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Vivir por un código",
					Definition = "¿Qué joven no se aferra a la barandilla en la poderosa justa, cegado por el sol en su brillante armadura, deseando ser aquel adornado con acero y cabalgando para complacer al Rey y la Reina? ¿Qué joven campesino con nada más que un pan y una cerda coja no desearía cambiarlo todo por la lanza y el brillante estandarte? Un caballero es muchas cosas: un guerrero sagrado, una espada jurada, a veces también un villano, pero un caballero no puede evitar ser un símbolo para todos los que la ven. Un caballero significa algo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Tomar una postura moral"),
						new MasterMove("Liderar soldados en batalla")
					},
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada",
							Dices = new List<DiceTypes> { DiceTypes.d10, DiceTypes.d10 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = 0,
							IgnoresArmor = false,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					}
				},

				new Monster
				{
					Name = "Merchant",
					Organization = TagIDs.Grupo, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Obtener beneficio",
					Definition = "\"Bastones de diez pies. Consigan sus bastones de diez pies aquí. Antorchas, brillantes y calientes. Mulas también, tercas pero de raza inmaculada. ¿Necesitas un saco de lino? ¡Aquí mismo! Ven y lleva tus bastones de diez pies.\"",
					Moves = new List<MasterMove>
					{
						new MasterMove("Proponer un proyecto comercial"),
						new MasterMove("Ofrecer una 'oferta'")
					},
					Attacks = new List<AttackDef> { }, // Sin ataques según la descripción
				},

				new Monster
				{
					Name = "Noble",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Gobernar",
					Definition = "¿Se les concede su lugar por los dioses, tal vez? ¿Es por eso que pueden pasar sus riquezas y poder por nacimiento? Algún truco o encantamiento de la sangre, tal vez. El campesino dobla la rodilla y se arrastra y trabaja y el noble viste la elegancia de su lugar y, dicen, todos tenemos nuestras cargas. Me da la sensación de que nosotros tenemos que cargar piedras mientras ellos cargan su peso en oro. Debe ser una vida dura.",
					Moves = new List<MasterMove> {
						new MasterMove("Dar una orden"),
						new MasterMove("Ofrecer una recompensa")
					}
				},
				new Monster
				{
					Name = "Peasant",
					Organization = TagIDs.Horda, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs> { TagIDs.Inteligente }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Arreglárselas",
					Definition = "Cubiertos de suciedad, pisoteados en la parte inferior de la gran cadena del ser, todos nos mantenemos sobre las espaldas de aquellos que cultivan nuestra comida en sus granjas. Algunos campesinos lo hacen mejor que otros, pero ninguno verá una moneda de oro en su día. Soñarán de noche cómo algún día, de alguna manera, lucharán contra un dragón y salvarán a una princesa. No actúes como si no fueras uno antes de perder el poco sentido que tenías, aventurero."
				},

				new Monster
				{
					Name = "Rebel",
					Organization = TagIDs.Horda, // Varios tags en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Alterar el orden",
					Definition = "En el campo serían llamados proscritos y expulsados o asesinados. Sin embargo, la ciudad está llena de lugares para esconderse. Sótanos húmedos para estudiar mapas y planear y conspirar contra un sistema corrupto. Como ratas, roen lejos el orden, ya sea para suplantarlo de nuevo o simplemente erosionarlo todo. La línea entre el cambio y el caos es fina; algunos rebeldes caminan esa delgada línea y otros solo quieren verlo todo arder. El disfraz, un cuchillo en la oscuridad o una antorcha arrojada en el momento adecuado son todas herramientas del rebelde. La ardiente marca de la anarquía es un miedo común entre los nobles de Dungeon World. Estos hombres y mujeres son la razón."
				},

				new Monster
				{
					Name = "Soldier",
					Organization = TagIDs.Horda, // Varios tags en Organización
					Size = TagIDs.Pequeño, // Solo un tag en Size
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado }, // Todos los tags adicionales en la lista de Tags
					Instinct = "Luchar",
					Definition = "Para un plebeyo con un brazo fuerte, a veces es esto o ser un bandido. Es llevar los colores y ponerse una armadura que no encaja bien y marchar hacia lo desconocido con otros mil hombres y mujeres asustados reclutados para luchar en las guerras de nuestro tiempo. Podrían estar escondidos en el bosque, viviendo de alces cazados furtivamente y esquivando la guardia del rey. Mejor arriesgar la vida en servicio a una causa. Tirar valientemente el destino con los compañeros y esperar salir del otro lado todavía entero. Además, los nobles necesitan hombres y mujeres fuertes. ¿Qué dicen? Un puñado de soldados vence a una boca llena de argumentos."
				},
				new Monster
				{
					Name = "Spy",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size según la descripción
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs>(),
					Instinct = "Infiltrarse",
					Definition = "Queridos por los reyes pero nunca realmente confiados. Misteriosos, secretos y cautivadores, la vida de un espía es, si le preguntas a un plebeyo, llena de romance e intriga. Son un cuchillo en la oscuridad y un par de ojos vigilantes. Un espía puede ser tu mejor amigo, tu amante o ese anciano que ves en el mercado todos los días. Nunca se sabe. Demonios, tal vez eres un espía, dicen que hay magia que puede cambiar las mentes de la gente sin que lo sepan. ¿Cómo podemos confiar en ti?"
				},

				new Monster
				{
					Name = "Manitas",
					Organization = TagIDs.Solitario, // Solo un tag en Organización
					Size = TagIDs.Pequeño, // Sin tag en Size según la descripción
					MaxHP = 0, // Sin HP según la descripción
					CurrentHP = 0,
					Armor = 0, // Sin armadura según la descripción
					Tags = new List<TagIDs>(),
					Instinct = "Crear",
					Definition = "Se dice que si ves a un chapucero en el camino y no le ofreces un trago de cerveza o algo de tu comida, dejará una maldición de mala suerte. Un chapucero es algo divertido. Estos extraños a menudo viajan por los caminos entre pueblos con sus carros de cosas raras y mulas favoritas. Con un perro raído y siempre una historia que contar. A veces, también el correo, si tienes suerte y vives en un lugar donde no llega la Correspondencia Real. Si eres amable, tal vez te vendan una rosa que nunca se marchita o un reloj que suena con el sonido de la risa de las hadas. O tal vez solo sean vendedores antisociales. Nunca se sabe, ¿verdad?"
				}

			}
		},
		new MonsterPack
		{
			Name = "Hordas Voraces",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Formiano Zángano",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Cauteloso },
					MaxHP = 7,
					CurrentHP = 7,
					Armor = 4,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Conexión con la Colmena", "Insectoide" },
					Instinct = "Seguir órdenes",
					Definition = "Con justa causa, dicen que estas criaturas (como todos los insectos, realmente) están reclamadas por los poderes de la Ley. Son orden hecha carne, una sociedad perfectamente estratificada en la que cada larva, cría y adulto conoce su lugar en la gran colmena. El formiano es una extraña intersección entre hombres y hormigas. (Aunque hay tribus aladas que parecen avispas en el Desierto Occidental, he oído. Y algunas con grandes brazos dentados como mantis en los bosques del este.) Altos, con un caparazón duro y una mente aún más dura, estos formianos en particular son la casta inferior. Trabajan las colinas y panal con alegría monomaniaca que solo puede ser conocida por una mente tan alienígena.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Dar la alarma"),
						new MasterMove("Crear valor para la colmena"),
						new MasterMove("Asimilar")
					}
				},
				new Monster
				{
					Name = "Formiano Capataz",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Cauteloso },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Látigo con Púas",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Conexión con la Colmena", "Insectoide" },
					Instinct = "Mandar",
					Definition = "Se necesitan dos manos para gobernar un imperio: una para empuñar el cetro y otra para azotar. Estas criaturas hormiga son ese látigo. Por suerte para ellos, con dos brazos adicionales, eso es mucho látigo para azotar. Supervisan las vastas enjambres de drones trabajadores que construyen las poderosas cavernas y zigurats que salpican los lugares donde se encuentran los formianos. Uno de cada cien, estos brutos son dos o tres pies más altos que sus parientes pálidos y casi sin mente, y tienen un ingenio más agudo y cruel para igualar. A menudo ignorarán a las razas blandas (como nos llaman) si no interferimos en un proyecto, pero ponte en el camino de La Gran Obra y espera nada menos que toda su atención. No quieres toda su atención.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Ordenar drones a la batalla"),
						new MasterMove("Poner en movimiento grandes números")
					}
				},
				new Monster
				{
					Name = "Formiano Centurión",
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Cauteloso },
					Size = TagIDs.Pequeño,
					MaxHP = 7,
					CurrentHP = 7,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Lanza con Púas",
							Dices = new List<DiceTypes> { DiceTypes.d6, DiceTypes.d6 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Conexión con la Colmena", "Insectoide", "Alas" },
					Instinct = "Luchar según lo ordenado",
					Definition = "Ya sea en forma de legionario, parte del ejército permanente formiano, o como guardia pretoriana de la reina, cada colmena formiana contiene un gran número de estos insectoides peligrosos. Más oscuros en el caparazón, a menudo marcados con surcos y las marcas ceremoniales que los distinguen de sus drones, los centuriones formianos son su fuerza de combate y con razón. Nacidos, criados y viviendo con el propósito singular de matar a los enemigos de su colmena, luchan con una mente y cien espadas. Hasta ahora, los poderes de la Ley han visto conveniente ahorrar a la humanidad una gran guerra con estas criaturas, pero los hemos visto en escaramuzas: descendiendo a veces sobre pueblos fronterizos con sus alas parpadeando en el calor o saliendo de un montículo arenoso para limpiar una mina recién excavada. El suyo es un derramamiento de sangre ordenado, cometido sin placer sino la consecución de un objetivo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Avanzar como uno solo"),
						new MasterMove("Convocar refuerzos"),
						new MasterMove("Dar la vida por la colmena")
					}
				},
				new Monster
				{
					Name = "Reina Formiana",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Cauteloso, TagIDs.Acaparador },
					Size = TagIDs.Pequeño,
					MaxHP = 24,
					CurrentHP = 24,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mandíbulas aplastantes",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Conexión con la Colmena", "Insectoide" },
					Instinct = "Expandir formianos",
					Definition = "En el corazón de cada colmena, sin importar su tamaño o tipo, vive una reina. Tan grande como cualquier gigante, se sienta protegida por su guardia, servida por cada dron y capataz con su propio propósito singular: expandir su especie y hacer crecer la colmena. Parir los huevos. Nutrir. No entendemos las mentes de estas criaturas, pero se sabe que pueden comunicarse con sus hijos, de alguna manera, a través de vastas distancias y que comienzan a enseñarles las formas de la tierra, la piedra y la guerra mientras aún son larvas pálidas y retorcidas, sin decir una palabra. Matar a una es sembrar el caos en la colmena; sin su reina, el resto se vuelve uno contra otro en una rabia ciega y loca.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llamar a cada formiano que ha engendrado"),
						new MasterMove("Liberar una mutación larval medio formada"),
						new MasterMove("Organizar y dar órdenes")
					}
				},
				new Monster
				{
					Name = "Rastreador Gnoll",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 1,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Arco",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Rastreador de olores" },
					Instinct = "Acechar debilidades",
					Definition = "Una vez que huelen tu sangre, no puedes escapar. No sin intervención de los dioses, o al menos los guardabosques del duque. La maleza del desierto es un lugar peligroso para explorar por tu cuenta y si caes y te rompes la pierna o comes el cactus equivocado, bueno, tendrás suerte si mueres de sed antes de que los gnolls te encuentren. Prefieren a su presa viva, ya ves; romper huesos y los gritos de los moribundos añaden una especie de suculencia a una comida. Criaturas repugnantes, ¿verdad? Te perseguirán, lenta y constantemente, mientras mueres. Si escuchas risas en el viento del desierto, bueno, mejor reza para que la Muerte venga a buscarte antes de que lo hagan ellos."
			+ " Instinto: Acechar debilidades",
					Moves = new List<MasterMove>
					{
						new MasterMove("Rastrear obstinadamente a la presa"),
						new MasterMove("Atacar en un momento de debilidad")
					}
				},
				new Monster
				{
					Name = "Emissario Gnoll",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 18,
					CurrentHP = 18,
					Armor = 1,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga ceremonial",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Rastreo de olores" },
					Instinct = "Compartir perspicacia divina",
					Definition = "¡Oh, un emisario! Qué agradable. Sospecho que no sabías que los gnolls tenían embajadores, ¿verdad? Sí, incluso estas hienas raquíticas tienen que comportarse bien a veces. No, no con nosotros. Ni con los enanos tampoco. No, el emisario es el que, entre sus compañeros de camada, trata directamente con su goteante señor demoníaco. ¿Aterrador? Desde luego. Cada sabueso tiene un amo con la mano en la cadena. Este gnoll escucha la voz de su amo. La escucha y obedece.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Transmitir influencia demoníaca"),
						new MasterMove("Impulsar a la manada en un frenesí")
					}
				},
				new Monster
				{
					Name = "Gnoll Alpha",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 2,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada",
							Dices = new List<DiceTypes> { DiceTypes.d10, DiceTypes.d10 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = 0, // No especificaste un bono específico en el daño, ajusta según sea necesario
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Rastreo de olores" },
					Instinct = "Impulsar la manada",
					Definition = "Cada manada tiene su líder. Más grande, tal vez, sería la forma más simple. A menudo, sin embargo, con estos mutts delgados y sucios, no se trata del tamaño ni de los dientes afilados, sino de la crueldad. De la disposición a matar a tus hermanos y comerlos mientras la manada observa. Disposición a profanar la manada de una manera que los someta a ti. Si son tan horribles entre ellos, hacia su propia familia viva, piensa en cómo deben vernos a nosotros. Es difícil ser simplemente carne en una tierra de carnívoros.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Exigir obediencia"),
						new MasterMove("Enviar a la manada a cazar")
					}
				},
				new Monster
				{
					Name = "Guerrero de Sangre Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño, // Cambiado a Mediano según tus indicaciones
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Hoja dentada",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +2,
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Escabroso }
						}
					},
					Instinct = "Luchar",
					Definition = "La horda orca es una colección salvaje, sedienta de sangre y llena de odio de tribus. Hay mitos e historias que cuentan el origen de su furia: una maldición demoníaca, una patria destruida, magia élfica malinterpretada, pero la verdad se ha perdido en el tiempo. Cada orco capaz, ya sea hombre o mujer, niño o anciano, jura lealtad al jefe de guerra y su tribu y porta la hoja dentada de un guerrero de sangre. Los hombres son entrenados para pelear y matar, los orcos nacen para eso.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Luchar con abandono"),
						new MasterMove("Regocijarse en la destrucción")
					}
				},
				new Monster
				{
					Name = "Berserker Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Grande, // Cambiado a Grande según tus indicaciones
					MaxHP = 20,
					CurrentHP = 20,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Cuchilla",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5, // No especificaste un bono específico en el daño, ajusta según sea necesario
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Mutaciones" },
					Instinct = "Enfurecerse",
					Definition = "Manchados en el ritual impío de la Unción Por la Sangre de la Noche, algunos guerreros de la horda ascienden a una especie de caballería retorcida. Intercambian su cordura por este honor, adentrándose a medio camino en un mundo de locura giratoria. Esto hace que los berserkers sean los más grandes de su tribu, aunque con el tiempo, el caos se propaga. El raro berserker que vive más de unos pocos años se vuelve horrible y retorcido, creciendo cuernos o un brazo adicional con el que agarrar las cuchillas de hierro que prefieren en la batalla.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Entrar en un frenesí"),
						new MasterMove("Desatar el caos")
					}
				},
				new Monster
				{
					Name = "Rompedor Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					MaxHP = 16,
					CurrentHP = 16,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Martillo",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente, TagIDs.Cerca }
						}
					},
					Instinct = "Aplastar",
					Definition = "Antes de aventurarte por la tierra de la horda, valiente señor, escucha un momento la historia de Sir Regnus. Regnus era como tú, señor, un paladín de la Orden, todo resplandor en su armadura y con un escudo tan alto como un hombre. Orgulloso de ello, también; se llamaba a sí mismo Espejoescudo. Cuenta la leyenda que había puesto sus ojos en rescatar a algún sacerdote perdido, un secuestro de la abadía en las fronteras. Regnus se encontró con algunos orcos en sus viajes, una docena más o menos, y pensó, como uno podría pensar, que no serían rival. La batalla se unió y todo iba bien hasta que uno de esos orcos emergió de la refriega con un martillo más grande que el que cualquier hombre debería ser capaz de blandir. Dicen que estaba construido más como un ogro o un troll y, con un solo golpe, aplastó a Regnus al suelo, escudo y todo. No era un orc ordinario, dicen. Era un rompedor. No pueden hacer placas propias, ¿ves?, así que tal vez sea la envidia lo que impulsa a estas robustas criaturas a aplastar y destrozar como lo hacen. Táctica efectiva, sin embargo. Ten cuidado ahí fuera.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Derribar a los poderosos"),
						new MasterMove("Aplastar a los orgullosos")
					}
				},
				new Monster
				{
					Name = "Ojo Uno Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Magico, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Infligir heridas",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +2, // No especificaste un bono específico en el daño, ajusta según sea necesario
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente, TagIDs.Escabroso }
						}
					},
					Special = new List<string> { "Un ojo" },
					Instinct = "Odiar",
					Definition = "En nombre de Aquel de la Vista Hendida y por el Primer Sacrificio de Carne Élfica invocamos a los Viejos Poderes. Por el Segundo Sacrificio, hago mi reclamo a lo que es mío: la magia oscura de la Noche. ¡A Su imagen, camino hacia Gor-sha-thak, el Horca de Hierro! ¡Llamo a las runas! ¡Llamo al cielo nublado! Toma este órgano mortal, come de la carne de nuestro enemigo y dame lo que me pertenece.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Desgarrar la carne con magia divina"),
						new MasterMove("Arrancar un ojo"),
						new MasterMove("Hacer un sacrificio y crecer en poder")
					}
				},
				new Monster
				{
					Name = "Chamán Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño, // Asumí Mediano según la descripción
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Explosión elemental",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = 0, // No especificaste un bono específico en el daño, ajusta según sea necesario
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.tocar, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Poder elemental" },
					Instinct = "Fortalecer a los orcos",
					Definition = "Hay jefes y líderes de tribus entre los orcos. Hay quienes se levantan para tomar el poder y caen bajo las maquinaciones de sus enemigos. Sólo hay un Jefe de Guerra. Un orco en toda la horda que se destaca del resto, portador de las bendiciones tanto del Un Ojo como de los Chamanes. Pero aquel que camina con los elementos bajo la Noche. Pero alguien que porta la Espada de Hierro de las Edades y lleva sobre sus hombros el antiguo rencor contra las razas civiles. El Jefe de Guerra debe ser respetado, obedecido y, sobre todo, temido. Toda la gloria para el Warchie",
					Moves = new List<MasterMove>
					{
						new MasterMove("Dar protección de la tierra"),
						new MasterMove("Dar el poder del fuego"),
						new MasterMove("Dar la velocidad del agua"),
						new MasterMove("Dar la claridad del viento")
					}
				},
				new Monster
				{
					Name = "Esclavista Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 3,
					CurrentHP = 3,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Látigo",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = 0,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Instinct = "Tomar",
					Definition = "Velas rojas ondean en el mar del sur. Velas rojas y barcos de hueso, madera antigua y hierro. La flota de guerra de la horda. Los orcos por allá han tomado el mar, hostigando pueblos isleños y llevándose a pescadores y sus familiares. Se dice que la costumbre se está extendiendo hacia el norte y los orcos aprenden el valor del trabajo libre. Se dedican a ello como un deber sagrado, especialmente si pueden poner sus manos en elfos. Difícil pensar en un destino más sombrío que vivir toda tu vida en una galera orca, con la espalda encorvada bajo el látigo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atrapar a alguien bajo una red"),
						new MasterMove("Drogarlos")
					}
				},
				new Monster
				{
					Name = "Cazador de Sombras Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Inteligente, TagIDs.Sigiloso },
					Size = TagIDs.Pequeño,
					MaxHP = 10,
					CurrentHP = 10,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga envenenada",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = 0,
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Capa de sombras" },
					Instinct = "Matar en la oscuridad",
					Definition = "No todos los ataques de los orcos son antorchas y gritos y esclavitud. Entre aquellos que siguen a Aquel de la Vista Hendida, el veneno y el asesinato en la oscuridad se consideran artes sagradas. Entra el cazador de sombras. Orcos envueltos en la magia de la Noche que se deslizan en campamentos, pueblos y templos y terminan con las vidas de aquellos dentro. No te distraigas tanto por los aullidos de los berserkers que no notes el cuchillo en tu espalda.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Derretirte en las sombras"),
						new MasterMove("Envolverlos en oscuridad")
					}
				},
				new Monster
				{
					Name = "Jefe de Guerra Orc",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño, // Asumí Mediano según la descripción
					MaxHP = 16,
					CurrentHP = 16,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada de Hierro de las Edades",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Bendiciones de Ojo Uno, Bendiciones de Chamán, Protección divina contra daño mortal" },
					Instinct = "Dirigir",
					Definition = "Hay jefes y hay líderes de las tribus entre los orcos. Hay quienes se elevan para tomar el poder y caen bajo las maquinaciones de sus enemigos. Pero solo hay un Jefe de Guerra. Solo un orco en toda la horda que se destaca entre los demás, llevando las bendiciones de los Ojo Uno y los Chamanes ambos. Pero uno que camina con los elementos bajo la Noche. Pero uno que lleva la Espada de Hierro de las Edades y carga la antigua rencilla contra las razas civilizadas sobre sus hombros. El Jefe de Guerra debe ser respetado, obedecido y, sobre todo, temido. Toda gloria al Jefe de Guerra.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Hacer un espectáculo de poder"),
						new MasterMove("Enfurecer a las tribus")
					}
				},
				new Monster
				{
					Name = "Espía Tritón",
					FavouriteToken = VTTTokens.Blue1,
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 2,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Tridente",
							Dices = new List<DiceTypes> { DiceTypes.d10, DiceTypes.d10 },
							RollType = RollTypes.Roll_Disadvantage,
							Tags = new List<TagIDs> { TagIDs.tocar, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Acuático" },
					Instinct = "Espiar en el mundo superficial",
					Definition = "Una aldea de pescadores atrapó uno en su red, hace algún tiempo. Parte hombre y parte criatura escamosa del mar, habló en una forma rota del idioma común antes de sofocarse en el aire libre. Les habló a los pescadores de una marea que se avecina, un aumento inevitable del poder de algún dios del mar profundo y que el imperio tritón se levantaría y arrastraría la tierra hacia el océano. La historia se difundió y ahora, cuando los pescadores navegan por los mares agitados, observan y se preocupan de que los cuentos del tritón moribundo fueran ciertos. Que hay poderes profundos abajo que observan y esperan. Temen que la marea esté subiendo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Golpear en la debilidad")
					}
				},
				new Monster
				{
					Name = "Invocamareas Tritón",
					FavouriteToken = VTTTokens.Blue1,
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Magico, TagIDs.Inteligente },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 2,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Olas",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Acuático", "Mutaciones" },
					Instinct = "Provocar El Diluvio",
					Definition = "Parte sacerdote, parte proscrito entre los suyos, el invocamareas habla con la voz de las profundidades. Pueden ser reconocidos por sus mutaciones: piel transparente, quizás, o filas de dientes como un tiburón. Ojos o dedos luminosos, luces de pesca en la oscuridad de su reino submarino. Hablan en una extraña lengua que puede llamar y comandar a las criaturas del mar. Cabalgan hipocampos salvajes y lanzan extraños hechizos que pudren las cubiertas de madera de los barcos o las recubren de percebes lo suficientemente pesados como para hundirlas. Ahora, los invocamareas regresan a las ciudades de los tritones, llevando la noticia de que la profecía se está cumpliendo. El mundo de los hombres se ahogará en salmuera helada. Los invocamareas hablan y los señores comienzan a escuchar.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Lanzar un hechizo de agua y destrucción"),
						new MasterMove("Ordenar a las bestias del mar"),
						new MasterMove("Revelar proclamación divina")
					}
				},
				new Monster
				{
					Name = "Tritón Submarino",
					FavouriteToken = VTTTokens.Blue1,
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Arpón",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Acuático" },
					Instinct = "Hacer la guerra",
					Definition = "Los tritones no son una raza militar por naturaleza. Se alejan de la batalla excepto cuando los sahuagin atacan, y entonces solo se defienden y se retiran a las profundidades donde sus enemigos no pueden seguirlos. Esta tendencia comienza a cambiar. A medida que los invocamareas vienen a reunir a su gente, algunos hombres y mujeres tritón toman las armas. Llaman a estos generales 'submarinos' y les construyen armaduras de conchas y vidrio endurecido. Nadan en formación, empuñando picas y arpones, y atacan a las tripulaciones de barcos que se aventuran demasiado lejos del puerto. Observa sus pendones de algas en el horizonte y el grito de caracola de un llamado a la batalla, y mantén, si puedes, tus barcos cerca de la costa.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Liderar a los tritones a la batalla"),
						new MasterMove("Arrastrarlos bajo las olas")
					}
				},
				new Monster
				{
					Name = "Noble Tritón",
					FavouriteToken = VTTTokens.Blue1,
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Size = TagIDs.Pequeño,
					MaxHP = 6,
					CurrentHP = 6,
					Armor = 2,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Tridente",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Acuático" },
					Instinct = "Dirigir",
					Definition = "Se dice que las casas gobernantes tritón fueron elegidas al amanecer de los tiempos. Otorgadas con el señorío sobre todas las razas del mar por algún dios ahora olvidado. Estas líneas de sangre continúan, transmitiendo el gobierno de padre a hija y madre a hijo a lo largo de las edades. A cada uno se le permite gobernar su ciudad de la manera que elija, algunos solos o con sus cónyuges, otros en consejo de hermanos y hermanas. En épocas pasadas, eran conocidos por su sabiduría y las líneas de sangre de temperamento ecuánime eran respetadas por encima de todo. La profecía de los invocamareas está cambiando eso: se espera que los nobles sean fuertes, no sabios. Los nobles han comenzado a responder, y algunos temen que la antigua sangre esté cambiando para siempre. Puede ser demasiado tarde para retroceder. El tiempo y la marea no esperan a nadie.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Incitar a los tritones a la guerra"),
						new MasterMove("Llamar a refuerzos")
					}
				}

			}
		},
		new MonsterPack
		{
			Name = "Poderes planares",
			Monsters = new List<Monster> {
				new Monster
				{
					Name = "Ángel",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Aterrador, TagIDs.Divino, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 18,
					CurrentHP = 18,
					Armor = 4,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada de Llamas",
							Dices = new List<DiceTypes> { DiceTypes.d10, DiceTypes.d10 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = +4,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Alas" },
					Instinct = "Compartir la voluntad divina",
					Definition = "Así fue escrito que los cielos se abrieron para Avra'hal y emergió un ángel de las nubes para hablarle, y se le apareció como su primogénita, hermosa, de piel ébano y ojos dorados, y Avra'hal lloró al verla. 'No temas', le ordenó. 'Ve a las aldeas que te he mostrado en tus sueños y muéstrales la palabra que he escrito en tu alma.' Avra'hal lloró y lloró, y estuvo de acuerdo en hacerlo, tomando su espada y su tomo, y entró en las aldeas, una gran sed de sangre en sus labios, porque la palabra que el ángel escribió en el alma de Avra'hal era 'matar'.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Entregar visiones y profecías"),
						new MasterMove("Incitar a los mortales a la acción"),
						new MasterMove("Exponer pecado e injusticia")
					}
				},
				new Monster
				{
					Name = "Diablo con Púas",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Grande, TagIDs.Planar, TagIDs.Aterrador },
					Size = TagIDs.Pequeño,
					MaxHP = 16,
					CurrentHP = 16,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espinas",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Escabroso }
						}
					},
					Special = new List<string> { "Espinas" },
					Instinct = "Desgarrar carne y derramar sangre",
					Definition = "Hay mil formas de diablo, tal vez más. Algunos comunes y otros únicos. Cada vez que los Inquisidores descubren uno nuevo, lo escriben en el Códice de los Tormentadores y el conocimiento se comparte entre las abadías con la esperanza de que las atrocidades de ese tipo en particular no vuelvan a encontrar su camino en el mundo. El diablo con púas ha sido conocido por mucho tiempo por los hermanos y hermanas de la Inquisición. Aparece solo en un lugar de gran violencia o cuando es convocado por un conjurador descarriado. Cubierto de púas afiladas, este demonio en particular se deleita en derramar sangre, preferiblemente empalando víctimas a trozos o enteras sobre sus espinas y dejándolas morir allí. Cruel pero no particularmente efectivo más allá del asesinato. Una baja prioridad inquisitorial.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Empalar a alguien"),
						new MasterMove("Matar indiscriminadamente")
					}
				},
				new Monster
				{
					Name = "Diablo Encadenado",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Planar },
					Size = TagIDs.Pequeño,
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 3,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Aplastar",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Instinct = "Capturar",
					Definition = "¿Piensas que la frase 'llevarlo al infierno' no significa nada? Es lamentablemente literal, en el caso del diablo encadenado. Apareciendo de manera diferente para cada víctima, esta criatura invocada tiene un solo propósito: envolver a su víctima en bobinas de ataduras y llevarla a un lugar de tormento. A veces vendrá como una masa con forma humana de hierro oxidado, ganchos y bobinas de enlaces desparejos. Otras veces, como un enredo tumultuoso de cuerda o algas o sábanas ensangrentadas retorcidas. Los resultados son siempre los mismos.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Tomar un prisionero"),
						new MasterMove("Volver de donde vino"),
						new MasterMove("Torturar con alegría")
					}
				},
				new Monster
				{
					Name = "Elemental Conceptual",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Planar, TagIDs.Astuto, TagIDs.Amorfo },
					Special = new List<string> { "Forma ideal" },
					Instinct = "Perfeccionar su concepto",
					Definition = "Los planos no son tan literales como nuestro mundo. Vestidos en el caos elemental hay lugares de sustancias más extrañas que el aire y el agua. Aquí, ríos de tiempo chocan contra costas de miedo cristalino. Tormentas sombrías de pesadilla hierven y revuelven en un cielo iluminado por risas. A veces, los espíritus de estos lugares pueden ser atraídos a nuestro mundo, aunque son infinitamente más impredecibles y extraños que el simple fuego o la tierra podrían ser. También es más fácil cometer errores; uno podría intentar invocar un elemental de riqueza y sorprenderse al encontrar un elemental de asesinato en su lugar.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Demostrar su concepto en su forma más pura")
					}
				},
				new Monster
				{
					Name = "Corruptor",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Planar, TagIDs.Acaparador },
					Size = TagIDs.Pequeño, // Asumí Mediano según la descripción
					MaxHP = 12,
					CurrentHP = 12,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga secreta",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Instinct = "Negociar",
					Definition = "Seguramente, buen hombre, debes saber por qué estoy aquí. Debes saber quién soy. Dijiste las palabras. Derramaste la sangre y seguiste las instrucciones casi al pie de la letra. Tu pronunciación fue un poco incorrecta, pero eso se espera. He venido a darte lo que siempre has deseado, amigo. ¿Gloria, amor, dinero? Cosas insignificantes cuando tienes las bóvedas del infierno para explorar. No te veas tan sorprendido, sabías a lo que venías. Solo tienes una cosa que deseamos. Promételo y el mundo será tuyo para tomar. Confía en mí.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Ofrecer un trato con consecuencias horribles"),
						new MasterMove("Explorar las bóvedas del infierno en busca de una ficha de negociación"),
						new MasterMove("Hacer un espectáculo de poder")
					}
				},
				new Monster
				{
					Name = "Djinn",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Magico },
					Size = TagIDs.Grande,
					MaxHP = 14,
					CurrentHP = 14,
					Armor = 4,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Llama",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Hecho de llamas" },
					Instinct = "Arder eternamente",
					Definition = "Deja de frotar esa lámpara, idiota. No me importa lo que hayas leído, no te concederá deseos. Te traje aquí para mostrarte algo real, algo verdadero. ¿Ves este mural? Muestra la antigua ciudad. La verdadera ciudad que existió antes. La llamaban Majilis y estaba hecha de latón por los espíritus. Tenían sirvientes gólem y amantes humanos y, en ese día, se decía que podías intercambiarles un año de tu vida por un favor. No estamos aquí para reunir tesoro esta noche, tonto, estamos aquí para aprender. Los djinn a veces todavía vienen a estos lugares, y debes entender su historia si esperas comportarte correctamente. Son poderosos, malvados y orgullosos, y debes conocerlos si esperas sobrevivir a una invocación. Ahora, trae la lámpara aquí y la encenderemos, se oscurece y estas ruinas son peligrosas de noche.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Conceder poder a cambio de un precio"),
						new MasterMove("Invocar las fuerzas de la Ciudad de Latón")
					}
				},
				new Monster
				{
					Name = "Hell Hound",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Planar, TagIDs.Organizado },
					Size = TagIDs.Pequeño, // Asumí Mediano según la descripción
					MaxHP = 10,
					CurrentHP = 10,
					Armor = 1,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco ígneo",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Piel de sombra" },
					Definition = "Cuando uno incumple un trato, ¿no viene el deudor a cobrar? ¿El deudor no envía a alguien a cobrar lo adeudado? Lo mismo ocurre con los poderes inferiores. Sólo quieren lo que es suyo. Un grupo de sombras aullantes, llamas y huesos dentados, impulsados por el cuerno de caza. No cesarán, no se pueden evadir.",
					Instinct = "Perseguir",
					Moves = new List<MasterMove>
					{
						new MasterMove("Seguir a pesar de todos los obstáculos"),
						new MasterMove("Escupir fuego"),
						new MasterMove("Invocar las fuerzas del infierno sobre su objetivo")
					}
				},
				new Monster
				{
					Name = "Imp",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Planar, TagIDs.Inteligente, TagIDs.Organizado },
					Size = TagIDs.Pequeño,
					MaxHP = 7,
					CurrentHP = 7,
					Armor = 1,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Lengua de fuego",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.tocar }
						}
					},
					Definition = "Estos pequeños demonios observadores a menudo actúan como sujetos vinculantes por primera vez para los brujos neófitos. Se los puede encontrar infestando cábalas arcanas, bebiendo pociones cuando nadie los observa y persiguiendo mascotas y sirvientes con pequeñas horcas. Una caricatura de la verdadera demoníaca, estas pequeñas criaturas, afortunadamente, no son demasiado difíciles de unir o extinguir.",
					Instinct = "Hostigar",
					Moves = new List<MasterMove>
					{
						new MasterMove("Enviar información de vuelta al infierno"),
						new MasterMove("Causar problemas")
					}
				},
				new Monster
				{
					Name = "Inevitable",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Cauteloso, TagIDs.Amorfo, TagIDs.Planar },
					Size = TagIDs.Grande, // Asumí Mediano según la descripción
					MaxHP = 21,
					CurrentHP = 21,
					Armor = 5,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Martillo",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Hecho de Orden" },
					Definition = "Todo llega a su fin. La realidad sangra por el corte del cuchillo de la entropía. Al borde del tiempo mismo se encuentra lo inevitable. Masivos, poderosos y aparentemente tallados en materia estelar, lo inevitable interviene sólo cuando la magia o la calamidad han deshecho la madeja del destino. Donde los arrogantes y poderosos hierven la sustancia del destino y buscan socavar las leyes mismas de la realidad, lo inevitable llega para guiar las cosas de regreso al orden correcto. Inquebrantable, aparentemente inmune al daño mortal y absolutamente enigmático, se dice que lo Inevitable es todo lo que quedará cuando el largo hilo del tiempo se acabe.",
					Instinct = "Preservar el orden",
					Moves = new List<MasterMove>
					{
						new MasterMove("Finalizar un hechizo o efecto"),
						new MasterMove("Hacer cumplir una ley de la naturaleza o del hombre"),
						new MasterMove("Dar un vistazo al destino")
					}
				},
				new Monster
				{
					Name = "Larvas",
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Planar, TagIDs.Inteligente },
					Size = TagIDs.Pequeño,
					MaxHP = 10,
					CurrentHP = 10,
					Armor = 0,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Limo",
							Dices = new List<DiceTypes> { DiceTypes.d4, DiceTypes.d4 },
							Tags = new List<TagIDs> { TagIDs.tocar },
							RollType = RollTypes.Roll_Disadvantage
						}
					},
					Instinct = "Sufrir",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llenarlos de desesperación"),
						new MasterMove("Implorar clemencia"),
						new MasterMove("Atraer la atención maligna")
					},
					Definition = "Aquellos que han visto visiones de los Planos Inferiores, y han sobrevivido manteniendo su cordura, hablan de masas de estos gusanos retorcidos. Larvas con rostros de hombres y mujeres, clamando por salvación en un nido de llamas. A veces, se pueden provocar a salir a través de una rasgadura en el velo dimensional, emergiendo, retorciéndose y atormentándose en nuestro mundo. Una invitación a hacer buenas acciones en la vida.",
				},
				new Monster
				{
					Name = "Pesadilla",
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Grande, TagIDs.Magico, TagIDs.Aterrador, TagIDs.Planar },
					Size = TagIDs.Grande,
					MaxHP = 7,
					CurrentHP = 7,
					Armor = 4,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Aplastar",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Llamas y sombras" },
					Instinct = "Cabalgar desenfrenadamente",
					Moves = new List<MasterMove>
					{
						new MasterMove("Envolver a un jinete en llamas infernales"),
						new MasterMove("Expulsarlos")
					},
					Definition = "La manada surgió de un pacto hecho en los días en que la gente aún habitaba las Estepas Devastadas. Se decía que eran señores de los caballos, nacidos en la silla de montar. Uno de ellos, en un intento por dominar a sus pares, hizo un pacto oscuro con algún poder maligno y entregó a cambio sus mejores caballos. Tenía algo de poder, seguro, pero ¿qué es una dinastía de mil años cuando la vida es tan corta? Ahora, los demonios del abismo montan los mejores caballos jamás vistos. Pelajes de aceite brillante y crines de llama atormentada: estos son corceles de la caballería infernal.",
				},
				new Monster
				{
					Name = "Quasit",
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Planar },
					Size = TagIDs.Pequeño,
					MaxHP = 7,
					CurrentHP = 7,
					Armor = 2,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Armas infernales",
							Dices = new List<DiceTypes> { DiceTypes.d6 }
						}
					},
					Special = new List<string> { "Forma adaptable" },
					Instinct = "Servir",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar sin freno"),
						new MasterMove("Infligir dolor")
					},
					Definition = "Un demonio con algo de ambición. Un quasit es una especie de soldado raso en el reino demoníaco. Un plebeyo, armado con colmillos o garras o alas o alguna otra cosa para darle una pequeña ventaja sobre sus pares infernales. Comúnmente vinculado por nigromantes para transportar cargas pesadas o construir puentes o vigilar sus torres retorcidas, un quasit puede asumir muchas formas, ninguna de ellas agradable.",
				},
				new Monster
				{
					Name = "El Tarrasco",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Enorme,
					Tags = new List<TagIDs> { TagIDs.Planar },
					Special = new List<string> { "Impenetrable" },
					Instinct = "Consumir",
					Definition = "El Tarrasco. Legendario juggernaut imparable, devorador de ciudades y tragador de barcos, caballos y caballeros. Una criatura no vista en una era, pero sobre la cual se cuentan todo tipo de historias. Un hilo de verdad se teje a través de estas historias. No puede ser asesinado. Ninguna cuchilla puede atravesar su concha pétrica ni hechizo penetrar el escudo que de alguna manera porta. Las historias dicen, sin embargo, que la voluntad de un alma pura puede enviarlo a dormir, aunque lo que eso signifique y, por los dioses, dónde se podría encontrar tal cosa, rogamos no tener que aprenderlo nunca. Duerme. En algún lugar en la periferia del borde plano, duerme por ahora.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Tragar a una persona, grupo o lugar entero"),
						new MasterMove("Liberar un resto de un lugar largo comido de su garganta")
					}
				},
				new Monster
				{
					Name = "Demonio de la Palabra",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Planar, TagIDs.Magico },
					Instinct = "Promover su palabra",
					Moves = new List<MasterMove>
					{
						new MasterMove("Lanzar un hechizo relacionado con su palabra"),
						new MasterMove("Traer su palabra en abundancia")
					},
					Definition = "Toda la magia mortal son solo palabras. Los hechizos son oraciones, fórmulas rutinarias, runas lanzadas o canciones cantadas. Letras, palabras, oraciones y sintaxis unidas en un lenguaje que todo el mundo podría entender. Por medio de las palabras podemos hacer llorar o exaltar a nuestros compañeros, podemos pintar imágenes y susurrar deseos a los dioses. No es de extrañar, entonces, que en todo ese poder esté la intención. Que cada palabra que pronunciamos, si se repite y se le da significado o emoción, puede desencadenar una especie de invocación involuntaria. Los demonios de la palabra son convocados por accidente, aparecen al azar y a menudo tienen una vida corta, pero vienen para atender a una palabra en particular. Caprichosos, impredecibles y peligrosos, sí, pero posiblemente útiles, según la palabra."
				}





			}
		},
		new MonsterPack
		{
			Name = "Habitantes del pantano",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Bakunawa",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Escabroso, TagIDs.Contundente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Piercing = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Anfibio" },
					Instinct = "Devorar",
					Definition = "La hermana de la Tortuga-Dragón es una poderosa reina serpiente. Diez yardas de escamas y músculos, dicen que despierta con hambre cuando el sol desaparece del cielo. Se siente atraída por la luz brillante en la oscuridad y, como cualquier serpiente, la Bakunawa es astuta. Buscará primero engatusar y engañar, y solo recurrirá a la violencia cuando no haya otra opción disponible."
				},
				new Monster
				{
					Name = "Basilisk",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Definition = "“Pocos han visto un basilisco y han vivido para contarlo. ¿Consíguelo? ¿Has visto un basilisco? Un poco de humor de basilisco. Lo siento, sé que están buscando algo útil, señores. Cosas serias, lo entiendo. El basilisco, incluso sin su capacidad de convertir la carne en piedra con una mirada, es una criatura peligrosa. Un poco como una rana, ojos saltones y seis patas musculosas diseñadas para saltar. Un poco como un caimán, con mandíbulas mordaces y dientes cortantes. Cubierto de escamas pétreas y muy difícil de matar. Es mejor evitarlo, si es posible”.",
					Instinct = "Crear nuevas estatuas",
					Moves = new List<MasterMove>
					{
						new MasterMove("Convertir carne en piedra con la mirada"),
						new MasterMove("Retirarse a un laberinto de piedra")
					}
				},
				new Monster
				{
					Name = "Black Pudding",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Amorfo },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque corrosivo",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Amorfo" },
					Definition = "¿Cómo se mata un montón de sustancia pegajosa? ¿Un gran y blando montón de sustancia pegajosa que también quiere disolverte y sorberte? Ésa es una buena pregunta para la que no tengo respuesta. Háganos saber cuando se entere",
					Instinct = "Disolver",
					Moves = new List<MasterMove>
					{
						new MasterMove("Comer metal, carne o madera"),
						new MasterMove("Escurrirse en un lugar problemático: comida, armadura, estómago")
					}
				},
				new Monster
				{
					Name = "Coutal",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Astuto },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Rayo de luz",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Alas", "Halo" },
					Definition = "Como desafiando directamente la decadencia y la suciedad del mundo, los dioses nos concedieron el cotal. Como si dijera: \"hay belleza, incluso en este lugar sombrío\". Una serpiente en vuelo con alas enjoyadas, estas hermosas criaturas brillan con una luz suave, como lo hace el sol a través de las vidrieras. Brillante, sabio y tranquilo, un cotal a menudo sabe muchas cosas y ve muchas más. Es posible que puedas hacer un intercambio con él a cambio de algún favor. Buscan limpiar, purgar y hacer de este mundo oscuro uno mejor. Lástima que tengamos tan pocos. Los dioses son crueles.",
					Instinct = "Limpiar",
					Moves = new List<MasterMove>
					{
						new MasterMove("Pasar juicio sobre una persona o lugar"),
						new MasterMove("Convocar fuerzas divinas para purificar"),
						new MasterMove("Ofrecer información a cambio de servicio")
					}
				},
				new Monster
				{
					Name = "Crocodilian",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Bite",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Anfibio", "Camuflaje" },
					MaxHP = 10,
					Armor = 2,
					Instinct = "Comer",
					Definition = "Es un cocodrilo realmente grande. En serio. Muy grande.",

					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar a una víctima desprevenida"),
						new MasterMove("Escapar al agua"),
						new MasterMove("Aferrar algo fuertemente en sus mandíbulas")
					}
				},
				new Monster
				{
					Name = "Doppelgänger",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Dagger",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Shapeshifting" },
					MaxHP = 12,
					Armor = 0,
					Instinct = "Infiltrarse",
					Definition = "Su forma natural, si alguna vez la ves, es repulsiva. Como una criatura que dejó de crecer a medio camino, antes de decidir si era un elfo, un humano o un enano. Entonces nuevamente, tal vez así es como llegas a ser como un doppelgänger, sin forma, sin figura propia. Quizás todo lo que realmente buscan es un lugar para encajar. Si sales al mundo, cuando regreses a casa, asegúrate de que tus amigos sean quienes crees que son. Podrían, en cambio, ser un doppelgänger y tu amigo podría estar muerto en el fondo de un pozo en algún lugar. Entonces nuevamente, dependiendo de tus amigos, eso podría ser una mejora."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Adoptar la forma de una persona cuya carne ha probado"),
						new MasterMove("Usar la identidad de otro en su beneficio"),
						new MasterMove("Dejar la reputación de alguien destrozada")
					}
				},
				new Monster
				{
					Name = "Dragon Turtle",
					FavouriteToken = VTTTokens.GreenBoss,
					Organization = TagIDs.Solitario,
					Size = TagIDs.Enorme,
					Tags = new List<TagIDs> { TagIDs.Cauteloso },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Bite",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Caparazón", "Anfibio" },
					MaxHP = 20,
					Armor = 4,
					Instinct = "Resistir el cambio",
					Definition = "Bakunawa tiene un hermano. Donde ella se enfurece rápidamente y tiene hambre de oro, él es lento y robusto. Ella es un cuchillo y él es un escudo. Una gran tortuga que yace en el lodo y el fango durante edades mientras pasan, barro acumulado en su espalda, a veces árboles y arbustos. A veces todo un clan equivocado de trasgos construirá sus chozas y cocinará sus miserables comidas en el caparazón de la tortuga dragón. Sus mandíbulas que se cierran pueden ser lentas como un glaciar, pero pueden desgarrar un muro del castillo. Ten cuidado por donde pisas."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Avanzar implacablemente"),
						new MasterMove("Utilizar todo su peso"),
						new MasterMove("Destruir estructuras y edificios")
					}
				},
				new Monster
				{
					Name = "Dragon Whelp",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Cauteloso, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Elemental breath",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Alas", "Sangre Elemental" },
					MaxHP = 16,
					Armor = 3,
					Instinct = "Crecer en poder",
					Definition = "¿Qué? ¿Pensabas que todos eran de una milla de largo? ¿Pensabas que no venían más pequeños que eso? Claro, pueden ser no más grandes que un perro y no más inteligentes que un mono, pero un dragón joven aún puede eructar una bola infernal de fuego que te derretirá la armadura y te dejará gritando en el barro. Sus escamas, también, son más suaves que las de sus parientes más grandes, pero aún pueden desviar una flecha o una espada no perfectamente dirigida. El tamaño no es la única medida del poder."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Establecer una guarida, formar una base de poder"),
						new MasterMove("Llamar a lazos familiares"),
						new MasterMove("Exigir juramentos de servidumbre")
					}
				},
				new Monster
				{
					Name = "Ekek",
					Organization = TagIDs.Horda,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "garras",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Alas-brazo" },
					MaxHP = 3,
					Armor = 1,
					Instinct = "Golpear",
					Definition = "Feos, arrugados seres pájaros, estos. Una vez, tal vez, en algún pasado antiguo, fueron una raza de hombres angelicales desde lo alto, pero ahora comen ratas que pescan del fango con patas-talón y devoran con dientes-aguja. Entienden las lenguas de hombres y enanos, pero hablan en poco más que lenguas balbuceantes, imitando las palabras que oyen con risas burlonas. Es una cosa escalofriante ver una bestia tan cercana al hombre o al pájaro pero no exactamente ninguno de los dos."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar desde el aire"),
						new MasterMove("Realizar los mandados de una criatura más poderosa")
					}
				},
				new Monster
				{
					Name = "Fire Eels",
					FavouriteToken = VTTTokens.Red1,
					Organization = TagIDs.Horda,
					Size = TagIDs.Minusculo,
					Tags = new List<TagIDs>(),
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Burning touch",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = -2,
							Tags = new List<TagIDs> { TagIDs.tocar }
						}
					},
					Special = new List<string> { "Aceite inflamable", "Acuático" },
					MaxHP = 3,
					Armor = 0,
					Instinct = "Encender",
					Definition = "Estas extrañas criaturas no son más grandes ni más inteligentes que sus parientes mundanos. Tienen la misma naturaleza viciosa. Sobre sus parientes tienen una ventaja: una secreción aceitosa que rezuma de su piel. Les dificulta ser atrapados. Además, con un giro de su cuerpo pueden encender el líquido, dejando charcos de aceite ardiente sobre la superficie del agua y asando a presas y depredadores por igual. Escuché que las cosas viscosas son buenos ingredientes para equipo resistente al fuego, pero primero debes hacerte con uno."
				},
				new Monster
				{
					Name = "Frogman",
					FavouriteToken = VTTTokens.Green1,
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Spear",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Anfibio" },
					MaxHP = 7,
					Armor = 1,
					Instinct = "Hacer la guerra",
					Definition = "Croak croak croak. Pequeños y verrugosos enanitos. Alguien, ya sea un mago o un dios menor, tuvo la idea de una mala broma con estas criaturas. Se paran como hombres, visten con tela recogida y celebran en sus aldeas ranosas. Hablan una forma pidgin del idioma de los hombres y están constantemente en guerra con sus vecinos. Son codiciosos y estúpidos, pero lo suficientemente astutos cuando necesitan defenderse. Algunos dicen también que sus sacerdotes tienen una habilidad notable para curar. O tal vez son simplemente muy, muy difíciles de matar."
				},
				new Monster
				{
					Name = "Hydra",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs>(),
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Bite",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Muchas cabezas", "Solo muerto por un golpe al corazón" },
					MaxHP = 16,
					Armor = 2,
					Instinct = "Crecer",
					Definition = "Un poco como un dragón, aunque sin alas. Cabezas, nueve en número al nacer, brotan de un tronco musculoso y tejen un patrón sinuoso en el aire. Una hidra debe ser temida, un terror escamoso del pantano. Sin embargo, los más antiguos, tienen más cabezas, ya que cada intento fallido de asesinarlo solo lo hace más fuerte. Corta una cabeza y crecen dos más en su lugar. Solo un golpe, verdadero y fuerte, al corazón puede poner fin a la vida de una hidra. Ni el tiempo, ni la marea, ni ninguna otra cosa excepto esto."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar a muchos enemigos a la vez"),
						new MasterMove("Regenerar una parte del cuerpo (especialmente una cabeza)")
					}
				},
				new Monster
				{
					Name = "Kobold",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Spear",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Conexión dragón" },
					MaxHP = 3,
					Armor = 1,
					Instinct = "Servir a los dragones",
					Definition = "Algunos tienden a agrupar a estos pequeños hombres-dragón, parecidos a ratas, con trasgos, orcos, ogros y hobgoblins. Son más inteligentes y sabios que sus parientes, sin embargo. Los kobolds son esclavos subyugados a los dragones y fueron, en tiempos antiguos, los guardianes de su sabiduría y sirvientes hechiceros. Sus clanes, con nombres como Ironscale y Whitewing, se forman alrededor de un maestro dragón y viven para servir y hacer su voluntad. Ver a un kobold significa que hay más cerca, y si hay más cerca, entonces no puede estar lejos un poderoso dragón.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Montar una trampa"),
						new MasterMove("Invocar dragones o aliados dracónidos"),
						new MasterMove("Retirarse y reagruparse"),
					}
				},
				new Monster
				{
					Name = "Hobgoblin",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente, TagIDs.Organizado, TagIDs.Cauteloso, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada o Lanza",
							Dices = new List<DiceTypes> { DiceTypes.d8,DiceTypes.d8, },
							RollType = RollTypes.Roll_Advantage,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> {  },
					MaxHP = 6,
					Armor = 3,
					Instinct = "Hacer la guerra",
					Definition = "Los hobgoblins se parecen superficialmente a los duendes en el tono de la piel y los rasgos faciales, pero son erguidos y altos como un hombre, son inteligentes, utilizan armaduras y armas fabricadas y demuestran una propensión a la organización militar. Luchan en formación, designando sargentos y tenientes para servir bajo las órdenes de un general, y cada oficial comanda una banda de duendes reclutados. Los hobgoblins viven para la guerra y el derramamiento de sangre, matando o esclavizando a criaturas más débiles que ellos. Más agresivos y organizados que sus primos los duendes y los osgos, ven a todas las demás criaturas como seres inferiores a los que hay que subyugar y reservan un odio especial hacia todos los elfos, especialmente los elfos. Los hobgoblins valoran sus posesiones y fabrican sus propias armas y armaduras. Los hobgoblins gobiernan las tribus de goblins más civilizadas, a veces construyendo pequeños asentamientos y fortalezas que rivalizan con las de construcción humana.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Comandar otros goblinoides"),
						new MasterMove("Formar filas"),
					}
				},
				new Monster
				{
					Name = "Bugbear",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Inteligente, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada o Lanza",
							Dices = new List<DiceTypes> { DiceTypes.d8,DiceTypes.d8, },
							RollType = RollTypes.Roll_Advantage,
							Tags = new List<TagIDs> { TagIDs.Contundente, TagIDs.Cerca }
						}
					},
					Special = new List<string> {  },
					MaxHP = 12,
					Armor = 1,
					Instinct = "Consumir, Ser mejor que tú",
					Definition = "a veces llamados hombres del saco, aterrorizan a las personas que viven en las fronteras. Como todos los hombres bestia, los Bugbears se alimentan de humanos. A diferencia de la mayoría de los hombres bestia, los Bugbears tienden a ser solitarios. Si los osgos se unen a otros, podrían formar equipo con algunos otros osgos o servir como exploradores para un ejército de hombres bestia más grande, pero sólo mientras continúe el alboroto. Los osgos consideran que otros hombres bestia en sus territorios elegidos son amenazas y los ahuyentan, matándolos si es necesario",
					Moves = new List<MasterMove>
					{
						new MasterMove("Agarrar a alguien"),
						new MasterMove("Mutilar a una victima desprevenida"),
						new MasterMove("Sorprender al enemigo"),
						new MasterMove("Aplastar con su maza"),
					}
				},
				new Monster
				{
					Name = "Bugbear brute",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Hacha enorme primitiva",
							Dices = new List<DiceTypes> { DiceTypes.d10,DiceTypes.d10, },
							Bonus = 4,
							Piercing = 2,
							RollType = RollTypes.Roll_Advantage,
							Tags = new List<TagIDs> { TagIDs.Contundente, TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Son dos bestias, un bugbear y un puto tigre" },
					MaxHP = 16,
					Armor = 1,
					Instinct = "despejar el camino para el resto del escuadrón.",
					Definition = "El Bugbear Brute trabaja en conjunto con un escuadrón de Goblin Grenadiers y un Goblin Operative. Es un gran duende con un garrote pesado o un hacha o algo así. Ya ves adónde voy con esto.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Derribarlos o hacerlos a un lado"),
						new MasterMove("Llama al Operativo Goblin para que te ayude con las habilidades astutas.")
					}
				},
				new Monster
				{
					Name = "Bugbear montado en tigre",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Aterrador, TagIDs.Inteligente, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Morning star gigante",
							Dices = new List<DiceTypes> { DiceTypes.d10,DiceTypes.d10, },
							Bonus = 6,
							Piercing = 3,
							RollType = RollTypes.Roll_Advantage,
							Tags = new List<TagIDs> { TagIDs.Contundente, TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Son dos bestias, un bugbear y un puto tigre" },
					MaxHP = 12,
					Armor = 1,
					Instinct = "mata enemigos sin piedad y dale de comer al tigre.",
					Definition = "Los Bugbear. Ya conoces al tipo. Duendes grandes y corpulentos. Éste ha descubierto cómo ensillar a un maldito tigre y no morir. Aunque podrías hacerlo. Una vez que uno muere, el otro probablemente seguirá luchando.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Saltar por encima"),
						new MasterMove("Rugido de tigre")
					}
				},
				new Monster
				{
					Name = "Lizardman",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Inteligente, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Spear",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Anfibio" },
					MaxHP = 6,
					Armor = 2,
					Instinct = "Destruir la civilización",
					Definition = "Un hechicero ambulante una vez me dijo que los hombres lagarto vinieron antes que nosotros. Que antes de que elfos, enanos y hombres construyeran incluso el primer de sus cobertizos de madera y barro, una raza de orgullosos reyes lagarto caminaba por la tierra. Que vivían en palacios de cristal y adoraban a sus propios dioses escamosos. Tal vez sea cierto y tal vez no lo sea, ahora moran en lugares que los hombres hace mucho olvidaron o abandonaron, fabricando herramientas de vidrio volcánico y atacando las obras del mundo civilizado. Tal vez solo quieren recuperar lo que perdieron.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Emboscar a los desprevenidos"),
						new MasterMove("Lanzar un asalto anfibio"),
					}
				},
				new Monster
				{
					Name = "Medusa",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Inteligente, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Claws",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "La mirada convierte en piedra" },
					MaxHP = 12,
					Armor = 0,
					Instinct = "Coleccionar",
					Definition = "Las medusas son hijas de una madre con cabellos de serpiente, que las engendró en tiempos antiguos para llevar su nombre a través de las eras. Residen cerca de lugares civilizados, atrayendo a la gente a sus cuevas con promesas de belleza o riquezas inimaginables. Buenos apreciadores del arte, las medusas curan extrañas colecciones de sus víctimas, terror o éxtasis congelados para siempre en piedra. Satisfacen su vanidad al saber que fueron lo último que se vio en tantas vidas. Arrogantes, orgullosas y vengativas, buscan, a su manera, lo que muchos buscan: compañía interminable."
			,
					Moves = new List<MasterMove>
					{
						new MasterMove("Convertir una parte del cuerpo en piedra con la mirada"),
						new MasterMove("Atraer la mirada")
					}
				},
				new Monster
				{
					Name = "Sahuagin",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Endless teeth",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +4,
							Piercing = +1,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Contundente, TagIDs.Escabroso }
						}
					},
					Special = new List<string> { "Anfibio" },
					MaxHP = 3,
					Armor = 2,
					Instinct = "Derramar sangre",
					Definition = "La forma y habilidad de los hombres unidos al hambre y los dientes interminables de un tiburón. Voraces y llenos solo de odio, estas criaturas no se detendrán hasta que toda la vida haya sido consumida. No se puede razonar con ellos, no se pueden controlar ni saciar. Son hambre y sed de sangre, impulsados desde las profundidades del mar para arrasar pueblos costeros y tragar aldeas en islas.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Morder un miembro"),
						new MasterMove("Arrojar una lanza envenenada"),
						new MasterMove("Frenesí al ver sangre")
					}
				},
				new Monster
				{
					Name = "Sauropod",
					Organization = TagIDs.Horda,
					Size = TagIDs.Enorme,
					Tags = new List<TagIDs> { TagIDs.Cauteloso },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Trample",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							Tags = new List<TagIDs> { TagIDs.Alcance }
						}
					},
					Special = new List<string> { "Cuerpo blindado" },
					MaxHP = 18,
					Armor = 4,
					Instinct = "Perseverar",
					Definition = "Grandes bestias que viven en lugares desde hace mucho olvidados por las razas pensantes del mundo. Gentiles si no son provocados, pero poderosos si se enfurecen, aplastan a criaturas más pequeñas con el cuidado que podríamos dar al aplastar una hormiga bajo nuestras botas. Si ves uno, déjalo pasar y contémplalo con asombro, pero no despiertes al gigante.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Embiste"),
						new MasterMove("Derriba algo"),
						new MasterMove("Desata un bramido ensordecedor")
					}
				},
				new Monster
				{
					Name = "Swamp Shambler",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Magico },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Lash",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Forma de pantano" },
					MaxHP = 23,
					Armor = 1,
					Instinct = "Preservar y crear pantanos",
					Definition = "Algunos elementales son conjurados en círculos sagrados grabados en tiza. La mayoría, de hecho. Hay una especie de ciencia en eso. Otros, sin embargo, no son tan ordenados; no caen bajo las asignaciones cuidadosamente controladas de fuego, aire, agua o tierra. Algunos son una confluencia natural de vid y fango y hongo. No piensan como podría pensar un hombre. No se pueden entender como se entendería a un elfo. Simplemente son. Espíritus del pantano. Tambaleantes en el barro.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llamar al pantano mismo para obtener ayuda"),
						new MasterMove("Fundirse en el pantano"),
						new MasterMove("Reformarse en una nueva forma")
					}
				},
				new Monster
				{
					Name = "Troll",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Club",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Regeneración" },
					MaxHP = 20,
					Armor = 1,
					Instinct = "Destrozar",
					Definition = "Alto. Muy alto. Ocho o nueve pies cuando son jóvenes o débiles. Cubiertos por completo de piel verrugosa y resistente. Grandes dientes, cabello enredado como musgo de pantano y uñas largas y sucias. Algunos son verdes, otros grises, otros negros. Son clánicos y se odian entre ellos, sin mencionar al resto de nosotros. Casi imposibles de matar, a menos que tengas fuego o ácido de sobra. Corta una extremidad y observa. En pocos días, tienes dos trolls donde antes tenías uno. Un problema realmente grave, como puedes imaginar.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Deshacer los efectos de un ataque (a menos que sea causado por una debilidad, tu decisión)"),
						new MasterMove("Arrojar algo o a alguien")
					}
				},
				new Monster
				{
					Name = "Will-o-wisp",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Minusculo,
					Tags = new List<TagIDs> { TagIDs.Magico },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Ray",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Bonus = -2,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Cuerpo de luz" },
					MaxHP = 12,
					Armor = 0,
					Instinct = "Desorientar",
					Definition = "Observa una linterna flotando en la oscuridad, un viajero perdido en el pantano. Esperanza: un faro de luz brillante. Llamas, pero no hay respuesta. Comienza a desvanecerse y así lo sigues, chapoteando a través del lodo, cansándote en la persecución, esperando que te estén llevando a la seguridad. Tal es la triste historia que siempre termina en perdición. Estas criaturas son un misterio, algunos dicen que son fantasmas, otros faros de luz feérica. Nadie sabe la verdad. Sin embargo, son crueles. Todos pueden estar de acuerdo en eso.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Desviar a alguien"),
						new MasterMove("Abrir un camino hacia el peor lugar posible")
					}
				}
			}
		},
		new MonsterPack
		{
			Name = "Legiones no muertas",
			Monsters = new List<Monster> {
				new Monster
				{
					Name = "Abomination",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Constructo, TagIDs.Aterrador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Slam",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Muchas extremidades, cabezas, y demás" },
					MaxHP = 20,
					Armor = 1,
					Instinct = "Acabar con la vida",
					Definition = "Cadáveres cosidos sobre cadáveres conforman en su mayoría estas masas tambaleantes de magia oscura. La mayoría de los no muertos se crean para ser controlados, hechos para servir a algún propósito como construir una torre o servir como guardianes. No es así con la abominación. El último aspecto del ritual utilizado para otorgar fuego a sus infernales extremidades invoca un odio tan severo que la abominación solo conoce una tarea: desgarrar y despedazar lo único que no puede tener: la vida. Muchos estudiantes de las artes oscuras aprenden con su consternación mortal el hecho más importante sobre estos mastodontes: una abominación no tiene amo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Desgarrar la carne"),
						new MasterMove("Derramar tripas pútridas"),
					}
				},

				new Monster
				{
					Name = "Banshee",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Magico },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Scream",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Insubstancial" },
					MaxHP = 16,
					Armor = 0,
					Instinct = "Vengarse",
					Definition = "Sal de un encuentro con uno de estos espíritus vengativos simplemente sordo y date por afortunado el resto de tus días pacíficos y silenciosos. A menudo, confundida a primera vista con un fantasma o espíritu errante, la banshee revela un talento mucho más mortal para el asalto sónico cuando se enfurece. Y se enfada fácilmente. Víctima de la traición (a menudo por un ser querido), la banshee da a conocer su desagrado con un rugido o grito que puede pudrir la carne y desgarrar los sentidos. Dicen que si puedes ayudarla a obtener su venganza, podría otorgar recompensas. Si la afición de un espíritu despreciado es algo que querrías, bueno, esa es otra pregunta.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Ahoga todos los demás sonidos con un grito"),
						new MasterMove("Desata un ruido ensordecedor"),
						new MasterMove("Desaparecer en la niebla"),
					}
				},

				new Monster
				{
					Name = "Devorador",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Grande,
					MaxHP = 16,
					Armor = 1,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Smash",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Instinct = "Darse un festín con almas",
					Definition = "La mayoría de la gente sabe que los no muertos se alimentan de carne. El calor, la sangre y el tejido vivo continúan su existencia impía. Esto es cierto para la mayoría de los no muertos sin mente, animados por nigromancia negra. No es así con el devourer. Cuando una persona particularmente malvada (a menudo un manipulador de hombres, un sacerdote apóstata o algo así) muere de una manera espantosa, los oscuros poderes del Mundo del Calabozo podrían devolverla a una especie de vida. El devourer, sin embargo, no se alimenta de la carne de hombres o elfos. El devourer se come las almas. Mata con un placer que solo los seres conscientes pueden disfrutar y en los momentos de expiración de sus víctimas, respira como un hombre que se ahoga y se traga un alma. ¿Qué significa que tu alma sea devorada por una criatura así? Nadie se atreve a preguntar por miedo a descubrirlo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Devorar o atrapar un alma moribunda"),
						new MasterMove("Negociar por el regreso de un alma")
					}
				},
				new Monster
				{
					Name = "Dragonbone",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Enorme,
					Tags = new List<TagIDs> { },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Bite",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Piercing = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Escabroso }
						}
					},
					Definition = "Místicos nigromantes debaten: ¿es esta criatura realmente no muerta o es un gólem hecho de un material particularmente raro y blasfemo? Los huesos, tendones y escamas de un dragón muerto forman este sombrío autómata. Alado pero incapaz de volar, con forma de dragón pero sin el fuego poderoso de tal noble criatura, el dragonbone sirve a su amo con una devoción retorcida y a menudo se utiliza para asaltar los castillos y torres de nigromantes rivales. Se necesitaría un ser de considerable maldad para retorcer los restos de un dragón de esta manera.",
					Instinct = "Servir",
					MaxHP = 20,
					Armor = 2,
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar sin piedad")
					}
				},

				new Monster
				{
					Name = "Draugr",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Rusty sword",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Toque gélido" },
					Instinct = "Tomar de los vivos",
					MaxHP = 7,
					Armor = 2,
					Definition = "En Nordemark, hombres y mujeres cuentan historias en sus salones de madera sobre un lugar donde van los muertos nobles. Un salón de hidromiel en la cima de su montaña celestial donde los hombres de valor van a esperar la batalla final por el mundo. Es un lugar bueno. Es un lugar donde uno espera ir después de la muerte. ¿Y los muertos ingloriosos? ¿Aquellos que caen por veneno o en un acto de cobardía, guerreros aunque puedan ser? Bueno, esos salones de hidromiel no están abiertos para todos y cada uno. Algunos regresan, congelados y retorcidos, y potenciados por la rabia celosa y libran su guerra eterna no contra las fuerzas de gigantes o trolls, sino contra los pueblos de los hombres que una vez conocieron.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Congelar la carne"),
						new MasterMove("Llamar a los muertos indignos")
					}
				},
				new Monster
				{
					Name = "Ghost",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Aterrador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Phantom touch",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Insubstancial" },
					Instinct = "Atormentar",
					MaxHP = 16,
					Armor = 0,
					Definition = "Cada cultura cuenta la historia de la misma manera. Vives, amas u odias, ganas o pierdes, mueres de alguna manera que no te gusta y aquí estás, fantasmal y lleno de decepción y lo que sea. Algunas personas se toman la molestia, personas valientes y amables, de buscar a los muertos y ayudarles a pasar a su merecido descanso. Puedes encontrarlos, la mayoría de las veces, en la taberna bebiendo las terribles cosas que han visto o balbuceando consigo mismos en el manicomio. La muerte cobra un peaje en los vivos, sin importar cómo te enfrentes a ella.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Revelar la naturaleza aterradora de la muerte"),
						new MasterMove("Atormentar un lugar de importancia"),
						new MasterMove("Ofrecer información desde el otro lado, a un precio")
					}
				},
				new Monster
				{
					Name = "Ghoul",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "garras",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Piercing = +1,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Escabroso }
						}
					},
					Instinct = "Comer",
					MaxHP = 10,
					Armor = 1,
					Definition = "Hambre. Hambre hambre hambre. Desesperada y aferrada hambre de vacío estomacal. Garras afiladas para desgarrar la carne y dientes para rasgar y romper huesos y chupar la médula suave en el interior. Vomitar odio y rabia celosa gritando y cargar sobre piernas retorcidas, asustar a la carne viva y endulzarla aún más con el hedor del miedo. Banquete. Campesino o caballero, mago, sabio, príncipe o sacerdote, todos son carne tan deliciosa.", Moves = new List<MasterMove>
					{
						new MasterMove("Roer una parte del cuerpo"),
						new MasterMove("Obtener los recuerdos de su comida")
					}
				},
				new Monster
				{
					Name = "Lich",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Astuto, TagIDs.Cauteloso, TagIDs.Acaparador, TagIDs.Constructo },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Magical Force",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Lejos },
							IgnoresArmor = true
						}
					},
					MaxHP = 16,
					Armor = 5,
					Instinct = "Vivir eternamente",
					Definition = "\"Al final, te entregan un pergamino y un medallón engastado para conmemorar tus logros. Gran Maestro de la Abjuración, me llamaron. Anciano. Débil y marchito y solo un poco demasiado senil para ellos, esos tontos medio celosos. Apenas aprendices, y se autodenominaban El Nuevo Consejo. Me da asco, o lo haría, si aún pudiera sentirlo. Me dijeron que era un honor y que sería recordado para siempre. Era como escuchar mi propio elogio fúnebre. Adecuado, de alguna manera, ¿no crees? Me llevó otros diez años aprender los rituales y otros cuatro para recopilar el material y ves ante ti los frutos de mi trabajo. Perduro. Vivo. Veré la muerte de esta era y el amanecer de la siguiente. Me duele tener que hacer esto, pero, ya ves, no se te puede permitir poner en peligro mi investigación. Cuando te encuentres con la Muerte, dile hola por mí, ¿quieres?",
					Moves = new List<MasterMove>
					{
						new MasterMove("Lanzar un hechizo perfeccionado de muerte o destrucción"),
						new MasterMove("Poner en marcha un ritual o gran obra"),
						new MasterMove("Revelar una preparación o plan ya completado")
					}
				},
				new Monster
				{
					Name = "Mohrg",
					Organization = TagIDs.Grupo,
					MaxHP = 10,
					Armor = 0,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordisco",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.tocar }
						}
					},
					Special = new List<string> { },
					Instinct = "Provocar estragos",
					Definition = "Nunca te sales con la tuya al cometer un asesinato. En realidad, no. Puedes evadir la ley, puedes escapar de tu propia conciencia al final y morir, gordo y feliz en una mansión en algún lugar. Sin embargo, cuando los propios dioses notan tus malas acciones, ahí es donde tu suerte se agota y nace un mohrg. El mohrg es un esqueleto: carne, piel y cabello todos podridos. Todo menos sus entrañas: sus entrañas retorcidas y enredadas aún se derraman desde sus vientres, mágicamente conservadas y a menudo envueltas, a manera de soga, alrededor de sus cuellos. No piensan, exactamente, pero sufren. Matan y causan estragos y sus almas no descansan. Tal es el castigo, tanto para ellos por el crimen como para toda la humanidad por atreverse a asesinarse mutuamente. Los dioses son justos y son implacables.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Enfurecerse"),
						new MasterMove("Añadir a su colección de entrañas")
					}
				},
				new Monster
				{
					Name = "Momia",
					Organization = TagIDs.Solitario,
					MaxHP = 16,
					Armor = 1,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Divino, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Golpear",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { },
					Instinct = "Disfrutar del descanso eterno",
					Definition = "Hay culturas que veneran a los muertos. No los entierran en la fría tierra y lamentan su partida. Estas personas pasan semanas preparando el cadáver sagrado para su descanso eterno. Se construyen templos, pirámides y grandes bóvedas de piedra para albergarlos y se llenan de esclavos, mascotas y oro. ¡Lo mejor para vivir en el lujo más allá de las Puertas Negras, ¿no? No te dejes tentar por estas bóvedas, ¡oh, sé esa mirada codiciosa! Presta atención a mis advertencias o arriesga un destino terrible, porque a los muertos honrados no les gusta que los molesten. El robo solo provocará su ira, ¡no digas que no te advertí!",
					Moves = new List<MasterMove>
					{
						new MasterMove("Maldecirlos"),
						new MasterMove("Envolverlos"),
						new MasterMove("Levantarse de nuevo")
					}
				},
				new Monster
				{
					Name = "Nightwing",
					Organization = TagIDs.Horda,
					MaxHP = 7, CurrentHP = 7,
					Armor = 1,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Sigiloso },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Desgarrar",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Alas" },
					Instinct = "Cazar",
					Definition = "Los eruditos de las artes necrománticas te dirán que el apelativo \"no muerto\" se aplica no solo a aquellos que han vivido, muerto y vuelto a un estado de vida intermedio. Es el nombre correcto de cualquier criatura cuya energía se origina más allá de las Puertas Negras. La criatura que los hombres llaman el nightwing es una de ellas, potenciada por la luz negativa del dominio de la Muerte. Tomando la forma de criaturas aladas masivas (algunas más parecidas a murciélagos, otras como buitres, otras como antiguas cosas de cuero) los nightwings viajan en bandadas depredadoras, bajando para despojar la carne de ganado, caballos y campesinos desafortunados más allá del toque de queda. Observa el cielo nocturno por sus ojos rojos. Escucha su chillido. Y reza a los dioses para que tengas algo bajo lo cual esconderte hasta que pasen.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar desde el cielo nocturno"),
						new MasterMove("Volar lejos con la presa")
					}
				},
				new Monster
				{
					Name = "Shadow",
					Organization = TagIDs.Horda,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Constructo },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque de sombra",
							Dices = new List<DiceTypes> { DiceTypes.d6, DiceTypes.d6 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Alcance }
						}
					},
					MaxHP = 11,
					Armor = 4,
					Special = new List<string> { "Forma de sombra" },
					Instinct = "Oscurecer",
					Definition = "Llamamos a los elementos. Llamamos al fuego, siempre ardiente. Invocamos al agua, dadora de vida. Suplicamos a la tierra, firme y estable. Clamamos al aire, siempre cambiante. Estos elementos los reconocemos y les damos nuestras gracias, pero les pedimos que nos dejen pasar. El elemental al que llamamos esta noche conoce otro nombre. Llamamos al elemento de la Noche. Sombra, te nombramos. Mensajero de la muerte y asesino negro, reclamamos como propio. Acepta nuestro sacrificio y haz nuestra voluntad hasta que llegue la mañana.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Apagar la luz"),
						new MasterMove("Generar otra sombra a partir de los muertos")
					}
				},
				new Monster
				{
					Name = "Sigben",
					Organization = TagIDs.Horda,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Constructo },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Latigazo de cola",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Progenie de vampiro" },
					MaxHP = 11,
					Armor = 2,
					Instinct = "Molestar",
					Definition = "\"¡Perro aswang y cola de látigo saltarina! Enviadas por vampiros con sus dos retorcidas piernas, estas cosas feas parecen la cabeza de una rata o un cocodrilo, quizás, peludas y afiladas de dientes. Tienen alas marchitas, pero no pueden usarlas, y colas largas y azotadoras, con puntas envenenadas. Estúpidas, vengativas y traviesas, causan todo tipo de caos cuando las sueltan de las extrañas jarras de arcilla en las que nacen. Solo un vampiro podría amar a una cosa tan miserable.\"",
					Moves = new List<MasterMove>
					{
						new MasterMove("Envenenarlos"),
						new MasterMove("Hacer el trabajo de un vampiro")
					}
				},
				new Monster
				{
					Name = "Skeleton",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Golpe",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					MaxHP = 7,
					Armor = 1,
					Instinct = "Tomar la apariencia de la vida",
					Definition = "Dem bones, dem bones, dem dry bones.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Actuar como lo hizo en vida"),
						new MasterMove("Apagar el calor de la vida"),
						new MasterMove("Reconstruirse a partir de huesos diversos")
					}
				},
				new Monster
				{
					Name = "Spectre",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque marchito",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Insubstancial" },
					MaxHP = 12,
					Armor = 0,
					Instinct = "Expulsar la vida de un lugar",
					Definition = "Para algunas personas, cuando pasan, la Muerte misma no puede liberar su agarre en los lugares que más aman. Un sacerdote cuya devoción al templo es mayor que la de su dios. Un funcionario de un gremio bancario que no puede soportar separarse de su bóveda. Un borracho y su taberna favorita. Todos hacen excelentes espectros. No actúan por el hambre habitual que impulsa a los muertos vivientes, sino por celos. Celos de que alguien más pueda llegar a amar su hogar tanto como ellos y expulsarlos. Estos lugares les pertenecen y estos espíritus invisibles matarán antes de dejar que alguien los envíe a su descanso.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Convertir su persecución contra una criatura"),
						new MasterMove("Dar vida al entorno")
					}
				},
				new Monster
				{
					Name = "Vampire",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Organizado, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Fuerza sobrenatural",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Piercing = 1,
							Bonus = +5,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Cambiar de forma", "Mente antigua" },
					MaxHP = 10,
					Armor = 2,
					Instinct = "Manipular",
					Definition = "Los tememos, porque nos llaman. Tan parecidos a nosotros, o cómo esperamos ser: hermosos, apasionados y poderosos. Se sienten atraídos hacia nosotros por lo que no pueden ser: cálidos, amables y vivos. Estas almas atormentadas solo pueden esperar, como máximo, pasar su maldición espantosa a otro y en cada uno vive la semilla retorcida de su creador. Los vampiros engendran vampiros. El sufrimiento engendra sufrimiento. No te dejes seducir por su seducción o puedes recibir su regalo: una corona de sombras y las cadenas de un dolor eterno e inmortal.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Encantar a alguien"),
						new MasterMove("Alimentarse de su sangre"),
						new MasterMove("Retirarse para planear de nuevo")
					}
				},
				new Monster
				{
					Name = "Wight-Wolf",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Salto",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Piercing = 1,
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Forma de sombra" },
					MaxHP = 7,
					Armor = 1,
					Instinct = "Cazar",
					Definition = "Al igual que el nightwing, el wight-wolf es una criatura que no nace en nuestro mundo. De alguna manera, deslizándose por los sellos de las Puertas Negras de la Muerte, estos espíritus toman la forma de enormes perros o lobos sombríos y cazan a los vivos por diversión. Viajan en manadas, lideradas por un poderoso alfa, pero poseen una especie de inteligencia desconocida para los verdaderos cánidos. Sus cacerías salvajes llaman la atención de los muertos vivientes inteligentes, como liches, vampiros y demás, quienes a veces hacen pactos con el alfa y sirven a un propósito sombrío juntos. Escucha el aullido de los sabuesos de la Muerte y reza para que no aúllen por ti.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Cercar a la presa"),
						new MasterMove("Convocar a la manada")
					}
				},
				new Monster
				{
					Name = "Zombie",
					Organization = TagIDs.Horda,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordida",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					MaxHP = 11,
					Armor = 1,
					Instinct = "¡Ceeeerebros!",
					Definition = "Cuando ya no haya más espacio en el Infierno.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar con una abrumadora cantidad"),
						new MasterMove("Atraparlos"),
						new MasterMove("Ganar fuerza de los muertos, generar más zombies")
					}
				}

			}
		},
		new MonsterPack
		{
			Name = "Bosques oscuros",
			Monsters = new List<Monster>
			{
				new Monster
				{
					Name = "Assassin Vine",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Amorfo,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Sigiloso },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espinas",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Escabroso }
						}
					},
					Special = new List<string> { "Planta" },
					MaxHP = 15,
					Armor = 1,
					Instinct = "Crecer",
					Definition = "Entre los animales existe una clara división entre cazador y cazado. Basta con una mirada para saber, ya sea por colmillos y ojos brillantes, garras o picaduras venenosas, cuáles de las criaturas de este mundo están destinadas a matar y cuáles están destinadas a ser asesinadas. Tal división, si tienes los ojos para verlo, corta el mundo de hojas y flores por la mitad. Los druidas en sus círculos forestales lo saben. Los rangers también pueden detectar tal planta antes de que sea demasiado tarde. La gente común, sin embargo, deambula donde no debería: senderos en lo profundo del bosque cubiertos de enredaderas, y con un chasquido, estas cuerdas hambrientas se tensan, arrastrando a su presa carnosa hacia la maleza. Cuida tus pies, viajero.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Disparar nuevos brotes"),
						new MasterMove("Atacar a los desprevenidos")
					}
				},
				new Monster
				{
					Name = "Blink Dog",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Magico, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordida",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Ilusión" },
					MaxHP = 6,
					Armor = 4,
					Instinct = "Cazar",
					Definition = "Ahora lo ves, ahora no. Perros alguna vez propiedad de un señor hechicero y dotados con una especie de manto ilusorio, escaparon hacia los bosques alrededor de su guarida y comenzaron a cruzarse con lobos y perros salvajes del bosque. Puedes detectarlos, si tienes suerte, por el brillante plateado de sus pelajes y sus extraños aullidos ululantes. Tienen un talento notable para no estar exactamente donde parecen estar y lo utilizan para derribar presas mucho más fuertes que ellos. Si te encuentras frente a una manada de blink dogs, más vale que cierres los ojos y pelees. Tendrás más facilidad cuando no te traicione tu vista natural. Con tales hechicerías se contaminan los lugares naturales del mundo con cosas antinaturales.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Dar la apariencia de estar en un lugar donde no están"),
						new MasterMove("Llamar a la manada"),
						new MasterMove("Moverse con una velocidad asombrosa")
					}
				},
				new Monster
				{
					Name = "Centaur",
					Organization = TagIDs.Horda,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Arco",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +2,
							Piercing = 1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.tocar }
						}
					},
					Special = new List<string> { "Mitad caballo, Mitad hombre" },
					MaxHP = 11,
					Armor = 1,
					Instinct = "Enfurecerse",
					Definition = "Será una reunión de clanes nunca vista en esta era. Llama a Stormhoof y Brightspear. Convoca a Whitemane e Ironflanks. Sopla el cuerno y comenzaremos nuestra reunión, diremos las palabras y uniremos a nuestro pueblo. Demasiado tiempo han cortado los hombres los antiguos árboles para sus barcos. Los elfos son débiles y cobardes, amigos de esta babosa mannish. Será un fuego purificador desde los bosques más oscuros. ¡Levanta la bandera roja de la guerra! Hoy contraatacamos a estos simios y recuperamos lo que es nuestro!",
					Moves = new List<MasterMove>
					{
						new MasterMove("Sobrepasarlos"),
						new MasterMove("Disparar una diana perfecta"),
						new MasterMove("Moverse con velocidad implacable")
					}
				},

				// Chaos Ooze
				new Monster
				{
					Name = "Chaos Ooze",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Aterrador, TagIDs.Amorfo, TagIDs.Planar },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Toque deformante",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.tocar }
						}
					},
					Special = new List<string> { "Ooze", "Fragmentos de otros planos incrustados en él" },
					MaxHP = 23,
					Armor = 1,
					Instinct = "Cambiar",
					Definition = "La barrera entre Dungeon World y los planos elementales no es, como podrías esperar, un muro de piedra. Es mucho más poroso. Lugares donde las razas civilizadas no suelen pisar a veces, cómo decirlo, pueden tener una fuga. Como una presa que se suelta un poco. Trozos y pedazos del caos se derraman. A veces, se solidifican como un huevo en una sartén, ahí es donde obtenemos el material para muchos de los cachivaches mágicos del Gremio. Útil, ¿verdad? A veces, sin embargo, se retuerce y se aplasta un poco y se queda así, deformando todo lo que toca en alguna otra forma extraña. El caos engendra caos, y crece.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Causar un cambio en apariencia o sustancia"),
						new MasterMove("Breve puente entre los planos")
					}
				},

				// Cockatrice
				new Monster
				{
					Name = "Cockatrice",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Pequeño,
					Tags = new List<TagIDs> { TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Pico",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Toque de piedra" },
					MaxHP = 6,
					Armor = 1,
					Instinct = "Defender el nido",
					Definition = "Nunca he visto algo así, señor. Rodrick pensó que era un pollo, tal vez. Pobre Rodrick. Yo pensé que era un lagarto de algún tipo, aunque él tenía razón, tenía un pico y plumas grises como un pollo. ¿Cierto? Bueno, verás, lo encontramos en el bosque, en un nido al pie de un árbol mientras estábamos con la cerda. Buscando setas, señor. Le dije a Rodrick que estábamos... sí, señor, el pájaro... verás, nos estaba mirando fijamente a Rodrick y él intentó asustarlo con un palo para robar los huevos, pero la cosa le picoteó la mano. Rápido fue, también. Traté de alejarlo pero él solo se volvió más lento y más lento y sí, como lo ves ahora, señor. Todo congelado como cuando dejamos al perro afuera durante la noche en invierno hace dos años. Pobre e estúpido Rodrick. ¿No era un pájaro ni un lagarto, verdad, señor?",
					Moves = new List<MasterMove>
					{
						new MasterMove("Iniciar una transformación lenta en piedra")
					}
				},
				new Monster
				{
					Name = "Dryad",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Magico,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Astuto },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Enredaderas aplastantes",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Planta" },
					MaxHP = 12,
					Armor = 2,
					Instinct = "Amar apasionadamente la naturaleza",
					Definition = "Mucho más hermosa que cualquier hombre o mujer nacida en los reinos civilizados. Mirar a una es enamorarse. Profundo y castigador también. La cosa es que ellas no aman, al menos no a la gente carnosa que a menudo las encuentra. Su amor es algo primitivo, casado con los bosques, con un gran roble que les sirve de hogar, madre y lugar sagrado. También es una maldición ver una, nunca te amarán de vuelta. No importa lo que hagas. No importa cómo te comprometas con ellas, siempre te despreciarán. Si su roble sufre daño, no solo tendrás que lidiar con la ira de la dríade, sino que en cada pueblo cercano hay una docena de hombres con un anhelo secreto en su corazón, listos para asesinarte mientras duermes por solo una sonrisa de semejante criatura.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atraer a un mortal"),
						new MasterMove("Fundirse en un árbol"),
						new MasterMove("Volverse contra ellos a la naturaleza")
					}
				},

				// Eagle Lord
				new Monster
				{
					Name = "Eagle Lord",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Organizado, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Talones",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = +1,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Poderosas alas" },
					MaxHP = 10,
					Armor = 1,
					Instinct = "Dominar las alturas",
					Definition = "Algunos del tamaño de caballos. Incluso más grandes: los reyes y reinas de las águilas. Su grito perfora el cielo de la montaña y ay de aquellos que caigan bajo la sombra de sus poderosas alas. Los antiguos magos forjaron un pacto con ellos en los días primordiales. Los hombres tomarían las llanuras y valles y dejarían las cimas de las montañas a los señores águila. Estos pactos sagrados deben ser honrados, no sea que claven sus garras en ti. Afortunados son los elfos, pues los fabricantes de sus tratados aún viven y cuando el peligro llega a las tierras élficas, los señores águila a menudo sirven como espías y monturas para ellos. De larga vida y orgullosos, algunos podrían estar dispuestos a comerciar con sus antiguos secretos por el precio adecuado también.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar desde el cielo"),
						new MasterMove("Arrastrar a alguien al aire"),
						new MasterMove("Llamar a juramentos antiguos")
					}
				},
				new Monster
				{
					Name = "Elvish Warrior",
					Organization = TagIDs.Horda,
					Size = TagIDs.Inteligente,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Espada",
							Dices = new List<DiceTypes> { DiceTypes.d6, DiceTypes.d6 },
							RollType = RollTypes.Roll_Advantage,
							Bonus = +0,
							Piercing = 0,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Agudo sentido" },
					MaxHP = 3,
					Armor = 2,
					Instinct = "Buscar la perfección",
					Definition = "Como con todo lo que emprenden, los elfos abordan la guerra como un arte. Los vi pelear, una vez. La Batalla del Velo de Astrid. Sí, soy tan viejo, muchacho, ahora cállate. Una doncella guerrera, vestida con una armadura que brillaba como el cielo invernal. Cabello blanco ondeando y una bandera de azul océano atada a su lanza. Parecía deslizarse entre los árboles como lo haría un ángel, golpeando y bañando su hoja en sangre que humeaba en el aire frío. Nunca me sentí tan pequeño antes. Entrené con el maestro de armas de Battlemoore, ¿sabes? He sostenido una espada más tiempo del que has estado vivo, muchacho, y en ese momento supe que mi habilidad no significaba nada. Gracias a los dioses que los elfos estaban con nosotros entonces. Una cosa más hermosa y terrible nunca he visto.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atacar un punto débil"),
						new MasterMove("Poner en marcha planes antiguos"),
						new MasterMove("Usar el bosque a su favor")
					}
				},

				// Elvish High Arcanist
				new Monster
				{
					Name = "Elvish High Arcanist",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Magico,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Fuego Arcano",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							IgnoresArmor = true,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Lejos }
						}
					},
					Special = new List<string> { "Sentidos agudos" },
					MaxHP = 12,
					Armor = 0,
					Instinct = "Desatar el poder",
					Definition = "La verdadera magia élfica no es como los hechizos de los hombres. La hechicería mannish es toda fórmulas y rituales. Ellos engañan para encontrar los secretos arcanos que resuenan a su alrededor. Son sordos a la sinfonía arcana que canta en los bosques. La magia élfica requiere un oído afinado para escuchar esa sinfonía y la voz con la que cantar. Armonizan con lo que ya resuena. Los hombres atan las fuerzas de la magia a su voluntad; los elfos simplemente pellizcan las cuerdas y tararean. Los Altos Arcanistas, de alguna manera, se han vuelto más y menos que cualquier elfo. El latido de su sangre es el pulso de toda la magia en este mundo.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Trabajar la magia que la naturaleza demanda"),
						new MasterMove("Lanzar los elementos")
					}
				},
				new Monster
				{
					Name = "Griffin",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Talones",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Alas" },
					MaxHP = 10,
					Armor = 1,
					Instinct = "Servir a los aliados",
					Definition = "A primera vista, uno podría confundir al grifo con otro error mágico como la mantícora o la quimera. ¿No parece parte de eso? Estas criaturas tienen la altivez regia de un león y el porte arrogante de un águila, pero temperan eso con la lealtad inquebrantable de ambos. Ganarse la amistad de un grifo es tener un aliado todos tus días vivos. Verdaderamente un regalo. Si alguna vez tienes la suerte de conocer a uno, sé respetuoso y deferente por encima de todo. Puede que no lo parezca, pero pueden percibir los desaires más sutiles y los responderán con un pico afilado y garras.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Juzgar la valía de alguien"),
						new MasterMove("Llevar a un aliado en alto"),
						new MasterMove("Golpear desde arriba")
					}
				},

				// Hill Giant
				new Monster
				{
					Name = "Hill Giant",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Enorme,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Rocas arrojadas",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +3,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Lejos, TagIDs.Contundente }
						}
					},
					MaxHP = 10,
					Armor = 1,
					Instinct = "Arruinar todo",
					Definition = "¿Alguna vez has visto a un ogro antes? Más grande que eso. También más tonto y más malvado. Espero que te guste que te arrojen vacas. ",
					Moves = new List<MasterMove>
					{
						new MasterMove("Lanzar algo"),
						new MasterMove("Hacer algo estúpido"),
						new MasterMove("Hacer temblar la tierra")
					}
				},

				// Ogre
				new Monster
				{
					Name = "Ogre",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Garrote",
							Dices = new List<DiceTypes> { DiceTypes.d8 },
							Bonus = +5,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Cerca, TagIDs.Contundente }
						}
					},
					MaxHP = 10,
					Armor = 1,
					Instinct = "Devolver el mundo a días más oscuros",
					Definition = "Una historia, entonces. En algún momento de la no tan larga historia de la raza mannish hubo una división. En días en que los hombres eran simplemente habitantes-del-lodo sin magia propia, se dividieron en dos: un grupo dejó sus cuevas y los oscuros bosques y construyó la primera ciudad para honrar a los dioses. Los otros, una horda salvaje y feroz, se retiraron a la oscuridad. Crecieron allí. En los bosques profundos, un odio sombrío por su pariente más suave les dio fuerza. Encontraron a sus propios dioses oscuros, allí en los bosques y colinas. Pasaron las edades y se criaron altos, fuertes y llenos de odio. Hemos forjado acero y ellos lo igualan con su salvajismo. Puede que hayamos olvidado nuestras raíces comunes, pero en algún lugar, en lo más profundo, los ogros recuerdan.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Destruir algo"),
						new MasterMove("Entrar en una furia"),
						new MasterMove("Tomar algo por la fuerza")
					}
				},
				// Razor Boar
				new Monster
				{
					Name = "Razor Boar",
					Organization = TagIDs.Solitario,
					Size = TagIDs.Pequeño,
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Colmillos",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Piercing = 3,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Escabroso }
						}
					},
					MaxHP = 16,
					Armor = 1,
					Instinct = "Destrozar",
					Definition = "Los colmillos del jabalí cortante desgarran la armadura de metal como si fuera un tejido. Voraces, salvajes e imparables, se alzan sobre sus parientes mundanos. ¿Matar a uno? Un trofeo mayor de valentía y habilidad es difícil de nombrar, aunque escuché que un jabalí cortante mató al Rey Borracho de un solo golpe. ¿Crees que eres un cazador mejor que él?",
					Moves = new List<MasterMove>
					{
						new MasterMove("Desgárralos"),
						new MasterMove("Rompe la armadura y armas")
					}
				},

				// Satyr
				new Monster
				{
					Name = "Satyr",
					Organization = TagIDs.Grupo,
					Tags = new List<TagIDs> { TagIDs.Astuto, TagIDs.Magico, TagIDs.Acaparador },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Carga",
							Dices = new List<DiceTypes> { DiceTypes.d8, DiceTypes.d8 },
							RollType = RollTypes.Roll_Disadvantage,
							Bonus = +0,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					Special = new List<string> { "Encantamiento" },
					MaxHP = 10,
					Armor = 1,
					Instinct = "Disfrutar",
					Definition = "Uno de los pocos seres que se encuentran en los bosques antiguos que no quieren herirnos, matarnos o comernos directamente. Residen en claros bañados por el sol, y bailan en sus divertidas patas de cabra al ritmo de la música encantadora tocada en flautas hechas de hueso y plata. Sonríen fácilmente y, siempre y cuando los complazcas con chistes y deportes, tratarán a nuestra especie con amistad. Tienen un lado malo, así que si los cruzas, date prisa en ir a otro lugar; muy pocas cosas guardan rencor como el obstinado sátiro.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Atraer a otros a la juerga a través de la magia"),
						new MasterMove("Forzar regalos sobre ellos"),
						new MasterMove("Jugar bromas con ilusiones y trucos")
					}
				},

				// Sprite
				new Monster
				{
					Name = "Sprite",
					Organization = TagIDs.Horda,
					Size = TagIDs.Minusculo,
					Tags = new List<TagIDs> { TagIDs.Sigiloso, TagIDs.Magico, TagIDs.Astuto, TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Daga",
							Dices = new List<DiceTypes> { DiceTypes.d4, DiceTypes.d4 },
							RollType = RollTypes.Roll_Disadvantage,
							Bonus = +0,
							Tags = new List<TagIDs> { TagIDs.tocar }
						}
					},
					Special = new List<string> { "Alas", "Magia feérica" },
					MaxHP = 3,
					Armor = 0,
					Instinct = "Jugar bromas",
					Definition = "Los clasificaría como elementales, excepto que 'ser molesto' no es un elemento.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Jugar una broma para exponer la verdadera naturaleza de alguien"),
						new MasterMove("Confundir sus sentidos"),
						new MasterMove("Crear una ilusión")
					}
				},
				new Monster
				{
					Name = "Treant",
					Organization = TagIDs.Grupo,
					Size = TagIDs.Grande,
					Tags = new List<TagIDs> { TagIDs.Inteligente, TagIDs.Amorfo },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Ramas contundentes",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Bonus = +5,
							Tags = new List<TagIDs> { TagIDs.Alcance, TagIDs.Contundente }
						}
					},
					Special = new List<string> { "Madera" },
					MaxHP = 21,
					Armor = 4,
					Instinct = "Proteger la naturaleza",
					Definition = "Viejos, altos y gruesos de corteza, caminan entre la oscuridad bordeada de árboles. Fuertes, lentos y nacidos en el bosque, los treants se enojan rápido, advertimos. Si vas al bosque con un hacha, conoce a los treants como tus enemigos.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Moverse con fuerza implacable"),
						new MasterMove("Arraigar"),
						new MasterMove("Propagar magia antigua")
					}
				},

				// Werewolf
				new Monster
				{
					Name = "Hombre Lobo",
					Organization = TagIDs.Solitario,
					Tags = new List<TagIDs> { TagIDs.Inteligente },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordida",
							Dices = new List<DiceTypes> { DiceTypes.d10 },
							Piercing = 1,
							Bonus = +2,
							Tags = new List<TagIDs> { TagIDs.Cerca, TagIDs.Escabroso }
						}
					},
					Special = new List<string> { "Débil a la plata" },
					MaxHP = 12,
					Armor = 1,
					Instinct = "Despojar la apariencia de la civilización",
					Definition = "Hermoso, ¿verdad? La luna, quiero decir. Nos está observando, ¿sabes? Sus bonitos ojos plateados nos miran mientras dormimos. Loca, también, como todas las más hermosas. Si fuera una mujer, doblaría la rodilla y la haría mi esposa en el acto. No, no te he llamado aquí para hablar de ella, aunque. ¿Las cadenas? Para tu seguridad, no la mía. Estoy maldito, ves. Debes haberlo sospechado. Los reyes hechiceros lo llamaron \"licantropía\" en su día, transmitido por una mordida para hacer más de nuestra especie. No, no pude encontrar una cura. Por favor, no tengas miedo. ¿Tienes las flechas que te di? De plata, sí. Ah, empiezas a entender. No llores, hermana. Debes hacer esto por mí. No puedo soportar más sangre en mis manos. Debes poner fin a esto. Por mí.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Transformarse para pasar desapercibido como bestia o hombre"),
						new MasterMove("Golpear desde dentro"),
						new MasterMove("Cazar como hombre y bestia")
					}
				},

				// Worg
				new Monster
				{
					Name = "Worg",
					Organization = TagIDs.Horda,
					Tags = new List<TagIDs> { TagIDs.Organizado },
					Attacks = new List<AttackDef>
					{
						new AttackDef
						{
							AttackName = "Mordida",
							Dices = new List<DiceTypes> { DiceTypes.d6 },
							Bonus = +0,
							Tags = new List<TagIDs> { TagIDs.Cerca }
						}
					},
					MaxHP = 3,
					Armor = 1,
					Instinct = "Servir",
					Definition = "Así como los caballos son para las razas civilizadas, así van los worgs para los goblins. Monturas, feroces en la batalla, montadas solo por los más valientes y peligrosos, se encuentran y crían en el bosque primigenio para servir a los goblins en sus guerras contra los hombres. El único worg seguro es un cachorro, separado de su madre. Si puedes encontrar uno de estos, o hacer huérfanos de una camada con una espada afilada, tendrás lo que podría convertirse en un protector o sabueso leal con el tiempo. Entrenarlo bien, ten en cuenta, ya que los worgs son inteligentes y nunca completamente libres de sus impulsos primarios.",
					Moves = new List<MasterMove>
					{
						new MasterMove("Llevar a un jinete a la batalla"),
						new MasterMove("Darle ventaja a su jinete")
					}
				}
			}
		}

	};
}

public class MonsterPack
{
	public string Name { get; set; } = "";
	public List<Monster> Monsters { get; set; } = new List<Monster>();
}
