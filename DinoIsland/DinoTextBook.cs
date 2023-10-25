using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;

public class DinoTextBook
{
	public List<string> Agenda = new List<string>
	{
		"Haz de Dino Island un lugar misterioso, peligroso y lleno de dinosaurios.",
		"Desafía a los héroes a descubrir su verdadera identidad.",
		"Juega para descubrir si lograrán salir de la isla y quiénes serán si lo logran."
	};

	public List<string> Principles = new List<string>
	{
		"Sé un fanático de los personajes.",
		"Apunta siempre a un personaje específico.",
		"Haz preguntas y amplía las respuestas.",
		"Dale a cada ubicación detalles únicos y memorables.",
		"El entorno es tan peligroso como los dinosaurios.",
		"Atribuye a cada especie de dinosaurio algún rasgo distintivo.",
		"Contrapone lo natural y lo artificial.",
		"Obliga a los héroes a elegir entre salvarse a sí mismos y ayudar a los demás.",
		"Los dinosaurios son animales, no monstruos, hazlos reales: impresionantes, aterradores, extraños, familiares, imparables o gentiles según corresponda.",
	};

	public List<MasterMove> MasterMoves = new List<MasterMove>
	{
		new MasterMove("Muestra señales de la presencia cercana de un dinosaurio. (Huellas, evidencia de pastoreo, una presa reciente, un rugido, pequeños dinosaurios huyendo, etc.)"),
		new MasterMove("¡Aparece un dinosaurio! ¡Dale algún rasgo distintivo!"),
		new MasterMove("Lesiona a los personajes según lo establecido."),
		new MasterMove("Sus lesiones causan problemas."),
		new MasterMove("Introduce a un NPC útil. ¡Dales un objetivo!"),
		new MasterMove("Mata a un NPC útil."),
		new MasterMove("Desorienta a los personajes."),
		new MasterMove("Ofrece lo que necesitan, con un peligro en el camino. (Cuéntales el peligro)"),
		new MasterMove("Diles lo que necesitan y déjales descifrar como conseguirlo. (Cuando lo obtienen, tienen éxito. Otras soluciones podrían funcionar.)"),
		new MasterMove("Sepáralos."),
		new MasterMove("Revela algo misterioso."),
		new MasterMove("Pasa el tiempo. (Anochece, tienen que descansar, una oportunidad expira, etc.)"),
		new MasterMove("Usa una ACCIÓN DE DINOSAURIO."),
		new MasterMove("Usa una ACCIÓN DE UBICACIÓN.")
	};


	public List<MasterMove> FinaleMoves = new List<MasterMove>
	{
		new MasterMove("Aparece una versión nueva y más poderosa de un enemigo que enfrentaste."),
		new MasterMove("La isla comienza a morir, quizás desgarrándose por un terremoto, hundiéndose en el océano, explotando con el volcán o siendo absorbida por un vórtice temporal."),
		new MasterMove("Un héroe debe decidir si sacrificarse o no.")
	};

	public List<string> WhyComingOptions = new List<string>
	{
		"Motivo no definido",
		"Hemos sido invitados como huéspedes, en misteriosas circunstancias.",
		"Hemos sido contratados para trabajar aquí, en misteriosas circunstancias.",
		"Estamos aquí para explorar o investigar.",
		"Somos criminales o contrabandistas, aquí por un golpe.",
		"Estamos en una misión de rescate/recuperación. ¿A quién o qué estamos persiguiendo?",
		"Estamos en una misión encubierta, para infiltrarnos o sabotear."
	};

	public List<string> WhereAreYouOptions = new List<string>
	{
		"Lugar no definido",
		"La incubadora.",
		"Los corrales de Triceratops.",
		"Dormitorios abandonados apresuradamente.",
		"Un monorraíl alto sobre la selva.",
		"Una playa llena de escombros.",
		"Una cueva, esperando a que pase la lluvia."
	};

	public List<string> TheWayOutOptions = new List<string>
	{
		"Escape no definido",
		"Llamar para rescate en la estación de radio.",
		"Un avión de hélice oculto de un contrabandista.",
		"El helicóptero en el que llegaron.",
		"Un submarino militar.",
		"Un velero / yate de recreo anclado en alta mar.",
		"Un crucero que pasa una vez a la semana."
	};

