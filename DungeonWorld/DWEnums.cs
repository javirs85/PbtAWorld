using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;

namespace DungeonWorld;

public enum DWMovementIDs
{
	DW_RawSTR, DW_RawDEX, DW_RawCON, DW_RawINT, DW_RawWIS, DW_RawCHA,
	DW_NotSet, DW_Basic, DW_Advanced, DW_DefyDanger, DW_DD_STR, DW_DD_DEX, DW_DD_CON, DW_DD_INT, DW_DD_WIS, DW_DD_CHA,
	DW_DD, DW_DiscernReality, DW_Interfere, DW_Parley, DW_Supplies, DW_IHaveWhatINeed, DW_SproutLore, DW_Help, DW_DealDamage, DW_Defend, DW_HnS,
	DW_Volley, DW_ReceiveDamage, DW_LastBreath, DW_Recover, DW_Camp, DW_KeepYouMind, DW_HuntDown, DW_IKnowAMan, DW_GlossOverFight,
	DW_FightAsOne, DW_RunAway, DW_Scout, DW_HoldBreath, DW_Travel,
	DW_Barbarian_Hunger,
	DW_Barbarian_Formidable,
	DW_Barbarian_Forastero,
	DW_Barbarian_UpperHand,
	DW_Barbarian_Adv_Muscle,
	DW_Barbarian_Adv_Panter,
	DW_ALL_Adv_ImproveStat2,
	DW_ALL_Adv_SuperiorStat,
	DW_Barbarian_Adv_Impresive,
	DW_Barbarian_Adv_Sanson,
	DW_Barbarian_Adv_VoleyAll,
	DW_Barbarian_Adv_Instinct,
	DW_Barb_Knowledge,
	DW_Barb_Reputation,
	DW_Barb_Smart,
	DW_Barb_Works,
	DW_Barb_DoWorks,
	DW_Barb_Adv_Parry,
	DW_Barb_Adv_MoreWorks,
	DW_Barb_Adv_Cute,
	DW_Barb_Adv_Party,
	DW_Barb_Adv_SilverTonge,
	DW_Cleric_Spells,
	DW_Bard_Works_Fascination,
	DW_Bard_Works_Cacophony,
	DW_Bard_Works_SweetWords,
	DW_Bard_Works_HeartStrings,
	DW_Bard_Works_Lulaby,
	DW_Bard_Works_Rapsody,
	DW_Bard_Works_WarSong,
	DW_Cleric_Spells_Light,
	DW_Cleric_Spells_Santify,
	DW_Cleric_Spells_Bless,
	DW_Cleric_Spells_CureWounds,
	DW_Cleric_Spells_Weapon,
	DW_Cleric_Spells_Santuary,
	DW_Cleric_Spells_SpeakDead,
	DW_Cleric_Spells_Push,
	DW_Cleric_CastSpell,
	DW_Cleric_PrepareSpell,
	DW_Cleric_Favor,
	DW_Cleric_Adv_Intervention,
	DW_Cleric_Adv_Balance,
	DW_Cleric_Adv_Serenity,
	DW_Cleric_Adv_MoreSpells,
	DW_Druid_ShapeShifter,
	DW_Druid_SecretLanguage,
	DW_Druid_TouchedBySpirit,
	DW_Druid_Comunion,
	DW_Druid_Adv_Red,
	DW_Druid_Adv_Call,
	DW_Druid_Adv_TigerEyes,
	DW_Ranger_Hunt,
	DW_Ranger_Shoot,
	DW_Ranger_Stealthy,
	DW_Ranger_FollowMe,
	DW_Ranger_Friend,
	DW_Ranger_Adv_Relatives,
	DW_Ranger_Adv_Naturalist,
	DW_Ranger_Adv_HideSun,
	DW_Ranger_Adv_Horse,
	DW_Ranger_Adv_Predator,
	DW_Fighter_Blind,
	DW_Fighter_Bend,
	DW_Fighter_Hard,
	DW_Fighter_Fright,
	DW_Fighter_Expert,
	DW_Fighter_Adv_IronSkin,
	DW_Fighter_Adv_Relentless,
	DW_Fighter_Adv_Cold,
	DW_Fighter_Adv_Conscient,
	DW_Fighter_Adv_IronEyes,
	DW_Thief_Backstab,
	DW_Thief_DangerSense,
	DW_Thief_Stealth,
	DW_Thief_Tricks,
	DW_Thief_Poison,
	DW_Fighter_Expert_Sword,
	DW_Fighter_Expert_Knife,
	DW_Fighter_Expert_Pole,
	DW_Fighter_Expert_Spear,
	DW_Fighter_Expert_Hammer,
	DW_Fighter_Expert_Axe,
	DW_Fighter_Expert_Mayal,
	DW_Fighter_Expert_Maze,
	DW_Ranger_Friend_Wolf,
	DW_Ranger_Friend_Lince,
	DW_Ranger_Friend_Cat,
	DW_Ranger_Friend_Bird,
	DW_Cleric_AdvSpells_Dispell,
	DW_Cleric_AdvSpells_Stop,
	DW_Cleric_AdvSpells_See,
	DW_Thief_Poison_Tagit,
	DW_Thief_Poison_Widow,
	DW_Thief_Poison_Snake,
	DW_Thief_Poison_Moonkiss,
	DW_Thief_Poison_Goldenroot,
	DW_Thief_Poison_Eldercry,
	DW_Thief_Poison_Bloodweed,
	DW_Thief_Adv_Feline,
	DW_Thief_Adv_Trickster,
	DW_Thief_Adv_Door,
	DW_Thief_Adv_Dirty,
	DW_Thief_Adv_Cheater,
	DW_Wizard_Spells,
	DW_Wizard_Spells_Light,
	DW_Wizard_Spells_Enchant,
	DW_Wizard_Spells_Spirits,
	DW_Wizard_Spells_Invisible,
	DW_Wizard_Spells_Misil,
	DW_Wizard_Spells_Mimic,
	DW_Wizard_Spells_Telepathy,
	DW_Wizard_CastSpell,
	DW_Wizard_PrepareSpell,
	DW_Wizard_Ritual,
	DW_Wizard_AdvSpells_Dispell,
	DW_Wizard_AdvSpells_Fireball,
	DW_Wizard_AdvSpells_Sleep,
	DW_Wizard_Adv_MoreSpells,
	DW_Wizard_Adv_Guardian,
	DW_Wizard_Adv_Detect,
	DW_Wizard_Adv_Logic,
	DW_Paladin_Obliged,
	DW_Paladin_Oblige_Cheat,
	DW_Paladin_Oblige_Protect,
	DW_Paladin_Oblige_Crime,
	DW_Paladin_Oblige_RunAway,
	DW_Paladin_Oblige_Misery,
	DW_Paladin_Oblige_Superior,
	DW_Paladin_Grace,
	DW_Paladin_Eyes,
	DW_Paladin_NoFear,
	DW_Paladin_Hurt,
	DW_Paladin_Adv_Aura,
	DW_Paladin_Adv_Charge,
	DW_Paladin_Adv_Defender,
	DW_Paladin_Adv_Walk,
	DW_Paladin_Adv_Window,
	DW_Wielder_Valor,
	DW_Wielder_Measure,
	DW_Wielder_Weapon,
	DW_Wielder_Adv_Keep,
	DW_Wielder_Adv_Pain,
	DW_Wielder_Adv_Voices,
	DW_Wielder_Adv_Power,
	DW_Bard_Works_Counterpoint,
	DW_ALL_Adv_ImproveStat1,
	DW_Damage,
	DW_Barbarian_InitialChoose
}
public enum DWStats
{
	DW_STR, DW_DEX, DW_CON, DW_INT, DW_WIS, DW_CHA, DW_NotSet, DW_CHOSE, DW_DorS, DW_None, DW_PlusZero, DW_DEXCONWIS, DW_CON_Plus2
}

