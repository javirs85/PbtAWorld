﻿using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanShadows;


public enum Circles { NotSet, Mortalis, Noche, Poder, Velo }

public enum USAttributes{ Blood, Heart, Mind, Soul, Mortality, Night, Power, Veil, Circle, None, Status}

public enum KindsOfAdvance { Normal, Extra, Corruption };
public enum PayingMode { ToPay, ToBePaid };
public enum MovementTypes
{
	NotSet, ArchetipeMovement, FactionMovement, CorruptionMovement, DramaticMovement, DebtMovements, BasicMovements,
	UniqueMove,
	MageMagic,
	FaeMagic,
	CityMoveStatus1,
	CityMoveStatus2,
	FactionPhaseCityMove
}

public enum USMoveIDs
{
	rawBlood, rawHeart, rawMind, rawSoul, rawMortal, rawNight, rawPower, rawVeil, raw2d6,
	NotSet, B_Ataque, B_Escapar, B_Convencer, B_Calar, B_Confundir, B_distraer, B_KeepCalm, B_LiberarPoder, B_AyudarOFastidiar,
	F_01_echarse_a_la_calle, F_02, F_03, F_04, D_01, D_02, D_03, D_04, D_05,
	A_Hunt_01, A_Hunt_02, A_Hunt_03, A_Hunt_04, A_Hunt_05, A_Hunt_06, A_Hunt_07,
	A_Awak_01, A_Awak_02, A_Awak_03, A_Awak_04, A_Awak_05, A_Awak_06,
	A_Vet_01, A_Vet_02, A_Vet_03, A_Vet_04, A_Vet_05, A_Vet_06,
	A_Wolf_01, A_Wolf_02, A_Wolf_03, A_Wolf_04, A_Wolf_05, A_Wolf_06,
	A_Vamp_01, A_Vamp_02, A_Vamp_03, A_Vamp_04, A_Vamp_05, A_Vamp_06,
	A_Mage_01, A_Mage_02, A_Mage_03, A_Mage_04, A_Mage_05, A_Mage_06, A_Mage_07, A_Mage_08, A_Mage_09, A_Mage_10,
	A_Orac_01, A_Orac_02, A_Orac_03, A_Orac_04, A_Orac_05, A_Orac_06,
	A_Corrup_01, A_Corrup_02, A_Corrup_03, A_Corrup_04, A_Corrup_05, A_Corrup_06, A_Corrup_07,
	A_Fai_01, A_Fai_02, A_Fai_03, A_Fai_04, A_Fai_05, A_Fai_06, A_Fai_07, A_Fai_08, A_Fai_09, A_Fai_10, A_Fai_11, A_Fai_12, A_Fai_13,
	A_Spe_01, A_Spe_02, A_Spe_03, A_Spe_04, A_Spe_05, A_Spe_06,
	A_Swo_01, A_Swo_02, A_Swo_03, A_Swo_04, A_Swo_05,
	A_Imp_01, A_Imp_02, A_Imp_03, A_Imp_04, A_Imp_05, A_Imp_06,
	C_Hun_01, C_Hun_02, C_Hun_03, C_Hun_04,
	C_Awa_01, C_Awa_02, C_Awa_03, C_Awa_04,
	C_Wolf_01, C_Wolf_02, C_Wolf_03, C_Wolf_04,
	C_Vamp_01, C_Vamp_02, C_Vamp_03, C_Vamp_04,
	C_Mage_01, C_Mage_02, C_Mage_03, C_Mage_04,
	C_Orac_01, C_Orac_02, C_Orac_03, C_Orac_04,
	C_Imp_01, C_Imp_02, C_Imp_03, C_Imp_04,
	C_Swo_01, C_Swo_02, C_Swo_03, C_Swo_04,
	C_Corrupt_01, C_Corrupt_02, C_Corrupt_03, C_Corrupt_04,
	C_Fai_01, C_Fai_02, C_Fai_03, C_Fai_04,
	C_Spe_01, C_Spe_02, C_Spe_03, C_Spe_04,
	C_Vet_01, C_Vet_02, C_Vet_03, C_Vet_04,
	D_Hun_01, D_Hun_02, D_Hun_03,
	D_Awak_01, D_Awak_02, D_Awak_03,
	D_Vet_01, D_Vet_02, D_Vet_03,
	D_Wolf_01, D_Wolf_02, D_Wolf_03,
	D_Vamp_01, D_Vamp_02, D_Vamp_03, D_Vamp_04, D_Vamp_05,
	D_Mage_01, D_Mage_02, D_Mage_03,
	D_Orac_01, D_Orac_02, D_Orac_03,
	D_Corrup_01, D_Corrup_02, D_Corrup_03,
	D_Fai_01, D_Fai_02, D_Fai_03,
	D_Spe_01, D_Spe_02, D_Spe_03,
	D_Swo_01, D_Swo_02, D_Swo_03,
	D_Imp_01, D_Imp_02, D_Imp_03,
	U_Corr_01, U_Corr_02, U_Fae_01, U_Fae_02, U_Fae_03, U_Fae_04, U_Fae_05, U_Imp_01, U_Imp_02, U_Ora_01, U_Ora_02, U_Mage_01, U_Mage_02, U_Mage_03, U_Mage_04,
	U_Mage_05, U_Mage_06, U_Mage_07, U_Swo_01, U_Swo_02, U_Swo_03, U_Swo_04, U_Vamp_01, U_Vamp_02, U_Vamp_03, U_Spec_01, U_Spec_02, U_Spec_03, U_Spec_04, U_Spec_05,
	U_Spec_06, U_Spec_07, U_Spec_08, U_Vet_01, U_Vet_02, U_Awa_01, U_Awa_02, U_Awa_03,
	LIO_Awa_01, LIO_Awa_02, LIO_Awa_03, LIO_Awa_04,
	LIO_Hunter_01, LIO_Hunter_02, LIO_Hunter_03, LIO_Hunter_04,
	LIO_Vet_01, LIO_Vet_02, LIO_Vet_03, LIO_Vet_04,
	LIO_Wolf_01, LIO_Wolf_02, LIO_Wolf_03, LIO_Wolf_04, LIO_Wolf_05,
	LIO_Vamp_01, LIO_Vamp_02, LIO_Vamp_03, LIO_Vamp_04,
	LIO_Spect_01, LIO_Spect_02, LIO_Spect_03, LIO_Spect_04,
	LIO_Mage_01, LIO_Mage_02, LIO_Mage_03, LIO_Mage_04,
	LIO_Orac_01, LIO_Orac_02, LIO_Orac_03, LIO_Orac_04,
	LIO_Sworn_01, LIO_Sworn_02, LIO_Sworn_03, LIO_Sworn_04,
	LIO_Fae_01, LIO_Fae_02, LIO_Fae_03, LIO_Fae_04,
	LIO_Imp_01, LIO_Imp_02, LIO_Imp_03, LIO_Imp_04,
	LIO_Corrupt_01, LIO_Corrupt_02, LIO_Corrupt_03, LIO_Corrupt_04,
	CityStatus1_01,
	CityStatus1_02,
	CityStatus1_03,
	CityStatus2_01,
	CityStatus2_02,
	CityStatus2_03,
	CityStatus2_04,
	CityFaction_01,
	CityFaction_02,
	CityFaction_03,
	CityFaction_04,
	CityFaction_05,
	CityFaction_06,
	CityFaction_07,
	CityStatus1_04,
	D_Orac_04
}

