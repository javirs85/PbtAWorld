using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;


public class DinoPlayer : Player
{
	public string Wound1 { get; set; } = string.Empty;
	public string Wound2 { get; set; } = string.Empty;
	public bool IsDown { get; set; } = false;
	public DinoClasses Class { get; set; } = DinoClasses.NotSet;
	public int Int { get; set; } = 0;
	public int Physic { get; set; } = 0;
	public int Cold { get; set; } = 0;

	public List<DinoMove> AllClassMoves { get; set; } = new List<DinoMove>();

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
