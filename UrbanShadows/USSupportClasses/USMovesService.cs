using PbtALib;
using System.Reflection;

namespace UrbanShadows;

public class USMovesService : MovesServiceBase
{
	public List<USMove> AllMovements { get; set; } = new();
	public List<LIO> AllLio { get; set; } = new();

	public USMove GenerateImprovedMovement(USMove move, USCharacterSheet Player)
	{
		USMove NewMove = new USMove(move.ID, move.Rolls);
		NewMove.CopyContentFrom(move);
		if(NewMove.ID == USMoveIDs.D_03) //Negarse a pagar una deuda
		{
			NewMove.AvailableExtras.Add(RollExtras.bonusMinus3);
			NewMove.AvailableExtras.Add(RollExtras.bonusMinus2);
			NewMove.AvailableExtras.Add(RollExtras.bonusPlus1);
			NewMove.AvailableExtras.Add(RollExtras.bonusPlus2);
			NewMove.AvailableExtras.Add(RollExtras.bonusPlus3);
		}

		if(NewMove.ID == USMoveIDs.F_01_echarse_a_la_calle)
		{
			if(Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Awak_01))
			{
				NewMove.Rolls.Add(USAttributes.Heart);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ConsequencesOn79.Options!.AddRange(
					new List<string> {
						"[+] Como sea que los encuentres requiere que ofrezcas una Deuda a un intermediario."
					});
				var m = USMoveIDs.A_Awak_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vamp_06)) //Es mi barrio
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.AvailableExtras.Add(RollExtras.bonusPlus3);
				var m = USMoveIDs.A_Vamp_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Spe_03)) //Ciudad fantasma
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.AvailableExtras.Add(RollExtras.bonusPlus1);
				var m = USMoveIDs.A_Spe_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			
		}
		if (NewMove.ID == USMoveIDs.F_02) //ponerle cara a un nombre
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Imp_04)) // amigos en los bajos fondos
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Imp_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Swo_04)) // Aunténtico policía
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Swo_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.F_03) //Investigar un lugar de poder
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Swo_04)) // Aunténtico policía
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Swo_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if(Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Awak_03)) //La guarida del león
			{
				NewMove.Rolls.Add(USAttributes.just13);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Awak_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}





		if (NewMove.ID == USMoveIDs.B_Ataque)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Swo_05)) //Ajedrez, no damas
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Swo_05;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_04)) //Ajedrez, no damas
			{
				NewMove.Rolls.Add(USAttributes.just13);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Hun_01)) //Divide y venceré
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Hun_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Hunt_02)) //Letal
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Hunt_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Hun_02)) //Dificil de matar
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Hun_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_06)) // Sacar la pistola en una pelea de navajas 
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Vet_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Wolf_06)) // Temerario
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Wolf_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Wolf_02)) //La fuerza de la naturaleza
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Wolf_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Mage_01)) //Las artes oscuras
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.Rolls.Add(USAttributes.Soul);
				var m = USMoveIDs.C_Mage_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if (NewMove.ID == USMoveIDs.B_Escapar)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Spe_05)) //Muro? Qué muro? 
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.Rolls.Add(USAttributes.just13);
				var m = USMoveIDs.A_Spe_05;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Hun_01)) //Divide y venceré
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Hun_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Wolf_02)) //La fuerza de la naturaleza
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Wolf_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Fai_05)) // Lo llevamos en la sangre
			{
				var m = USMoveIDs.A_Fai_05;
				foreach(var o in GetMovement(m).PreCondition.Options)
					NewMove.PreCondition.Options.Add("[+] "+o);

				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if (NewMove.ID == USMoveIDs.B_Convencer)
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Imp_03))
			{
				NewMove.Rolls.Add(USAttributes.just13);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Imp_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if(Player.Archetype == US_Classes.Vampire)
			{
				NewMove.AvailableExtras.Add(RollExtras.bonusPlus3);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("Gasta una deuda antes de tirar para avanzar el movimiento y aplicar +3. Sólo en esta tirada");
			}
			if(Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Hunt_06))
			{
				NewMove.Rolls.Add(USAttributes.Blood);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Hunt_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Wolf_04)) // Lobo alfa
			{
				var m = USMoveIDs.A_Wolf_04;
				NewMove.Rolls.Add(USAttributes.Blood);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Fai_03)) // Negociador astuto
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Fai_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}


		if (NewMove.ID == USMoveIDs.B_Calar)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vamp_05)) //Mantener cerca a tus amigos 
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.Rolls.Add(USAttributes.just13);
				var m = USMoveIDs.A_Vamp_05;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Imp_02))  //mide tu marca
			{
				var om = GetMovement(USMoveIDs.A_Imp_02);
				foreach(var i in om.PreCondition.Options!)
				{
					NewMove.PreCondition.Options!.Add("[+] " + i);
				}
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + om.Title + "**\r\n " + om.PreCondition.MainText);
			}
			if(Player.Archetype == US_Classes.Vampire)
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("Opción extra si está en tu red");
				NewMove.PreCondition.Options.Add("[RED] Cuál es la verdadera hambre de tu personaje?");
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Orac_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Orac_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Wolf_03)) //Sabueso callejero
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.Rolls.Add(USAttributes.Soul);
				var m = USMoveIDs.C_Wolf_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if (NewMove.ID == USMoveIDs.B_Confundir)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Awak_05))
			{
				NewMove.Rolls.Add(USAttributes.Heart);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Awak_05;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Imp_04)) //En la lista negra
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Imp_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Spe_02)) // No toleraré que me ignores 
			{
				NewMove.Rolls.Add(USAttributes.Soul);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*No toleraré que me ignores**\r\nSi *Confundes, distraes, esgañas** a un a alguien con una demonstración obviamente sobrenatural, tira con Espíritu en vez de Mente.");
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Wolf_03)) //Sabueso callejero
			{
				NewMove.IsImprovedByOtherMove = true;
				NewMove.Rolls.Add(USAttributes.Soul);
				var m = USMoveIDs.C_Wolf_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Fai_03)) // Lo llevamos en la sangre
			{
				var m = USMoveIDs.A_Fai_03;
				NewMove.Rolls.Add(USAttributes.Heart);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if (NewMove.ID == USMoveIDs.B_KeepCalm)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vamp_04)) //Sangre fría
			{
				NewMove.Rolls.Add(USAttributes.Blood);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Vamp_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.Archetype == US_Classes.Sworn)
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.U_Swo_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Hunt_01))
			{
				NewMove.Rolls.Add(USAttributes.Blood);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Hunt_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if (NewMove.ID == USMoveIDs.B_AyudarOFastidiar)
		{
			if (Player.Archetype == US_Classes.Vampire)
			{
				NewMove.AvailableExtras.Add(RollExtras.bonusPlus1);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("+1 Si están en tu red");
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Spe_02)) // No toleraré que me ignores 
			{
				NewMove.Rolls.Add(USAttributes.just10);
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*No toleraré que me ignores**\r\nCuando fastidies a alguien no tires y considera que has sacado un 10+");
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_03)) // Invertir 
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Vet_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Awa_01))
			{
				NewMove.Rolls.Add(USAttributes.just10);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Awa_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}

		}

		if (NewMove.ID == USMoveIDs.B_LiberarPoder)
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Spe_06)) //Catalizador 
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Spe_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Awa_02)) //Si no puedes con ellos .. 
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Awa_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Orac_04)) //Catalizador 
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Orac_04;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Vet_04)) // Ya estoy viejo para estas mierdas 
			{
				var m = USMoveIDs.A_Vet_04;
				NewMove.IsImprovedByOtherMove = true;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Orac_01)) //De vuelta a las andadas
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Orac_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}




		if (NewMove.ID == USMoveIDs.CityStatus1_01) //debilitar la posición de una facción
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Vamp_03)) //Fake news
			{
				NewMove.Rolls.Add(USAttributes.Heart);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Vamp_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}			
		}

		if (NewMove.ID == USMoveIDs.CityStatus1_03) //Consultar a tus contactos
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_02)) //Fake news
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.CityStatus1_04) //Ocuparte de tus asuntos
		{
			if (Player.Archetype == US_Classes.Awaken) //Ocuparme de ellos
			{
				NewMove.Rolls.Add(USAttributes.Heart);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.U_Awa_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		

		if (NewMove.ID == USMoveIDs.D_02) //cobrarse una deuda
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Vamp_02)) // mantenlos dentro
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Vamp_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		
		if (NewMove.ID == USMoveIDs.D_03) //negarse a pagar una deuda
		{
			if (Player.SelectedArchetypeMoves.Contains(USMoveIDs.A_Imp_06)) // palabras de comadreja
			{
				NewMove.Rolls.Add(USAttributes.Mind);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.A_Imp_06;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if(Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Awa_03)) // Libre como el viento
			{
				NewMove.Rolls.Add(USAttributes.just13); 
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Awa_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Fai_02)) // Negociador astuto
			{
				NewMove.Rolls.Add(USAttributes.just13);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Fai_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.CityStatus1_02) //hacer correr la voz
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Imp_01)) // palabras de comadreja
			{
				NewMove.Rolls.Add(USAttributes.just13);
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Imp_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.U_Imp_02) //Finalizar un chanchullo
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Imp_02)) // Finero sucio
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Imp_02;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}

		if(NewMove.ID == USMoveIDs.A_Swo_01)
		{
			if(Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.A_Swo_02)
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Swo_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Swo_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.A_Orac_02) //Piscometría
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Orac_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Orac_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.A_Orac_06) // Rozar la superficie
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Orac_01))
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Orac_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.A_Mage_02) // Santosanctorum
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Mage_03)) //Magia negra
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Mage_03;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}
		if (NewMove.ID == USMoveIDs.A_Fai_01) // Magia feerica
		{
			if (Player.SelectedCorruptionMoves.Contains(USMoveIDs.C_Fai_01)) //Aire y oscuridad
			{
				NewMove.IsImprovedByOtherMove = true;
				var m = USMoveIDs.C_Fai_01;
				NewMove.ImprovedByOhterMoveExplanation.Add("*" + GetMovement(m).Title + "**\r\n " + GetMovement(m).PreCondition.MainText);
			}
		}


		if (NewMove.HasRoll())
		{
			NewMove.AvailableExtras.Add(RollExtras.bonusPlus1);
		}

		NewMove.FixRolls();

		return NewMove;
	}

	

	public USMovesService()
	{
		AllMovements.AddRange(GenerateBasicMovments());

		AllMovements.Add(new USMove(USMoveIDs.B_LiberarPoder, USAttributes.Soul) { Archetipe = US_Classes.All, Title = "Liberar tu poder" });

		AllMovements.AddRange(GenerateFactionMovements());
		AllMovements.AddRange(GenerateDebtMovements());

		AllMovements.AddRange(GenerateHunterMovements());
		AllMovements.AddRange(GenerateAwakenMovements());
		AllMovements.AddRange(GenerateVeteranMovements());
		AllMovements.AddRange(GenerateWolfMovements());
		AllMovements.AddRange(GenerateVampireMovements());
		AllMovements.AddRange(GenerateMageMovements());
		AllMovements.AddRange(GenerateOracleMovements());
		AllMovements.AddRange(GenerateCorruptedMovements());
		AllMovements.AddRange(GenerateFairyMovements());
		AllMovements.AddRange(GenerateSpectreMovements());
		AllMovements.AddRange(GenerateSwornMovements());
		AllMovements.AddRange(GenerateImpMovements());

		AllMovements.AddRange(GenerateHunterCorruptionMovements());
		AllMovements.AddRange(GenerateAwakenCorruptionMovements());
		AllMovements.AddRange(GenerateVeteranCorruptionMovements());
		AllMovements.AddRange(GenerateWolfCorruptionMovements());
		AllMovements.AddRange(GenerateVampireCorruptionMovements());
		AllMovements.AddRange(GenerateMageCorruptionMovements());
		AllMovements.AddRange(GenerateOracleCorruptionMovements());
		AllMovements.AddRange(GenerateCorrupteCorruptionMovements());
		AllMovements.AddRange(GeneratefairyCorruptionMovements());
		AllMovements.AddRange(GenerateSpectreCorruptionMovements());
		AllMovements.AddRange(GenerateSwornCorruptionMovements());
		AllMovements.AddRange(GenerateImpCorruptionMovements());

		AllMovements.AddRange(GenerateHunterDramaticMovements());
		AllMovements.AddRange(GenerateAwakenDramaticMovements());
		AllMovements.AddRange(GenerateVeteranDramaticMovements());
		AllMovements.AddRange(GenerateWolfDramaticMovements());
		AllMovements.AddRange(GenerateVampireDramaticMovements());
		AllMovements.AddRange(GenerateMageDramaticMovements());
		AllMovements.AddRange(GenerateOracleDramaticMovements());
		AllMovements.AddRange(GenerateCorruptedDramaticMovements());
		AllMovements.AddRange(GenerateFairyDramaticMovements());
		AllMovements.AddRange(GenerateSpectreDramaticMovements());
		AllMovements.AddRange(GenerateSwornDramaticMovements());
		AllMovements.AddRange(GenerateImpDramaticMovements());

		AllMovements.AddRange(GenerateAwakenUniqueMoves());
		AllMovements.AddRange(GenerateCorruptedUniqueMoves());
		AllMovements.AddRange(GenerateFaeUniqueMoves());
		AllMovements.AddRange(GenerateImpUniqueMoves());
		AllMovements.AddRange(GenerateMageUniqueMoves());
		AllMovements.AddRange(GenerateOracleUniqueMoves());
		AllMovements.AddRange(GenerateSpecterUniqueMoves());
		AllMovements.AddRange(GenerateSwornUniqueMoves());
		AllMovements.AddRange(GenerateVampUniqueMoves());
		AllMovements.AddRange(GenerateVeteranUniqueMoves());

		AllMovements.Add(new USMove(USMoveIDs.rawBlood, USAttributes.Blood) { Title = "Sangre" });
		AllMovements.Add(new USMove(USMoveIDs.rawMind, USAttributes.Mind) { Title = "Mente" });
		AllMovements.Add(new USMove(USMoveIDs.rawHeart, USAttributes.Heart) { Title = "Corazón" });
		AllMovements.Add(new USMove(USMoveIDs.rawSoul, USAttributes.Soul) { Title = "Espíritu" });
		AllMovements.Add(new USMove(USMoveIDs.rawMortal, USAttributes.Mortality) { Title = "Mortalis" });
		AllMovements.Add(new USMove(USMoveIDs.rawNight, USAttributes.Night) { Title = "Noche" });
		AllMovements.Add(new USMove(USMoveIDs.rawPower, USAttributes.Power) { Title = "Poder" });
		AllMovements.Add(new USMove(USMoveIDs.raw2d6, USAttributes.None) { Title = "2d6" });

		AllLio.AddRange(GenerateAwakenLIO());
		AllLio.AddRange(GenerateHunterLIO());
		AllLio.AddRange(GenerateVeteranLIO());
		AllLio.AddRange(GenerateMageLIO());
		AllLio.AddRange(GenerateOracleLIO());
		AllLio.AddRange(GenerateSwornLIO());
		AllLio.AddRange(GenerateFairLIO());
		AllLio.AddRange(GenerateImpLIO());
		AllLio.AddRange(GenerateCorruptedLIO());
		AllLio.AddRange(GenerateWolfLIO());
		AllLio.AddRange(GenerateVampireLIO());
		AllLio.AddRange(GenerateSpecterLIO());

		AllMovements.AddRange(GenerateStatus1CityMoves());
		AllMovements.AddRange(GenerateStatus2CityMoves());
		AllMovements.AddRange(GenerateFactionMoves());
	}

	public List<USMoveIDs> GetInitialMovesIDsByArchetype(US_Classes arch)
	{
		var list = from mov in AllMovements
				   where 
						mov.Archetipe == arch && 
						mov.TypeOfMovement == MovementTypes.ArchetipeMovement && 
						mov.IsSelected
				   select mov.ID;

		return list.ToList();
	}


	public override IMove GetMovement<TMovIDs, TClases>(TMovIDs _ID, TClases _archetype)
	{
		USMoveIDs ID = (USMoveIDs)(object)_ID;
		US_Classes archetype = (US_Classes)(object)_archetype;

		if (ID == USMoveIDs.B_LiberarPoder)
		{
			var m = GetArchetypeBasedLetItOutMovement(archetype);
			var original = AllMovements.Find(x => x.ID == USMoveIDs.B_LiberarPoder);
			original.PreCondition = m.PreCondition;
			original.ConsequencesOn6 = m.ConsequencesOn6;
			original.ConsequencesOn79 = m.ConsequencesOn79;
			original.ConsequencesOn10 = m.ConsequencesOn10;
			original.AdvancedConsequences = m.AdvancedConsequences;

			return original;
		}

		return AllMovements.Find(x => x.ID == ID) ?? new USMove(USMoveIDs.NotSet, USAttributes.None) { Title = "Unknown movement" };
	}
	USMove GetArchetypeBasedLetItOutMovement(US_Classes archetype)
	{
		var m = new USMove(USMoveIDs.B_LiberarPoder, USAttributes.Soul)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Liberar tu poder",
			PreCondition = new Consequences
			{
				MainText = "Cuando liberas los poderes mas oscuros de tu ser, elige una habilidad de la lista y tira con Espíritu.",
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Márcate corrupción y el MC te dirá cómo el efecto de tu poder es costoso, limitado o inestable."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Elije ignorar la corrupción o las complicaciones."
			},
			AdvancedConsequences = new Consequences
			{
				MainText = " 12+, tus poderes o habilidades se manifiestan de alguna forma inesperada pero útil. Puedes márcate corrupción para hacer permanente esa manifestación.",
			}
		};

		m.Title = "Liberar tu poder";

		return m;
	}

	public override IMove GetMovement<TMovIDs>(TMovIDs _ID)
	{
		USMoveIDs ID = (USMoveIDs)(object)_ID;
		return AllMovements.Find(x => x.ID == ID) ?? new USMove(USMoveIDs.NotSet, USAttributes.None) { Title = "Unknown movement" };
	}


	#region GenerateMovements

	private List<USMove> GenerateBasicMovments()
	{
		List<USMove> result = new();

		result.Add(new USMove(USMoveIDs.B_Ataque, USAttributes.Blood)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			Title = "Llevarlo a la violencia",
			IsImproved = false,
			PreCondition = new Consequences
			{
				MainText = "Cuando le lances un ataque a alguien,  tira con Sangre. "				
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Inflige daño según lo establecido y TU OPONENTE elige 1 opción:",
				Options = new List<string>
					{
						"Te hiere a tí también.",
						"Te pone en una situación complicada.",
						"Crea una oportunidad para escapar"
					}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, TU eliges también 1 de las siguientes opciones:",
				Options = new List<string>
					{
						"Haces un daño terrible",
						"Obtienes algo de él.",
						"Creas una oportunidad para un aliado"
					}
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "Con un 12+, infliges daño según lo establecido y eliges 2 de la lista de 10+",
			}

		});
		result.Add(new USMove(USMoveIDs.B_Escapar, USAttributes.Blood)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Escapar de una situación",
			PreCondition = new Consequences
			{
				MainText = "Cuando *aproveches una oportunidad** para escapar de una situación, tira con Sangre.",
				Options = new List<string>
					{
						"Sufres daño durante tu huida",
						"acabas en otra situación peligrosa",
						"te dejas algo importante",
						"tienes una deuda con un PNJ por su ayuda",
						"cedes a tu naturaleza básica y marcas corrupción"
					}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Eliges 1 y el MC también elige otra (2 en total):",
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Elije 1, el MC no elije (1 en total)"
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "Escapas y haces un descubrimiento importante.",
			}
		});
		result.Add(new USMove(USMoveIDs.B_Convencer, USAttributes.Heart)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Persuadir a un PNJ",
			PreCondition = new Consequences
			{
				MainText = "Cuando persuades  a un *PNJ** mediante seducción, promesas o amenazas,  tira con Corazón.\r\nSi cobras una Deuda con el PNJ *antes** de tirar el dado, suma +3 a tu total",
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Comparten tu opinión y hacen lo que les pides, pero, se oponen a tu propuesta o exigen un pago -una deuda, un favor, recursos- antes de aceptar seguir adelante."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Comparten tu opinión y hacen lo que les pides."
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "Hará lo que le hayas pedido y te ayudará con ese asunto hasta el final.",
			}
		});
		result.Add(new USMove(USMoveIDs.B_Calar, USAttributes.Mind)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Calar a alguien",
			PreCondition = new Consequences
			{
				MainText = "Cuando intentes calar a alguien, tira con Mente. Gastad puntos, mientras estés interactuando con ese personaje, para hacerle una pregunta al jugador que lo interpreta.\nSi pertenecéis a la mismo Circulo, hazle una pregunta más, aunque hayas fallado la tirada.\n\r",
				Options = new List<string>
					{
						"¿Quién mueve los hilos de tu personaje?",
						"¿Qué problema tiene tu personaje con (...)?",
						"¿Qué espera conseguir tu personaje de (...)?",
						"¿Cómo podría yo hacer que tu personaje (...)?",
						"¿Qué le preocupa a tu personaje que ocurra?",
						"¿Cómo podría yo hacer que tu personaje contrajera una Deuda conmigo?"
					}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Obtienes 2 puntos y la otra persona obtiene también 1 punto que puede gastar en preguntarte a ti. ",
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Obtienes 2 puntos y la otra persona 0",
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "Puedes hacer cualquier pregunta (una por cada punto), no solo las de la lista. Pregunta lo que quieras, incluso «¿Estás mintiendo?». Tu objetivo es un libro abierto.",
			}
		});
		result.Add(new USMove(USMoveIDs.B_Confundir, USAttributes.Mind)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Confundir, distraer o engañar",
			PreCondition = new Consequences
			{
				MainText = "Cuando intentes confundir, distraer o engañar a alguien, tira con Mente. Si superas la tirada, se lo traga, al menos durante un momento.",
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, elige dos opciones:"
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, elige 3 opciónes.",
				Options = new List<string>
					{
						"Creas una oportunidad.",
						"Revelas un punto débil o un defecto.",
						"Dejas a tu objetivo confundido durante un tiempo.",
						"Evitas más complicaciones."
					}
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "12+, obtienes las 4 opciones. Además, duplica el efecto de una de ellas.",
			}
		});
		result.Add(new USMove(USMoveIDs.B_KeepCalm, USAttributes.Soul)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			Title = "Mantener la calma",
			PreCondition = new Consequences
			{
				MainText = "Cuando las cosas se pongan serias y mantengas la calma, dile al MC qué situación quieres evitar y tira con Espíritu.",
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Ell MC te dirá el coste que conlleva para ti."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Todo va bien."
			},
			AdvancedConsequences = new Consequences
			{
				MainText = "La calma de tu oposición se ve comprometida. Dile lo que le va a costar mantener su curso de acción actual.",
			}
		});
		result.Add(new USMove(USMoveIDs.B_AyudarOFastidiar, USAttributes.Circle)
		{
			TypeOfMovement = MovementTypes.BasicMovements,
			IsSelected = true,
			IsImproved = false,
			TicksCircle = true,
			Title = "Ayudar o interferir",
			PreCondition = new Consequences
			{
				MainText = "Cuando ayudes o te interpongas en el camino de un PJ. *Después de que haya tirado**, tira con su Círculo.",
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Dale un +1 o -2 a su tirada, pero te expones a peligro, enredo o coste"
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Dale un +1 o -2 a su tirada sin contrapartidas"
			}
		});

		return result;
	}


	private List<USMove> GenerateFactionMovements()
	{
		List<USMove> result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.F_01_echarse_a_la_calle, USAttributes.Circle)
		{
			TypeOfMovement = MovementTypes.FactionMovement,
			IsSelected = true,
			Title = "Echarse a la calle",
			TicksCircle = true,
			PreCondition = new Consequences
			{
				MainText = "Cuando *te eches a la calle para conseguir lo que quieres**,  di el nombre de la persona a la que acudes y tira con su Circulo. Si superas la tirada, estará disponible y tendrá lo que quieres."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, elige 1 opción:",
				Options = new List<string>
					{
						"La persona a la que acudes ya tiene problemas propios con los que lidiar.",
						"Lo que necesitas tiene un coste mayor de lo que esperabas."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.F_02, USAttributes.Circle)
		{
			TypeOfMovement = MovementTypes.FactionMovement,
			IsSelected = true,
			TicksCircle = true,
			Title = "Ponerle cara a un nombre",
			PreCondition = new Consequences
			{
				MainText = "Cuando le pongas cara a un nombre o un nombre a una cara, tira con su Circulo. Si fallas la tirada no lo conoces o tienes una Deuda con él; el MC te dirá cuál de las dos."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Si superas la tirada, conoces su reputación; el Maestro de Ceremonias te dirá lo que la mayoría de la gente sabe sobre él. "
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, ya has tratado antes con esa persona; descubres algo interesante y útil sobre él o tiene una Deuda contigo. (tu elijes)"
			}
		});
		result.Add(new USMove(USMoveIDs.F_03, USAttributes.Circle)
		{
			TypeOfMovement = MovementTypes.FactionMovement,
			IsSelected = true,
			TicksCircle = true,
			Title = "Investigar un lugar de poder",
			PreCondition = new Consequences
			{
				MainText = "Cuando investigues un lugar poderoso, tira con el Circulo a la que pertenezca."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Si superas la tirada, verás la realidad subyacente bajo la superficie."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, puedes hacerle una pregunta al Maestro de Ceremonias sobre las tramas y la política de esa Facción."
			}
		});
		return result;
	}
	private List<USMove> GenerateDebtMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.DebtMovements,
			IsSelected = true,
			Title = "Hacerle un favor a alguien",
			PreCondition = new Consequences
			{
				MainText = "Cuando le hagas un favor a alguien, *sin recibir nada a cambio** contrae una Deuda contigo."
			}
		});
		result.Add(new USMove(USMoveIDs.D_05, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.DebtMovements,
			IsSelected = true,
			Title = "Saldar una deuda",
			TicksCircle = true,
			PreCondition = new Consequences
			{
				MainText = "Cuando pagues una deuda, haz lo reclamado y marca el círculo del acreedor de la deuda."
			}
		});
		result.Add(new USMove(USMoveIDs.D_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.DebtMovements,
			IsSelected = true,
			Title = "Meterte en sus asuntos",
			PreCondition = new Consequences
			{
				MainText = "Cuando *interfieres en los negocios de alguien**, le debes una Deuda. \r\n"
			}
		});
		result.Add(new USMove(USMoveIDs.D_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.DebtMovements,
			IsSelected = true,
			TicksCircle = true,
			Title = "Cobrarse una deuda",
			PreCondition = new Consequences
			{
				MainText = "Cuando te cobres una Deuda, recuérdale a tu deudor por qué está en Deuda contigo.\nSi es un PJ aplica 7-9, si es un PNJ aplica 10+ (No hay tirada)."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Para hacer que un personaje jugador:",
				Options = new List<string>
					{
						"Te haga un favor de coste moderado.",
						"Te eche una mano.",
						"Fastidie a otro.",
						"Responda a una pregunta con sinceridad.",
						"Cancele una Deuda de la que sea acreedor.",
						"Te transfiera a ti el derecho a cobrarle una Deuda a otra persona.",
					}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Para hacer que un personaje NO jugador:",
				Options = new List<string>
					{
						"Responda con sinceridad a una pregunta sobre su Facción.",
						"Organice un encuentro con un PNJ de su Círculo.",
						"Te haga un regalo valioso y útil.",
						"Cancele una Deuda de la que sea acreedor.",
						"Te transfiera a ti el derecho a cobrarle una Deuda a otra persona.",
						"Te dé un +3 para Convencerlo (esta opción ha de elegirse antes de tirar).",
					}
			}
		});
		result.Add(new USMove(USMoveIDs.D_03, USAttributes.Status)
		{
			TypeOfMovement = MovementTypes.DebtMovements,
			IsSelected = true,
			Title = "Negarse a pagar una deuda",
			PreCondition = new Consequences
			{
				MainText = "Cuando te niegues a honrar una Deuda, tira con la diferencia de *estatus** entre tú y tu acreedor."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText= "Te libras de la obligación por ahora, pero sigues debiendo la Deuda. Además, les debes una deuda adicional o marcas corrupción, tu eliges."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Te libras de la obligación por ahora, pero sigues debiendo la Deuda."
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "No puedes evitar la soga: o honras la Deuda en su totalidad o borras todas las Deudas que te debe su Círculo y tendrás un -1 en curso al Estatus con su Círculo hasta que pase el tiempo."
			}
		});
		return result;
	}


	private List<USMove> GenerateHunterMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Hunt_01, USAttributes.None)
		{
			Title = "Exterminador",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando mantengas la calma durante una cacería, tira con Sangre en vez de Espíritu."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_02, USAttributes.None)
		{
			Title = "Letal",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando hagas daño suma +1"
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_03, USAttributes.Mind)
		{
			Title = "Leyendo también se aprende",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando te encuentres un tipo nuevo de criatura sobrenatural, tira con Mente. Si fallas la tirada, malinterpretas a la criatura; el Maestro de Ceremonias te dirá cómo."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Si superas la tirada, el Maestro de Ceremonias te dirá un poco sobre ella y cómo se la puede matar."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10 +, tras oír la información, hazle una pregunta al Maestro de Ceremonias; la contestará con honestidad. "
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_04, USAttributes.None)
		{
			Title = "Piso franco",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Tienes un lugar seguro en el que esconderte. Detállalo y elige 3 rasgos que tenga:",
				Options = new List<string>
					{
						"Dispositivos de vigilancia de alta tecnología.",
						"Una prisión mística.",
						"Muros / ventanas / puertas reforzados.",
						"Agua y comida para una semana.",
						"Explosivos dispuestos para volar el lugar."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_05, USAttributes.Blood)
		{
			Title = "¡Por aquí!",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando guíes a alguien para ponerlo a salvo, tira con Sangre. Si fallas la tirada, todos quedan a salvo excepto tú; te dejan atrás y la salida se cierra para ti."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7 - 9, o bien tú sufres daño o bien uno de ellos sufre daño(a tu elección)."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10 +, todos conseguís escapar sanos y salvos."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_06, USAttributes.Blood)
		{
			Title = "¿Quieres tentar a la suerte?",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Persuadas** a un PNJ mientras blandes un arma de 2-daño o superior, tira con Sangre en vez de Corazón."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Hunt_07, USAttributes.None)
		{
			Title = "Preparado para todo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = " Tienes una armería bien provista, llena de armas tanto antiguas como modernas. Cógete otra arma personalizada o añádele otra característica a cada una de las que ya tengas."
			}
		});

		return result;
	}
	private List<USMove> GenerateAwakenMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Awak_01, USAttributes.None)
		{
			Title = "Conozco a un tío",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando te *echas a la calle** para conseguir lo que necesitas de un miembro de tu Círculo, tira con *Corazón** en lugar de con su Círculo"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, tu lista mejora:",
				Options = new List<string> {
					"Como sea que los encuentres requiere que ofrezcas una Deuda a un intermediario."
				}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Awak_02, USAttributes.None)
		{
			Title = "Encantador, no sincero",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "+1 Corazón (Max 3)"
			}
		});
		result.Add(new USMove(USMoveIDs.A_Awak_03, USAttributes.None)
		{
			Title = "La guarida del león",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando obtienes acceso a una zona segura dentro de un santuario, punto de reunión o lugar de poder, puedes *Estudiarla** como si hubieras sacado un 12+.\r\n\r\n Si el lugar está controlado por un Circulo distinto al tuyo, también encuentras pruebas incriminatorias que implican a un PNJ poderoso (a tu elección) dentro de ese círculo.\n\rEntregarle las pruebas a él (o a uno de sus enemigos) cuenta como cobrar una deuda.",
				Options =new List<string>
				{
					"Con un acierto, ves bajo la superficie hasta la realidad que hay debajo; el MC revelará un área, PNJ u objeto situado dentro que no es lo que parece.",
					"Con un 10+, tu perspicacia revela mucho sobre la política y los planes del Círculo; haz al MC una pregunta sobre el Círculo y tira con +1 cuando actúes según la respuesta."
				}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Awak_04, USAttributes.None)
		{
			Title = "Esta es mi ciudad",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando conciertas una reunión con un individuo poderoso o peligroso en un espacio mundano abarrotado (museo, restaurante, etc) obtén dos puntos que puedes gastar 1 por 1 para:",
				Options = new List<string>
				{
					"+1 para escapara de la situación",
					"crea una abertura para que tú u otro personaje escape de la situación",
					"elije por el MC cuando escapes y saques un 7-9"
				}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Awak_05, USAttributes.None)
		{
			Title = "Con piel de cordero",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Confundas, distraigas o engañes** con alguien con quien has compartido previamente un momento de intimidad, tira con *Corazón** en lugar de mente."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Awak_06, USAttributes.Heart)
		{
			Title = "De una forma u otra",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando supliques ayuda a un miembro de tu Círculo ante una situación apremiante, tira con *Corazón**.\r\nCon un éxito, aceptan ayudarte o te deben una deuda, a su elección.\r\nCon un 10+, su culpabilidad es palpable: si se niegan y te deben una deuda tienes +1 constante contra ellos mientras tengas la deuda.\r\nCon un fallo estás expuesto y vulnerable, son libres de hacer lo que quieran... y tú marcas corrupción si ignoran tu súplica."
			}
		});


		return result;
	}
	private List<USMove> GenerateVeteranMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Vet_01, USAttributes.Mind)
		{
			Title = "Viejos amigos, viejos favores",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando te encuentres por primera vez a un personaje no jugador, en vez de ponerle nombre a una cara, puedes declarar que es un viejo amigo y tirar con Mente. Si superas la tirada, te ofrecerá consuelo y ayuda, aunque por ello se exponga a sufrir peligro o represalias."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, dile al Maestro de Ceremonias por qué tienes una Deuda con esa persona."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Si fallas la tirada, dile al Maestro de Ceremonias por qué te quiere muerto."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vet_02, USAttributes.None)
		{
			Title = "Auténtico artista",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando crees algo para alguien con tu taller, márcate su Facción."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vet_03, USAttributes.None)
		{
			Title = "Invertir",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando alguien tenga 2 o más Deudas contigo y le eches una mano o le fastidies, tira con Mente en vez de Facción."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vet_04, USAttributes.None)
		{
			Title = "¡Ya estoy viejo para estas mierdas!",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando te veas en medio de una pelea que hayas tratado de impedir, obtienes armadura+1 y +1 a todas las tiradas destinadas a poneros a salvo a los demás y a ti."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vet_05, USAttributes.Mind)
		{
			Title = "El plan perfecto",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando traces un plan con alguien, tira con Mente." +
							"Mientras el plan se lleva a cabo, puedes gastar los puntos, uno por opción.",
				Options = new List<string>
					{
						"Sumarle 1 a la tirada de alguien (elige esta opción después de esa tirada)",
						"Descartar todo el daño que alguien sufra de un único ataque.",
						"Garantizar que los tuyos tengan a mano exactamente el equipo que necesitan."
					}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, obtienes 2 puntos."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = " Con un +10, obtienes 3 puntos.",
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas la tirada, obtienes 1 punto, pero tu plan se desmorona en el peor momento."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vet_06, USAttributes.Mind)
		{
			Title = "Sacar la pistola en una pelea de navajas",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando lances un ataque con el que agraves seriamente el conflicto, tira con Mente en vez de Sangre."
			}
		});

		return result;
	}
	private List<USMove> GenerateWolfMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Wolf_01, USAttributes.Blood)
		{
			Title = "Reconocer el terreno",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Si al principio de la sesión estás patrullando activamente tu territorio, tira con Sangre. Si no estás patrullando asume que has sacado 6-"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7 - 9, uno de tus problemas(a tu elección) aflora, pero la situación está estable en su mayoría. "
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10 +, tu territorio está seguro y los problemas son mínimos; obtienes + 1 a todas las tiradas para echarte a la calle en tu territorio."
			},
			ConsequencesOn6 = new Consequences { MainText = "la cosa se pone fea y tus problemas se desbocan." }
		});
		result.Add(new USMove(USMoveIDs.A_Wolf_02, USAttributes.Blood)
		{
			Title = "Sabueso",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando vayas a la caza de alguien,  tira con Sangre."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Si superas la tirada, sabes exactamente dónde encontrarlo y puedes seguir su olor hasta dar con él. "
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, obtienes +1 a la siguiente tirada contra él."
			},
			ConsequencesOn6 = new Consequences { MainText= " algo desagradable te encuentra a ti primero." }
		});
		result.Add(new USMove(USMoveIDs.A_Wolf_03, USAttributes.None)
		{
			Title = "Regeneración",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando liberes tu poder, añade esta opción a la lista:",
				Options = new List<string>
					{
						"Se te cierran las heridas; cúrate 1-daño."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Wolf_04, USAttributes.Heart)
		{
			Title = "Lobo alfa",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando convenzas a un personaje no jugador en tu territorio, tira con Sangre en vez de Corazón."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Wolf_05, USAttributes.Soul)
		{
			Title = "Desde el borde del abismo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Puedes abandonar tu forma lupina a voluntad. Cuando lo hagas, tira con Espíritu. Si fallas la tirada, te transformas, pero la transformación es incompleta, lenta o dolorosa. Si superas la tirada, vuelves a tu forma original."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, sufres 1-daño o te marcas corrupción."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Wolf_06, USAttributes.None)
		{
			Title = "Temerario",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = " Si te tiras de cabeza al peligro sin cubrirte las espaldas,  obtienes armadura+1. Si estás liderando a un grupo, este también obtiene armadura+1."
			}
		});

		return result;
	}
	private List<USMove> GenerateVampireMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Vamp_01, USAttributes.Blood)
		{
			Title = "Hambre eterna",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Ansías sangre, emociones o carne humanas, elige una. Cuando te alimentes, tira con Sangre."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "elige 2"
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "elige 3",
				Options = new List<string>
					{
						"Te curas 1-daño.",
						"Descubres un secreto sobre tu presa.",
						"Tu víctima no muere."
					}
			},
			ConsequencesOn6 = new Consequences
			{
				MainText= "Si fallas tu hambre se apodera de tí y todo el mundo sufre."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vamp_02, USAttributes.Status)
		{
			Title = "Siempre bienvenido",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando intentas colarte en un lugar restringido manipulando a un subordinado o guardia, tira con tu Estatus dentro de su Círculo."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText= "Con un éxito, te abren el paso a pesar de sus dudas."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText= "Además, prometen intentar mantener tu nombre fuera de cualquier problema que surja."
			},
			ConsequencesOn6 = new Consequences
			{
				MainText= "Si fallas, se mantienen firmes... pero, sin querer, te dan la oportunidad de acceder por la fuerza."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vamp_04, USAttributes.None)
		{
			Title = "Sangre fría",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando *mantienes la calma** desafiando las convenciones sociales y las expectativas de los mortales, tira con Sangre en vez de Espíritu."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vamp_05, USAttributes.None)
		{
			Title = "Mantener cerca a tus amigos",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando *cales a alguien** mientras les ayudas a satisfacer sus vicios, obtén un 12+ sin tirar. Si son de tu círculo, además, obtén un +1 constante cuando actúes basándote en sus respuestas."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vamp_06, USAttributes.None)
		{
			Title = "Es mi barrio",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando te *echas a la calla** tras alguien que te debe una Deuda, puedes cobrar la Deuda antes de tirar para sumar +3 a tu tirada.\r\nSi tienes éxito, también los encuentras en una situación comprometida o vulnerable; obtienes +1 continuo contra ellos durante la escena."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Vamp_07, USAttributes.None)
		{
			Title = "Aterrador",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "+1 en Sangre (Max +3)"
			}
		});

		return result;
	}
	private List<USMove> GenerateMageMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Mage_01, USAttributes.Soul)
		{
			Title = "Canalizar",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando canalices y reúnas tu magia, tira con Espíritu.",
				
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Obtienes 1 punto, pero no puedes volver a canalizar en esta escena."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Obtienes 3 puntos"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Obtienes 3 puntos y eliges 1 opción de la lista que aparece a continuación",
				Options = new List<string>
					{
						"Obtienes –1 a todas las tiradas hasta que descanses.",
						"Sufres 1-daño (perforante)",
						"Te marcas corrupción."
					}
			},
			ClosingText = "Los puntos te durarán hasta que los gastes. Puedes gastarlos para lanzar cualquier hechizo que tengas según se indique en su descripción."
		});
		result.Add(new USMove(USMoveIDs.A_Mage_02, USAttributes.Soul)
		{
			Title = "Sanctasanctórum",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando vayas a tu santuario a por un ingrediente para un hechizo, una reliquia o un libro, tira con Espíritu.",
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas, no tienes lo que estás buscando, pero conoces a alguien que probablemente sí lo tenga."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Tienes algo que vale para lo que necesitas."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Tienes algo que se le acerca, pero le falta o le falla algo importante",
				Options = new List<string>
					{
						"Obtienes –1 a todas las tiradas hasta que descanses.",
						"Sufres 1-daño (perforante)",
						"Te marcas corrupción."
					}
			},
		});

		result.Add(new USMove(USMoveIDs.A_Mage_04, USAttributes.None)
		{
			Title = "HECHIZO: Rastrear",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para descubrir dónde se encuentra alguien.Tienes que tener un objeto personal que pertenezca al objetivo o residuos corporales recientes(un mechón de pelo, trozos de uñas cortadas, sangre, etcétera).",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_05, USAttributes.None)
		{
			Title = "HECHIZO: Elementalismo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Invocas los elementos para golpear a tus enemigos. Gasta 1 punto para lanzar un ataque usando tu magia como arma(3 - daño, cerca o 2 - daño, cerca, área).",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_06, USAttributes.None)
		{
			Title = "HECHIZO: Borrar la memoria",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para hacer que un objetivo indefenso olvide hasta una hora de su memoria reciente.Puedes gastar un punto más y marcarte corrupción para colocar recuerdos alternativos en su lugar.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_07, USAttributes.None)
		{
			Title = "HECHIZO: Escudo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para obtener armadura+1 o dársela a alguien cercano, o gasta 2 puntos para proporcionar armadura+1 a todas las personas que haya en una zona pequeña, entre las que puedes estar incluido.Esta armadura dura hasta el final de la escena.Puedes apilar varios usos de Escudo a la vez.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_08, USAttributes.None)
		{
			Title = "HECHIZO: Manto de oscuridad",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para hacerte invisible durante unos momentos.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_09, USAttributes.None)
		{
			Title = "HECHIZO: Teletransporte",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para teletransportarte una corta distancia dentro de la escena en la que te encuentras.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_10, USAttributes.None)
		{
			Title = "HECHIZO: Maleficio",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 punto para hacerle 1 - daño(perforante) a alguien a cualquier distancia.Para ello necesitas una muestra de su pelo, sangre o saliva.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Mage_11, USAttributes.None)
		{
			Title = "HECHIZO: Baratija",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 para producir un objeto pequeño y mundano que se adapte perfectamente a tus necesidades: una llave para una sola puerta, una bala para un arma, etc"
			}
		});

		return result;
	}
	private List<USMove> GenerateOracleMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Orac_01, USAttributes.Soul)
		{
			Title = "Predicciones",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Al inicio de cada sesión, tira con Espíritu. Con un 10+, obtienes 2 puntos. Con un 7-9, obtienes 1 punto. Durante la sesión, puedes gastar cada uno de esos puntos para declarar que algo terrible está a punto de pasar. Tus aliados y tú obtenéis un +1 a todas las tiradas destinadas a evitar el inminente desastre. Si fallas la tirada, ves la muerte de alguien importante para ti y obtienes un –1 a todas las tiradas destinadas a impedirlo.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Orac_02, USAttributes.Soul)
		{
			Title = "Psicometría",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Siempre que examines y analices un objeto interesante, tira con Espíritu.",
				Options = new List<string>
					{
						"¿Cuál es la historia de este objeto?",
						"¿Qué maldiciones, protecciones o límites tiene este objeto?",
						"¿Cuál es el lugar de este objeto?",
						"¿Qué secretos o misterios ha presenciado este objeto?",
						"¿Qué emociones fuertes han estado cerca de este objeto últimamente?"
					}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, haz 3 preguntas."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7-9, haz 1 pregunta"
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas, la emoción que hay en el objeto te abruma y obtienes –1 a todas las tiradas durante esa escena."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Orac_03, USAttributes.None)
		{
			Title = "Doble vida",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Toma Mortalidad como segunda Facción. Cuando alguien tire con tu Facción o se la marque,  dile cuál de las dos que tienes es más adecuada.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Orac_04, USAttributes.None)
		{
			Title = "Médium",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Avanza liberar tu poder para todos los personajes que haya en tu presencia, incluido tú mismo.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Orac_05, USAttributes.None)
		{
			Title = "Cueste lo que cueste",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando interfieras en los planes o acciones de alguien para impedir que una de tus visiones se cumpla, márcate su Facción y obtendrás +1 a la siguiente tirada.",
			}
		});
		result.Add(new USMove(USMoveIDs.A_Orac_06, USAttributes.Soul)
		{
			Title = "Rozar la superficie",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando toques a alguien, puedes leer sus pensamientos superficiales. Tira con Espíritu.",
				Options = new List<string>
					{
						"¿Qué está pensando tu personaje ahora mismo ?",
						"¿A quién estás protegiendo?",
						"¿Por qué guardas secretos?",
						"¿Qué dolor oculta tu personaje?"
					}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10 +, haz 3 preguntas"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un 7 - 9, haz 1 pregunta"
			},
			ConsequencesOn6= new Consequences
			{
				MainText = "Si fallas, haces 1 - daño(perforante) a la otra persona y a ti mismo."
			}
		});

		return result;
	}
	private List<USMove> GenerateCorruptedMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Corrup_01, USAttributes.Blood)
		{
			Title = "El demonio interior",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando adoptes tu forma demoníaca, tira con Sangre.",
				Options = new List<string>
					{
						"Obtienes armadura+1.",
						"Te curas 2-daño.",
						"Infliges +1 daño.",
						"+arma demoníaca (3-daño, toque; o 2-daño, cerca).",
						"+desplazamiento demoníaco (vuelo, moto llameante, etcétera)."
					}
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas la tirada, elige 1 opción y contraes una Deuda con tu jefe."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Elige 2 opciones"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Elige 1 opción"
			},
			ClosingText = "Si estás haciendo un trabajo para tu jefe, elige 1 opción más. Si te marcas corrupción, elige 1 opción más."
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_02, USAttributes.None)
		{
			Title = "Invocación",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Puedes cobrarte una Deuda que alguien tenga contigo para aparecer en su presencia. Los demás también pueden cobrarse una Deuda que tengas con ellos para hacerte aparecer donde estén."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_03, USAttributes.Blood)
		{
			Title = "Lengua de plata",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando *leas a alguien** a alguien, a base de tentarlos con poder, tira con Corazón en vez de Mente."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_04, USAttributes.Soul)
		{
			Title = "Zarcillos en la oscuridad",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando busques la orientación de tu jefe mediante rituales y presagios, tira con Espíritu. " +
				"Si superas la tirada, se muestran señales ante ti: si sigues la senda marcada, obtienes un +1 a la siguiente. " +
				"Con un 7-9, acabas aún más involucrado en el servicio a tu jefe; para poder seguir tu camino tendrás que mantener la calma. " +
				"Si fallas la tirada, tu jefe tiene trabajo para ti ahora mismo; adopta tu forma demoníaca y ponte manos a la obra o sufrirás 2-daño (perforante)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_05, USAttributes.None)
		{
			Title = "Frío como el hielo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Súmate 1 a Sangre (máximo +3)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_06, USAttributes.None)
		{
			Title = "Duro como el acero",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Obtienes 1-armadura. Las fuentes de daño benditas o sagradas ignoran tu armadura. Las armas diseñadas para aturdir o incapacitar no te afectan"
			}
		});
		result.Add(new USMove(USMoveIDs.A_Corrup_07, USAttributes.None)
		{
			Title = "Trabajo demoniaco",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando termines un trabajo para tu jefe, márcate Velo. Tu jefe contrae una Deuda contigo por\r\ncada trabajo que termines."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Puedes cobrarte una Deuda de tu jefe, como a cualquier otro personaje no jugador, para que:",
				Options = new List<string>
					{
						"Responda con sinceridad a una pregunta sobre su Facción.",
						"Te presente a un miembro poderoso de su Facción.",
						"Te haga un regalo valioso y útil.",
						"Cancele una Deuda de la que sea acreedor.",
						"Te transfiera a ti el derecho a cobrarle una Deuda a otra persona.",
						"Te dé un +3 para Convencerlo (esta opción ha de elegirse antes de tirar)."
					}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Puede que tu jefe te ofrezca una oportunidad de comprar tu libertad, pero las Deudas solas\r\nno bastarán."
			}
		});
		return result;
	}
	private List<USMove> GenerateFairyMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Fai_01, USAttributes.None)
		{
			Title = "Magia feérica",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Elije 3 poderes (movimientos PODER). Siempre que uses un poder feérico, elige 1 opción:",
				Options = new List<string>
					{
						"Márcate corrupción.",
						"Contraes una Deuda con tu monarca.",
						"Sufres 1-daño (perforante)."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_02, USAttributes.None)
		{
			Title = "Un plato que se sirve ahora",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando jures vengar a alguien (incluido tú mismo), obtienes +1 a todas las tiradas contra el objetivo de esa venganza. Por cada escena en la que no persigas tu venganza, sufrirás 1-daño (perforante)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_03, USAttributes.Blood)
		{
			Title = "Lo llevamos en la sangre",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando engañes a alguien, tira con Corazón en vez de Mente."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_04, USAttributes.None)
		{
			Title = "La balanza de la Justicia",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Puedes cobrarle una Deuda a alguien para usar un poder de Magia feérica (incluidos poderes que normalmente no podrías usar) sobre esa persona sin coste."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_05, USAttributes.None)
		{
			Title = "Descorrer el Velo",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando escapes, añade esta opción a la lista:",
				Options = new List<string>
					{
						"Escapas a tu tierra natal, para bien o para mal."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_07, USAttributes.None)
		{
			Title = "Las palabras se las lleva el viento",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando alguien rompa una promesa que te haya hecho o te mienta y lo descubras, contrae una Deuda contigo y obtienes +1 a la siguiente tirada contra él."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_08, USAttributes.None)
		{
			Title = "PODER: Furia salvaje",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Invocas un elemento de la naturaleza con el que puedes golpear a tus enemigos (2-daño, cerca, área; o 3-daño cerca/lejos)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_09, USAttributes.None)
		{
			Title = "PODER: La caricia de la Naturaleza",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "El contacto contigo cura 2-daño. No puedes usar este poder en ti mismo."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_10, USAttributes.None)
		{
			Title = "PODER: Marchitar",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Haces que el contacto contigo resulte mortífero (3-daño, íntimo, perforante)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_11, USAttributes.None)
		{
			Title = "PODER: Glamour",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Creas ilusiones para engañar los sentidos. Los efectos no duran mucho."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_12, USAttributes.None)
		{
			Title = "PODER: Cambio de forma",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Puedes tomar forma de animal brevemente."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Fai_13, USAttributes.None)
		{
			Title = "PODER: Confusión",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Toca a un objetivo para sumirlo en un estado emocional concreto (a tu elección). Puedes marcarte corrupción para elegir hacia quién está dirigida esa emoción."
			}
		});

		return result;
	}
	private List<USMove> GenerateSpectreMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Spe_01, USAttributes.None)
		{
			Title = "Manifestarse",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "La gente normal no puede percibirte ni interactuar contigo a menos que te manifiestes. Para manifestarte, dedica un momento a concentrarte con tranquilidad y elige 2:",
				Options = new List<string>
					{
						"Eres audible.",
						"Eres visible.",
						"Eres tangible para el mundo físico y este es tangible para ti."
					}
			},
			ClosingText = "Puedes marcarte corrupción para elegir solo 1 opción o las 3."
			
		});
		result.Add(new USMove(USMoveIDs.A_Spe_02, USAttributes.None)
		{
			Title = "No toleraré que me ignores",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Cuando fastidies a alguien (ayudar o *interferir**), no tires y considera que has sacado un 10+. \n\nSi *Confundes, distraes, esgañas** a un a alguien con una demonstración obviamente sobrenatural, tira con Espíritu en vez de Mente."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Spe_03, USAttributes.None)
		{
			Title = "Ciudad fantasma",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Cuando te *eches a la calle** en busca de fantasmas, obtendrás un +1 a todas las tiradas para tratar con ellos. Con un fallo aún encuentras a un fantasma que tiene lo que necesitas, pero están perdidos o son peligrosos: tu eliges."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Spe_04, USAttributes.None)
		{
			Title = "Potente",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Obtienes +1 a Espíritu (máximo +3)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Spe_05, USAttributes.None)
		{
			Title = "Muro? qué muro?",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Siempre tienes una oportunidad para *escapar de una situación**. Puedes elegir una opción más de la lista para llevarte a alguien contigo. Si fallas, tu y quien estubiera contigo, acabais atrapados en el peligroso espacio entre los mundos de lo vivo y lo muerto."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Spe_06, USAttributes.None)
		{
			Title = "Catalizador",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Avanaza *dejarlo salir** para todos los PJs en tu presencia, incluido tu mismo"
			}
		});

		return result;
	}
	private List<USMove> GenerateSwornMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Swo_01, USAttributes.Mind)
		{
			Title = "Proteger y servir",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando leas una situación cargada, tira con Mente. Con un éxito, haz preguntas al MC; toma +1 cuando actúes según las respuestas",
				Options = new List<string>
					{
						"¿cuál es mi ruta de escape / entrada / salida?",
						"¿qué enemigo es más vulnerable a mí?",
						"¿qué debo vigilar?",
						"¿Cuál es la verdadera posición de mi enemigo?",
						"¿en quién no puedo confiar?",

					}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con 7-9, pregunta 1."
			},
			ConsequencesOn10 = new Consequences { MainText = "Con un 10+, pregunta 2." },
			ConsequencesOn6 = new Consequences { MainText = "Con un fallo, reconoces una debilidad en tu propia posición o preparativos que deberías haber visto venir." }
		});
		result.Add(new USMove(USMoveIDs.A_Swo_02, USAttributes.Mind)
		{
			Title = "Difícil de esquivar",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando sigues a un PNJ por las calles de la ciudad, tira con Mente. Si aciertas, a donde ellos vayan, tú los sigues."
			},
			ConsequencesOn79 = new Consequences { MainText = "Con un 7-9, te encuentras con algún problema por el camino; resuélvelo rápidamente o pierde el rastro" },
			ConsequencesOn6 = new Consequences { MainText = "Con un fallo, tu presa te lleva exactamente donde quiere; prepárate para las fauces cerradas de la trampa." }
		});
		result.Add(new USMove(USMoveIDs.A_Swo_03, USAttributes.None)
		{
			Title = "Enrevesado",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Coge +1 Mente (máx+3)."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Swo_04, USAttributes.None)
		{
			Title = "Aunténtico policía",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Pongas cara a un nombre** o *estudies un santuario**, punto de reunión o lugar de poder, tira con Mente en lugar de con el Círculo correspondiente. Siempre puedes hacer una pregunta adicional al MC sobre la persona o lugar en cuestión, incluso si fallas."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Swo_05, USAttributes.None)
		{
			Title = "Ajedrez, no damas",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando recurras a la violencia con cualquier tipo de ventaja seria -números, posición, sorpresa, etc.- y consigas un éxito, dile a tu oponente qué opción no puede elegir de su lista antes de que elija."
			}
		});

		return result;
	}
	private List<USMove> GenerateImpMovements()
	{
		var result = new List<USMove>();

		result.Add(new USMove(USMoveIDs.A_Imp_01, USAttributes.Mind)
		{
			Title = "Como de costumbre",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando pase el tiempo -o al principio de la partida- tira con Mente. Con un acierto, tus operaciones habituales generan un nuevo plan o proporcionan una oportunidad para avanzar en uno de tus planes existentes, tú eliges.",
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+, también eliges 1:",
				Options = new List<string>
					{
						"Un cliente leal revela los secretos de un poderoso PNJ, a tu elección.",
						"Un PNJ que te debe una deuda aparece para cumplir con su obligación.",
						"Un PNJ de estatus 3 de tu círculo te ofrece una deuda por tus servicios.",
					}
			},
			ConsequencesOn6 = new Consequences { MainText = "Si fallas, un familiar o amigo íntimo te arrastra a un plan que preferirías haber evitado; genera un nuevo plan con tres complicaciones y el MC te dirá qué terrible destino le espera a tu aliado si no cumples." }
		});
		result.Add(new USMove(USMoveIDs.A_Imp_02, USAttributes.None)
		{
			Title = "Mide tu marca",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Calas a alguien**, añade estas opciones a tu lista.\r\nSi fallas, pregunta 1 de esta lista, pero parecerás sospechoso o sórdido, tú eliges.",
				Options = new List<string>
				{
					"Que necesidad urgente tienes que yo podría resolver",
					"Que es lo más valioso que podrías venderme"
				}
			}
		});
		result.Add(new USMove(USMoveIDs.A_Imp_04, USAttributes.None)
		{
			Title = "Amigos en los bajos fondos",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando consigas un éxito al *poner cara a un nombre** con un PNJ de estatus 3, nombra también a un subordinado o ayudante de bajo nivel que trabaje para él y describe cómo este subordinado ha llegado recientemente a contraer una deuda contigo."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Imp_05, USAttributes.None)
		{
			Title = "Soy un puto demonio",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Ignora todo el daño la primera vez que alguien te inflija al menos 2 de daño en una escena. Al final de cada escena, borra tu casilla de Daño leve."
			}
		});
		result.Add(new USMove(USMoveIDs.A_Imp_06, USAttributes.None)
		{
			Title = "Palabras de comadreja",
			TypeOfMovement = MovementTypes.ArchetipeMovement,
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando te *niegues a pagar una Deuda** hablando rápido y liando a tu enemigo, tira con Mente en lugar de con la diferencia de Estatus. Si aciertas -además de los efectos normales- marca el Círculo de tu deudor como si hubieras cumplido la Deuda."
			}
		});

		return result;
	}


	private List<USMove> GenerateHunterCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Hun_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Divide y venceré",
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando entres solo en una situación peligrosa, marca corrupción para adelantar todos tus movimientos y lleva +1 a Sangre por la escena.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Hun_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Difícil de matar",
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para ganar armadura+1 hasta el final de la escena.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Hun_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Esperando ayuda",
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para que un equipo de apoyo de cazadores mortales llegue a la escena (3-daño pequeño 1-armadura entrenados) Marca una segunda corrupción para que aparezcan en una posición superior.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Hun_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Impulso suicida",
			IsSelected = false,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Si hay alguien cerca de ti a punto de sufrir daño, puedes marcarte corrupción para sufrirlo tú en su lugar.",
			}
		});
		return result;
	}
	private List<USMove> GenerateAwakenCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Awa_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Metido hasta el cuello",
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para *interferir** en el camino de alguien de otro Círculo como si hubieras sacado un 10+.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Awa_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Si no puedes con ellos…",
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Coge una habilidad (Liberar tu poder) de un arquetipo de otro Círculo. Siempre que la sueltes y saques un 12+, marca una corrupción adicional.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Awa_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Libre como el viento",
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para negarte a pagarle una Deuda a alguien que no sea mortal como si hubieras sacado un 12+.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Awa_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Manos largas",
			IsSelected = false,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción después de reunirte con un PNJ poderoso para revelar que le has quitado algo importante. Marca corrupción de nuevo para ocultar tu papel en el robo durante algún tiempo.",
			}
		});
		return result;
	}
	private List<USMove> GenerateVeteranCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Vet_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "De vuelta a las andadas",
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Coge dos habilidades de 'Liberar tu poder' de otro arquetipo. Cuando uses estas habilidades no puedes elegir no marcar corrupción (con 10+)",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vet_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Síndrome de Diógenes",
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para buscar entre tus cosas y encontrar justo lo que necesitas para lidiar con la situación en la que te encuentras.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vet_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "¿Os pillo en mal momento, cabrones?",
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para entrar en escena. Puedes marcártela una vez más para traerte a alguien contigo.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vet_04, USAttributes.Mind)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Horribles experimentos",
			IsSelected = false,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando trabajas en tu taller con alguien (vivo o muerto) marca corrupción para hacer hasta dos preguntas sobre sus secretos o debilidades. Deben responder honestamente.",
			}
		});
		return result;
	}
	private List<USMove> GenerateSpectreCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Spe_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Posesión",
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para poseer mentalmente a una persona débil (a discreción del MC) en tu presencia; borra un trauma por cada experiencia humana \"normal\" -comer una comida, comprar ropa, etc.- que realices mientras controlas su cuerpo.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Spe_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Telequinesia",
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Puedes mover y levantar objetos pequeños a distancia si te concentras. Puedes marcarte corrupción para mover objetos mayores, pero de un tamaño no superior al de un coche.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Spe_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Pesadilla",
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Márcate corrupción para meterte en los sueños de alguien que esté durmiendo en tu presencia. Mientras estés allí, puedes interactuar con esa persona y con sus sueños como si se tratasen de espíritus.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Spe_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Sifón",
			IsSelected = false,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Márcate corrupción para introducirte en el cuerpo de alguien, hacerle 2-daño (perforante) y curar 1-daño de tu corpus.",
			}
		});
		return result;
	}
	private List<USMove> GenerateWolfCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Wolf_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Uno con la bestia",
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción cuando te transformes para seleccionar dos cualidades adicionales o eliminar dos debilidades existentes de su Transformación. Marca una segunda corrupción para hacer ambas cosas.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Wolf_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "La fuerza de la naturaleza",
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Obtienes +1 Sangre (máx. +4). Cada vez que tiras con Sangre y obtienes un 12+, marca corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Wolf_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Sabueso callejero",
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para transformarte en un coyote o un perro. Mientras estás en esta forma, puedes tirar con ESPÍRITU en lugar de mente para *Calar a alguien** o *Confundir, distraerlo y engañarlo.**",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Wolf_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Territorio conocido",
			IsSelected = false,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para ubicar la fuente del mayor peligro para ti o alguien que selecciones dentro de tu territorio o centro de la ciudad, incluso si la amenaza se ha ocultado con magia o mentiras.",
			}
		});
		return result;
	}
	private List<USMove> GenerateVampireCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Vamp_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Auténtico cazador",
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando estés persiguiendo a un PNJ humano por la noche, márcate corrupción. Tu presa no podrá escapar de ti, huya adonde huya, y podrás alimentarte de él o matarlo a voluntad.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vamp_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Mantenlos dentro",
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando cobres la última Deuda de alguien de tu Web, marca corrupción para conservar la Deuda y mantenerlos en tu Red.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vamp_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Fake news",
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando *debilitas la posición de alguien** (Fase de facciones) mediante rumores falsos, marca corrupción para tirar con Corazón en lugar de Estatus.",
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas, marca corrupción para que el rastro conduzca a un aliado, no a ti."
			}
		});
		result.Add(new USMove(USMoveIDs.C_Vamp_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Magia de sangre",
			IsSelected = false,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Elige 2 Poderes de Hada; marca corrupción para usar uno sin coste adicional. Puedes realizar este avance de corrupción una segunda vez para obtener los Poderes de Hada restantes.",
			}
		});
		return result;
	}
	private List<USMove> GenerateMageCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Mage_01, USAttributes.None)
		{
			Title = "Las Artes Oscuras",
			TypeOfMovement = MovementTypes.CorruptionMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando recurras a la violencia con energías mágicas o psíquicas, marca corrupción para tirar con Espíritu en lugar de Sangre.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Mage_02, USAttributes.None)
		{
			Title = "Sobre un caballo pálido",
			TypeOfMovement = MovementTypes.CorruptionMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción, 1 por 1, y pronuncia el verdadero nombre de un personaje en la escena para infligir hasta 3 daños (ap) en ellos; solo puedes apuntar a un personaje con este poder una vez por sesión.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Mage_03, USAttributes.None)
		{
			Title = "Magia negra",
			TypeOfMovement = MovementTypes.CorruptionMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para ignorar un requisito que te haya puesto el Maestro de Ceremonias al usar tu santuario.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Mage_04, USAttributes.None)
		{
			Title = "Protección",
			TypeOfMovement = MovementTypes.CorruptionMovement,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para crear una protección mágica del tamaño de una habitación pequeña. La protección dura un mes y un día o hasta que la liberes.",
			}
		});
		return result;
	}
	private List<USMove> GenerateOracleCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Orac_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Émpata",
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando *cales a alguien, Roces la superficie o utilices Psicometría**, puedes marcarte corrupción para hacer las preguntas que quieras, no solo las de las listas.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Orac_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "El ojo que todo lo ve",
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción y sufrir 1-daño (perforante) para tener una visión sobre la situación en la que te encuentras. Hazle una pregunta al Maestro de Ceremonias; la contestará con honestidad.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Orac_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Oscuro destino",
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para maldecir a una facción de la ciudad con una suerte terrible; tendrán -1 en curso en el siguiente turno de facción. Marca corrupción de nuevo para ocultar tu papel o asegurarte de que la maldición dure mucho tiempo.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Orac_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Mirada penetrante",
			IsSelected = false,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para clavar los ojos en alguien y obligarle a quedarse quieto mientras mantengas la mirada. Vuelve a marcar Corrupción para hacerles olvidar la experiencia.",
			}
		});
		return result;
	}
	private List<USMove> GenerateCorrupteCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Corrupt_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Beneficios adicionales",
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para hacer un movimiento de ciudad adicional cuando pasa el tiempo; si usas tu Estatus de Círculo para el movimiento, añade +1 a tu tirada.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Corrupt_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Justo bajo la superficie",
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Puedes marcarte corrupción para adoptar tu forma demoníaca sin tirar y con todas las opciones de la lista.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Corrupt_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Innegable",
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando alguien se niegue a pagarte una Deuda, puedes marcarte corrupción para convertir su resultado en un fallo (tras su tirada).",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Corrupt_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Desde el Infierno",
			IsSelected = false,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Márcate corrupción para hacer que tu jefe mande una cuadrilla de demonios a trabajar para ti durante una escena (2-daño, grupo pequeño, 2-armadura, demoníacos).",
			}
		});
		return result;
	}
	private List<USMove> GeneratefairyCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Fai_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Aire y oscuridad",
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Obtienes los poderes feéricos restantes. Cuando uses Magia feérica, dejas de poder elegir sufrir daño.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Fai_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Negociador astuto",
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando te niegas a cumplir una Deuda, puedes marcar corrupción para sacar un 12+ en vez de tirar.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Fai_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Gracia supranatural",
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Obtienes +1 a Corazón (máximo +4). Siempre que tires con Corazón y saques un 12+, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Fai_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Todos tenemos una",
			IsSelected = false,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Toca a alguien y marca corrupción para maldecirlo con una vulnerabilidad elemental. Todo el daño de una fuente que selecciones (fuego, acero, hierro, etc.) se trata como +1 daño y ap.",
			}
		});
		return result;
	}
	private List<USMove> GenerateImpCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Imp_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Así es como gano yo",
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Haces correr la voz** en tu Círculo de que necesitas algo (mov. de facción), marca corrupción para sacar un 12+ en lugar de tirar los dados. Marca corrupción para dar al vendedor una Deuda en lugar del precio que te pidan cuando llegue el objeto.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Imp_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Dinero sucio",
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando *Finalizas un chanchullo**, marca corrupción para recibir las cuatro bendiciones en lugar de sólo dos.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Imp_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Endulza el trato",
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando *persuades a un PNJ** ofreciéndole una bonificación adicional o un soborno atractivo, marca corrupción para sacar un 12+ en lugar de tirar el dado.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Imp_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "En la lista negra",
			IsSelected = false,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para declarar a alguien enemigo de tu pueblo; otros de los tuyos lo manipularán, antagonizarán o algo peor. Hasta que digas lo contrario, avanza *Confundir, distraer o engañar** para cualquiera que se dirija a ellos; también reciben -1 en curso durante cada turno de facción.",
			}
		});
		return result;
	}
	private List<USMove> GenerateSwornCorruptionMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.C_Swo_01, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Un paso por delante",
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Obtienes +1 Mente (máx+4). Siempre que tires con Mente y saques un 12+, marca corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Swo_02, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Mis pajaritos",
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Marca corrupción para tirar con Mente en vez de Estatus cuando consultes a tus contactos en otro Círculo (Fase de facciones).",
			},
			ConsequencesOn6 = new Consequences { MainText = "Si fallas, marca corrupción de nuevo y elige entre responder a la pregunta difícil de tu contacto o deberle una Deuda." }
		});
		result.Add(new USMove(USMoveIDs.C_Swo_03, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Estudiante de las Artes Arcanas",
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Elige tres Hechizos. Marca corrupción para ganar dos puntos que puedes usar para lanzar esos hechizos.",
			}
		});
		result.Add(new USMove(USMoveIDs.C_Swo_04, USAttributes.None)
		{
			TypeOfMovement = MovementTypes.CorruptionMovement,
			Title = "Asuntos Infernales",
			IsSelected = false,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando pases a la violencia, puedes marcar corrupción para sacar un 12+ en vez de tirar.",
			}
		});
		return result;
	}


	private List<USMove> GenerateHunterDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Hun_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando hieras a un mortal durante tu persecución de lo sobrenatural, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Hun_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, hazle\r\nuna pregunta; tendrá que contestarla con honestidad. Luego te hará una pregunta a ti; contéstala\r\ncon honestidad o márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Hun_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Hunter,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje, elije a un personaje de otro jugador y dale uno de los\r\nmovimientos de Cazador que tengas. Se lo puede quedar para siempre.",
			}
		});
		return result;
	}
	private List<USMove> GenerateAwakenDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Awak_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando des de lado tus responsabilidades mortales para ocuparte de lo sobrenatural, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Awak_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con alguien que no sea mortal, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Awak_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Awaken,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras, cada personaje tiene que decidir si tu muerte le inspira o corrompe una parte de su ser. Si le inspira, se borra un avance de corrupción que haya tomado (en caso de que lo haya hecho). Si le corrompe, toma un avance de corrupción inmediatamente.",
			}
		});
		return result;
	}
	private List<USMove> GenerateVeteranDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Vet_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando te lances hacia el peligro de cabeza y de manera consciente, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Vet_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, cuéntale una historia sobre el pasado y las lecciones que has aprendido.",
				Options = new List<string>
					{
						"Ambos obtenéis +1 a la siguiente.",
						"Tú obtienes +1 a la siguiente y la otra persona, –1 a la siguiente.",
						"Obtienes 1 punto. Gástalo para echarle una mano a ese personaje, por muy lejos que esté."
					}
			}
		});
		result.Add(new USMove(USMoveIDs.D_Vet_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Veteran,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje, elije a un personaje para que herede tu taller y Auténtico artista.",
			}
		});
		return result;
	}
	private List<USMove> GenerateSpectreDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Spe_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Cuando presencies una injusticia y no hagas nada,  márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Spe_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, obtendrás 1 punto. Siempre que esa persona se meta en problemas, puedes gastar uno de esos puntos para aparecer donde esté.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Spe_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Spectre,
			PreCondition = new Consequences
			{
				MainText = "Cuando rellenes todas tus casillas de daño, tu corpus quedará esparcido y disperso. Te recompondrás en unos cuantos días. Cuando tu espíritu descanse en paz de manera permanente o retires a tu personaje, todos los personajes presentes obtendrán +1 Espíritu (máximo +3).",
			}
		});
		return result;
	}
	private List<USMove> GenerateWolfDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Wolf_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando empieces una cacería en pos de alguien, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Wolf_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, crearás un vínculo primario con ella; siempre sabrás dónde encontrarla y cuándo está en problemas. Este vínculo durará hasta el final de la siguiente sesión.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Wolf_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Wolf,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje, alguien a quien quieras proteger que esté en escena escapará y se pondrá a salvo, por muy improbable que eso fuera.",
			}
		});
		return result;
	}
	private List<USMove> GenerateVampireDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Vamp_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando te alimentes de una víctima en contra de su voluntad, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Vamp_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona,  cuéntale un secreto sobre ti o contraerás una Deuda con ella. Sea como sea, esa persona entra en tu red y contrae una Deuda contigo.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Vamp_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje,  nombra a alguien que haya en escena a quien quieras muerto; tus subordinados y aliados lo perseguirán sin tregua.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Vamp_04, USAttributes.None)
		{
			Title = "Movimiento inicial",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Vampire,
			PreCondition = new Consequences
			{
				MainText = "Cuando pase el tiempo, o al comienzo del juego, elige a alguien en tu Web y descubre un secreto sobre él que preferiría mantener enterrado. Marca corrupción para hacer una pregunta de seguimiento sobre la respuesta; su jugador debe responder honestamente."
			}
		});
		return result;
	}
	private List<USMove> GenerateMageDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Mage_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando hagas un trato con alguien oscuro y poderoso, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Mage_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con alguien, decide si esa persona te importa o no. Si no te importa, sigue con su vida tal cual. Si te importa, tiene un –1 a todas las tiradas de escapar hasta que tenga un momento de intimidad con otra persona.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Mage_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras, puedes echarle una maldición devastadora a alguien que haya cerca. Especifica sus efectos y cómo puede librarse de ella.",
			}
		});
		return result;
	}
	private List<USMove> GenerateOracleDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Orac_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando le digas a alguien una profecía falsa,  márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Orac_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona,  obtendrás una visión clara y específica sobre su futuro. Puedes hacer un máximo de 3 preguntas sobre la visión; márcate corrupción por cada una que hagas.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Orac_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje,  haz una proclamación al mundo que reverberará en los sueños por todo el planeta. Detalla las señales de lo que se cierne. El Maestro de Ceremonias hará que tu profecía se cumpla más pronto que tarde.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Orac_04, USAttributes.None)
		{
			Title = "Movimiento inicial",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando pase el tiempo, o al comienzo del juego, utiliza tu movimiento *Revelaciones**",
			}
		});
		return result;
	}
	private List<USMove> GenerateCorruptedDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Corrup_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando convenzas a alguien de algo en nombre de tu jefe, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Corrup_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, te transfiere el derecho a cobrar una Deuda que otro tuviera con ella.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Corrup_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras,  cóbrate todas las Deudas que tenga contigo tu jefe para volver. Si tu jefe no está en Deuda contigo, le pedirá a otra persona que se endeude por ti. Si esa persona se niega, se acabó lo que se daba. Encantados de haberte conocido.",
			}
		});
		return result;
	}
	private List<USMove> GenerateFairyDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Fai_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando rompas una promesa o digas una mentira descarada, márcate corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Fai_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona,  pídele que te haga una promesa. Si se niega o rompe la promesa, contrae 2 Deudas contigo.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Fai_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje, elige a un personaje y concédele el favor de tu corte. Puede elegir entre tomar Magia feérica y dos de tus poderes feéricos o avanzar convencer a un personaje no jugador.",
			}
		});
		return result;
	}
	private List<USMove> GenerateSwornDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Swo_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando rompas uno de tus votos o trabajes en contra de los intereses de tus amos: marca corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Swo_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, explícales si te importa más que tu juramento. Si sí lo hace, marca corrupción y ellos obtienen un punto que pueden gastar en cualquier momento para convocarte en su ubicación.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Swo_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Sworn,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras o retires a tu personaje, ofrece tu arma a otro. Si la acepta, átalos a tres de tus juramentos. Haz que te lo juren.",
			}
		});
		return result;
	}
	private List<USMove> GenerateImpDramaticMovements()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.D_Imp_01, USAttributes.None)
		{
			Title = "Movimiento de corrupción",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando hagas un trato que ponga en peligro a tu familia, amigos o comunidad: marca corrupción.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Imp_02, USAttributes.None)
		{
			Title = "Movimiento de intimidad",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando compartas un momento de intimidad física o emocional con otra persona, prométele que le conseguirás algo que desee sin pedir nada a cabio. Dale una deuda y toma +1 en curso para conseguir lo que les has prometido.",
			}
		});
		result.Add(new USMove(USMoveIDs.D_Imp_03, USAttributes.None)
		{
			Title = "Movimiento final",
			TypeOfMovement = MovementTypes.DramaticMovement,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando mueras uno de tus planes llega a buen puerto, pero otra persona cosecha las recompensas. Elige quien se beneficiará de los planes que pusiste en marcha.",
			}
		});
		return result;
	}

	private List<USMove> GenerateCorruptedUniqueMoves()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.U_Corr_01, USAttributes.Veil)
		{
			Title = "Trabajo para mi patrón",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "Cuando completes un trabajo para tu patrón, marca *Velo**. Tu patron te debe una deuda por cada trabajo completado. Puedes cobrar una Deuda a tu patrón para que él:",
				Options = new List<string>
				{
					"Responda a una pregunta honestamente",
					"Organice un encuentro con un PNJ de Velo",
					"Te conceda una bendición o un regalo útil",
					"Borre una deuda que tengas con alguien",
					"Te conceda una deuda que él tenga"
				}
			}
		});
		result.Add(new USMove(USMoveIDs.U_Corr_02, USAttributes.None)
		{
			Title = "Amo y señor",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Corrupted,
			PreCondition = new Consequences
			{
				MainText = "En cualquier momento tu patrón puede canjear una deuda que tengas con él para infringirte corrupción (1 por 1)",
			}
		});
		return result;
	}
	private List<USMove> GenerateFaeUniqueMoves()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.U_Fae_01, USAttributes.None)
		{
			Title = "Poder: Caricia de la naturaleza",
			TypeOfMovement = MovementTypes.FaeMagic,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Tu toque cura 2-daño, empezando por el crítico; Las heridas se cierran, los huesos vuelven a unirse, etc. No puedes usar este poder contigo mismo",
			}
		});
		result.Add(new USMove(USMoveIDs.U_Fae_02, USAttributes.None)
		{
			Title = "Poder: Marchitar",
			TypeOfMovement = MovementTypes.FaeMagic,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Puedes imbuir tu toque con el poder de matar (3-daño íntimo ap). El efecto es entendido instantáneamente por el objetivo como un ataque y deja una fea marca o cicatriz en el punto de contacto.",
			}
		});
		result.Add(new USMove(USMoveIDs.U_Fae_03, USAttributes.None)
		{
			Title = "Poder: Encantamientos",
			TypeOfMovement = MovementTypes.FaeMagic,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Creas ilusiones para engañar a los sentidos. Los efectos no duran mucho, pero son convincentes. No puedes disfrazarte ni ocultar tus acciones con estos trucos.",
			}
		});
		result.Add(new USMove(USMoveIDs.U_Fae_04, USAttributes.None)
		{
			Title = "Poder: Cambio de forma",
			TypeOfMovement = MovementTypes.FaeMagic,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Puedes cambiar tu forma a la de un animal mediano durante una escena. Hasta tres personas a las que designes pueden seguir entendiendo tu discurso, pero todos los demás te perciben como si ladraras,gorjearas, etc.",
			}
		});
		result.Add(new USMove(USMoveIDs.U_Fae_05, USAttributes.None)
		{
			Title = "Poder: Bedlam",
			TypeOfMovement = MovementTypes.FaeMagic,
			IsSelected = true,
			Archetipe = US_Classes.Fair,
			PreCondition = new Consequences
			{
				MainText = "Puedes tocar a un objeto vulnerable para ponerlo en un estado emocional específico (a tu elección) durante la escena. Marca corrupción para que esa emoción se dirija a un objetivo de tu elección.",
			}
		});
		return result;
	}
	private List<USMove> GenerateImpUniqueMoves()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.U_Imp_01, USAttributes.None)
		{
			Title = "Generar un nuevo chanchullo",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando generas un chanchullo elige un círculo principal, uno de tus servicios y dos complicaciones (colabora con el MC para justificarlo)",
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Complicaciones",
				Options = new List<string>
				{
					"Has prometido a alguien involucrado algo que aún no tienes.",
					"Necesitas la ayuda de un cómplice poco fiable o de dudosa lealtad.",
					"Debes engañar o manipular a un PNJ poderoso y peligroso.",
					"Necesitas robar algo de un lugar altamente seguro.",
					"Tienes que esperar un evento o momento predeterminado.",
					"Has atraído la atención de una oposición peligrosa."
				}
			}			
		});
		result.Add(new USMove(USMoveIDs.U_Imp_02, USAttributes.None)
		{
			Title = "Finalizar un chanchullo",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Imp,
			PreCondition = new Consequences
			{
				MainText = "Cuando lleves a buen puerto un chanchullo, elige dos bonus y un pago. El MC te detallará como llegan.\nAnota los pagos conseguidos por que no se pueden repetir en toda la partida\n(Elije 2 y 1, no hay tirada)"
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "BENEFICIOS",
				Options = new List<string>
				{
					"Atraes nuevos negocios; generas un nuevo chanchullo.",
					"Reduces tus deudas; cancelas una Deuda que debes.",
					"Haces valer tu poder; tomas una Deuda sobre un PNJ.",
					"Mejoras tu reputación; marcas un Círculo afectado por el trato."
				}
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Pagos (Solo una vez cada uno)",
				Options = new List<string>
				{
					"Disponibles al inicio del juego:",
					"+1 a cualquier Círculo (máx.+3)",
					"Contratar esbirros infernales",
					"Adquirir un arsenal",
					"Adquirir un nuevo recurso",
					"Adquirir un nuevo recurso",
					"Resolver un problema\n\n",

					"Después de 4+ pagos:",
					"+1 a cualquier Círculo (máx.+3)",
					"+1 Estatus (máx.+2)",
					"Adquirir un arma legendaria",
					"Adquirir un sanctum",
					"Adquirir magia feérica",
					"Retirar tu personaje a un lugar seguro"
				}
			}
		});
		return result;
	}
	private List<USMove> GenerateOracleUniqueMoves()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.U_Ora_01, USAttributes.Status)
		{
			Title = "Necesito ayuda",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Cuando acudas a tu benefactor en busca de ayuda o recursos tira con Estatus."
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "Con un éxito te dan lo que necesitas, siempre que tengas una visión profética de un problema que tengan en este momento."
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "Con un 10+: la ayuda que te dan es excepcionalmente útil."
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Con un fallo revelan que has pasado por alto algo que perjudicó enormemente a su estatus; están decididos a recordarte su poder sobre ti antes incluso de considerar tu petición."
			}
		});
		result.Add(new USMove(USMoveIDs.U_Ora_02, USAttributes.Soul)
		{
			Title = "Revelaciones",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = true,
			Archetipe = US_Classes.Oracle,
			PreCondition = new Consequences
			{
				MainText = "Antes de cada turno de facción, o al comienzo de la partida, tira con espíritu. Si tienes éxito elige una de las opciones siguientes. Después del turno de facción el MC te dirá lo que tus herramientas proféticas han revelado",
				Options = new List<string>
				{
					"el destino te ha brindado una oportunidad de cumplir tu papel para tu benefactor, el MC te dirá como aprovecharla.",
					"un aliado ha llegado a poseer un objeto que podría revelar más sobre tu profecía; el MC te dirá donde lo guarda",
					"una tragedia ha hecho posible que escapes o alteres tu camino profético; el MC te dirá lo que debes hacer"
				}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "con un 7-9 también tienes que elegir:",
				Options = new List<string>
				{
					"una amenaza se acerca; el MC te dirá por que te acecha a tí o a tu benefactor",
					"un aliado está tramando una traición; el MC te dirá como puedes evitarla"
				}
			},
			ConsequencesOn6 = new Consequences
			{
				MainText = "Si fallas, recivirás una premonición aterradora sobre la profecía que te une a tu benefactor; toma -1 en curso a los esfuerzos que hagas para evitar que se cumpla",
			}
		});
		return result;
	}
	private List<USMove> GenerateMageUniqueMoves()
	{
		var result = new List<USMove>();
		result.Add(new USMove(USMoveIDs.U_Mage_01, USAttributes.None)
		{
			Title = "Hechizo: Rastrear",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 para conocer la ubicación de una persona específica. Debes tener un objeto personal que pertenezca  al objetivo o restos recientes de su cuerpo (un mechón de cabello, recortes de uñas, su sangre...)"
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_02, USAttributes.None)
		{
			Title = "Hechizo: Elementalismo",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Conjuras los elementos para atacar a tus enemigos. Gasta 1 para *Pasar a la violencia** con tu magia como arma (cerca 3-daño o cerca 2-daño área)"
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_03, USAttributes.None)
		{
			Title = "Hechizo: Enlace",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 para vincular telepáticamente hasta dos personajes en tu presencia durante unas horas, lo que les permite comunicarse entre sí, y contigo, independientemente de la distancia. Puedes gastar adicionalmente (1 por 1) para agregar más personajes a esta red, incluso si los otros miembros no están presentes."
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_04, USAttributes.None)
		{
			Title = "Hechizo: Blindage",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 para proporcionar armadura+1 a ti mismo o a alguien cercano o gasta 2 para proporcionar armadura+1 a todos en un área pequeña, posiblemente incluyéndote a ti mismo. Esta aramadura dura hasta el final de la escena, Puedes acomular múltiples usos de Blindaje a la vez."
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_05, USAttributes.None)
		{
			Title = "Hechizo: Velo",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Gasta 1 para volverte invisible a la vista (mundana, sobrenatural, electrónica, etc) por unos momentos."
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_06, USAttributes.None)
		{
			Title = "Hechizo: Teletransportarse",
			TypeOfMovement = MovementTypes.MageMagic,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Usa 1 para teletransportarte una distancia corta dentro de una escena en la que te encuentres."
			}
		});
		result.Add(new USMove(USMoveIDs.U_Mage_07, USAttributes.None)
		{
			Title = "Trabajar en mi sanctum",
			TypeOfMovement = MovementTypes.UniqueMove,
			IsSelected = false,
			Archetipe = US_Classes.Mage,
			PreCondition = new Consequences
			{
				MainText = "Cuando ingresas en tu santuario para trabajar en algo, el MC te dirá: 'Claro, no hay problema, pero ...' y luego de 1 a 4 de lo siguiente:",
				Options = new List<string>
				{
					"te llevará horas/días/semanas/meses de trabajo o tiempo de recuperación",
					"Primero tendrás que invocar/construir X",
					"Necesitarás los servicios de X para completarlo",
					"Requiere un ingrediente o material raro y costoso",
					"Solo funcionará durante un breve período de tiempo y es posible que no sea fiable",
					"Significará exponer a cualquier persona cercana a graves consecuencias",
					"Tu santuario carece de X, añádeselo y podrás completarlo",
					"Requerirá una parte de ti mismo o un sacrificio comparable para completarlo",
					"Debes viajar a X para completarlo"
				}
			}
		});
		return result;
	}
	private List<USMove> GenerateSwornUniqueMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.U_Swo_01, USAttributes.None)
			{
				Title = "Juramentado y corrupción",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Sworn,
				PreCondition = new Consequences
				{
					MainText = "Cuando hagas un avance de corrupción borra uno de tus votos, ya no te ata. Si eliminas todos tus votos tu juramento esta roto (cambia de libreto inmediatamente)."
				}
			},
			new USMove(USMoveIDs.U_Swo_02, USAttributes.None)
			{
				Title = "El poder de mi arma",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Sworn,
				PreCondition = new Consequences
				{
					MainText = "Mientras lleves tu arma legendaria, avanza el movimiento adecuado."
				}

			},
			new USMove(USMoveIDs.U_Swo_03, USAttributes.None)
			{
				Title = "Lo hago por ellos",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Sworn,
				PreCondition = new Consequences
				{
					MainText = "Cuando blandas tu arma al servicio de tus maestros, puedes tirar con mente en lugar de espíritu para *Mantener la calma**."
				}

			},
			new USMove(USMoveIDs.U_Swo_04, USAttributes.None)
			{
				Title = "Roto",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Sworn,
				PreCondition = new Consequences
				{
					MainText = "Tu arma, como tu juramento, está atada a tu lealtad. Si tu juramento se rompe, tu arma te abandonará llegando a traicionarte para asegurarse de escapar de tu servicio"
				}

			}
		};
	}
	private List<USMove> GenerateVampUniqueMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.U_Vamp_02, USAttributes.None)
			{
				Title = "Mi refugio mis reglas",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Vampire,
				PreCondition = new Consequences
				{
					MainText = "Cuando alguien entra voluntariamente en tu refugio, lo añades a tu red."
				}
			},
			new USMove(USMoveIDs.U_Vamp_01, USAttributes.None)
			{
				Title = "Mi red",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Vampire,
				PreCondition = new Consequences
				{
					MainText = "Cuando alguien se acerca a tí para pedirte un favor, consejo, negociar información o amenazar tus intereses, entra en tu Red y te debe una deuda... aunque no le pagues nada a cambio. La gente sale de tu Red sólo cuando ya no te debe nada. Cuando alguien está en tu red ganas lo siguiente:",
					Options = new List<string>
					{
						"+1 en curso para *Ayudar o interferir**",
						"Siempre que uses *Calar a alguien** con alguien de tu red añade la siguiente opción a la lista: cuál es la verdadera hambre de tu personaje?",
						"Gasta una deuda antes de tirar para *persuadir** para avanzar persuasión por esta tirada, y sumar +3 al total"
					}
				}
			},
			new USMove(USMoveIDs.U_Vamp_03, USAttributes.None)
			{
				Title = "Saber más",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Vampire,
				PreCondition = new Consequences
				{
					MainText = "Cuando pase el tiempo (o al principio de la partida) elige a alguien de tu red y averigua un secreto sobre él que preferiría mantener enterrado. Marca corrupción para hacer una pregunta de seguimiento sobre la respuesta; su jugador debe responderte con sinceridad."
				}
			}
		};
	}
	private List<USMove> GenerateSpecterUniqueMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.U_Spec_01, USAttributes.None)
			{
				Title = "Cuidar de ellos",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando una de tus anclas se pone en peligro, lo sabes; marca trauma y obten un +1 continuo a todos los movimientos hasta que la veas a salvo.."
				}
			},
			new USMove(USMoveIDs.U_Spec_02, USAttributes.None)
			{
				Title = "Resolver un ancla",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando resuelves un ancla, limpia todo tu trauma y borra un avance de corrupción"
				}
			},
			new USMove(USMoveIDs.U_Spec_03, USAttributes.None)
			{
				Title = "Perder un ancla",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando un ancla es destruida o arruinada, llena tu marcador de trauma y toma un avance de corrupción"
				}
			},
			new USMove(USMoveIDs.U_Spec_04, USAttributes.None)
			{
				Title = "Trauma",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Empiezas cada sesión con 2 traumas marcados. Puedes eliminar trauma mediante movimientos de trauma. Si alguna vez llenas tu marcador de trauma el MC puede pedirte que hagas un movimiento de trauma en cualquier momento, pero siempre puedes elegir qué movimiento de trauma haces en ese momento."
				}
			},
			new USMove(USMoveIDs.U_Spec_05, USAttributes.None)
			{
				Title = "Heridas",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "La primea vez que recibas daño en una escena, marca trauma. Cuando te llenes de daño, tu corpus se dispersará. Marca trauma para que se reforme en unos días en una de tus anclas, o marca 3 de trauma para que se reforme inmediatamente en un ancla a elección del MC. Si no puedes marcar trauma el MC te dice cómo/cuándo te reformas."
				}
			},
			new USMove(USMoveIDs.U_Spec_06, USAttributes.None)
			{
				Title = "Pasar al otro lado",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando tu última ancla se resuelva o se destruya, pasas a mejor vida. Elige una bendición o maldición que concedes a la ciudad por cada ancla que se haya resuelto o destruido respectivamente."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Bendiciones",
					Options = new List<string>
					{
						"Inspiras a un PNJ a perdonar a alguien que una vez le hizo daño, poniendo fin a un antiguo conflicto",
						"Limpias o restauras un lugar preciado que todos creían arruinado o irreparable.",
						"Curas o restauras a alguien a quien heriste o perjudicaste en el pasado.",
						"Revelas a un PNJ la verdad sobre tu muerte y fallecimiento"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Maldiciones",
					Options = new List<string>
					{
						"Dejas tras de ti un reflejo psíquico de tu miedo e ira, algo terrible que persigue a los mortales en la noche",
						"Imbuyes un objeto con poder de pesadilla; el MC elige quien se queda con el objeto maldito.",
						"Llevas a un PNJ cercano a ti a una espiral descendiente",
						"No falleces, sino que te traga el olvido"
					}
				}
			},
			new USMove(USMoveIDs.U_Spec_07, USAttributes.Blood)
			{
				Title = "TRAUMA: Arremeter contra un PNJ",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando arremetes contra un PNJ con furia, tira con Sangre. Con un éxito, elimina todos tus traumas e infringe el daño establecido.",
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con 6-: pierdes completamente el control de tu forma ectoplásmatica; marca corrupción."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Con 7-9: tu violencia es salvaje; te deja vulnerable, se te va de las manos o causa algún daño colateral, a elección del MC."
				}
			},
			new USMove(USMoveIDs.U_Spec_08, USAttributes.Soul)
			{
				Title = "TRAUMA: Comulgar con tus anclas",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Spectre,
				PreCondition = new Consequences
				{
					MainText = "Cuando comulgas con una de tus anclas, tira con espíritu. Con un éxito tu ancla alivia tu psique fracturada: borra 2 traumas.",
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Con 10+: tu comunión revela una forma de resolver el ancla. Elimina todo el trauma."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un 6-: sólo eliminas 1 trauma, algo que amenaza al ancla interrumpe tu meditación."
				}
			},
		};
	}
	private List<USMove> GenerateVeteranUniqueMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.U_Vet_01, USAttributes.None)
			{
				Title = "Mi taller",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Veteran,
				PreCondition = new Consequences
				{
					MainText = "Cuando ingresas en tu taller para trabajar en algo, el MC te dirá: 'Claro, no hay problema, pero ...' y luego de 1 a 4 de lo siguiente:",
					Options = new List<string>
					{
						"te llevará horas/días/semanas/meses de trabajo o tiempo de recuperación",
						"Primero tendrás que invocar/construir X",
						"Necesitarás los servicios de X para completarlo",
						"Requiere un ingrediente o material raro y costoso",
						"Solo funcionará durante un breve período de tiempo y es posible que no sea fiable",
						"Significará exponer a cualquier persona cercana a graves consecuencias",
						"Tu taller carece de X, añádeselo y podrás completarlo",
						"Requerirá una parte de ti mismo o un sacrificio comparable para completarlo",
						"Debes viajar a X para completarlo"
					}
				}
			},
			new USMove(USMoveIDs.U_Vet_02, USAttributes.None)
			{
				Title = "Mis creaciones",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Veteran,
				PreCondition = new Consequences
				{
					MainText = "Los objetos creados en tu taller están a salvo del MC. No pueden ser destruidos o tomados sin tu permiso, incluso si los vendes o regalas a otro personaje. Cuando crees algo específicamente para otro personaje, marca su Círculo cuando el proyecto esté terminado."
				}
			}
		};
	}
	private List<USMove> GenerateAwakenUniqueMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.U_Awa_01, USAttributes.None)
			{
				Title = "Se han ido",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Awaken,
				PreCondition = new Consequences
				{
					MainText = "Cuando una de tus relaciones mortales llega a su fin por cualquier motivo -te dejan, mueren, abandonan la ciudad, les dices que dejen de contactar contigo, etc.- marca inmediatamente un avance de corrupción. Si la pérdida de una relación mortal hace que retires a tu personaje debido a la corrupción, dile al MC a quién culpas más por la pérdida;\r\ntu personaje perseguirá al responsable como Amenaza hasta que se haga \"justicia\"."
				}
			},
			new USMove(USMoveIDs.U_Awa_02, USAttributes.None)
			{
				Title = "Ocuparme de ellos",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Awaken,
				PreCondition = new Consequences
				{
					MainText = "Cuando te ocupes de tus relaciones con los mortales durante el turno de facción, no hagas ningún otro movimiento de ciudad y tira con Corazón. Con un éxito, uno de los mortales más cercanos a ti te ofrece una forma de estrechar vuestros lazos; elimina un avance de corrupción si aceptas lo que te proponen."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText="Con un 7-9, aceptar no es tan sencillo; lo que te piden amenaza con exponerles a la parte de tu vida que has mantenido oculta."
				},
				ConsequencesOn6 = new Consequences{ MainText ="Con un fallo, tus intentos de arreglar las cosas llegan demasiado tarde; una de tus relaciones mortales finalmente corta lazos contigo de una forma dolorosa y pública"}
			},
			new USMove(USMoveIDs.U_Awa_03, USAttributes.Soul)
			{
				Title = "Mi kit",
				TypeOfMovement = MovementTypes.UniqueMove,
				IsSelected = true,
				Archetipe = US_Classes.Awaken,
				PreCondition = new Consequences
				{
					MainText = "Tienes algo de equipo que has ido adquiriendo desde que eres consciente del mundo sobrenatural, la mayoría guardado en el maletero de tu coche o en una bolsa que llevas contigo.\r\nCuando busques en tu kit algún equipo mundano -bengalas de carretera, botiquín de primeros auxilios, etc.- útil para la situación, tira con Espíritu.. Con un éxito, encuentras algo que te puede servir."
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="Con un 10+, es perfecto; toma +1 en curso para utilizarlo en la escena."
				},
				ConsequencesOn6 = new Consequences{ MainText ="Si fallas, la situación se agrava mientras intentas prepararte: ¡prepárate!"}
			}
		};
	}


	private List<LIO> GenerateHunterLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Hunter_01,
				Text = "Encuentra y persigue a alguien o algo por la ciudad con rastros o información limitados.",
				Archetype = US_Classes.Hunter
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Hunter_02,
				Text = "Improvisa un arma (daño2, mano, desastrosa) o (armadura-1, frágil).",
				Archetype = US_Classes.Hunter
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Hunter_03,
				Text = "Improvisa un explosivo (daño3, ruidoso, fuego) o bomba de humo (aturdidor, ruidosa, humo).",
				Archetype = US_Classes.Hunter
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Hunter_04,
				Text = "Forzar a un enemigo vulnerable a huir de tu\r\npresencia y entregar un mensaje.",
				Archetype = US_Classes.Hunter
			}
		};
	}
	private List<LIO> GenerateAwakenLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Awa_01,
				Text = "Consigue acceso a una zona asegurada o bloqueada.",
				Archetype = US_Classes.Awaken
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Awa_02,
				Text = "Atrae atención inmediata de los mortales sobre una persona o situación.",
				Archetype = US_Classes.Awaken
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Awa_03,
				Text = "Encuentra una pista o ventaja en un area inmediata que antes se había pasado por alto.",
				Archetype = US_Classes.Awaken
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Awa_04,
				Text = "Convence a un PNJ de que actúe con bondad, interés o en propio beneficio.",
				Archetype = US_Classes.Awaken
			}
		};
	}
	private List<LIO> GenerateVeteranLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Vet_01,
				Text = "Sorprende a un enemigo desprevenido con un golpe terrible o déjalo K.O.",
				Archetype = US_Classes.Veteran
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vet_02,
				Text = "Protege un lugar, o genera barricadas con materiales mínimos.",
				Archetype = US_Classes.Veteran
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vet_03,
				Text = "Asusta o intimida a alguien con un recordatorio de quien solías ser.",
				Archetype = US_Classes.Veteran
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vet_04,
				Text = "Revela la forma en que un antiguo aliado o enemigo está dando forma a un conflicto actual.",
				Archetype = US_Classes.Veteran
			}
		};
	}
	private List<LIO> GenerateVampireLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Vamp_01,
				Text = "Crea una oportunidad para ESCAPAR, ignorando impedimentos mortales",
				Archetype = US_Classes.Vampire
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vamp_02,
				Text = "Realiza una hazaña fantástica de fuerza o agilidad vampírica",
				Archetype = US_Classes.Vampire
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vamp_03,
				Text = "Extiende tus sentidos vampíricos por un corto periodo de tiempo",
				Archetype = US_Classes.Vampire
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Vamp_04,
				Text = "Muestra dominancia: PNJ de bajo nivel se van, PJ deben MANTENER LA CALMA",
				Archetype = US_Classes.Vampire
			}
		};
	}
	private List<LIO> GenerateWolfLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Wolf_01,
				Text = "Curate 2-daño inmediatamente empezando por daño crítico",
				Archetype = US_Classes.Wolf
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Wolf_02,
				Text = "Transfórmate sin necesidad de la Luna",
				Archetype = US_Classes.Wolf
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Wolf_03,
				Text = "Realiza una proeza de fuerza o velocidad lupina",
				Archetype = US_Classes.Wolf
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Wolf_04,
				Text = "Aumenta tus sentidos lupinos a niveles supernaturales",
				Archetype = US_Classes.Wolf
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Wolf_05,
				Text = "Requiere REGENERAR: Se te cierran las heridas; cúrate 1-daño.",
				Archetype = US_Classes.Wolf
			}
		};
	}
	private List<LIO> GenerateSpecterLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Spect_01,
				Text = "Transpórtate instantáneamente a uno de tus anclas, sin importar la distancia",
				Archetype = US_Classes.Spectre
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Spect_02,
				Text = "Toma control de una maquina o vehículo poseyendo su forma mecánica",
				Archetype = US_Classes.Spectre
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Spect_03,
				Text = "Desata un rayo de energía exoplasmática (daño2, cerca, area, perforante)",
				Archetype = US_Classes.Spectre
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Spect_04,
				Text = "Sigue a un mortal ordinario, sin importar a donde vaya",
				Archetype = US_Classes.Spectre
			}
		};
	}
	private List<LIO> GenerateMageLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Mage_01,
				Text = "Deflacta o redirige un golpe justo antes de que te toque",
				Archetype = US_Classes.Mage
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Mage_02,
				Text = "Realiza una proeza de fuerza o precisión telequinética",
				Archetype = US_Classes.Mage
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Mage_03,
				Text = "Detecta la presencia o funcionamiento de objetos mágicos o hechizos",
				Archetype = US_Classes.Mage
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Mage_04,
				Text = "Cambia la forma o naturaleza de un objeto expuesto o hechizo mágico",
				Archetype = US_Classes.Mage
			}
		};
	}
	private List<LIO> GenerateOracleLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Orac_01,
				Text = "Expón la verdad esencial de una cosa o persona en tu presencia",
				Archetype = US_Classes.Oracle
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Orac_02,
				Text = "Manipula las hebras de la realidad para ayudar o perjudicar un PNJ en tu presencia",
				Archetype = US_Classes.Oracle
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Orac_03,
				Text = "Impresiona o asusta a alguien con un conocimiento del pasado",
				Archetype = US_Classes.Oracle
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Orac_04,
				Text = "Canaliza una potente profecía del más allá sobre un personaje presente",
				Archetype = US_Classes.Oracle
			}
		};
	}
	private List<LIO> GenerateSwornLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Sworn_01,
				Text = "Destruye un conjuro mágico o ilusión o encantamiento solo con tocarlo",
				Archetype = US_Classes.Sworn
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Sworn_02,
				Text = "Cúbrete con una armadura mágica. Consúmela para absorber todo del daño de un solo golpe",
				Archetype = US_Classes.Sworn
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Sworn_03,
				Text = "Derriba a todos los enemigos menores con una ráfaga de fuerza elemental",
				Archetype = US_Classes.Sworn
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Sworn_04,
				Text = "Obliga a alguien a responder preguntas sinceras durante una escena",
				Archetype = US_Classes.Sworn
			}
		};
	}
	private List<LIO> GenerateFairLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Fae_01,
				Text = "Invoca una tormenta elemental de tu corte (daño2, cerca, area, penetrante)",
				Archetype = US_Classes.Fair
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Fae_02,
				Text = "Aparece ante los demás como alguien a quien anteriormente has tocado",
				Archetype = US_Classes.Fair
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Fae_03,
				Text = "Obliga a los elementos de tu corte a explicarte lo que han visto",
				Archetype = US_Classes.Fair
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Fae_04,
				Text = "Crea un vinculo telepático con alguien durante una escena",
				Archetype = US_Classes.Fair
			}
		};
	}
	private List<LIO> GenerateCorruptedLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Corrupt_01,
				Text = "Impregna tu tacto de corrupción demoníaca (daño2, intimidante, penetrante)",
				Archetype = US_Classes.Corrupted
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Corrupt_02,
				Text = "Impresiona, asusta o consterna a alguien con una demostración de furia demoníaca",
				Archetype = US_Classes.Corrupted
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Corrupt_03,
				Text = "Atraviesa un obstáculo físico creado por manos mortales",
				Archetype = US_Classes.Corrupted
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Corrupt_04,
				Text = "Invoca a tu patrón oscuro directamente donde estas",
				Archetype = US_Classes.Corrupted
			}
		};
	}
	private List<LIO> GenerateImpLIO()
	{
		return new List<LIO>
		{
			new LIO
			{
				ID= USMoveIDs.LIO_Imp_01,
				Text = "Olfatear un escondite secreto, incluso cuando esté expertamente oculto o escondido",
				Archetype = US_Classes.Imp
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Imp_02,
				Text = "Teletransportarte a tu establecimiento desde cualquier distancia o posición",
				Archetype = US_Classes.Imp
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Imp_03,
				Text = "Infiltrarte en una zona hostil aparentando no ser digno de interés",
				Archetype = US_Classes.Imp
			},
			new LIO
			{
				ID= USMoveIDs.LIO_Imp_04,
				Text = "Infligir 4 daños (ap) a un objetivo vulnerable que te subestime",
				Archetype = US_Classes.Imp
			}
		};
	}

	private List<USMove> GenerateStatus1CityMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.CityStatus1_01, USAttributes.Status)
			{
				Title = "Debilitar la posición de alguien",
				TypeOfMovement = MovementTypes.CityMoveStatus1,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando usas rumores y cotilleos, tira con Estatus. Con un éxito, los rumores cuajan. Tienen un -1 en curso a los movimientos durante el turno de facción hasta que encuentren alguna forma de disipar los rumores."
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Con un 10+, uno de sus enemigos se entera de tus chismes y se acerca a ti con información perjudicial sobre los intereses de tu objetivo."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText="Con un fallo, tu objetivo rastrea las historias directamente hasta ti... y te pilla en un punto vulnerable antes de que puedas reaccionar."
				}
			},
			new USMove(USMoveIDs.CityStatus1_02, USAttributes.Status)
			{
				Title = "Hacer correr la voz",
				TypeOfMovement = MovementTypes.CityMoveStatus1,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando corres la voz de que necesitas algo para tu Círculo -un tomo mágico, información secreta, un guardaespaldas experto, etc.- tira con Estatus. "
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="Con un 10+, aparece en manos de un aliado; es tuyo a cambio de una Deuda."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText="Con un resultado de 7-9, acaba en manos de un rival, que quiere un favor o un regalo además de una Deuda antes de entregarlo."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un fallo, la cosa aparece en la puerta de tu casa con malvadas ataduras, exponiéndote a la ira de un PNJ de estatus 3 de otro Círculo."
				}
			},
			new USMove(USMoveIDs.CityStatus1_03, USAttributes.Status)
			{
				Title = "Consulta a sus contactos",
				TypeOfMovement = MovementTypes.CityMoveStatus1,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = $"Cuando consultes a tus contactos en otro Círculo, tira con estatus en ese Círculo. Con un éxito, pregunta 3; tus contactos responderán lo mejor que puedan.\r\n\r\n",
					Options = new List<string>
					{
						"¿De qué conflicto está hablando todo el mundo?",
						"¿Qué pasó con ________?",
						"¿Qué ha estado haciendo ________ recientemente?",
						"¿Quién es responsable de ________?",
						"¿Quién tiene una deuda con ________?"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText="Con un 7-9, mantén 1. Con un 10+, mantén 2."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un fallo, pregunte 1 y mantenga 1, pero su contacto también tiene una pregunta dura sobre sus lealtades y fidelidades. Responde honestamente, marca corrupción o debes una deuda, tú eliges."
				}
			},
			new USMove(USMoveIDs.CityStatus1_04, USAttributes.Status)
			{
				Title = "Ocuparte de tus asuntos",
				TypeOfMovement = MovementTypes.CityMoveStatus1,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando no te metas en los asuntos de la ciudad, dile al MC cómo pasas el tiempo y tira. Con un éxito, un viejo amigo o un nuevo aliado se acerca a ti para pedirte ayuda; marca una corrupción si lo rechazas."
				},
				ConsequencesOn10 = new Consequences{MainText="Con un 10+, haz una pregunta al MC sobre la situación; te responderá con sinceridad."},
				ConsequencesOn6 = new Consequences {MainText="Con un fallo, un PNJ interrumpe tus asuntos cotidianos para cobrar una Deuda que esperabas haber olvidado, mezclándote en un lío dentro de tu Círculo que preferirías haber evitado."}
			}
		};
	}

	private List<USMove> GenerateStatus2CityMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.CityStatus2_01, USAttributes.Status)
			{
				Title = "Reunir las fuerzas de una facción",
				TypeOfMovement = MovementTypes.CityMoveStatus2,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando intentes reunir fuerzas en tu Círculo para socavar una facción o sus posesiones, tira con Estatus.\r\nCon un éxito, puedes dar una Deuda a un PNJ poderoso de tu Círculo -a elección del MC- para reducir la fuerza de tu objetivo o debilitar su control sobre un activo específico, a tu elección.\r\n"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Con un 7-9, tus aliados tardan en moverse; dales otra Deuda para acelerar las cosas, o únete a ellos directamente en el ataque."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un fallo, el ataque se desmorona y crea una oportunidad para tus enemigos; dile al MC cómo te has dejado vulnerable ante ellos."
				}
			},
			new USMove(USMoveIDs.CityStatus2_02, USAttributes.Status)
			{
				Title = "Reclamar",
				TypeOfMovement = MovementTypes.CityMoveStatus2,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando reclames un bien vulnerable, tira con Estatus. Con un éxito, tu reclamación es ampliamente reconocida; apodérate del bien y el MC te dirá qué beneficios te aporta.",
					Options = new List<string>
					{
						"el bien ya no es vulnerable",
						"el activo no tiene rival que lo reclame",
						"el activo no requiere que cobres una deuda."
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Con un 7-9, elige 1"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Con un 10+, los 3"
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Si fallas, tu reclamación te pone en el punto de mira de un PNJ de Estatus 3 que también desea el activo; tu reclamación se queda corta, y el MC te dirá cuál de tus aliados o activos está en el punto de mira del PNJ de Estatus 3 en un intento de asustarte."
				}
			},
			new USMove(USMoveIDs.CityStatus2_03, USAttributes.Status)
			{
				Title = "Reclutar nuevos aliados",
				TypeOfMovement = MovementTypes.CityMoveStatus2,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando reclutes aliados de otro Círculo, dile al MC qué ayuda necesitas y tira con Estatus. Con un éxito, el MC te dirá quién está disponible para ser contratado; si gastas una Deuda, estará disponible hasta después del siguiente turno de facción.",
					Options = new List<string>
					{
						"son infaliblemente honestos",
						"son excepcionalmente hábiles",
						"son notablemente discretos",
						"están agresivamente centrados"
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, elige 3"},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Con un 7-9, elige 2"
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un fallo, antes de que puedas conectar con nadie, alguien de tu propio Círculo se entera de tu petición y difunde rumores sobre tu debilidad; lleva -1 en curso a tu Estatus hasta que demuestres tu fuerza a los tuyos."
				}
			},
			new USMove(USMoveIDs.CityStatus2_04, USAttributes.Status)
			{
				Title = "Reclamar estatus 3",
				TypeOfMovement = MovementTypes.CityMoveStatus2,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando hagas una reclamación de Estatus-3 en la ciudad, tira 2d6 y revisa la lista. Con un éxito, sube tu estatus a Estatus-3 y obtén el control de una facción relevante. Cualquier PC que alcance el Estatus-3 puede hacer movimientos de facción junto a las facciones de PNJs en cada turno de facción; su facción siempre se considera creciendo.",
					Options = new List<string>
					{
						"Si tienes influencia significativa sobre una facción de Tamaño 2+, suma 1.",
						"Si tienes seis Deudas sobre PNJ de Estatus-3, suma 1.",
						"Si tienes Estatus-0 en más de un Círculo, resta 1.",
						"Si controlas personalmente menos de dos activos, resta 1."
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, tu ascenso al poder genera nuevas alianzas y oportunidades; realiza un movimiento de ciudad adicional durante los dos próximos turnos de facción. "},
				ConsequencesOn79 = new Consequences { MainText = "Con un resultado de 7-9, tu ascenso provoca animadversión y celos dentro de tus propias filas; otro miembro de tu facción se marcha para unirse a otra facción, llevándose consigo un activo tuyo." },
				ConsequencesOn6 = new Consequences { MainText = " Con un fallo, tu ascenso se ve bloqueado por un PNJ de Estatus 3 que te odia a ti y a tus aliados; no puedes hacer otra reclamación hasta que te los ganes... o los elimines directamente." }
			}
		};
	}

	private List<USMove> GenerateFactionMoves()
	{
		return new List<USMove>
		{
			new USMove(USMoveIDs.CityFaction_01, USAttributes.None)
			{
				Title = "Atacar abiertamente a una facción",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción ataca abiertamente a otra facción, tira con la diferencia entre los Tamaños de las dos facciones. Con un éxito, la facción atacada sacrifica una baza apropiada o pierde un punto de Tamaño, a su elección."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Con un resultado de 7-9, la facción atacante debe sacrificar una baza apropiada o perder también un punto de Tamaño."
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Con un fallo, el objetivo tiende una trampa inteligente; captura o destruye una baza o reduce el Tamaño del atacante, a su elección."
				}
			},
			new USMove(USMoveIDs.CityFaction_02, USAttributes.None)
			{
				Title = "Consolidar el control",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando los líderes de una facción consolidan el control sobre sus fuerzas y activos existentes, tiran con su Fuerza.",
					Options = new List<string>
					{
						"se aseguran nuevas posesiones; marca recursos",
						"Buscan nuevos miembros; marcan reclutamiento",
						"exigen secreto; encubren otra acción"
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, eligen 2."},
				ConsequencesOn79 = new Consequences { MainText = "Con un 7-9, eligen 1" },
				ConsequencesOn6 = new Consequences { MainText = "Con un fallo, sus esfuerzos conducen a luchas internas; una autoridad es destronada o humillada, y una coalición rebelde dentro de la facción gana impulso: reduce la Fuerza de la facción." }
			},
			new USMove(USMoveIDs.CityFaction_03, USAttributes.None)
			{
				Title = "Localizar a alguien",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción intenta localizar a un personaje de estatus 1 o 2 dentro de la ciudad, tira:",
					Options = new List<string>
					{
						"Si la facción tiene una baza relevante, suma 1.",
						"Si su presa es del mismo Círculo, suma 1.",
						"Si la facción es de Tamaño-1 o Fuerza-1, resta 1.",
						"Si la presa se esconde activamente, resta 1."
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Si la presa es un PNJ: Con un 10+, descubren a la presa expuesta o vulnerable; la facción puede actuar impunemente sobre ella. Si la presa es un PC: Con un 10+, la facción rastreadora saca lo mejor de su presa; acorralan al PC con una fuerza abrumadora o una cuidadosa planificación que le deja poco espacio para evitar a sus perseguidores."},
				ConsequencesOn79 = new Consequences { MainText = "Si la presa es un PNJ: Con un resultado de 7-9, la facción encuentra a su presa; la ataca, la secuestra o se enfrenta a ella con algún coste. Si la presa es un PC: Con un 7-9, la facción rastrea su localización, pero el PC tiene tiempo de prepararse para las fuerzas limitadas que vienen hacia él." },
				ConsequencesOn6 = new Consequences { MainText = "Si la presa es un PNJ: Con un fallo, los intentos de la facción de localizarlos tienen éxito, pero sus agentes lo estropean todo y permiten que la presa escape ilesa. Si la presa es un PC: Con un fallo, alguien cercano al Pc le avisa antes de tiempo de la búsqueda de la facción... y de una oportunidad o debilidad que el Pc puede explotar..." }
			},
			new USMove(USMoveIDs.CityFaction_04, USAttributes.None)
			{
				Title = "Incitar al adversario",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción intenta incitar a un oponente a cometer un error, tira con la diferencia entre las Fuerzas de las dos facciones."
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, el objetivo muerde el anzuelo; la facción instigadora asesta un golpe terrible, destruye una baza vulnerable o socava una relación o alianza clave."},
				ConsequencesOn79 = new Consequences { MainText = "Con un resultado de 7-9, el objetivo evita lo peor de la trampa, pero causa suficientes problemas como para avergonzarse a sí mismo." },
				ConsequencesOn6 = new Consequences { MainText = "Con un fallo, el objetivo se da cuenta del plan; alguien de la facción objetivo acude a uno de los PJ para que le ayude a cambiar las tornas contra la facción instigadora." }
			},
			new USMove(USMoveIDs.CityFaction_05, USAttributes.None)
			{
				Title = "Apoderarse por la fuerza",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción se apodera de algo vulnerable por la fuerza, tira con su Fuerza. Con un éxito, se apoderan de ello; reducen el atributo apropiado de la facción objetivo y se apoderan de un bien vulnerable.",
					Options = new List<string>
					{
						"No sacrifican a un líder, aliado o activo importante.",
						"No suplantan un ataque de represalia inmediato.",
						"No causan daños colaterales graves."
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, los tres"},
				ConsequencesOn79 = new Consequences { MainText = "Con un 7-9, eligen uno" },
				ConsequencesOn6 = new Consequences { MainText = "Con un fallo, el ataque resulta en la destrucción total de la cosa que la facción atacante intentó apoderarse; alguien acude a uno de los PCs buscando ayuda para obtener justicia o venganza." }
			},
			new USMove(USMoveIDs.CityFaction_06, USAttributes.None)
			{
				Title = "Buscar en la ciudad",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción busca en la ciudad información útil -un raro conocimiento oculto, las debilidades de otra facción, la localización de un artefacto- tira con su Tamaño. Si aciertan, descubren algunos detalles cruciales, suficientes para pedir a un PJ o PNJ notable que siga investigando.",
					Options = new List<string>
					{
						"atraen la atención de una facción rival",
						"tienen que hacer vulnerable un activo",
						"tienen -1 en curso hasta el final del siguiente turno de la facción "
					}
				},
				ConsequencesOn10 = new Consequences { MainText = "Con un 10+, también eligen 1"},
				ConsequencesOn79 = new Consequences { MainText = "Con un 7-9, también eligen 2." },
				ConsequencesOn6 = new Consequences { MainText = "Con un fallo, un miembro de la facción que ha conseguido alguna información vital acaba muerto o desaparecido... pero no antes de transmitir lo que sabe a uno de los PJ." }
			},
			new USMove(USMoveIDs.CityFaction_07, USAttributes.None)
			{
				Title = "Ofrecer pasaje",
				TypeOfMovement = MovementTypes.FactionPhaseCityMove,
				IsSelected = true,
				Archetipe = US_Classes.All,
				PreCondition = new Consequences
				{
					MainText = "Cuando una facción ofrece paso a alguien -para entrar o salir de la ciudad- tira con su Tamaño. Si aciertas, el camino queda expedito, sin importar quién se oponga; elige 1:",
					Options = new List<string>
					{
						"alguien sale; queda fuera de su alcance hasta que decida regresar",
						"alguien entra; la facción gana una poderosa baza"
					}
				},
				ConsequencesOn79 = new Consequences { MainText = "Con un 7-9, el paso ofende a un PNJ de Estatus 3 que busca tributo por la intrusión; la facción debe realizar un favor -dedicar un movimiento de facción en el próximo turno de facción- sacrificar un activo o arriesgarse a una guerra abierta." },
				ConsequencesOn6 = new Consequences { MainText = "Con un fallo, el pasaje provoca un conflicto entre la facción y sus propios aliados antes de que pueda completarse; alguien acude a uno de los PJ en busca de ayuda para negociar una tregua." }
			}
		};
	}

	#endregion
}