public static class EnumExtensions
{
	public static string ToUI(this USAttributes ch)
	{
		return ch switch
		{
			USAttributes.Blood => "Sangre",
			USAttributes.Mind => "Mente",
			USAttributes.Soul => "Espíritu",
			USAttributes.Heart => "Corazón",
			USAttributes.Mortality => "Mortalis",
			USAttributes.Night => "Noche",
			USAttributes.Veil => "Velo",
			USAttributes.Power => "Poder",
			USAttributes.Circle => "Círculo",
			USAttributes.Status => "Estatus",
			_ => $"Unknown characteristic ToUI {ch}"
		};
	}

	public static string ToUI(this US_Classes arq)
	{
		return arq switch
		{
			US_Classes.Hunter => "Cazador",
			US_Classes.Awaken => "Despertado",
			US_Classes.Fair => "Hada",
			US_Classes.Mage => "Mago",
			US_Classes.Veteran => "Veterano",
			US_Classes.Vampire => "Vampiro",
			US_Classes.Corrupted => "Corrompido",
			US_Classes.Oracle => "Oraculo",
			US_Classes.Wolf => "Hombre Lobo",
			US_Classes.Spectre => "Espectro",
			US_Classes.Imp => "Duencedillo",
			US_Classes.Sworn => "Juramentado",
			US_Classes.Master => "Master",
			_ => $"Unknown arquetipe ToUI: {arq.ToString()}"
		};
	}

}