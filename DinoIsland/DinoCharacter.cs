using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtAWorldConnectivity;

namespace DinoIsland;


public class DinoPlayer : Player
{
	private string _name = string.Empty;

	public new string Name
	{
		get { return _name; }
		set {
			if(value == _name) return;
			var oldName = _name;
			_name = value;

			if (Client is not null && Client.IsConnected)
				Client.SendInfo($"{oldName} ahora se llama {value}");
		}
	}

	public string Wound1 { get; set; } = string.Empty;
	public string Wound2 { get; set; } = string.Empty;

	private bool _isdown = false;

	public bool IsDown
	{
		get { return _isdown; }
		set { 
			_isdown = value;
			if (Client is not null && Client.IsConnected)
			{
				if (_isdown)
					Client.SendInfo($"{Name} ha caído");
				else
					Client.SendInfo($"{Name} ha vuelto de entre los muertos");
			}
		}
	}

	public List<string> Gear { get; set; } = new List<string>();


	private DinoClasses _class = DinoClasses.NotSet;

	private PbtAWorldCommClient? Client;

	public void Connect(PbtAWorldCommClient _client)
	{
		if (_client != null && _client.IsConnected) {
			Client = _client;
		}
		else
		{
			throw new Exception("Client must be not null and connected before sending it here");
		}
	}

	private Random rnd = new Random();

	public async Task Roll(DinoStates stat, DinoMove Move)
	{
		int d1 = rnd.Next(1,7);
		int d2 = rnd.Next(1,7);
		int bonus = 0;
		if (stat == DinoStates.D_Steady) bonus = Steady;
		else if (stat == DinoStates.D_Fit) bonus = Fit;
		else if (stat == DinoStates.D_Clever) bonus = Clever;
		else if(stat == DinoStates.D_1) bonus = 1;
		else if(stat == DinoStates.D_0) bonus = 0;

		if(Client is not null)
			await Client.SendInfo($"{Name} tiró {Move.Tittle} ({stat.ToUI()}{bonus.ToNiceUIStat()}): {d1} + {d2} + {bonus.ToNiceUIStat()} = {d1+d2+bonus}");
	}

	public DinoClasses Class
	{
		get { return _class; }
		set {
			_class = value;
			InitClass();
		}
	}


	public int Clever { get; set; } = 0;
	public int Fit { get; set; } = 0;
	public int Steady { get; set; } = 0;

	public List<DinoMoveIDs> AllPurchasedMoves { get; set; } = new List<DinoMoveIDs>();

	public async Task PurchaseMove(DinoMove move)
	{
		if(!AllPurchasedMoves.Contains(move.ID))	
			AllPurchasedMoves.Add(move.ID);
		if(Client is not null)
			await Client.SendInfo($"{Name} adquirió {move.Tittle}");
	}

	private void InitClass()
	{
		AllPurchasedMoves.Clear();
		Gear.Clear();
		switch (Class)
		{
			case DinoClasses.Hunter:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Hun_Tracker);
				Gear.Add("Elige: Rifle tranquilizante (5 dardos)");
				Gear.Add("Elige: Arco de caza (10 flechas)");
				Gear.Add("Ropa de camuflaje");
				Gear.Add("Cuchillo de caza");
				Gear.Add("Una bolsa de cecina");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Doctor:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Doc_TreatWounds);
				Gear.Add("Kit de primeros auxilios");
				Gear.Add("linterna tipo lápiz");
				Gear.Add("analgésicos");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Engineer:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Eng_JuryRig);
				Gear.Add("Herramientas (destornillador, cinta americana, etc)");
				Gear.Add("Tablet con funda resistente");
				Gear.Add("Frontal led");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Kid:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Kid_aaaaah);
				AllPurchasedMoves.Add(DinoMoveIDs.D_Kid_IKnowThis);
				Gear.Add("Dinosaurio de juguete");
				Gear.Add("Navaja suiza");
				Gear.Add("Chocolatina y lata de refresco");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Paleontologist:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Pal_Expert);
				Gear.Add("Herramientas básicas de excavación");
				Gear.Add("Bandana");
				Gear.Add("Cantimplora");
				Gear.Add("Pequeño fósil con valor sentimental");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Soldier:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Sol_KillOrBeKilled);
				Gear.Add("Rifle de asalto");
				Gear.Add("Pistola");
				Gear.Add("Linterna");
				Gear.Add("Cuchillo de combate");
				Gear.Add("Un cargador extra");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.Survivor:
				AllPurchasedMoves.Add(DinoMoveIDs.D_Sur_BeenAroundTheBlock);
				AllPurchasedMoves.Add(DinoMoveIDs.D_Sur_HomewardBound);
				Gear.Add("Lanza");
				Gear.Add("trapos de camuflaje");
				Gear.Add("Plantas comestibles");
				Gear.Add("Mochila vieja");
				Gear.Add("Un hedor terrible");
				Gear.Add("");
				Gear.Add("");
				Gear.Add("");
				break;
			case DinoClasses.NotSet:
				break;
			default:
				break;
		}
	}

	public DinoStats FavoriteStat => Class switch
	{
		DinoClasses.Doctor => DinoStats.Cold,
		DinoClasses.Engineer => DinoStats.Mind,
		DinoClasses.Paleontologist => DinoStats.Mind,
		DinoClasses.Kid => DinoStats.NotSet,
		DinoClasses.Survivor => DinoStats.Mind,
		DinoClasses.Soldier => DinoStats.Cold,
		DinoClasses.Hunter => DinoStats.Mind,
		_ => throw new NotImplementedException()
	};

	public string Looks { get; set; } = "Aspecto";
	public List<string> LooksOtions => Class switch
	{
		DinoClasses.Doctor => new List<string> { "Aspecto", "Elegante", "Todavía con uniforme", "Ropa de diseño" },
		DinoClasses.Engineer => new List<string> { "Aspecto", "Grande", "Polo y kakis", "Empollón" },
		DinoClasses.Paleontologist => new List<string> { "Aspecto", "polvoriento", "recién salido de la academia", "resistente" },
		DinoClasses.Kid => new List<string> { "Aspecto", "deportivo", "alternativo", "friki" },
		DinoClasses.Survivor => new List<string> { "Aspecto", "Quemado por el sol", "Fuera de este tiempo", "Meticulosamente afeitado" },
		DinoClasses.Soldier => new List<string> { "Aspecto", "Corpulento", "Fibrado", "con cicatrices" },
		DinoClasses.Hunter => new List<string> { "Aspecto", "ropa técnica", "tatuado", "atractivo" },
		_ => throw new NotImplementedException()
	};
	public string Behavior { get; set; } = "Personalidad";
	public List<string> BehaviorOptions => Class switch
	{
		DinoClasses.Doctor => new List<string> { "Personalidad", "Controlado", "Autoritaria", "Agotada" },
		DinoClasses.Engineer => new List<string> { "Personalidad", "Preciso", "cascarrabias", "despreocupado" },
		DinoClasses.Paleontologist => new List<string> { "Personalidad", "aventurero", "despistado", "meditabundo" },
		DinoClasses.Kid => new List<string> { "Personalidad", "curioso", "tímido", "travieso" },
		DinoClasses.Survivor => new List<string> { "Personalidad", "Reservado", "Gregario", "Feral (salvaje)" },
		DinoClasses.Soldier => new List<string> { "Personalidad", "Autoritario", "Agresivo", "Imperturbable" },
		DinoClasses.Hunter => new List<string> { "Personalidad", "arrogante", "sarcástico", "mordaz" },
		_ => throw new NotImplementedException()
	};
}