public enum DWClasses
{
	DW_Barbarian, DW_Bard, DW_Cleric, DW_Druid, DW_Explorer, DW_Fighter, DW_Thief, DW_Mage, DW_Paladin, DW_Wielder,
	DW_NotSet
}
public enum MonsterKinds { cavernas, pantano, nomuerto, BosqueOscuro, Horda, Experimentos, Profundidades, Planares, Gentes, NotSet }

public static class DWExtesions
{
	public static string ToUI(this DWStats stat)
	{
		return stat switch
		{
			DWStats.DW_NotSet => "NotSet",
			DWStats.DW_STR => "FUE",
			DWStats.DW_DEX => "DES",
			DWStats.DW_CON => "CON",
			DWStats.DW_INT => "INT",
			DWStats.DW_WIS => "SAB",
			DWStats.DW_CHA => "CAR",
			DWStats.DW_DorS => "FUE o DES",
			DWStats.DW_CON_Plus2 => "CON+2",
			DWStats.DW_DEXCONWIS => "DES CON o SAB",
			DWStats.DW_PlusZero => "2d6",
			DWStats.DW_CHOSE => "Elije",
			_ => "Unknown DWStat"
		};
	}
	public static string ToLONG_UI(this DWStats stat)
	{
		return stat switch
		{
			DWStats.DW_NotSet => "NotSet",
			DWStats.DW_STR => "fuerza",
			DWStats.DW_DEX => "destreza",
			DWStats.DW_CON => "constitución",
			DWStats.DW_INT => "inteligencia",
			DWStats.DW_WIS => "sabiduría",
			DWStats.DW_CHA => "carisma",
			DWStats.DW_DorS => "FUE o DES",
			DWStats.DW_CON_Plus2 => "CON+2",
			DWStats.DW_DEXCONWIS => "DES CON o SAB",
			DWStats.DW_PlusZero => "+0",
			DWStats.DW_CHOSE => "Elije",
			_ => "Nada"
		};
	}


	public static string ToUI(this DWClasses clas)
	{
		return clas switch
		{
			DWClasses.DW_Barbarian => "Barbaro",
			DWClasses.DW_Bard => "Bardo",
			DWClasses.DW_Cleric => "Clerigo",
			DWClasses.DW_Druid => "Druida",
			DWClasses.DW_Explorer => "Ranger",
			DWClasses.DW_Fighter => "Guerrero",
			DWClasses.DW_Thief => "Ladrón",
			DWClasses.DW_Mage => "Mago",
			DWClasses.DW_Paladin => "Paladín",
			DWClasses.DW_Wielder => "Portador",
			_ => "Unknown DWClass"
		};
	}

	public static string ToUI(this DWMovementIDs id, DWMovesService moves)
	{
		var m = moves.GetMovement(id);
		if (m is not null) return m.Tittle;
		else return $"move {id} is not in the database";
	}
}