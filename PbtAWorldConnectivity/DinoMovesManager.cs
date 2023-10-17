using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PbtAWorldConnectivity;


public enum DinoMoves { D_Run, D_Hide, D_DoIt, D_ManUp, D_LookThere, D_TakeMyHand, D_Fight, D_LayLand, D_Instruct, D_Scavenge, D_LaidPlans, D_Casualty }
public enum DinoStates { D_Fit, D_Steady, D_Clever, D_MC, D_Weapon, D_NotSet, D_NoRoll}

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


public class DinoMovesManager
{
    public List<Move<DinoMoves, DinoStates>> DangerMoves { get; set; } = new List<Move<DinoMoves, DinoStates>>
    {
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Run, DinoStates.D_Fit)
        {
            Name = "Corre!",
            Trigger = "Cuando corres, tira + ",
            On10 = new Consequence
            {
                MainText = "Escapas a una ubicación segura. El DM la describirá. Tienes una idea aproximada de dónde estás."
            },
            On79 = new Consequence
            {
                MainText = "Elige 1:",
                Options = new List<string>
                {
                    "Llegas a una nueva ubicación, pero aún estás siendo perseguido.",
                    "Escapas de la amenaza... pero te encuentras en una nueva situación peligrosa."
                }
            },
            On6 = new Consequence
            {
                MainText = "Resultas herido y la amenaza persiste."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Hide, DinoStates.D_Clever)
        {
            Name = "Escondete!",
            Trigger = "Cuando te escondes de un depredador, indica dónde te estás escondiendo y tira + ",
            On10 = new Consequence
            {
                MainText = "No puede encontrarte ni alcanzarte. Estás a salvo."
            },
            On79 = new Consequence
            {
                MainText = "Alguien más queda expuesto. Si te mantienes oculto, estarás bien, pero ellos no. Si estás solo, el DM te ofrecerá una elección difícil diferente."
            },
            On6 = new Consequence
            {
                MainText = "¡Sorpresa! Está justo encima de ti."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_DoIt, DinoStates.D_Steady)
        {
            Name = "Simplemente Hazlo!",
            Trigger = "Cuando haces algo que normalmente puedes hacer fácilmente (por ejemplo, desbloquear una puerta, cruzar silenciosamente una habitación o conducir un automóvil) bajo presión, di qué sucederá si cometes un error y luego tira + ",
            On10 = new Consequence
            {
                MainText = "Lo logras."
            },
            On79 = new Consequence
            {
                MainText = "Resbalaste, dudaste o tomaste atajos. El DM te ofrecerá una elección difícil."
            },
            On6 = new Consequence
            {
                MainText = "Bueno, ya sabes lo que sucede."
            }
        },
         new Move<DinoMoves, DinoStates>(DinoMoves.D_ManUp, DinoStates.D_Fit)
        {
            Name = "Echale valor!",
            Trigger = "Cuando confías en la pura fisicalidad para superar dificultades o ignoras una lesión debilitante, tira + ",
            On10 = new Consequence
            {
                MainText = "Resistes."
            },
            On79 = new Consequence
            {
                MainText = "Tienes éxito, pero estás exhausto; resta -1 en tu próxima tirada con FORMA FÍSICA."
            },
            On6 = new Consequence
            {
                MainText = "Estás seriamente herido."
            }
        },
         new Move<DinoMoves, DinoStates>(DinoMoves.D_LookThere, DinoStates.D_Clever)
        {
            Name = "Mira allí!",
            Trigger = "Cuando creas una distracción para proteger a un amigo, di qué es y tira + ",
            On10 = new Consequence
            {
                MainText = "Atraes la atención del dinosaurio donde pretendías. Tu amigo está a salvo."
            },
            On79 = new Consequence
            {
                MainText = "El dinosaurio te nota a ti."
            },
            On6 = new Consequence
            {
                MainText = "Lo mejor que puedes hacer es recibir el golpe por tu amigo. ¿Lo harás? "
            },
            ClossingText = "Si eliges llamar la atención del dinosaurio hacia ti, siempre tienes éxito",
        },
         new Move<DinoMoves, DinoStates>(DinoMoves.D_TakeMyHand, DinoStates.D_MC)
        {
            Name = "Toma mi Mano!",
            Trigger = "Cuando dejas lo que estás haciendo para ayudar a alguien más en apuros, tira +",
            On10 = new Consequence
            {
                MainText = "Tienen éxito, con tu ayuda."
            },
            On79 = new Consequence
            {
                MainText = "Elige 1:",
                Options = new List<string>
                {
                    "Se separan del grupo.",
                    "Resuelves su problema, pero te creas uno para ti mismo."
                }
            },
            On6 = new Consequence
            {
                MainText = "Lo empeoraste para ambos."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Fight, DinoStates.D_Weapon)
        {
            Name = "Lucha!",
            Trigger = "Cuando luchas por tu vida, tira " ,
            On10 = new Consequence
            {
                MainText = "Compras un momento precioso para que alguien te ayude. Elije las dos opciones de la siguiente lista."
            },
            On79 = new Consequence
            {
                MainText = "Elije sólo una:",
                Options = new List<string>
                {
                    "No resultas herido",
                    "Hieres al enemigo, el MC elige cómo."
                }
            },
            On6 = new Consequence
            {
                MainText = "Realiza el Movimiento de CAIDO. Lo siento. "
            },
            ClossingText = "El MC siempre puede decidir que no puedes luchar contra un dinosaurio"
        }
    };

    public List<Move<DinoMoves, DinoStates>> SafetyMoves { get; set; } = new List<Move<DinoMoves, DinoStates>>
    {
        new Move<DinoMoves, DinoStates>(DinoMoves.D_LayLand, DinoStates.D_Clever)
        {
            Name = "Reconocer el terreno",
            Trigger = "Cuando tú y un compañero se toman un momento tranquilo para llegar a un buen punto de observación y orientarse, cuentan una historia, luego tiran + Inteligencia. El DM te hablará sobre dos puntos de referencia, uno natural y otro hecho por el hombre, que puedes ver.",
            On10 = new Consequence
            {
                MainText = "también te mostrarán dónde estás en el mapa"
            },
            On6 = new Consequence
            {
                MainText = "Descubres un peligro inminente."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Instruct, DinoStates.D_Steady)
        {
            Name = "Instruir",
            Trigger = "Cuando guías a otro héroe a través de una tarea riesgosa que sabes hacer, pero que deben hacer ellos (quizás porque estás comunicándote por walkies, están en lados opuestos de una cerca o estás herido), cuéntales una historia y tira + Calma. Con un éxito: Eres un buen maestro. Tienen éxito.",
            On79 = new Consequence
            {
                MainText = "No lo hacen tan bien como tú lo harías. Elige 1:",
                Options = new List<string>
                {
                    "Toma más tiempo de lo esperado.",
                    "Los expone al peligro.",
                    "Te expone al peligro."
                }
            },
            On6 = new Consequence
            {
                MainText = "Los confundes, enfadas o distraes (su elección). La tarea está arruinada más allá de poder salvarla y has empeorado las cosas."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Scavenge, DinoStates.D_Clever)
        {
            Name = "Rebuscar",
            Trigger = "Cuando tú y otro héroe se toman un momento tranquilo para buscar objetos o información útil, cuéntales una historia y tira + Inteligencia",
            On10 = new Consequence
            {
                MainText = "Encuentras algo útil. Tal vez incluso eso que estabas esperando."
            },
            On79 = new Consequence
            {
                MainText = "Encuentras algo práctico, pero haces mucho ruido. Puedes hacer como si ningún dinosaurio te hubiera oído, si quieres."
            },
            On6 = new Consequence
            {
                MainText = "Encuentras algo malo."
            }
        },
        new Move<DinoMoves, DinoStates>(DinoMoves.D_Casualty, DinoStates.D_NoRoll)
        {
            Name = "Caído",
            Trigger = "Cuando estás gravemente herido (o te lesionas estando ya herido), estás en mal estado. Cuéntale a alguien tu secreto más oscuro o esperanza no cumplida, luego elige 1:",
            On10 = new Consequence
            {
                MainText = "",
                Options = new List<string>
                {
                    "Tienes un último acto heroico, sujeto a la discreción del DM, antes de morir.",
                    "stás FUERA DE COMBATE. No puedes hacer nada, pero tu personaje sobrevivirá si los demás pueden sacarte de la isla a tiempo."
                }
            },
            ClossingText = "De cualquier manera, puedes elegir un playbook no utilizado y crear un nuevo personaje. El DM te dirá cuándo aparece tu nuevo personaje."
        },
    };
}