	public List<string> ObstacleMCOptions = new List<string>
	{
		"Obstáculo no definido",
		"La única ruta es a través de los corrales/territorio de velocirraptores.",
		"El monorraíl es la única forma de llegar a donde vamos, y está fuera de servicio.",
		"Debemos esperar esta maldita tormenta.",
		"No podemos irnos sin completar nuestra misión.",
		"Necesitamos entrar en el complejo, pero está asegurado.",
		"Nuestra forma de salir de la isla está dañada, inaccesible o aún no ha llegado."
	};


	public List<string> ObstaclePlayersOptions = new List<string>
	{
		"Misterio no definido",
		"¿Por qué han perdido contacto con el mundo exterior?",
		"¿Quién saboteó su misión? (¿y por qué?)",
		"¿Por qué su contacto no los encontró y dónde están?",
		"¿Cuál es la fuente de la extraña transmisión que está sobrecargando sus señales?",
		"¿Por qué están fallando sus brújulas... y hacia dónde está el norte?",
		"¿Quiénes son las figuras sombrías que los observan desde los arbustos y qué quieren?"
	};

	public List<string> AvailableRumors = new List<string>
	{
		"Corrientes oceánicas y rocas submarinas hacen que sea casi imposible llegar a la isla en barco.",
		"Alguien está creando nuevas especies de plantas y animales en la isla.",
		"Ningún humano había puesto un pie en la isla antes del año pasado.",
		"El gobierno chino tiene algo que ver con lo que está sucediendo.",
		"Hay nativos que adoran a los dinosaurios como dioses.",
		"A veces hay extrañas nubes de tormenta moradas sobre la isla.",
		"Un amigo borracho te contó lo que vieron en la isla. Mayormente tonterías, pero murieron poco después en circunstancias misteriosas.",
		"Tienes un amigo o familiar que fue a esta isla y nunca regresó.",
		"La gente va por períodos de dos años y hasta los conserjes ganan siete cifras.",
		"Las brújulas no funcionan del todo bien.",
		"Hay arañas del tamaño de un coco.",
		"El Museo de Historia Natural tiene una nueva exhibición que se inaugura pronto y es tan secreta que incluso la mayoría de los curadores no saben de qué se trata."
	};


	public List<string> Gimmicks = new List<string>
	{
		"Agudeza Visual: Solo puede detectar movimiento.",
		"Bolsas de Veneno: Tiene una mordida venenosa o escupe toxinas letales.",
		"Piel Venenosa: Su piel es tóxica, causando dolor, parálisis, ceguera o alucinaciones.",
		"Camuflaje: Puede cambiar de color para mezclarse con su entorno.",
		"Inteligente: Capaz de resolver problemas complejos.",
		"Cazadores en Manada: Trabajan juntos para cazar presas.",
		"Arbóreo: Vive en los árboles.",
		"Territorial: Marca y defiende límites específicos.",
		"Caníbal: Se alimenta de su propia especie.",
		"Mimetismo: Puede imitar sonidos, ya sea de dinosaurios, humanos o máquinas.",
		"Eléctrico: Almacena y libera descargas eléctricas poderosas.",
		"Regeneración: Puede curarse rápidamente y regenerar apéndices perdidos.",
		"Sonar: Caza utilizando ecos de sonidos.",
		"Escalada: Proficiente en escalar o incluso se adhiere a superficies.",
		"Hierbabuena: Atraído obsesivamente por alguna sustancia moderna.",
		"Constructor de Trampas: Construye trampas naturales, como telarañas o hoyos.",
		"Grito Sónico: Produce un sonido que puede herir, desorientar o derribar a los oponentes en grupo.",
		"Fértil: Se reproduce rápidamente.",
		"Señal de Peligro: Da señales cuando está cerca, tal vez con un sonido de sonaja, despliegue, aullido o colores brillantes.",
		"Prensil: Usa su cola, o tal vez una trompa, para sujetar cosas."
	};

	public List<string> DinoNickNames = new List<string>
	{
		"MMDs (Man-Made Dinosaurs)",
		"APAs (Animales prehistóricos artificiales)",
		"Crichtons",
		"Paleos",
		"Waybacks o Retrosaurios",
		"FIDOs (Fossil induced dinosaur organism)"
	};

	public List<string> MysteriusOrganizations = new List<string>
	{
		"The Hallet Institute",
		"恐⻰龙 (Kǒnglóng)",
		"Mantell Industries",
		"Hilltop",
		"SynGen",
		"D.R.I (Dinosaur Research Institute)"
	};

