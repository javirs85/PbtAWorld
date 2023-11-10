using PbtALib;
using Blazored.Toast.Services;
using PbtADBConnector;

namespace DinoIsland;


public class DinoCharacter : PbtACharacter
{

	public DinoGameController Game;
	public DinoCharacter(DinoGameController _game)
	{
		Game = _game;
	}
	protected override void InitInternal()
	{
		InitClass();
	}

	public DinoCharacter() 
	{
	}


	private string _w1;
	public string Wound1
	{
		get { return _w1; }
		set { 
			if(_w1 != value)
			{
				_w1 = value;
				StoreChangeOnBD($"{Name} recivió su primera herida: {value}");
			}
		}
	}
	private string _w2;
	public string Wound2
	{
		get { return _w2; }
		set
		{
			if (_w2 != value)
			{
				_w2 = value;
				StoreChangeOnBD($"{Name} recivió su segunda herida: {value}");
			}
		}
	}
	private bool _isdown;

	public bool IsDown
	{
		get { return _isdown; }
		set 
		{
			if (_isdown != value)
			{
				_isdown = value;
				if(_isdown)
					StoreChangeOnBD($"{Name} ha caído");
				else
				StoreChangeOnBD($"{Name} ha vuelto de entre los muertos");
			}
		}
	}



	public List<string> Gear { get; set; } = new List<string>();

	public string Rumor { 
		get => rumor; 
		set
		{
			if(rumor != value)
			{
				rumor = value;
				StoreChangeOnBD();
			}
		}
	}
	public bool IsRumorSet => Rumor != "Sin rumores de momento";

	public List<string> Stories { get;set; } = new List<string>();
	public List<MapItem> MapItems { get; set; } = new();

	public void UpdateMapItems(List<MapItem> mapItems)
	{
		MapItems = mapItems;
		OnUpdateUI();
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
		OnUpdateUI();
	}


	private DinoClasses _class = DinoClasses.NotSet;

	private IToastService? Toaster;



	public override int GetBonus<T>(T _stat)
	{
		if(_stat is DinoStates)
		{
			DinoStates stat = (DinoStates)(object)_stat;
			switch (stat)
			{
				case DinoStates.D_Fit: return Fit;
				case DinoStates.D_Steady: return Steady;
				case DinoStates.D_Clever: return Clever;
				case DinoStates.D_1:return 1;
				case DinoStates.D_0:return 0;
				case DinoStates.D_2:return 2;
				case DinoStates.D_3: return 3;

				case DinoStates.D_MC:
				case DinoStates.D_Weapon:
				case DinoStates.D_NotSet:
				case DinoStates.D_NoRoll:
				case DinoStates.D_Story:
				default:
					throw new Exception($"Cannot roll {stat} at DinoCharacter GetStatBonus");
			}
		}

		throw new Exception("stat is not a DinoState");
	}

	public async Task StoreChangeOnBD(string message = "")
	{
		if(Game is not null)
			await Game.StoreChangesOnCharacter(this, message);
	}

	public DinoClasses Class
	{
		get { return _class; }
		set {
			_class = value;
		}
	}

	private int _clever;
	private int fit = 0;
	private int steady = 0;
	private string behavior = "Personalidad";
	private string looks = "Aspecto";
	private string rumor = "Sin rumores de momento";

	public int Clever
	{
		get { return _clever; }
		set 
		{ 
			if( _clever != value )
			{
				_clever = value;
				StoreChangeOnBD($"{Name} cambió su Inteligencia a {value}");
			}
		}
	}


	public int Fit { 
		get => fit; 
		set
		{
			if (fit != value)
			{
				fit = value;
				StoreChangeOnBD($"{Name} cambió su forma física a {value}");
			}
		}
	}

	public int Steady { 
		get => steady;
		set
		{
			if (steady != value)
			{
				steady = value;
				StoreChangeOnBD($"{Name} cambió su forma física a {value}");
			}
		}
	}
	public List<DinoMoveIDs> AllPurchasedMoves { get; set; } = new List<DinoMoveIDs>();

	public async Task PurchaseMove(DinoMove move)
	{
		if(!AllPurchasedMoves.Contains(move.ID))	
			AllPurchasedMoves.Add(move.ID);
		await StoreChangeOnBD($"{Name} adquirió {move.Tittle}");
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
				AllPurchasedMoves.Add(DinoMoveIDs.D_Sur_SetHouse);
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

	public string Looks { 
		get => looks;
		set
		{
			if (looks != value)
			{
				looks = value;
				StoreChangeOnBD($"{Name} cambió su apaciencia a {value}");
			}
		}
	}
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
	public string Behavior { 
		get => behavior;
		set {
			if (behavior != value)
			{
				behavior = value;
				StoreChangeOnBD($"{Name} cambió su comportamineto a {value}");
			}
		}
	}
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
