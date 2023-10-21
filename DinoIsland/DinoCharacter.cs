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
	public event EventHandler UpdateUI;
	private string _name = string.Empty;

	public new string Name
	{
		get { return _name; }
		set {
			if(value == _name) return;
			var oldName = _name;
			_name = value;

			if(Client is not null)
			{
				Client.UserName = value;
				if (Client.IsConnected)
					Client.SendInfo($"{oldName} ahora se llama {value}");
			}
			
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
	
	private string _rumor = string.Empty;

	public string Rumor
	{
		get { return _rumor; }
		set { 
			_rumor = value; 
			Client.SendParamsMessage(MessageKinds.NewRumor, _rumor);
		}
	}

	public List<string> Stories { get;set; } = new List<string>();
	public List<MapItem> MapItems { get; set; } = new();

	public void UpdateMapItems(List<MapItem> mapItems)
	{
		MapItems = mapItems;
		UpdateUI?.Invoke(this, EventArgs.Empty);
	}

	public void UpdateMapItems(MapItem mapItem)
	{
		if (mapItem.Action == MapActions.Add)
		{
			if (MapItems.Find(x => x.ID == mapItem.ID) == null)
			{
				MapItems.Add(mapItem);
			}
		}
		else if (mapItem.Action == MapActions.Remove)
		{
			var item = MapItems.Find(x => x.ID == mapItem.ID);
			if (item != null)
				MapItems.Remove(item);
		}
		UpdateUI?.Invoke(this, EventArgs.Empty);
	}


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

	public async Task SendMapUpdate(MapItem item)
	{
		if(Client is not null && Client.IsConnected) 
			await Client.SendParamsMessage(MessageKinds.Map, System.Text.Json.JsonSerializer.Serialize(item));
	}

	public async Task RequestServerForMapUpdate()
	{
		if (Client is not null && Client.IsConnected)
			await Client.SendSimpleCommandMessage(MessageKinds.UpdateMapRequest);
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
		{
			var report = new RollReport<DinoMoveIDs, DinoStates>(Move.ID, stat, Move.Tittle)
			{
				bonus = bonus,
				d1 = d1,
				d2 = d2,
				Roller = Name,
				Stat = stat,
			};
			
			var encoded = System.Text.Json.JsonSerializer.Serialize(report);
			await Client.SendRollReport(encoded);
		}
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
		Stories.Clear();
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
				Stories.Add("Tu captura más impresionante");
				Stories.Add("Aquella vez que estuviste perdido en plena naturaleza salvaje");
				Stories.Add("Una forma en la que los animales son mejores que las personas");
				Stories.Add("Lo más raro que te hayas comido");
				Stories.Add("Algo que un idiota hizo y consiguió que lo mataran");
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
				Stories.Add("Porque te hiciste doctor");
				Stories.Add("Aquella vez que estuviste aterrorizado");
				Stories.Add("Un error casi fatal");
				Stories.Add("Cuando alguien sobrevivió milagrosamente");
				Stories.Add("Como liberas tensión?");
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
				Stories.Add("Algo ineficiente que te enfurece");
				Stories.Add("Algo que está perfectamente diseñado");
				Stories.Add("Esa cosa que sueñas con construir");
				Stories.Add("Un momento de placer simple");
				Stories.Add("Aquella vez en que te obligaron a tomar atajos");
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
				Stories.Add("Una vez en la que fuiste realmente valiente");
				Stories.Add("La cosa más molesta que hacen tus padres");
				Stories.Add("Una explicación sobre algo que desconcierta a los adultos");
				Stories.Add("Algo cool que un amigo te contó");
				Stories.Add("Algo de lo que estás secretamente asustado");
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
				Stories.Add("Como te enamoraste de los dinosaurios");
				Stories.Add("Porque tu archienemigo es un chapucero");
				Stories.Add("Algo que nunca has entendido sobre la gente");
				Stories.Add("Una lección de vida que tu mentor te enseñó");
				Stories.Add("La historia detrás del fósil que llevas encima");
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
				Stories.Add("Aquella vez que burlaste a la muerte");
				Stories.Add("Porque te alistaste");
				Stories.Add("Un chiste interno que compartías con tu escuadrón");
				Stories.Add("Algo que te persigue");
				Stories.Add("Una suprestición que te mantiene con vida");
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
				Stories.Add("Una habilidad de supervivencia útil que aprendiste aquí");
				Stories.Add("La personas con la que esperas reencontrarte");
				Stories.Add("La comodidad mundana que echas más de menos");
				Stories.Add("Que harías diferente si salieras de esta isla");
				Stories.Add("Algo de la isla que, en realidad, te gusta");
				break;
			case DinoClasses.NotSet:
				break;
			default:
				break;
		}
	}

	public DinoStates FavoriteStat => Class switch
	{
		DinoClasses.Doctor => DinoStates.D_Steady,
		DinoClasses.Engineer => DinoStates.D_Clever,
		DinoClasses.Paleontologist => DinoStates.D_Clever,
		DinoClasses.Kid => DinoStates.D_NotSet,
		DinoClasses.Survivor => DinoStates.D_Clever,
		DinoClasses.Soldier => DinoStates.D_Steady,
		DinoClasses.Hunter => DinoStates.D_Clever,
		DinoClasses.Master => DinoStates.D_Clever,
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
		DinoClasses.Master => new List<string> { "" },
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
		DinoClasses.Master => new List<string> { "" },
		_ => throw new NotImplementedException()
	};
}