	public List<string> NPCGoals = new List<string>
	{
		"Llegar hasta un ser querido en otra parte de la isla.",
		"Permanecer en el lugar hasta que todo se calme.",
		"Evitar a los dinosaurios a toda costa.",
		"Vengarse de la persona que creen es responsable de todo el lío.",
		"Cobrar, en efectivo.",
		"Nadie puede irse.",
		"Recuperar copias de seguridad de todos los datos.",
		"Completar su investigación.",
		"Devolver todo a la normalidad.",
		"Proteger un secreto personal a toda costa."
	};


	public List<string> NPCOffers = new List<string>
	{
		"Acceso a tarjetas clave, contraseñas, etc.",
		"Orientación hacia una ubicación o persona.",
		"Un arma y/o la habilidad para usar una.",
		"Conocimiento sobre un dinosaurio.",
		"Conocimiento de un alijo de armas, combustible, artefactos, etc.",
		"Habilidad con un vehículo.",
		"Habilidad con un sistema técnico: energía, portales temporales, tanques de clonación, seguridad, etc.",
		"Atención médica."
	};

	public Mystery WhyDinos = new Mystery
	{
		Question = "Por qué hay dinosaurios?",
		Solutions = new List<MysterySolution> {
				new MysterySolution
				{
					Solution = "Fueron genéticamente creados por humanos.",
					FirstClue = "Un dinosaurio tiene algún tipo de \"etiqueta\": literalmente, una etiqueta, un tatuaje, etc."
				},
				new MysterySolution
				{
					Solution = "Nunca se extinguieron aquí; la isla es un mundo perdido.",
					FirstClue = "Una antigua ruina que representa a humanos y dinosaurios juntos."
				},
				new MysterySolution
				{
					Solution = "Es una anomalía espacio-temporal.",
					FirstClue = "Algo de otra época, por ejemplo: un soldado romano muerto, una máquina futurista o un automóvil Modelo T."
				},
				new MysterySolution
				{
					Solution = "Son sofisticadas falsificaciones robóticas.",
					FirstClue = "Un dinosaurio se comporta brevemente de manera errática, casi como si estuviera fallando."
				},
				new MysterySolution
				{
					Solution = "Es una evolución inversa impulsada por el cambio climático.",
					FirstClue = "El clima en la isla es extraño."
				},
				new MysterySolution
				{
					Solution = "Fueron despertados por el cambio climático/descongelamiento del hielo.",
					FirstClue = "Encuentran glaciares o cuevas de hielo con cavidades vacías y derretidas."
				}
		},
	};
	public Mystery WhyComplex = new Mystery
	{
		Question = "Cual es la utilidad del complejo",
		Solutions = new List<MysterySolution> {
			new MysterySolution
			{
				Solution = "Modificar genét. dinos para estudiarlos científicamente",
				FirstClue = "Conocimiento científico"
			},
			new MysterySolution
			{
				Solution = "Modificar genét. dinos para aplicaciones militares",
				FirstClue = "El cadáver de un soldado con un parche de bandera en el hombro."
			},
			new MysterySolution
			{
				Solution = "Modificar genét. dinos para investigación farmacéutica",
				FirstClue = "El nombre de una destacada empresa farmacéutica en un letrero."
			},
			new MysterySolution
			{
				Solution = "Modificar genét. dinos para atracción turística",
				FirstClue = "Una caja de folletos deteriorados para \"Dino Island\"."
			},
			new MysterySolution
			{
				Solution = "Una estación de investigación no relacionada que estudia el cambio climático, el volcán, anomalías electromagnéticas, etc.",
				FirstClue = "Equipos científicos que no tienen nada que ver con dinosaurios."
			},
			new MysterySolution
			{
				Solution = "Sistema de realidad virtual para que las personas controlen dinosaurios y cacen humanos de forma remota.",
				FirstClue = "Un búnker lleno de sillones reclinables y auriculares de realidad virtual de alta tecnología inoperantes."
			},
			new MysterySolution
			{
				Solution = "Una colonia utópica.",
				FirstClue = "Dormitorios familiares abandonados y pequeñas parcelas de granja/jardín."
			},
			new MysterySolution
			{
				Solution = "Crear soldados híbridos dinosaurio-humanos.",
				FirstClue = "Un humano muerto con piel escamosa."
			},
			new MysterySolution
			{
				Solution = "Un parque temático.",
				FirstClue = "Un centro de visitantes, completo con un llamativo letrero de \"Dino Island\"."
			}
		}
	};
	public Mystery WhatWentGrong = new Mystery
	{
		Question = "Qué salió mal?",
		Solutions = new List<MysterySolution> {
			new MysterySolution
			{
				Solution = "Los dinosaurios fueron introducidos intencionalmente en una estación de investigación ajena e inconsciente como un experimento.",
				FirstClue = "Una \"caja de envío\" de dinosaurios vacía, pero el dinosaurio no escapó, claramente lo soltaron."
			},
			new MysterySolution
			{
				Solution = "Sabotaje por parte de una corporación rival, eco-activistas, un trabajador descontento o nativos enfadados.",
				FirstClue = "Un PNJ (vivo o muerto) que no parece pertenecer al lugar."
			},
			new MysterySolution
			{
				Solution = "Los dinosaurios desarrollaron rasgos impredecibles y desastrosos.",
				FirstClue = "Un dinosaurio con un rasgo impactante."
			},
			new MysterySolution
			{
				Solution = "Los trabajadores se rebelaron.",
				FirstClue = "Un misterioso letrero pintado a mano en una pared, árbol o roca."
			},
			new MysterySolution
			{
				Solution = "Un corte de energía liberó a los dinosaurios.",
				FirstClue = "Un agujero en la cerca eléctrica."
			},
			new MysterySolution
			{
				Solution = "Un brote de gripe dinosauria.",
				FirstClue = "Un PNJ muere/murió tosiendo sangre (¡o un héroe!).."
			}
		}
	};


