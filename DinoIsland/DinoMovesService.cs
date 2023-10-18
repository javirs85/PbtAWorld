using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PbtALib;

using DinoIsland;


public enum DinoMoveIDs { notSet, D_Run, D_Hide, D_DoIt, D_ManUp, D_LookThere, D_TakeMyHand, D_Fight, D_LayLand, D_Instruct, D_Scavenge, D_LaidPlans, D_Casualty, D_RawFit, D_RawClever, D_RawSteady, D_2d6,
	D_Doc_TreatWounds,
	D_Eng_JuryRig,
	D_Hun_Scaveng,
	D_Pal_Expert,
	D_Sol_KillOrBeKilled,
	D_Sur_KillOrBeKilled,
	D_Sur_BeenAroundTheBlock,
	D_Sur_HomewardBound,
	D_Sur_Hoarder,
	D_Sur_FadeAway,
	D_Sol_LeaveNoOneBehind,
	D_Sol_GunToYourHead,
	D_Sol_CloseQuartersExpert,
	D_Pal_LizardBrain,
	D_Pal_CuriosityKilledTheQuetzalcoatlus,
	D_Pal_Polymath,
	D_Kid_IKnowThis,
	D_Kid_aaaaah,
	D_Kid_InspireHeroism,
	D_Kid_GoodListener,
	D_Hun_Trapper,
	D_Hun_ItsTooQuiet,
	D_Eng_Construct,
	D_Eng_TheNuclearOption,
	D_Doc_BackFromTheBrink,
	D_Doc_HealTyself,
	D_Doc_Veterinarian
}

public static class Extensions
{
    public static string ToUI(this DinoStates moveId) 
    {
        return moveId switch
        {
            DinoStates.D_Fit => "Forma física",
            DinoStates.D_Steady => "Calma",
            DinoStates.D_NoRoll => "Sin tirada",
            DinoStates.D_Clever => "Inteligencia",
            DinoStates.D_NotSet => "Not set",
            DinoStates.D_MC => "Lo que pida el MC",
            DinoStates.D_Weapon => "sin bonificación, o +1 si tienes un arma",
            _ => "Not set"
        };
    }
}

