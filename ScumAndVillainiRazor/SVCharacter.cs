using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ScumAndVillainy;

public class SVCharacter : PbtALib.PbtACharacter
{

	private SVClasses _profession = SVClasses.NotSet;

	public SVClasses Profession
	{
		get { return _profession; }
		set { 
			if(_profession != value)
			{
				_profession = value;
				InitClass();	
			}
		}
	}

	public Clock Recovery { get; set; } = new Clock("Curación", 6);

	public string Alias { get; set; } = "Alias";
	public string Look { get; set; } = "Apariencia";

	public Heritages Heritage { get; set; } = Heritages.NotSet;
	public Backgrounds Background { get; set; } = Backgrounds.NotSet;

	public string HowXP = string.Empty;
	public List<SVMoveIDs> SelectedAbilities { get; set; } = new();
	public List<SVItemIDs> SelectedItems { get; set; } = new();

	public bool UsedArmorNormal { get; set; } = false;
	public bool UsedArmorSpecial { get; set; } = false;
	public bool UsedArmorHeavy { get; set; } = false;

	public Vices Vice { get; set; } = Vices.NotSet;
	public List<Traumas> Traumas { get; set; } = new List<Traumas> { ScumAndVillainy.Traumas.NoTrauma, ScumAndVillainy.Traumas.NoTrauma , ScumAndVillainy.Traumas.NoTrauma , ScumAndVillainy.Traumas.NoTrauma };

	public List<SVNPC> Friends { get; set; } = new();
	public List<SVItemIDs> ActiveItems { get; set; } = new();

	#region stats

	private int _doctor;

	public int Doctor
	{
		get { return _doctor; }
		set { _doctor = value; }
	}


	public int Hack { get; set; } = 0;
	public int Rig { get; set; } = 0;
	public int Study { get; set; } = 0;
	public int Insight
	{
		get
		{
			int val = 0;
			if (Doctor > 0) val++;
			if (Hack > 0) val++;
			if (Rig > 0) val++;
			if (Study > 0) val++;
			return val;
		}
	}

	public int Helm { get; set; } = 0;
	public int Scramble { get; set; } = 0;
	public int Scrap { get; set; } = 0;
	public int Skulk { get; set; } = 0;
	public int Prowess
	{
		get
		{
			int val = 0;
			if (Helm > 0) val++;
			if (Scramble > 0) val++;
			if (Scrap > 0) val++;
			if (Skulk > 0) val++;
			return val;
		}
	}

	public int Attune { get; set; } = 0;
	public int Command { get; set; } = 0;
	public int Consort { get; set; } = 0;
	public int Sway { get; set; } = 0;
	public int Resolve
	{
		get
		{
			int val = 0;
			if (Attune > 0) val++;
			if (Command > 0) val++;
			if (Consort > 0) val++;
			if (Sway > 0) val++;
			return val;
		}
	}

	public int GetXP(SVStats stat)
	{
		if (stat == SVStats.Insight) return InsightXP;
		else if (stat == SVStats.Prowess) return ProwessXP;
		else if (stat == SVStats.Resolve) return ResolveXP;
		else return 0;
	}

	public override int GetBonus<T>(T statsEnum)
	{
		if (typeof(T) == typeof(SVStats))
		{
			SVStats stat = (SVStats)(object)statsEnum;
			return GetBonus(stat);
		}
		else
			return 0;
	}

	public int GetBonus(SVStats stat)
	{
		return stat switch
		{
			SVStats.Doctor => Doctor,
			SVStats.Hack => Hack,
			SVStats.Rig => Rig,
			SVStats.Study => Study,
			SVStats.Insight => Insight,
			SVStats.Helm => Helm,
			SVStats.Scramble => Scramble,
			SVStats.Scrap => Scrap,
			SVStats.Skulk => Skulk,
			SVStats.Prowess => Prowess,
			SVStats.Attune => Attune,
			SVStats.Command => Command,
			SVStats.Consort => Consort,
			SVStats.Sway => Sway,
			SVStats.Resolve => Resolve,
			_ => 0
		};
	}
	

	public void SetStat(SVStats stat, int i)
	{
		switch (stat)
		{
			case SVStats.Doctor: Doctor = i; break;
			case SVStats.Hack: Hack = i; break;
			case SVStats.Rig: Rig = i; break;
			case SVStats.Study: Study = i; break;

			case SVStats.Helm: Helm = i; break;
			case SVStats.Scramble: Scramble = i; break;
			case SVStats.Scrap: Scrap = i; break;
			case SVStats.Skulk: Skulk = i; break;

			case SVStats.Attune: Attune = i; break;
			case SVStats.Command: Command = i; break;
			case SVStats.Consort: Consort = i; break;
			case SVStats.Sway: Sway = i; break;
		}
	}
	#endregion
	public int Stress { get; set; } = 0;
	public int MaxStress { get; set; } = 9;
	public int StresLeft
	{
		get
		{
			return MaxStress - Stress;
		}
	}
	public string Harm1A { get; set; } = string.Empty;
	public string Harm1B { get; set; } = string.Empty;
	public string Harm2A { get; set; } = string.Empty;
	public string Harm2B { get; set; } = string.Empty;
	public string Harm3 { get; set; } = string.Empty;