	public List<ExtinctionEvent> ExtinctionEvents { get; set; } = new List<ExtinctionEvent>
	{
		new ExtinctionEvent
		{
			Tittle = "El volcán entra en erupción!",
			WarningMoves= new List<string>{
				"El suelo tiembla",
				"presagiando la erupción"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("El volcán entra en erupción"),
				new MasterMove("Una nube de ceniza sofocante cubre la zona"),
				new MasterMove("Rocas caen del cielo"),
				new MasterMove("Un flujo de lava bloquea su camino"),
				new MasterMove("Un flujo de lava se acerca directamente hacia ellos"),
				new MasterMove("Estampida de herbívoros que huyen.")
			},
			Clock = new Clock{ EventAt12 = "El volcán entra en erupción!"}
		},
		new ExtinctionEvent
		{
			Tittle = "¡Es un monzón!",
			WarningMoves= new List<string>{
				"Nubes oscuras en el horizonte, moviéndose rápido",
				"Truenos y relámpagos, demasiado cerca para la comodidad"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("Comienza el aguacero"),
				new MasterMove("Un rayo golpea, dañando algo importante"),
				new MasterMove("El suelo está peligrosamente resbaladizo"),
				new MasterMove("Las inundaciones hacen que un área sea intransitable"),
				new MasterMove("Todos los aviones están en tierra"),
				new MasterMove("Un avión se estrella"),
				new MasterMove("Los generadores fallan y se corta la energía"),
				new MasterMove("El Xenosaurio está suelto")
			},
			Clock = new Clock{ EventAt12 = "Un huracán arrasa la isla!"}
		},
		new ExtinctionEvent
		{
			Tittle = "¡Los dinosaurios han evolucionado!",
			WarningMoves= new List<string>
			{
				"Extrañas huellas en el barro",
				"Un llamado de dinosaurio que nadie reconoce"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("Un dinosaurio aparentemente normal exhibe un rasgo nuevo, poderoso e imposible (ver RASGOS ESPECIALES DE DINOSAURIOS)"),
				new MasterMove("Un dinosaurio muestra inteligencia humana o casi humana"),
				new MasterMove("Un dinosaurio es increíblemente grande"),
				new MasterMove("Los viejos trucos no funcionan"),
				new MasterMove("Se encuentran con el Xenosaurio")
			},
			Clock = new Clock{ EventAt12 = "Los dinosaurios son la nueva raza alfa"}
		},
		new ExtinctionEvent
		{
			Tittle = "¡Han enviado un equipo de eliminación!",
			WarningMoves= new List<string>
			{
				"Los héroes encuentran cadáveres: dinosaurios y humanos acribillados con precisión",
				"Voces inesperadas y hostiles en el walkie-talkie",
				"El sonido de disparos de ametralladora cerca"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("Una bala silba junto a la cabeza de alguien"),
				new MasterMove("Se escucha un disparo y un PNJ muere"),
				new MasterMove("Una granada (flashbang, gas lacrimógeno, explosiva) cae en la zona"),
				new MasterMove("Aparece un escuadrón de equipo de eliminación"),
				new MasterMove("El equipo de eliminación despliega una bomba nuclear"),
				new MasterMove("Genera un nuevo enemigo => Escuadrón: Equipo de Eliminación")
			},
			Clock = new Clock{ EventAt12 = "Asalto militar absoluto!"}
		},
		new ExtinctionEvent
		{
			Tittle = "¡Los dinosaurios alcanzarán el continente... tienes que detenerlos!",
			WarningMoves= new List<string>
			{
				"Revelar una forma para que los dinosaurios salgan de la isla",
				"Llegada de mercenarios con herramientas para capturar y retirar a los dinosaurios"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("Revelar un arma de destrucción masiva: un dispositivo nuclear, una forma de provocar una erupción volcánica, una forma de desatar un virus genético dirigido a los dinosaurios"),
				new MasterMove("La primera remesa está a punto de salir"),
				new MasterMove("A los dinosaurios no les gusta barcos/aviones/automóviles")
			},
			Clock = new Clock{ EventAt12 = "Los dinosaurios escapan de la isla!"}
		},
		new ExtinctionEvent
		{
			Tittle = "¡La anomalía temporal se está colapsando!",
			WarningMoves= new List<string>
			{
				"Extrañas nubes moradas en el cielo",
				"A alguien le sangra la nariz"
			},
			NewMasterMoves = new List<MasterMove>
			{
				new MasterMove("Los héroes son transportados repentinamente a una época diferente"),
				new MasterMove("Un portal gigante está absorbiendo todo"),
				new MasterMove("Aparece una criatura/objeto extraño del pasado lejano o el futuro distante"),
				new MasterMove("La comprensión de un PNJ sobre el tiempo se confunde"),
				new MasterMove("El tiempo se mueve de manera errática o hacia atrás")
			},
			Clock = new Clock{ EventAt12 = "El tiempo se rasga, todo se rompe!"}
		}
	};