public class DinoMovesService : MovesServiceBase
{
    public List<DinoMove> DangerMoves { get; set; } = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Run, DinoStates.D_Fit)
        {
            Tittle = "Corre!",
            PreCondition = new Consequences
            { 
                MainText = "Cuando corres, tira + Forma física "
            },
			ConsequencesOn10 = new Consequences
            {
                MainText = "Escapas a una ubicación segura. El DM la describirá. Tienes una idea aproximada de dónde estás."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Elige 1:",
                Options = new List<string>
                {
                    "Llegas a una nueva ubicación, pero aún estás siendo perseguido.",
                    "Escapas de la amenaza... pero te encuentras en una nueva situación peligrosa."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Resultas herido y la amenaza persiste."
            }
        },
        new DinoMove(DinoMoveIDs.D_Hide, DinoStates.D_Clever)
        {
            Tittle = "Escondete!",
			PreCondition = new Consequences
			{
				MainText = "Cuando te escondes de un depredador, indica dónde te estás escondiendo y tira + Inteligencia"
			},
            ConsequencesOn10 = new Consequences
            {
                MainText = "No puede encontrarte ni alcanzarte. Estás a salvo."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Alguien más queda expuesto. Si te mantienes oculto, estarás bien, pero ellos no. Si estás solo, el DM te ofrecerá una elección difícil diferente."
            },
            ConsequencesOn6 = new Consequences
			{
                MainText = "¡Sorpresa! Está justo encima de ti."
            }
        },
        new DinoMove(DinoMoveIDs.D_DoIt, DinoStates.D_Steady)
        {
            Tittle = "Simplemente Hazlo!",
			PreCondition = new Consequences
			{
				MainText = "Cuando haces algo que normalmente puedes hacer fácilmente (por ejemplo, desbloquear una puerta, cruzar silenciosamente una habitación o conducir un automóvil) bajo presión, di qué sucederá si cometes un error y luego tira + Calma"
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "Lo logras."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Resbalaste, dudaste o tomaste atajos. El DM te ofrecerá una elección difícil."
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Bueno, ya sabes lo que sucede."
            }
        },
         new DinoMove(DinoMoveIDs.D_ManUp, DinoStates.D_Fit)
        {
            Tittle = "Echale valor!",
			PreCondition = new Consequences
			{
				MainText = "Cuando confías en la pura fisicalidad para superar dificultades o ignoras una lesión debilitante, tira + Forma física"
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "Resistes."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Tienes éxito, pero estás exhausto; resta -1 en tu próxima tirada con FORMA FÍSICA."
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Estás seriamente herido."
            }
        },
         new DinoMove(DinoMoveIDs.D_LookThere, DinoStates.D_Clever)
        {
            Tittle = "Mira allí!",
			PreCondition = new Consequences
			{
				MainText = "Cuando creas una distracción para proteger a un amigo, di qué es y tira + Inteligencia"
			},
            ConsequencesOn10 = new Consequences
            {
                MainText = "Atraes la atención del dinosaurio donde pretendías. Tu amigo está a salvo."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "El dinosaurio te nota a ti."
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Lo mejor que puedes hacer es recibir el golpe por tu amigo. ¿Lo harás? "
            },
            ClosingText = "Si eliges llamar la atención del dinosaurio hacia ti, siempre tienes éxito",
        },
         new DinoMove(DinoMoveIDs.D_TakeMyHand, DinoStates.D_MC)
        {
            Tittle = "Toma mi Mano!",
			PreCondition = new Consequences
			{
				MainText = "Cuando dejas lo que estás haciendo para ayudar a alguien más en apuros, tira + lo que el MC crea conveniente"
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "Tienen éxito, con tu ayuda."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Elige 1:",
                Options = new List<string>
                {
                    "Se separan del grupo.",
                    "Resuelves su problema, pero te creas uno para ti mismo."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Lo empeoraste para ambos."
            }
        },
        new DinoMove(DinoMoveIDs.D_Fight, DinoStates.D_Weapon)
        {
            Tittle = "Lucha!",
			PreCondition = new Consequences
			{
				MainText = "Cuando luchas por tu vida, tira sin bonificación, con +1 si tienes un arma"
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "Compras un momento precioso para que alguien te ayude. Elije las dos opciones de la siguiente lista."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Elije sólo una:",
                Options = new List<string>
                {
                    "No resultas herido",
                    "Hieres al enemigo, el MC elige cómo."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Realiza el Movimiento de CAIDO. Lo siento. "
            },
            ClosingText = "El MC siempre puede decidir que no puedes luchar contra un dinosaurio"
        }
    };
    public List<DinoMove> SafetyMoves { get; set; } = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_LayLand, DinoStates.D_Clever)
        {
            Tittle = "Reconocer el terreno",
			PreCondition = new Consequences
			{
				MainText = "Cuando tú y un compañero os tomáis un momento tranquilo para llegar a un buen punto de observación y orientaros, cuenta una historia, luego tira + Inteligencia. El MC te hablará sobre dos puntos de referencia, uno natural y otro hecho por el hombre, que puedes ver."
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "también te mostrarán dónde estás en el mapa"
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Descubres un peligro inminente."
            }
        },
        new DinoMove(DinoMoveIDs.D_Instruct, DinoStates.D_Steady)
        {
            Tittle = "Instruir",
			PreCondition = new Consequences
			{
				MainText = "Cuando guías a otro héroe a través de una tarea peligrosa que sabes hacer, pero que deben hacer ellos (quizás porque estás comunicándote por walkies, están en lados opuestos de una cerca o estás herido), cuéntales una historia y tira + Calma. Con un éxito: Eres un buen maestro. Tienen éxito.",
			},
			ConsequencesOn79 = new Consequences
            {
                MainText = "No lo hacen tan bien como tú lo harías. Elige 1:",
                Options = new List<string>
                {
                    "Toma más tiempo de lo esperado.",
                    "Los expone al peligro.",
                    "Te expone al peligro."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Los confundes, enfadas o distraes (su elección). La tarea está arruinada más allá de poder salvarla y has empeorado las cosas."
            }
        },
        new DinoMove(DinoMoveIDs.D_Scavenge, DinoStates.D_Clever)
        {
            Tittle = "Rebuscar",
			PreCondition = new Consequences
			{
				MainText = "Cuando tú y otro héroe se toman un momento tranquilo para buscar objetos o información útil, cuéntales una historia y tira + Inteligencia"
			},
			ConsequencesOn10 = new Consequences
            {
                MainText = "Encuentras algo útil. Tal vez incluso eso que estabas esperando."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Encuentras algo práctico, pero haces mucho ruido. Puedes hacer como si ningún dinosaurio te hubiera oído, si quieres."
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Encuentras algo malo."
            }
        },
        new DinoMove(DinoMoveIDs.D_Casualty, DinoStates.D_NoRoll)
        {
            Tittle = "Caído",
			PreCondition = new Consequences
			{
				MainText = "Cuando estás gravemente herido (o te lesionas estando ya herido), estás en mal estado. Cuéntale a alguien tu secreto más oscuro o esperanza no cumplida, luego elige 1:",
				 Options = new List<string>
				{
					"Tienes un último acto heroico, sujeto a la discreción del DM, antes de morir.",
					"Estás FUERA DE COMBATE. No puedes hacer nada, pero tu personaje sobrevivirá si los demás pueden sacarte de la isla a tiempo."
				}
			},
            ClosingText = "De cualquier manera, puedes elegir un playbook no utilizado y crear un nuevo personaje. El DM te dirá cuándo aparece tu nuevo personaje."
        },
    };

    public List<DinoMove> DoctorMoves = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Doc_TreatWounds, DinoStates.D_Story)
        {
            Tittle = "Tratar Heridas",
            ForClass =DinoClasses.Doctor,
            PreCondition = new Consequences
            {
                MainText = "Cuando tomas un momento tranquilo para atender la lesión de otra persona y tienes el equipo adecuado, cuéntales una historia (sí, incluso si están inconscientes... un momento particularmente bueno para la honestidad). Tira, y tacha la lesión.\n\nSi las condiciones no son las idóneas entonces ...",
                Options = new List<string>
                {
                    "Si la situación es peligrosa, tira + Calma",
                    "Sin el equipo adecuado, tira + Inteligencia",
                    "Si se dan las dos, tira sin bonus"
                },
				
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Tratas su herida. Si es un Héroe, tacha la lesión de su hoja de personaje."
			},
			ConsequencesOn79 = new Consequences
	        {
		        MainText = "Podrías hacerlo... si las condiciones fueran adecuadas. El DM te dirá lo que necesitas. Cuando lo consigas, tacha la lesión."
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "El DM te dirá cómo has empeorado las cosas."
	        }
		},
		new DinoMove(DinoMoveIDs.D_Doc_BackFromTheBrink, DinoStates.D_Story)
		{
			Tittle = "De Vuelta del Abismo",
			ForClass = DinoClasses.Doctor,
			IsAdvancedMove = true,
			PreCondition = new Consequences
			{
				MainText = "Puedes tratar a un personaje que esté Fuera de Combate para revivirlo. Conservan su lesión anterior."
			}
		},
		new DinoMove(DinoMoveIDs.D_Doc_HealTyself, DinoStates.D_Story)
		{
			Tittle = "Curarse a sí mismo",
			ForClass = DinoClasses.Doctor,
			IsAdvancedMove = true,
			PreCondition = new Consequences
			{
				MainText = "Puedes usar el movimiento TRATAR HERIDAS en ti mismo."
			}
		},
		new DinoMove(DinoMoveIDs.D_Doc_Veterinarian, DinoStates.D_Story)
		{
			Tittle = "Veterinario",
			ForClass = DinoClasses.Doctor,
			IsAdvancedMove = true,
			PreCondition = new Consequences
			{
				MainText = "Puedes tratar las heridas de dinosaurios y animales."
			}
		}
	};

    public List<DinoMove> EngineerMoves = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Eng_JuryRig, DinoStates.D_Clever)
        {
            ForClass = DinoClasses.Engineer,
			Tittle = "Chapuzas",
	        PreCondition = new Consequences
	        {
		        MainText = "Siempre que improvisas una solución temporal a un problema, tira + Inteligencia."
	        },
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "Hará el truco."
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "Funcionará, pero elige 1:",
		        Options = new List<string>
		        {
			        "Tendrás que desmontar algo más",
			        "No durará mucho tiempo",
			        "Tomará un tiempo"
		        }
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Te metes con algo o alguien, y causas daño."
	        }
		},
		new DinoMove(DinoMoveIDs.D_Eng_Construct, DinoStates.D_Clever)
        {
	        Tittle = "Construir",
	        ForClass = DinoClasses.Engineer,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando lideras un equipo para construir algo sustancial (una balsa, puente, refugio, etc.), *asigna a una persona para que se encargue de la construcción.** Tú haces el diseño. Tira + Inteligencia.",
	        },
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "es una ingeniería excelente."
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "Elige 1:",
		        Options = new List<string>
		        {
			        "Necesitas algo que no tienes. El DM te dirá qué y dónde podrías encontrarlo.",
			        "Es un buen plan, pero tiene un defecto inevitable. El DM te dirá cuál es."
		        }
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Si fallas, hay un defecto que no notaste. Cuando surja, el DM te lo dirá."
	        },
	        ClosingText = "*Quien lidere la construcción**: Tira + el número de personas que te ayudan (máximo 3).\n\n*En un 10+**, lo construyes rápidamente y con maestría. \n*En un 7–9**, es un trabajo duro. Todos los constructores tienen -1 en su próxima tirada de AJUSTE. \n*En un fallo**, alguien resulta herido en el trabajo."
		},
		new DinoMove(DinoMoveIDs.D_Eng_TheNuclearOption, DinoStates.D_Clever)
		{
			Tittle = "La Opción Nuclear",
			ForClass = DinoClasses.Engineer,
			IsAdvancedMove = true,
			PreCondition = new Consequences
			{
				MainText = "Sabes cómo fabricar una bomba potente. Cuando construyes una, dile al grupo cuán poderosa es y cómo se activa. El DM te dirá cuánto tiempo llevará construirla y qué necesitas.\nCuando detones la bomba tira + Inteligencia",
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Explota sin problemas. ¡BOOM!"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Elige 1:",
				Options = new List<string>
				{
					"La bomba debe ser activada manualmente por alguien cerca de ella.",
					"La bomba es más o menos potente de lo planeado, elección del DM."
				}
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas, la bomba explota en el momento equivocado, el peor momento posible."
			}
		}
	};

    public List<DinoMove> HunterMoves = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Hun_Scaveng, DinoStates.D_Clever)
        {
            ForClass = DinoClasses.Hunter,
            Tittle = "Rastreador",
            PreCondition = new Consequences
            {
                MainText = "Cuando estudias tu entorno inmediato en busca de huellas, tira + Inteligencia.\n\nEn caso de éxito, sabes qué animales han estado aquí recientemente (aunque es posible que no sepas las especies exactas de dinosaurios) y el tamaño de sus grupos."
            },
            ConsequencesOn10 = new Consequences
            {
                MainText = "haz 3 preguntas de la lista siguiente"
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "haz 1 pregunta",
                Options = new List<string>
                {
                    "¿De dónde vienen los animales?",
                    "¿Hacia dónde se dirigen los animales?",
                    "¿Cómo puedo sorprenderlos desprevenidos?",
                    "¿Qué más cercano debería saber que quizás no sea obvio?"
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Te das cuenta de que un depredador se está preparando para atacar."
            },
            ClosingText = "Las respuestas deben ser sustanciales. Por ejemplo, '¿De dónde vienen los animales?' no debería ser simplemente '¡Por allí!', sino más bien 'Un cuerpo de agua al este.'"
        },
		new DinoMove(DinoMoveIDs.D_Hun_Trapper, DinoStates.D_Clever)
        {
	        Tittle = "Trampero",
	        ForClass = DinoClasses.Hunter,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Con el equipo adecuado, puedes preparar una trampa para un dinosaurio u otro animal y capturarlo. Describe tu plan. Cuando lo pongas en acción, tira + Inteligencia.",
	        },
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "En un 10+, capturas al dinosaurio de manera segura y firme."
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "Elige 1:",
		        Options = new List<string>
		        {
			        "El dinosaurio es capturado sin lesiones.",
			        "El dinosaurio es capturado de forma segura y no se soltará.",
			        "Nadie resultó herido durante la captura del dinosaurio."
		        }
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Si fallas, no pudiste capturar al dinosaurio, te has expuesto a ti mismo o a un amigo al peligro, y el dinosaurio también está enfadado."
	        }
        },
		new DinoMove(DinoMoveIDs.D_Hun_ItsTooQuiet, DinoStates.D_NoRoll)
        {
	        Tittle = "Demasiado silencio...",
	        ForClass = DinoClasses.Hunter,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Siempre sabes cuando te están cazando y no puedes ser emboscado. Para advertir a los demás sin alertar a tu enemigo, debes ¡HAZLO!"
	        }
        }
	};

    public List<DinoMove> KidMoves = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Kid_IKnowThis, DinoStates.D_NoRoll)
        {
            Tittle = "¡Yo Sé Esto!",
            ForClass = DinoClasses.Kid,
            IsAdvancedMove = false,
            PreCondition = new Consequences
            {
                MainText = "Cuando nadie más tiene una habilidad crucial, puedes revelar que, de hecho, tienes esa habilidad porque eres un niño precoz. El uso de la habilidad *siempre** requiere que *simplemente lo hagas.**"
            }
        },
		new DinoMove(DinoMoveIDs.D_Kid_aaaaah, DinoStates.D_NoRoll)
		{
			Tittle = "¡Ahhhhhhhhhhh!",
			ForClass = DinoClasses.Kid,
			IsAdvancedMove = false,
			PreCondition = new Consequences
			{
				MainText = "Siempre que gritas a otro Héroe pidiendo ayuda, deben responder a tu llamada."
			}
		},
		new DinoMove(DinoMoveIDs.D_Kid_InspireHeroism, DinoStates.D_NoRoll)
        {
	        Tittle = "Inspirar Heroísmo",
	        ForClass = DinoClasses.Kid,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando otro Héroe pone tus necesidades por encima de su propia seguridad (incluyendo en respuesta a ¡Ahhhhhh!), todas las tiradas que hagan se mejoran en un nivel. Un fallo se convierte en un 7–9, y un 7–9 se convierte en un 10+."
	        }
        },
		new DinoMove(DinoMoveIDs.D_Kid_GoodListener, DinoStates.D_NoRoll)
        {
	        Tittle = "Buen alumno",
	        ForClass = DinoClasses.Kid,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando te ofreces voluntario para un trabajo difícil y alguien más *TE INSTRUYE**, trata un fallo como si hubieran sacado un 7–9."
	        }
        }
	};

	public List<DinoMove> PaleontologistMoves = new List<DinoMove>
    {
		new DinoMove(DinoMoveIDs.D_Pal_Expert, DinoStates.D_Clever)
        {
	        ForClass = DinoClasses.Paleontologist,
	        Tittle = "Experto en Dinosaurios",
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando recurres a tu conocimiento para lidiar con un dinosaurio real, tira + Inteligencia.\n\nEn caso de éxito, puedes identificar su especie, sexo y si es herbívoro o carnívoro."
			},
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "puedes hacer 3 preguntas de la siguiente lista.",
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "puedes hacer 1 pregunta ",
		        Options = new List<string>
		        {
			        "¿Cuál es su motivación?",
			        "¿Cuáles son sus movimientos?",
			        "¿En qué tamaño de manada se desplaza?",
			        "¿Cuál es su debilidad?"
		        }
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Resulta que los dinosaurios vivos son diferentes de lo que pensabas, y para mal.",		        
	        },
			ClosingText = "Solo puedes usar este movimiento una vez por especie, a menos que tengas la oportunidad de estudiar más de cerca a un espécimen vivo."
		},
		new DinoMove(DinoMoveIDs.D_Pal_LizardBrain, DinoStates.D_NoRoll)
        {
	        Tittle = "Cerebro de Lagarto",
	        ForClass = DinoClasses.Paleontologist,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando obtienes un éxito con *EXPERTO EN DINOSAURIOS**, en lugar de hacer una de tus preguntas, puedes infundir una emoción simple (miedo, apatía, enojo, etc.) en un dinosaurio usando lenguaje corporal y sonido."
	        }
        },
		new DinoMove(DinoMoveIDs.D_Pal_CuriosityKilledTheQuetzalcoatlus, DinoStates.D_NoRoll)
        {
	        Tittle = "La Curiosidad Mató al Quetzalcoatlus",
	        ForClass = DinoClasses.Paleontologist,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando te pones en peligro en busca de conocimiento o para investigar un misterio, obtienes +1 en tu tirada."
	        }
        },
		new DinoMove(DinoMoveIDs.D_Pal_Polymath, DinoStates.D_Clever)
        {
	        Tittle = "Polímata",
	        ForClass = DinoClasses.Paleontologist,
	        IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Tus habilidades deductivas e inductivas se extienden más allá de los fósiles y la vida prehistórica. Cuando pasas tiempo examinando algo sólidamente misterioso, cuéntales una historia y tira + Inteligencia."
	        },
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "el DM te dirá algo interesante y útil que puedas deducir sobre el tema."
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "el DM te dirá lo que necesitas —una herramienta, conocimiento específico, etc.— para entenderlo, y una suposición sobre dónde podrías encontrarlo."
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Descubres algo horrible."
	        }
        }
	};

    public List<DinoMove> SoldierMoves = new List<DinoMove>
    {
		new DinoMove(DinoMoveIDs.D_Sol_KillOrBeKilled, DinoStates.D_Steady)
        {
	        Tittle = "Matar o Morir",
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando abres fuego contra un dinosaurio o grupo de dinosaurios, tira + Calma."
	        },
	        ConsequencesOn10 = new Consequences
	        {
		        MainText = "Los derribas."
	        },
	        ConsequencesOn79 = new Consequences
	        {
		        MainText = "Usas demasiada munición, te quedas sin balas."
	        },
	        ConsequencesOn6 = new Consequences
	        {
		        MainText = "Te atacan y de inmediato realizas el movimiento BAJA. (No falles.)"
	        }
        },
		new DinoMove(DinoMoveIDs.D_Sol_LeaveNoOneBehind, DinoStates.D_NoRoll)
		{
			Tittle = "No Dejar a Nadie Atrás",
			ForClass = DinoClasses.Soldier,
			IsAdvancedMove = true,
			PreCondition = new Consequences
			{
				MainText = "Cuando un aliado cercano está a punto de ser herido, asesinado o separado del grupo, puedes obtener +1 en las tiradas para ayudarlos."
			}
		},
		new DinoMove(DinoMoveIDs.D_Sol_GunToYourHead, DinoStates.D_NoRoll)
        {
	        Tittle = "Pistola en la Cabeza",
	        ForClass = DinoClasses.Soldier, // Ajusta la clase según corresponda
            IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando amenazas a un humano con violencia física, deben hacer lo que dices o recibir una lesión de tu elección."
	        }
        },
		new DinoMove(DinoMoveIDs.D_Sol_CloseQuartersExpert, DinoStates.D_NoRoll)
        {
	        Tittle = "Experto en Combate Cercano",
	        ForClass = DinoClasses.Soldier, 
            IsAdvancedMove = true,
	        PreCondition = new Consequences
	        {
		        MainText = "Cuando LUCHAS!, tu tirada se mejora en un nivel. Un fallo se convierte en un 7–9, y un 7–9 se convierte en un 10+."
	        }
        }
	};

	public List<DinoMove> SurvivorMoves = new List<DinoMove>
    {
        new DinoMove(DinoMoveIDs.D_Sur_BeenAroundTheBlock, DinoStates.D_Clever)
        {
            Tittle = "He estado allí...",
            PreCondition = new Consequences
            {
                MainText = "Cuando alguien menciona un lugar específico en la isla por primera vez, tira + Inteligencia si has estado allí."
            },
            ConsequencesOn10 = new Consequences
            {
                MainText = "sabes exactamente dónde está. Marca en el mapa y obtén +1 en todas las tiradas mientras viajas allí."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Recuerdas dónde está y la razón por la que es desafiante llegar allí. Di cuál es."
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "El MC te dirá la razón por la que juraste que nunca volverías."
            },
            ClosingText = "Independientemente de tu tirada, cuéntales sobre la última vez que estuviste allí."
        },
        new DinoMove(DinoMoveIDs.D_Sur_HomewardBound, DinoStates.D_Clever)
        {
            Tittle = "De Regreso a Casa",
            ForClass = DinoClasses.Survivor,
            PreCondition = new Consequences
            {
                MainText = "Cuando te diriges a tu refugio, tira + Inteligencia."
            },
            ConsequencesOn10 = new Consequences
            {
                MainText = "llegas después de un viaje seguro."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Aun llegas, pero elige 1:",
                Options = new List<string>
                {
                    "Te ves obligado a tomar una ruta indirecta y llegas horas más tarde de lo planeado.",
                    "Hay una amenaza esperándote."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "No puedes llegar allí. El MC te dirá por qué y te ofrecerá una elección de a dónde ir en su lugar."
            }
        },
        new DinoMove(DinoMoveIDs.D_Sur_Hoarder, DinoStates.D_Clever)
        {
            Tittle = "Acumulador",
			ForClass = DinoClasses.Survivor,
            IsAdvancedMove = true,
			PreCondition = new Consequences
            {
                MainText = "Has acumulado muchas cosas útiles en la isla: tarjetas clave, piezas mecánicas, botellas de orina de tiranosaurio, etc. Cuando podrías tener justo lo que necesitas, tira + Inteligencia."
            },
            ConsequencesOn10 = new Consequences
            {
                MainText = "lo tienes, o algo lo suficientemente similar."
            },
            ConsequencesOn79 = new Consequences
            {
                MainText = "Elige 1:",
                Options = new List<string>
                {
                    "Tienes algo similar, aunque no tan bueno.",
                    "Tienes la cosa, pero está en tu refugio."
                }
            },
            ConsequencesOn6 = new Consequences
            {
                MainText = "Tu búsqueda sale fallida y te cuesta tiempo valioso."
            }
        },
		new DinoMove(DinoMoveIDs.D_Sur_FadeAway, DinoStates.D_NoRoll)
        {
	        Tittle = "Desvanecerse",
			ForClass = DinoClasses.Survivor,
			IsAdvancedMove = true,
			PreCondition = new Consequences
	        {
		        MainText = "Mientras estás en la naturaleza, siempre que *TE ESCONDAS!**, trata tu tirada como un 10+, incluso si tu enemigo te tiene a la vista. Tus amigos deberán cuidarse solos."
	        }
        }
	};



	public List<DinoMove> AllMoves { get; set; } = new List<DinoMove>();

    public DinoMovesService()
    {
        AllMoves.AddRange(DangerMoves);
        AllMoves.AddRange(SafetyMoves);
        AllMoves.AddRange(DoctorMoves);
        AllMoves.AddRange(EngineerMoves);
        AllMoves.AddRange(HunterMoves);
        AllMoves.AddRange(KidMoves);
        AllMoves.AddRange(PaleontologistMoves);
        AllMoves.AddRange(SoldierMoves);
        AllMoves.AddRange(SurvivorMoves);

		AllMoves.Add(new DinoMove(DinoMoveIDs.D_RawClever, DinoStates.D_Clever) { Tittle = "Inteligencia" });
		AllMoves.Add(new DinoMove(DinoMoveIDs.D_RawFit, DinoStates.D_Fit) { Tittle = "Forma física" });
		AllMoves.Add(new DinoMove(DinoMoveIDs.D_RawSteady, DinoStates.D_Steady) { Tittle = "Calma" });
		AllMoves.Add(new DinoMove(DinoMoveIDs.D_2d6, DinoStates.D_NoRoll) { Tittle = "2d6" });

	}

	public override IMove GetMovement<TMovIDs, TClases>(TMovIDs ID, TClases archetype)
	{
		throw new NotImplementedException();
	}

	public override IMove GetMovement<TMovIDs>(TMovIDs _ID)
	{
		DinoMoveIDs ID = (DinoMoveIDs)(object)_ID;
		return AllMoves.Find(x => x.ID == ID) ?? new DinoMove(DinoMoveIDs.notSet, DinoStates.D_NotSet) { Tittle = "Unknown movement" };
	}
}
