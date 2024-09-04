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
		MasterMovesPacks.Add(new MasterMovePack { 
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


	}

}