	public List<Location> NaturalLocations = new List<Location> {
		new Location
		{
			Title = "Playa",
			Flavor = "Olas rompiendo en la orilla, el aire salado en las fosas nasales",
			Things = "Escombros dispersos, cangrejos, una luz en el horizonte, un velero varado.",
			LocationMoves =new List<MasterMove>
			{
				new MasterMove("Un aleta rompe la superficie del agua."),
				new MasterMove("Un grito resuena desde las selvas más allá."),
			}
		},
		new Location
		{
			Title = "La Cueva",
			Flavor = "Silencio espeluznante, sombras que podrían ocultar cualquier cosa, un olor a moho.",
			Things = "Podrían encontrar: Un nido de dinosaurios, una entrada secreta al complejo, CERATOPSIDOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Rocas caídas bloquean una salida."),
				new MasterMove("¿Son esas voces más adelante?"),
			}
		},
		new Location
		{
			Title = "Selva",
			Flavor = "Aire denso de humedad, enjambres de insectos, verde en todas direcciones.",
			Things = "Podrían encontrar: Una entrada al complejo, un explorador humano, el cadáver de alguien que se perdió.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Gíralos en el laberinto de árboles y enredaderas."),
				new MasterMove("Detén su paso con follaje impenetrable."),
			}
		},
		new Location
		{
			Title = "El Lago",
			Flavor = "Una brisa fresca, superficie cristalina, una enorme sombra submarina, olor a pescado.",
			Things = "Podrían encontrar: Una balsa, un puente precario, una casa de botes cerrada con llave, CRIATURAS ACUÁTICAS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Empuja a alguien o algo al agua."),
				new MasterMove("Cruzar es peligroso."),
			}
		},
		new Location
		{
			Title = "Las Montañas",
			Flavor = "El viento aúlla, acantilados imponentes que parecen subir para siempre.",
			Things = "Podrían encontrar: Una torre de radio, un avión estrellado, una caja de suministros sujeta a un paracaídas, PTEROSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Empuja algo o alguien hacia un abismo."),
				new MasterMove("Las rocas caen hacia ellos."),
				new MasterMove("La lluvia hace que las piedras resbalen."),
				new MasterMove("La noche cae y la temperatura desciende."),
			}
		},
		new Location
		{
			Title = "Terreno Abierto",
			Flavor = "Hierba alta susurrante, aros de baloncesto o porterías de fútbol en desuso.",
			Things = "Podrían encontrar: Una entrada secreta al complejo, equipo deportivo antiguo, un vehículo varado, PACHICEFALOSAURIOS, SAUROPODOS, ORNITOMIMOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Persíguelos a través."),
				new MasterMove("Átalos desde arriba."),
			}
		},
		new Location
		{
			Title = "El Río",
			Flavor = "Rápidos rugientes, rocío frío empapa tu ropa, rocas resbaladizas cubiertas de musgo.",
			Things = "Podrían encontrar: Una balsa y remos, peces, una entrada al complejo detrás de una cascada, HADROSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Empuja a alguien o algo al agua."),
				new MasterMove("La lluvia inunda el río, creando rápidos o haciendo una área intransitable."),
				new MasterMove("No hay manera de cruzar aquí."),
			}
		},
		new Location
		{
			Title = "El Pantano",
			Flavor = "Humedad sofocante, agua turbia hasta la cintura, olor a descomposición.",
			Things = "Podrían encontrar: Un bote de aire, ESPINOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Con el sol oculto por los árboles, gíralos."),
				new MasterMove("Alguien queda atrapado en el lodazal."),
				new MasterMove("Hay algo útil en el fango."),
			}
		},
		new Location
		{
			Title = "Cráter Volcánico",
			Flavor = "Calor extremo, terreno precario, el resplandor rojo del magma.",
			Things = "Podrían encontrar: Un lugar para colocar una bomba, un punto para ser recogidos por un helicóptero.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Una corriente de lava serpentea hacia ellos."),
				new MasterMove("Espeso gas venenoso se desplaza."),
				new MasterMove("Destruye algo para siempre."),
			}
		}
	};
	public List<Location> ArtificialLocations { get; set; } = new List<Location> {
		new Location
		{
			Title = "La Aviario",
			Flavor = "Pasarelas oscilantes, chillidos por todas partes, niebla que oculta la vista.",
			Things = "Podrían encontrar: Un atajo entre dos áreas, una forma de bajar de estos acantilados, PTEROSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Las pasarelas colapsan bajo su peso."),
				new MasterMove("Son forzados contra la jaula."),
			}
		},
		new Location
		{
			Title = "El Monorraíl",
			Flavor = "Enormes columnas de cemento, follaje cortado, música alegre pero tenue.",
			Things = "Podrían encontrar: Un mapa digital de la isla, transporte rápido a una parte diferente de la isla, SAUROPODOS, PTEROSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Parte de la vía ha sido destruida."),
				new MasterMove("El sistema de control del monorraíl está fallando."),
			}
		},
		new Location
		{
			Title = "Los Corrales",
			Flavor = "Vallas altas, el hedor de excremento de dinosaurio, huellas en el barro.",
			Things = "Podrían encontrar: Una valla eléctrica, un huevo de dinosaurio, excremento seco de dinosaurio, un rastreador GPS que debería estar conectado a un dinosaurio, CERATOPSIDOS, TERÓPODOS GRANDES.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("La valla eléctrica sigue activa."),
				new MasterMove("El dinosaurio o los dinosaurios siguen dentro."),
				new MasterMove("Algo terrible no está ahí... se ha escapado."),
			}
		},
		new Location
		{
			Title = "La Caseta de Energía",
			Flavor = "Túneles estrechos, tuberías y cables, vapor silbante, goteo de agua.",
			Things = "Podrían encontrar: Una forma de restaurar la energía a una parte o a toda la isla, linternas y herramientas, TERÓPODOS PEQUEÑOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Es un callejón sin salida."),
				new MasterMove("Atácalos desde las sombras."),
				new MasterMove("No tienen todas las herramientas o el conocimiento que necesitan."),
			}
		},
		new Location
		{
			Title = "La Torre de Radio",
			Flavor = "Juntas de metal crujientes, pájaros graznando, guano por todas partes.",
			Things = "Podrían encontrar: Walkie-talkies, un panel de control para acceder a la señal de radio, PTEROSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("La torre está transmitiendo una señal misteriosa."),
				new MasterMove("La torre necesita reparación antes de que funcione."),
				new MasterMove("La torre alberga un nido de pterosaurios."),
			}
		},
		new Location
		{
			Title = "El Puesto Fluvial",
			Flavor = "Un almacén de suministros sucio, el agrio olor del combustible, agua corriendo.",
			Things = "Podrían encontrar: Equipo de buceo, combustible, cuerda, tal vez una pequeña embarcación, SPINOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Algo o alguien es empujado al agua."),
				new MasterMove("Algo espera en el puesto."),
			}
		},
		new Location
		{
			Title = "El Escondite del Contrabandista",
			Flavor = "Una cabaña bien escondida para esconderse, mapas en todas las paredes.",
			Things = "Podrían encontrar: Armas, drogas, dinero, walkie-talkies, una pequeña avioneta o bote, paneles o compartimentos ocultos.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Desencadenan una trampa."),
				new MasterMove("Los contrabandistas regresan."),
			}
		}
	};
	public List<Location> ComplexLocations { get; set; } = new List<Location>
	{
		new Location
		{
			Title = "La Sala de Control",
			Flavor = "Docenas de pantallas, tazas de café abandonadas hace tiempo, el siseo de estática.",
			Things = "Podrían encontrar: Acceso a puertas, cerraduras, energía u otros sistemas; vistas de la isla/sitios del complejo.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Los sistemas de computadoras usan un sistema operativo propietario e inescrutable."),
				new MasterMove("Las cámaras revelan algo útil."),
				new MasterMove("Las cámaras revelan algo malo."),
			}
		},
		new Location
		{
			Title = "Dormitorios",
			Flavor = "Pequeñas viviendas abandonadas apresuradamente.",
			Things = "Podrían encontrar: Un diario personal con pistas; artículos personales que un PNJ podría querer; ropa de repuesto y otros artículos diversos.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Un PNJ regresa y encuentra a los jugadores rebuscando en sus cosas."),
				new MasterMove("Un dinosaurio atrapado en una habitación se libera."),
			}
		},
		new Location
		{
			Title = "El Vestíbulo",
			Flavor = "Un vestíbulo que alguna vez fue majestuoso, exhibiciones/estatuas celebratorias, polvo en los rayos de sol.",
			Things = "Podrían encontrar: Una pista sobre lo que era el complejo, un mapa del complejo, rutas marcadas hacia otras partes del complejo, ANQUILOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Un dinosaurio se esconde entre las exhibiciones."),
				new MasterMove("El camino que necesitan está bloqueado por escombros u otro daño."),
			}
		},
		new Location
		{
			Title = "La Criadero",
			Flavor = "El calor de las lámparas de calor de los incubadoras, cáscaras de huevo rotas crujen bajo los pies.",
			Things = "Podrían encontrar: Un huevo de dinosaurio, un dinosaurio bebé, muestras de sangre, embriones almacenados, un biólogo aterrorizado, ESTEGOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Una madre dinosaurio llega para defender a los jóvenes."),
				new MasterMove("Un bebé dinosaurio está cerca de la muerte."),
				new MasterMove("Algo está mal con los dinosaurios."),
				new MasterMove("\"¡Mantenete alejado de mi trabajo!\" Un científico se ha quedado atrás."),
			}
		},
		new Location
		{
			Title = "El Laboratorio",
			Flavor = "Especímenes en tanques, montones de registros y diarios, olor a formaldehído.",
			Things = "Podrían encontrar: Muestras o especímenes importantes, suministros médicos o científicos, equipo de manejo de dinosaurios, notas de investigación, XENOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Un espécimen se despierta y estalla."),
				new MasterMove("Muestra datos valiosos, a cambio de un precio."),
				new MasterMove("Hay algo aquí que les permitirá luchar contra los dinosaurios."),
			}
		},
		new Location
		{
			Title = "La Computadora Principal",
			Flavor = "Zumbido eléctrico, luces intermitentes, frialdad en el aire.",
			Things = "Podrían encontrar: Datos importantes, una unidad USB, un extinguidor de incendios, acceso a los sistemas de control del complejo, TERÓPODOS PEQUEÑOS, DROMAEOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Hay dos cables, ¿cuál es cuál?"),
				new MasterMove("Ah ah ah, no dijiste la palabra mágica. Se requiere una contraseña."),
			}
		},
		new Location
		{
			Title = "La Instalación Médica",
			Flavor = "Estanterías antes ordenadas ahora en desorden, mostradores de acero inoxidable.",
			Things = "Podrían encontrar: Un médico, suministros médicos, un PNJ con una lesión debilitante.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Un dinosaurio ha ingerido drogas y está buscando frenéticamente más."),
				new MasterMove("Otros sobrevivientes están tras la medicina y están dispuestos a matar por ella."),
			}
		},
		new Location
		{
			Title = "Oficinas",
			Flavor = "Suelos alfombrados, papel esparcido por todas partes, cubículos, fotos familiares.",
			Things = "Podrían encontrar: Archivos importantes, información sobre el complejo, una pistola, licor.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Un gerente cobarde se ha atrincherado dentro."),
				new MasterMove("La información llevará tiempo para descargar o revisar."),
			}
		},
		new Location
		{
			Title = "Los Túneles de Vapor",
			Flavor = "Oscuridad casi total, vapor que se escapa, tuberías densas.",
			Things = "Podrían encontrar: Un atajo, acceso a una ubicación anteriormente inalcanzable, TERÓPODOS PEQUEÑOS, SPINOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Los pasajes laberínticos los desorientan."),
				new MasterMove("El vapor ardiente bloquea su camino."),
				new MasterMove("Algo ha hecho su hogar aquí, en la oscuridad."),
			}
		}
	};
	public List<Location> ExtrangeLocations { get; set; } = new List<Location>
	{
		new Location
		{
			Title = "Ruinas Antiguas",
			Flavor = "Grabados misteriosos, estatuas y columnas que se desmoronan.",
			Things = "Podrían encontrar: Conocimientos perdidos hace mucho tiempo, un extraño artefacto, un vehículo asombroso.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Atrápelos en un laberinto de ruinas."),
				new MasterMove("Impresiónelos con estructuras y estatuas antiguas."),
				new MasterMove("Ofrezca un premio poderoso, a un precio."),
			}
		},
		new Location
		{
			Title = "La Aldea Nativa",
			Flavor = "Conversaciones susurradas, música de flauta y tambor, olor a jabalí cocido.",
			Things = "Podrían encontrar: Herramientas hechas a mano pero de alta calidad, una deliciosa comida caliente, nativos que desafían sus expectativas, dinosaurios domesticados.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Exija algo que los héroes no quieran desprenderse."),
				new MasterMove("Se ofendan."),
				new MasterMove("Desconfíen de los Héroes."),
			}
		},
		new Location
		{
			Title = "El Obelisco",
			Flavor = "Antiguo e antinatural, una textura extraña, un sonido familiar que simplemente no puedes ubicar.",
			Things = "Podrían encontrar: Marcas misteriosas, pistas sobre la historia de la isla, un panel de control oculto diferente a todo lo que han visto antes, TERIZINOSAURIOS.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Causar una lesión inesperada."),
				new MasterMove("Hacer algo inexplicable."),
				new MasterMove("No hacer nada en absoluto."),
			}
		},
		new Location
		{
			Title = "La Puerta Temporal",
			Flavor = "Colores y sonidos psicodélicos, arcos masivos, relámpagos morados.",
			Things = "Podrían encontrar: Una forma de detener a los dinosaurios de llegar al presente, una forma de regresar al presente, tecnología imposible.",
			LocationMoves = new List<MasterMove>
			{
				new MasterMove("Vomitar algo del pasado."),
				new MasterMove("Vomitar algo del futuro."),
				new MasterMove("Atraer a alguien hacia adentro."),
			}
		}
	};
}
public class Location
{
	public string Title { get; set; } = string.Empty;
	public string Flavor { get; set; } = string.Empty;
	public string Things { get; set; } = string.Empty;
	public List<MasterMove> LocationMoves { get; set; } = new List<MasterMove>();
}

