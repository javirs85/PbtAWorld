﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;

public enum DinoStates { D_Fit, D_Steady, D_Clever, D_MC, D_Weapon, D_NotSet, D_NoRoll,
	D_Story,
	D_1,
	D_0
}
public enum MovementType { DangerMove, SafetyMove, ClassMove, NotSet }
public enum DinoClasses { Doctor, Paleontologist, Kid, Hunter, Soldier, Survivor, Engineer, Master, NotSet}
public enum DinoMapTokens { Empty, Airstrip, Building, Docks, Hatchery, Lake, NativeSettlement, Road, TemporalAnomaly, Aviary, Clifs, Fence, Helipad, Mountain, RadioTower, LAboratory, Tunnel, Beach, Nest, Forest, Grass, Ruins, River, Swamp, Volcano, NotSet }

public static class Extensions
{

	public static DinoClasses ToDinoClass(this string str)
	{
		foreach (DinoClasses op in Enum.GetValues(typeof(DinoClasses)))
		{
			if (op.ToUIString() == str)
				return op;
		}
		return DinoClasses.NotSet;
	}
	public static string ToUIString(this DinoClasses c)
	{
		return c switch
		{
			DinoClasses.Engineer => "Ingeniero",
			DinoClasses.Survivor => "Superviviente",
			DinoClasses.Soldier => "Soldado",
			DinoClasses.Paleontologist => "Paleontólogo",
			DinoClasses.Hunter => "Cazador",
			DinoClasses.Kid => "Niño",
			DinoClasses.Doctor => "Doctor",
			DinoClasses.Master => "Master",
			_ => "Desconocida"
		};
	}
	public static string ToPNGPath(this DinoClasses c)
	{
		return c switch
		{
			DinoClasses.Engineer => "imgs/Icons/Engineer.png",
			DinoClasses.Survivor => "imgs/Icons/survivor.png",
			DinoClasses.Soldier => "imgs/Icons/Soldier.png",
			DinoClasses.Paleontologist => "imgs/Icons/Paleontologist.png",
			DinoClasses.Hunter => "imgs/Icons/Hunter.png",
			DinoClasses.Kid => "imgs/Icons/Kid.png",
			DinoClasses.Doctor => "imgs/Icons/Doctor.png",
			_ => "Desconocida"
		};
	}
	public static string ToUI(this DinoMapTokens token)
	{
		switch (token)
		{
			case DinoMapTokens.Empty: return "Empty";
			case DinoMapTokens.Airstrip: return "Pista de aterrizaje";
			case DinoMapTokens.Building: return "Edificio";
			case DinoMapTokens.Docks: return "Embarcadero";
			case DinoMapTokens.Hatchery: return "Incubadora criadero";
			case DinoMapTokens.Lake: return "Lago";
			case DinoMapTokens.NativeSettlement: return "Asentamiento nativo";
			case DinoMapTokens.Road: return "Carretera";
			case DinoMapTokens.TemporalAnomaly: return "Anomalía temporal";
			case DinoMapTokens.Aviary: return "Aviario";
			case DinoMapTokens.Clifs: return "Precipicio";
			case DinoMapTokens.Fence: return "Valla";
			case DinoMapTokens.Helipad: return "Helipuerto";
			case DinoMapTokens.Mountain: return "Montaña";
			case DinoMapTokens.RadioTower: return "Torre de radio";
			case DinoMapTokens.LAboratory: return "Laboratorio";
			case DinoMapTokens.Tunnel: return "Túnel";
			case DinoMapTokens.Beach: return "Playa";
			case DinoMapTokens.Nest: return "Nido";
			case DinoMapTokens.Forest: return "Bosque";
			case DinoMapTokens.Grass: return "Llanura";
			case DinoMapTokens.Ruins: return "Ruinas";
			case DinoMapTokens.River: return "Rio";
			case DinoMapTokens.Swamp: return "pantano/cenagal";
			case DinoMapTokens.Volcano: return "Volcán";
			case DinoMapTokens.NotSet: return "NotSet";
			default: return "NotSet";
		}

	}
	public static string ToImagePath(this DinoMapTokens token)
	{
		switch (token)
		{
			case DinoMapTokens.Empty: return "Empty";
			case DinoMapTokens.Airstrip: return "imgs/Icons/Map/Airstrip.png";
			case DinoMapTokens.Building: return "imgs/Icons/Map/Building.png";
			case DinoMapTokens.Docks: return "imgs/Icons/Map/Docks.png";
			case DinoMapTokens.Hatchery: return "imgs/Icons/Map/Hatchery.png";
			case DinoMapTokens.Lake: return "imgs/Icons/Map/Lake.png";
			case DinoMapTokens.NativeSettlement: return "imgs/Icons/Map/NativeSettlement.png";
			case DinoMapTokens.Road: return "imgs/Icons/Map/Road.png";
			case DinoMapTokens.TemporalAnomaly: return "imgs/Icons/Map/TemporalAnomaly.png";
			case DinoMapTokens.Aviary: return "imgs/Icons/Map/Aviary.png";
			case DinoMapTokens.Clifs: return "imgs/Icons/Map/Clifs.png";
			case DinoMapTokens.Fence: return "imgs/Icons/Map/Fence.png";
			case DinoMapTokens.Helipad: return "imgs/Icons/Map/Helipad.png";
			case DinoMapTokens.Mountain: return "imgs/Icons/Map/Mountain.png";
			case DinoMapTokens.RadioTower: return "imgs/Icons/Map/RadioTower.png";
			case DinoMapTokens.LAboratory: return "imgs/Icons/Map/LAboratory.png";
			case DinoMapTokens.Tunnel: return "imgs/Icons/Map/Tunnel.png";
			case DinoMapTokens.Beach: return "imgs/Icons/Map/Beach.png";
			case DinoMapTokens.Nest: return "imgs/Icons/Map/Nest.png";
			case DinoMapTokens.Forest: return "imgs/Icons/Map/Forest.png";
			case DinoMapTokens.Grass: return "imgs/Icons/Map/Grass.png";
			case DinoMapTokens.Ruins: return "imgs/Icons/Map/Ruins.png";
			case DinoMapTokens.River: return "imgs/Icons/Map/River.png";
			case DinoMapTokens.Swamp: return "imgs/Icons/Map/Swamp.png";
			case DinoMapTokens.Volcano: return "imgs/Icons/Map/Volcano.png";
			default: return "NotSet";
		}
	}

	public static string ToUIString(this DinoStates moveId)
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
			DinoStates.D_0 => "+0",
			DinoStates.D_1 => "+1",

			_ => "Not set"
		};
	}
}
