using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanShadows;

public class USTextBook : BaseTextBook
{
	public USTextBook()
	{
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Master moves",
			Moves = new List<MasterMove>
			{
				new MasterMove ("Haz aflorar un conflicto, ya sea antiguo o reciente."),
				new MasterMove ("Pon a alguien en peligro."),
				new MasterMove ("Inflige (o intercambia) daño."),
				new MasterMove ("Provoca corrupción."),
				new MasterMove ("Ofrece una oportunidad a un costo."),
				new MasterMove ("Revela un trato hecho en su ausencia."),
				new MasterMove ("Vuelve un movimiento en su contra."),
				new MasterMove ("Ofrece o reclama una Deuda pendiente."),
				new MasterMove ("Cambia las probabilidades, de repente o mágicamente."),
				new MasterMove ("Avisa a alguien de un peligro inminente."),
				new MasterMove ("Bloquea, explota o reclama un lugar de poder."),
				new MasterMove ("Expón las consecuencias y pregunta."),
				new MasterMove ("Activa el lado negativo de sus recursos.")
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "General advice",
			Moves = new List<MasterMove>
			{
				new MasterMove ("Usa un PNJ para cobrar/generar una deuda"),
				new MasterMove ("Empújalos a *echarse a la calle**"),
				new MasterMove ("Apóyate en triángulos PJ-PNJ-PJ"),
				new MasterMove ("Aparece con pistolas")
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Agenda",
			Moves = new List<MasterMove>
			{
				new MasterMove("Haz que la ciudad se sienta política y oscura"),
				new MasterMove("Mantén las vidas de los personajes fuera de control"),
				new MasterMove("Juega para descubrir qué sucede"),
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Principios",
			Moves = new List<MasterMove>
			{
				new MasterMove("Muestra la ciudad, desde los rascacielos hasta los barrios bajos"),
				new MasterMove("Dirígete a los personajes, no a los jugadores"),
				new MasterMove("Une a los personajes, incluso más allá de las fronteras"),
				new MasterMove("Coloca a los personajes en el centro de los conflictos"),
				new MasterMove("Envuelve tus movimientos en sombras"),
				new MasterMove("Da nombre a todos, dales motivaciones"),
				new MasterMove("Trata a todos según su posición"),
				new MasterMove("Haz muchas preguntas y construye a partir de las respuestas"),
				new MasterMove("Sé un fan de los personajes de los jugadores"),
				new MasterMove("Dale a los jugadores la oportunidad de opinar"),
				new MasterMove("Ensucia las manos de todos los involucrados"),
				new MasterMove("Ponle un precio a todo, especialmente a la amistad"),
			}
		});

		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Mortandad",
			Moves = new List<MasterMove>
			{
				new MasterMove("Adaptarse a circunstancias cambiantes"),
				new MasterMove("Reunirse en gran número para hacer frente a una amenaza"),
				new MasterMove("Descubrir información que ponga a alguien en peligro"),
				new MasterMove("Recordarle a alguien sus obligaciones del día a día"),
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Noche",
			Moves = new List<MasterMove>
			{
				new MasterMove("Exhibir un agresivo despliegue de fuerza"),
				new MasterMove("Amenazar las posesiones o intereses de alguien"),
				new MasterMove("Reclamar el territorio de necios o débiles"),
				new MasterMove("Sacar el mayor partido posible de una situación difícil"),
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Poder",
			Moves = new List<MasterMove>
			{
				new MasterMove("Dar prioridad a las consecuencias a largo plazo"),
				new MasterMove("Augurar místicamente una Tormenta que se avecina"),
				new MasterMove("Actuar en contra del caos o el cambio"),
				new MasterMove("Arrebatar recursos vulnerables o expuestos"),
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Velo",
			Moves = new List<MasterMove>
			{
				new MasterMove("Revelar una diversidad de culturas foráneas e insólitas"),
				new MasterMove("Ofrecer poder a cambio de una promesa o prenda"),
				new MasterMove("Llevar algo de un reino a otro"),
				new MasterMove("Agravar un conflicto por razones misteriosas u oscuras"),
			}
		});
		MasterMovesPacks.Add(new MasterMovePack
		{
			Title = "Movimientos de facción",
			Moves = new List<MasterMove>
			{
				new MasterMove
				{
					Tittle = "Atacar abiertamente a una facción",
					Detail = "Cuando una facción ataca abiertamente a otra facción, tira con la diferencia entre los Tamaños de las dos facciones. Con un éxito, la facción atacada sacrifica un activo apropiado o pierde un punto de Tamaño, a su elección. Con un resultado de 7-9, la facción atacante debe sacrificar un asset apropiado o perder también un punto de Tamaño. Con un fallo, el objetivo tiende una trampa inteligente; captura o destruye un Asset o reduce el Tamaño del atacante, a su elección."
				},
				new MasterMove
				{
					Tittle = "Consolidar el control",
					Detail = "Cuando los líderes de una facción consolidan el control sobre sus fuerzas y activos existentes, tiran con su Fuerza. Con un 10+, eligen 2. Con un 7-9, eligen 1:\r\n     · se aseguran nuevas posesiones; marca recursos\r\n     · Buscan nuevos miembros; marcan reclutamiento\r\n     · exigen secreto; encubren otra acción\r\nCon un fallo, sus esfuerzos conducen a luchas internas; una autoridad es destronada o humillada, y una coalición rebelde dentro de la facción gana impulso: reduce la Fuerza de la facción."
				}
				, new MasterMove
				{
					Tittle = "Localizar a alguien",
					Detail = "Cuando una facción intenta localizar a un personaje de estatus 1 o 2 dentro de la ciudad, tira.\r\n   · Si la facción tiene un activo relevante, suma 1.\r\n   · Si su presa es del mismo Círculo, suma 1.\r\n   · Si la facción es de Tamaño-1 o Fuerza-1, resta 1.\r\n   · Si la presa se esconde activamente, resta 1.\r\n\r\nSi la presa es un PNJ: Con un resultado de 7-9, la facción encuentra a su presa; la ataca, la secuestra o se enfrenta a ella con algún coste. Con un 10+, descubren a la presa expuesta o vulnerable; la facción puede actuar impunemente sobre ella. Con un fallo, los intentos de la facción de localizarlos tienen éxito, pero sus agentes lo estropean todo y permiten que la presa escape ilesa.\r\n\r\nSi la presa es un PC: Con un 7-9, la facción rastrea su localización, pero el PC tiene tiempo de prepararse para las fuerzas limitadas que vienen hacia él. Con un 10+, la facción rastreadora saca lo mejor de su presa; acorralan al PC con una fuerza abrumadora o una cuidadosa planificación que le deja poco espacio para evitar a sus perseguidores. Con un fallo, alguien cercano al Pc le avisa antes de tiempo de la búsqueda de la facción... y de una oportunidad o debilidad que el Pc puede explotar..."
				}
				, new MasterMove
				{
					Tittle = "Incitar al adversario",
					Detail = "Cuando una facción intenta incitar a un oponente a cometer un error, tira con la diferencia entre las Fuerzas de las dos facciones. Con un 10+, el objetivo muerde el anzuelo; la facción instigadora asesta un golpe terrible, destruye un activo vulnerable o socava una relación o alianza clave. Con un resultado de 7-9, el objetivo evita lo peor de la trampa, pero causa suficientes problemas como para avergonzarse a sí mismo. Con un fallo, el objetivo se da cuenta del plan; alguien de la facción objetivo acude a uno de los PJ para que le ayude a cambiar las tornas contra la facción instigadora."
				}
				, new MasterMove
				{
					Tittle = "Apoderarse por la fuerza",
					Detail = "Cuando una facción se apodera de algo vulnerable por la fuerza, tira con su Fuerza. Con un éxito, se apoderan de ello; reducen el atributo apropiado de la facción objetivo y se apoderan de un bien vulnerable. Con un 10+, los tres. Con un 7-9, eligen uno:\r\n   · No sacrifican a un líder, aliado o activo importante.\r\n   · no sufren un ataque de represalia inmediato\r\n   · No causan daños colaterales graves.\r\nSi fallan, el ataque resulta en la destrucción total de lo que la facción atacante intentaba apoderarse; alguien acude a uno de los PJ en busca de ayuda para obtener justicia o venganza."
				}
				, new MasterMove
				{
					Tittle = "Buscar en la ciudad",
					Detail = "Cuando una facción busca en la ciudad información útil -un raro conocimiento oculto, las debilidades de otra facción, la localización de un artefacto- tira con su Tamaño. Con un éxito, descubren algunos detalles cruciales, suficientes para pedir a un PJ o PNJ notable que siga investigando. Con un 7-9, también eligen 2. Con un 10+, eligen 1.\r\n   - atraen la atención de una facción rival\r\n   - tienen que hacer vulnerable un activo\r\n   - tienen -1 en curso hasta el final del siguiente turno de\r\n     la facción. Con un fallo, un miembro de la facción que \r\n     ha conseguido alguna información vital acaba muerto \r\n     o desaparecido... pero no antes de transmitir lo que \r\n     sabe a uno de los PJ."
				}
				, new MasterMove
				{
					Tittle = "Ofrecer pasaje",
					Detail = "Cuando una facción ofrece paso a alguien -para entrar o salir de la ciudad- tira con su Tamaño. Con un acierto, el camino queda expedito, sin importar quién se oponga; elige 1:\r\n   · alguien sale; queda fuera de su alcance hasta \r\n     regrese\r\n   · alguien entra; la facción gana una poderosa baza\r\n\r\nCon un 7-9, el paso ofende a un PNJ de Estatus 3 que busca tributo por la intrusión; la facción debe realizar un favor -dedicar un movimiento de facción en el próximo turno de facción- sacrificar un activo o arriesgarse a una guerra abierta. Con un fallo, el paso provoca un conflicto entre la facción y sus propios aliados antes de que pueda completarse; alguien acude a uno de los PJ en busca de ayuda para negociar una tregua."
				}
			}
		});
	}

}