public class Mystery
{
	public string Question { get; set; } = string.Empty;
	public List<MysterySolution> Solutions { get; set; } = new List<MysterySolution>();
	public MysterySolution SelectedSolution { get; set; } = new MysterySolution
	{
		FirstClue = "Not Set",
		Solution = "Not Set"
	};
}
public class MysterySolution
{
	public string Solution { get; set; } = string.Empty;
	public string FirstClue { get; set; } = string.Empty;
}

public class ExtinctionEvent
{
	public string Tittle { get; set; } = string.Empty;
	public List<string> WarningMoves { get; set; } = new();
	public List<MasterMove> NewMasterMoves { get; set; } = new();
	public Clock Clock { get; set; } = new();

}

public class MasterMove
{
	public string Tittle = string.Empty;
	public HowOftenUsed HowOften = HowOftenUsed.NeverUsed;

	public MasterMove(string txt) => Tittle = txt;

	public void Use()
	{
		if (HowOften == HowOftenUsed.NeverUsed) HowOften = HowOftenUsed.FewUses;
		else if (HowOften == HowOftenUsed.FewUses) HowOften = HowOftenUsed.LotsOfUses;
		else if (HowOften == HowOftenUsed.LotsOfUses) HowOften = HowOftenUsed.ToMuch;
		else if (HowOften == HowOftenUsed.ToMuch) HowOften = HowOftenUsed.NeverUsed;
	}

	public int Order
	{
		get
		{
			if (HowOften == HowOftenUsed.NeverUsed) return 0;
			else if (HowOften == HowOftenUsed.FewUses) return 1;
			else if (HowOften == HowOftenUsed.LotsOfUses) return 2;
			else return 3;
		}
	}

}