	public MaxLoads SelectedMaxLoad { get; set; } = MaxLoads.NotSet;
	
	public int PlaybookXP { get;set; } = 0;
	public int InsightXP { get;set; } = 0;
	public int ProwessXP { get; set; } = 0;
	public int ResolveXP { get; set; }= 0;
	
	public Clock CRED { get; set;} = new Clock("Créditos", 4);
	public Clock STASH { get; set; } = new Clock("Alijo", 40);
	public void RetrieveStash()
	{
		if (STASH.Status >= 2)
		{
			STASH.Status -= 2;
			CRED.Status ++;
		}
	}
	public void MoveToStash()
	{
		if(CRED.Status >= 1) {
			STASH.Status++;
			CRED.Status--;
		}
	}

	public List<SVMoveIDs> VeteranMoves { get; set; } = new List<SVMoveIDs>();


	protected override void InitInternal()
	{
		InitClass();
	}

	private void InitClass()
	{
		if(Profession == SVClasses.Mechanic)
		{
			HowXP = "Cuando solucionas un problema con habilidades técnicas o ingeniosamente";
			Rig = 2;
			Study = 1;
			SelectedAbilities.Add(SVMoveIDs.Tinker);
			Friends = new List<SVNPC> {
				new SVNPC { Name ="Slice", Detail="dueño de un depósito de chatarra.", Flavor="¿Qué piezas te guarda? ¿O acaso robaste algo suyo?" },
				new SVNPC { Name ="Nisa", Detail="una empleadora anterior.", Flavor="¿Una capitana o dueña de un negocio? ¿Terminó bien?" },
				new SVNPC { Name ="Stev", Detail="un jugador de mala reputación.", Flavor="¿Son amigos de toda la vida? ¿Le hiciste trampas en su mesa?" },
				new SVNPC { Name ="Len", Detail="un traficante de mercado negro.", Flavor="¿Te consigue las piezas que nadie más puede? ¿Decepcionaste al no entregar algo que prometiste?" },
				new SVNPC { Name ="Kenn", Detail="un miembro de la familia.", Flavor="¿También es mecánico? ¿Ambos competían por la atención de un padre?" },
			};
		}
		else if(Profession == SVClasses.muscle)
		{
			HowXP = "Cuando solucionas un problema por la fuerza o con amenazas";
			Scrap = 2;
			Command = 1;
			SelectedAbilities.Add(SVMoveIDs.Unstoppable);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Krieger", Detail="una pistola bláster.", Flavor="¿Es esta tu pistola preferida? ¿O un rival la lleva para usarte a ti?"},
				new SVNPC { Name ="Shod", Detail="un traficante de armas.", Flavor="¿Un mentor o ex socio que cobró? ¿Alguien a quien debes?"},
				new SVNPC { Name ="Chon-zek", Detail=" un cazarrecompensas.", Flavor="¿Ex compañero? ¿O un competidor de la misma procedencia?"},
				new SVNPC { Name ="Yazu", Detail="un policía corrupto.", Flavor="¿Familia para encubrir tus huellas, o alguien que todavía te persigue por meterlos en problemas?"},
				new SVNPC { Name ="Aya", Detail="una asesina.", Flavor="¿Una antigua amante que todavía te aprecia? ¿Un corazón despreciado? ¿O eres el objetivo que se escapó?}" }
			};
		}
		else if (Profession == SVClasses.mystic)
		{
			HowXP = "Cuando solucionas un problema con conocimientos o con La Fuerza";
			Attune = 2;
			Scramble = 1;
			SelectedAbilities.Add(SVMoveIDs.TheWay);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Horux", Detail="un antiguo maestro.", Flavor="¿Acudes a él en busca de consejo incluso ahora? ¿O siente que has malinterpretado sus enseñanzas?"},
				new SVNPC { Name ="Hicks", Detail="un proveedor de bienes místicos.", Flavor="¿Un proveedor confiable de cristales vosianos, o un oportunista despiadado que se aprovecha de tu fe?\r\n\r\n"},
				new SVNPC { Name ="Laxx", Detail="un xeno.", Flavor="¿Amigo inusual o enemigo peligroso? ¿Sensitivo a la Fuerza, o tu amigo “normal”?"},
				new SVNPC { Name ="Rye", Detail="un amor no correspondido.", Flavor="¿Fueron tu entrenamiento y costumbres lo que se interpuso entre ustedes?"},
				new SVNPC { Name ="Blish", Detail="un compañero místico.", Flavor="¿Caminando por el mismo sendero o con creencias completamente diferentes sobre la Fuerza?"},
			};
		}
		else if (Profession == SVClasses.pilot)
		{
			HowXP = "Cuando solucionas un problema con velocidad o estilo";
			Helm = 2;
			Rig = 1;
			SelectedAbilities.Add(SVMoveIDs.AcePilot);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Yattu", Detail="Un jefe de pandillas.", Flavor="¿Solías volar para ellos? ¿Los dejaste en la estacada en un trabajo?"},
				new SVNPC { Name ="Triv", Detail="Un mecánico de naves.", Flavor="¿Siempre te han ayudado con tu nave? ¿Te 'olvidaste' de pagarles por una gran mejora?"},
				new SVNPC { Name ="Choss", Detail="Un corredor profesional.", Flavor="¿Se dan consejos útiles mutuamente? ¿O siempre están tratando de superarse mutuamente?"},
				new SVNPC { Name ="Meris", Detail="Un bribón.", Flavor="¿Han estado juntos en trabajos antes? ¿Te han traicionado antes?"},
				new SVNPC { Name ="Mav", Detail="Un antiguo mentor.", Flavor="¿Qué trucos te enseñaron? ¿Están celosos de tu habilidad ahora?"}
			};
		}
		else if (Profession == SVClasses.scoundrel)
		{
			HowXP = "Cuando solucionas un problema con tu encanto o audacia";
			Sway = 2;
			Skulk = 1;
			SelectedAbilities.Add(SVMoveIDs.Serendipitous);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Nyx", Detail="Un prestamista de dinero.", Flavor="¿Eres un cliente favorito? ¿O un moroso con una deuda?"},
				new SVNPC { Name ="Ora", Detail="Un corredor de información.", Flavor="¿Siempre viene a ti con un consejo jugoso?"},
				new SVNPC { Name ="Jal", Detail="Un mecánico de naves.", Flavor="¿Siempre te han ayudado con tu nave? ¿O la nave es de ellos, y quieren lo que les corresponde?"},
				new SVNPC { Name ="Rhin", Detail="Un contrabandista.", Flavor="¿Una fuente confiable que transmite consejos? ¿Un bribón que ascendió en las filas contigo? ¿O un rival en tu línea de trabajo?"},
				new SVNPC { Name ="Battro", Detail="Un cazador de recompensas.", Flavor="¿Te han dejado ir antes? ¿Te están buscando ahora?"}
			};
		}
		else if (Profession == SVClasses.speaker)
		{
			HowXP = "Cuando solucionas un problema con mentiras o influencia";
			Consort = 2;
			Command = 1;
			SelectedAbilities.Add(SVMoveIDs.AirOfRespectability);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Arryn", Detail="Un noble.", Flavor="¿Un viejo amigo o pariente? ¿O alguien con quien te excediste en tus límites?"},
				new SVNPC { Name ="Manda", Detail="Un miembro del Gremio.", Flavor="¿Obtienes información privilegiada? ¿O robaste secretos del Gremio?"},
				new SVNPC { Name ="Kerry", Detail="Un médico.", Flavor="¿Siempre te tratan? ¿O les rompiste el corazón?"},
				new SVNPC { Name ="Je-zee", Detail="Un diplomático.", Flavor="¿Eran de facciones aliadas, o tenían metas opuestas?"},
				new SVNPC { Name ="_____", Detail="Añade alguien de tu pasado.", Flavor="Si obtienes 'Viejos amigos' amplia la lista cada vez que aterrizas en un sitio nuevo"}
			};
		}
		else if (Profession == SVClasses.stitch)
		{
			HowXP = "Cuando solucionas un problema con Perspicacia o Compasión";
			Doctor = 2;
			Study = 1;
			SelectedAbilities.Add(SVMoveIDs.ImADoctorNotA);
			Friends = new List<SVNPC>
			{
				new SVNPC { Name ="Jackev", Detail="Un traficante de drogas.", Flavor="¿Fuente legítima o alimentando un vicio? ¿O cortaste sus ganancias?"},
				new SVNPC { Name ="Alben", Detail="Un antiguo paciente.", Flavor="¿Por qué los trataste? ¿Cómo pueden ayudarte ahora?"},
				new SVNPC { Name ="Ditha", Detail="Un miembro de la familia.", Flavor="¿Apoyan tu trabajo? ¿O están tratando de hacerte volver a casa?"},
				new SVNPC { Name ="Juda", Detail="Un médico.", Flavor="¿Todavía te ayudan? ¿O fue un viejo rival que quiere que te castiguen por practicar la medicina de manera ilegal?"},
				new SVNPC { Name ="Lynie", Detail="Un administrador hospitalario.", Flavor="¿Un antiguo jefe? ¿Se metieron en problemas por algo que hiciste?"}
			};
		}
	}

}
