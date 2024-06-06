using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanShadows
{
	public enum ShipTypes { Stardancer, Cerberus, Firedrake}
	public enum ShipReputations { ambitious, brutal, valientes, honorables, profesionales, astutos, raros, sutiles}
	public enum CrewUpgrades { }

	public static class ShipExtensions
	{
		public static string ToUI(this ShipTypes shipType) => shipType switch
		{
			ShipTypes.Stardancer => "Stardancer",
			ShipTypes.Cerberus => "Querberus",
			ShipTypes.Firedrake => "Firedrake",
			_ => ""
		};

		public static string GetExplanation(this ShipTypes shipType) => shipType switch
		{
			ShipTypes.Stardancer => "Contrabandistas y escapistas. Buscan hacer trabajos ocasionales, pequeños robos y encontrar objetos perdidos",
			ShipTypes.Cerberus => "Especialistas en rescate. Se dedican a localizar personas o artículos perdidos y reclamar recompensas.",
			ShipTypes.Firedrake => "Rebeldes y criminales. Buscan proteger a los oprimidos y luchar contra el imperio.",
			_ => ""
		};
	}

	public class SVShip
	{
		public string Name { get; set; } = "El nombre de la nave";
		public int Credits { get; set; } = 2;
		public string HowXp = "Consigues XP cuando completas satisfactoriamente trabajos de transporte o contrabando";

		public int CrewQuality { get; set; } = 0;
		public int MaxCrewQuality = 3;
		public 

		public List<string> PayingMethods = new List<string>
		{
			"Pagar: Les das 1CRED a cambio de su trabajo, Sin historias, sin deudas",
			"Deberles 1: Prometes que les devolverás el favor cuando lo necesiten, ganas *status +1**. Solo pudes pagar así si compras *Calidad de la tripulación**",
			"Timarlos: Para qué pagar a alguien que no cobra por adelantado? Apunta *status -1** con esa facción"
		};

	}
}
