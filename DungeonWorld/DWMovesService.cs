using PbtALib;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class DWMovesService : MovesServiceBase
{
	public List<DWMovementIDs> BasicMovements = new List<DWMovementIDs> {
			DWMovementIDs.DW_DefyDanger, DWMovementIDs.DW_DiscernReality, DWMovementIDs.DW_IHaveWhatINeed,
			DWMovementIDs.DW_Interfere, DWMovementIDs.DW_Aid, DWMovementIDs.DW_Parley, DWMovementIDs.DW_Supplies,
			DWMovementIDs.DW_SproutLore, DWMovementIDs.DW_Defend,
			DWMovementIDs.DW_HnS, DWMovementIDs.DW_Volley, DWMovementIDs.DW_LastBreath,
			DWMovementIDs.DW_Recover, DWMovementIDs.DW_Camp
		};
	public List<DWMovementIDs> AdvancedMovements = new List<DWMovementIDs> {
			DWMovementIDs.DW_KeepYouMind, DWMovementIDs.DW_HuntDown, DWMovementIDs.DW_IKnowAMan,
			DWMovementIDs.DW_GlossOverFight, DWMovementIDs.DW_FightAsOne, DWMovementIDs.DW_RunAway,
			DWMovementIDs.DW_Scout, DWMovementIDs.DW_HoldBreath, DWMovementIDs.DW_Travel
		};

	public List<DWMovementIDs> BarbarianAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Barbarian_Adv_Impresive, DWMovementIDs.DW_Barbarian_Adv_Instinct, DWMovementIDs.DW_Barbarian_Adv_Muscle, DWMovementIDs.DW_Barbarian_Adv_Panter, DWMovementIDs.DW_Barbarian_Adv_Sanson, DWMovementIDs.DW_Barbarian_Adv_VoleyAll
		};
	public List<DWMovementIDs> BardAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Barb_Adv_Cute, DWMovementIDs.DW_Barb_Adv_MoreWorks, DWMovementIDs.DW_Barb_Adv_Parry, DWMovementIDs.DW_Barb_Adv_Party, DWMovementIDs.DW_Barb_Adv_SilverTonge
		};
	public List<DWMovementIDs> ClericAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Cleric_Adv_Balance, DWMovementIDs.DW_Cleric_Adv_Intervention, DWMovementIDs.DW_Cleric_Adv_MoreSpells, DWMovementIDs.DW_Cleric_Adv_Serenity
		};
	public List<DWMovementIDs> DruidAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Druid_Adv_Call, DWMovementIDs.DW_Druid_Adv_Red, DWMovementIDs.DW_Druid_Adv_TigerEyes, DWMovementIDs.DW_Druid_Adv_BorrowedPowers
		};
	public List<DWMovementIDs> FighterAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Fighter_Adv_Cold, DWMovementIDs.DW_Fighter_Adv_Conscient, DWMovementIDs.DW_Fighter_Adv_IronEyes, DWMovementIDs.DW_Fighter_Adv_IronSkin, DWMovementIDs.DW_Fighter_Adv_Relentless
		};
	public List<DWMovementIDs> ThiefAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Thief_Adv_Cheater, DWMovementIDs.DW_Thief_Adv_Dirty, DWMovementIDs.DW_Thief_Adv_Door, DWMovementIDs.DW_Thief_Adv_Feline, DWMovementIDs.DW_Thief_Adv_Trickster
		};
	public List<DWMovementIDs> WizardAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Wizard_Adv_Detect, DWMovementIDs.DW_Wizard_Adv_Guardian, DWMovementIDs.DW_Wizard_Adv_Logic, DWMovementIDs.DW_Wizard_Adv_MoreSpells
		};
	public List<DWMovementIDs> ExplorerAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Ranger_Adv_HideSun, DWMovementIDs.DW_Ranger_Adv_Horse, DWMovementIDs.DW_Ranger_Adv_Naturalist, DWMovementIDs.DW_Ranger_Adv_Predator, DWMovementIDs.DW_Ranger_Adv_Relatives
		};
	public List<DWMovementIDs> PaladinAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Paladin_Adv_Aura, DWMovementIDs.DW_Paladin_Adv_Charge, DWMovementIDs.DW_Paladin_Adv_Defender, DWMovementIDs.DW_Paladin_Adv_Walk, DWMovementIDs.DW_Paladin_Adv_Window
		};
	public List<DWMovementIDs> WielderAdvanced = new List<DWMovementIDs>
		{
			DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWMovementIDs.DW_ALL_Adv_SuperiorStat,
			DWMovementIDs.DW_Wielder_Adv_Keep, DWMovementIDs.DW_Wielder_Adv_Pain, DWMovementIDs.DW_Wielder_Adv_Power, DWMovementIDs.DW_Wielder_Adv_Voices
		};

	public List<DWMovementIDs> GetAdvancedMovementsFor(DWClasses prof)
	{
		return prof switch
		{
			DWClasses.DW_Barbarian => BarbarianAdvanced,
			DWClasses.DW_Cleric => ClericAdvanced,
			DWClasses.DW_Bard => BardAdvanced,
			DWClasses.DW_Druid => DruidAdvanced,
			DWClasses.DW_Fighter => FighterAdvanced,
			DWClasses.DW_Thief => ThiefAdvanced,
			DWClasses.DW_Mage => WizardAdvanced,
			DWClasses.DW_Wielder => WielderAdvanced,
			DWClasses.DW_Paladin => PaladinAdvanced,
			DWClasses.DW_Explorer => ExplorerAdvanced,

			_ => throw new Exception($"Unknown class {prof}")
		};
	}

	public List<DWMove> AllMovements = new List<DWMove>
	{
		new DWMove(DWMovementIDs.DW_DefyDanger, DWStats.DW_None)
		{
			Tittle = "Desafiar al peligro",
			PreCondition = new Consequences{
				MainText = "Cuando el peligro acecha y hay mucho en juego, pero de todos modos actúas, verifica si se aplica otro movimiento. Si no, tira...",
				Options = new List<string>
				{
					"... + FUE para potenciar o probar tu poder",
					"... + DES para emplear velocidad, ágil. o delicadeza",
					"... + CON para soportar o mantenerse firme",
					"... + INT para aplicar experiencia o un buen plan",
					"... + SAB usar la F. de vol. o confiar en tus sentidos",
					"... + CAR encantar, fanfarronear, impresionar o encajar"
				}
			},
			ConsequencesOn79 = new Consequences
			{
				MainText = "puedes hacerlo, pero el DJ presentará un éxito menor, un coste o una consecuencia (y tal vez una elección entre ellos, o una oportunidad de retroceder)"
			},
			ConsequencesOn10 = new Consequences
			{
				MainText = "lo logras tan bien como podrías esperar"
			}
		},
		 new DWMove (DWMovementIDs.DW_DiscernReality, DWStats.DW_WIS)
			{
				Tittle = "Discernir la realidad",
				PreCondition = new Consequences{
					MainText = "Cuando estudias minuciosamente una situación o persona y miras al DJ para saber más, tira +SAB. Con 7+ tira con ventaja si usas tu nuevos conocimientos"

				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Puedes hacer al DJ una pregunta de la lista"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Puedes hacer al DJ hace 3 preguntas de la lista",
					Options = new List<string>
					{
						"¿Qué pasó aquí recientemente?",
						"¿Qué va a pasar?",
						"¿A qué debo estar atento?",
						"¿Qué es útil o valioso aquí para mí?",
						"¿Quién o qué tiene realmente el control aquí?",
						"¿Qué hay aquí, que no es lo que parece ser?"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_IHaveWhatINeed, DWStats.DW_None)
			{
				Tittle = "Tengo lo que necesito",
				PreCondition = new Consequences{
					MainText = "Cuando decides que llevas algo contigo, borra un ⧫ (o ⧫⧫) de su equipo indefinido y marca un elemento o espacio para indicar que tiene eso. Si marcas un espacio, rellénalo con un elemento común o mundano. Como alternativa, gasta 1 uso de 'Cosas' (en lugar de equipo indefinido) para producir un artículo pequeño, común y mundano."
				}
			},
			new DWMove (DWMovementIDs.DW_Aid, DWStats.DW_None)
			{
				Tittle = "Ayudar",
				PreCondition = new Consequences{
					MainText = "Cuando ayudas a otro personaje que está apunto de tirar, tirar con ventaja pero te expones a los riesgos/costes/consecuencias."
				}
			},			
			new DWMove (DWMovementIDs.DW_Interfere, DWStats.DW_CHOSE)
			{
				Tittle = "Interferir",
				PreCondition = new Consequences{
					MainText = "Cuando intentas frustrar la acción de otro PJ y ninguno de los dos retrocede, tira ... ",
					Options = new List<string>
					{
						"... + FUE para potenciar o probar tu poder",
						"... + DES para emplear velocidad, ágil. o delicadeza",
						"... + CON para soportar o mantenerse firme",
						"... + INT para aplicar experiencia o un buen plan",
						"... + SAB usar la F. de vol. o confiar en tus sentidos",
						"... + CAR encantar, fanfarronear, impresionar o encajar"
					}

				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "eligen 1 pero te quedas desequilibrado, expuesto o vulnerables de algún modo"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "eligen 1 de la lista",
					Options = new List<string>
					{
						"Hacerlo de todos modos, pero tira Desventaja.",
						"Ceder, cambiar o desistir de tu movimiento"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Parley, DWStats.DW_CHA)
			{
				Tittle = "Parlamentar",
				PreCondition = new Consequences{
					MainText = "Cuando presionas (amenaza, implora, avergüenza, suplica, motiva...) o atraes (seduce, soborna, tienta...) a un PNJ, di lo que quieres que hagan (o no hagan). Sí tienen razón para resistir, tira +CAR. En el caso de ser un PJ, con un 7-9 elije una de la lista, con 10+ las dos, ",
					Options = new List<string>
					{
						"ÉL obtiene 1 XP si hace lo que tú quieres",
						"Debe hacer lo que tú quieres o revelar cómo podrías convencerlo de que lo hiciera"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Para PNJ: revelan algo que puedes hacer para convencerlos, aunque probablemente será costoso, complicado o desagradable"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Para PNJ: hacen lo que quieres o revelan dos formas de convencerlos (que no necesariamente sean fáciles, Parlamentar no es control mental). Ejemplos de cosas que pueden convencer serán:",
					Options = new List<string>
					{
						"Una promesa/un juramento/un voto",
						"Una oportunidad de hacerlo de forma segura/libre/discreta",
						"Apaciguar o apelar a su ego/honor/conciencia/miedos",
						"Un engaño convincente",
						"Una oferta mejor/justa/excesiva",
						"Ayudarles/hacerlo con ellos",
						"Violencia (o una amenaza creíble de violencia)",
						"Algo que quieren o necesitan",
						"Garantía/prueba/colaboración concretas",
						"Presión/permiso/ayuda de ____"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Supplies, DWStats.DW_None)
			{
				Tittle = "Reabastecimiento",
				PreCondition = new Consequences{
					MainText = "Cuando aproveches la oportunidad para reabastecerte, borra cualquier ⧫ y vuelve a seleccionar tu equipo como desees. Si estás pagando, un artículo valioso (como una bolsa de monedas) debe bastar para cubrir todo el grupo.",
				}
			},
			new DWMove (DWMovementIDs.DW_SproutLore, DWStats.DW_INT)
			{
				Tittle = "Decir conocimiento",
				PreCondition = new Consequences{
					MainText = "Cuando consultas tu conocimiento acumulado sobre algo, tira +INT"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "el DJ solo te dirá algo interesante, depende de ti para que sea útil. El DJ puede preguntarte ¿Cómo sabes esto? Dile la verdad, ahora"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "el DJ te dirá algo interesante, útil, y relevante sobre el tema. El DJ puede preguntarte ¿Cómo sabes esto? Dile la verdad, ahora"
				}
			},
			new DWMove (DWMovementIDs.DW_Help, DWStats.DW_None)
			{
				Tittle = "Ayudar",
				PreCondition = new Consequences{
					MainText = "Cuando ayudas a otro personaje que está a punto de tirar, él gana ventaja, pero estás expuesto a cualquier riesgo, costo o consecuencia."
				}
			},
			new DWMove (DWMovementIDs.DW_DealDamage, DWStats.DW_None)
			{
				Tittle = "Hacer daño",
				PreCondition = new Consequences{
					MainText = "Cuando dañes a un enemigo, pero no lo mates de forma directa, tira tu daño y di el resultado (más cualquier etiqueta (aparatoso, contundente, etc.). El DJ reducirá los PG del enemigo (menos su armadura) y describirá el resultado o te pedirá que lo hagas. Cuando tengas ventaja o desventaja en una tirada de daño, tira el dado de daño principal dos veces y guarda el resultado más alto o más bajo; luego añade bonificadores que se apliquen."
				}
			},
			new DWMove (DWMovementIDs.DW_Defend, DWStats.DW_CON)
			{
				Tittle = "Defender",
				PreCondition = new Consequences{
					MainText = "Cuando adoptes una postura defensiva o te metas en medio para proteger a otros, tira +CON y gana puntos que podrás usar. Cuando pasas a la ofensiva, dejas de concentrarte en la defensa, o la amenaza pasa, pierdes cualquier punto que tengas"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "tienes 1 puntos"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "tienes 3 puntos",
					Options= new List<string>
					{
						"Sufrir tú el daño/efectos de un ataque",
						"Reducir a la mitad el daño/ef. de un ataque",
						"Desviar toda la atención del atacante hacia ti",
						"Devolver el golpe (haz daño con desventaja)"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_HnS, DWStats.DW_DorS)
			{
				Tittle = "Saja-Raja",
				PreCondition = new Consequences{
					MainText = "Cuando luches en combate cuerpo a cuerpo con un enemigo de tu nivel, tira con FUE (DES para armas delicadas)"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "tu maniobra funciona, en su mayoría. Inflige Daño, pero sufres el ataque del enemigo"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "Inflige daño y elige 1",
					Options= new List<string>
					{
						"Evadir o impedir el ataque del enemigo",
						"Golpea fuerte y rápido, +1d6 de daño extra, pero sufres el ataque del enemigo"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Volley, DWStats.DW_DEX)
			{
				Tittle = "Disparar",
				PreCondition = new Consequences{
					MainText = "Cuando lanzas un ataque a distancia, tira +DES"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "infliges daño, pero eliges 1 de la lista de abajo",
					Options= new List<string>
					{
						"Tienes que moverte/mantenerte firme para conseguir el disparo, poniéndote en peligro de la elección del DJ",
						"Inflige Daño con desventaja",
						"Agotar tu munición, marcar el siguiente estado junto a tu arma / munición"
					}
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "tienes un tiro claro: ¡inflige daño! "
				}
			},
			new DWMove (DWMovementIDs.DW_LastBreath, DWStats.DW_PlusZero)
			{
				Tittle = "Último aliento",
				PreCondition = new Consequences{
					MainText = "Cuando te estás muriendo, vislumbras lo que hay más allá de las Puertas Negras de la Muerte (Descríbelo). Luego tira +nada (a la muerte no le importan los numeritos en tu ficha)"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "la Muerte te ofrecerá un trato: tómelo y estabilízate o recházalo y pasa más allá de las Puertas Negras hacia tu final"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "con un 10+, has\r\nengañado a la muerte: ya no estás muriendo, pero estás todavía en un mal lugar"
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Tu destino está sellado, el DJ te dirá cuando y como"
				}
			},
			new DWMove (DWMovementIDs.DW_Recover, DWStats.DW_None)
			{
				Tittle = "Recuperarse",
				PreCondition = new Consequences
				{
					MainText="Cuando *te tomas el tiempo para recuperar el aliento y cuidar de lo que te aqueja**, gasta 1 uso de Suministros y recupera 5 PG. No puedes beneficiarte de este movimiento de nuevo hasta que recibas más daño.\r\n\r\nCuando *atiendes a una debilidad o a una herida problemática**, explica cómo. El DJ dirá si se cura o debes hacer algo más (Desafiar el Peligro, gastar Suministros, encontrar __, *Levantar campamento**, etc.)"
                }
			},
			new DWMove (DWMovementIDs.DW_Camp, DWStats.DW_None)
			{
				Tittle = "Levantar un campamento",
				PreCondition = new Consequences{
					MainText = "Cuando te instalas para descansar en una zona peligrosa, alguien en el grupo debe gastar 1 uso de Suministros. Luego, turnaos para",
					Options= new List<string>
					{
						"Si has cumplido con tu impulso, marca XP",
						"Describe como tu opinión o relación con otro personaje ha cambiado. Si todos están de acuerdo, marca XP",
						"Señale algo impresionante que otro personaje lo hizo, que nadie más ha mencionado aún; si lo haces, marca XP"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "(ignora el 7-9) Cuando te despiertas de al menos unas pocas horas de sueño, elige 1. (2 Si gastas más suministros)",
					Options = new List<string>
					{
						"Recupera HP igual a la mitad de tu máximo",
						"Limpia todas tus debilidades",
						"Gana ventaja en tu próxima tirada"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_KeepYouMind, DWStats.DW_WIS)
			{
				Tittle = "Recupera el control de tu mente",
				PreCondition = new Consequences{
					MainText = "Cuando te veas obligado a actuar en contra de tu voluntad, marca PX si actúas según lo ordenado. Si te resistes, tira +SAB: ",
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "elije 1:",
					Options = new List<string>
					{
						"No hagas nada mientras luchas por el control",
						"Comienzas a actuar como obligado, pero te detienes o desvías en el último momento.",
						"Hazte daño para recuperar el control de inmediato (1d6 de daño, ignora la armadura)"
					}
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "te deshaces de la compulsión y actúas como deseas",
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Elije 1",
					Options = new List<string>
					{
						"Marca una debilidad, sufre 1d6 de daño y haz algo drástico para recuperar el control.",
						"Sigue como si nada. Más tarde descubriremos que has hecho"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_HuntDown, DWStats.DW_DEXCONWIS)
			{
				Tittle = "Dar caza",
				PreCondition = new Consequences{
					MainText = "Cuando persigas a tu presa, tira y añade...",
					Options= new List<string>
					{
						"+ DEX para superarlos por velocidad o maniobras",
						"+ CON para sobrevivir a ellos",
						"+ WIS para rastrearlos o buscarlos"
					}
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="acorralas a tu presa o la atrapas al aire libre"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "tu presa elige uno",
					Options = new List<string>
					{
						"Casi los tienes, solo hay un último obstáculo en tu camino",
						"Han ido a tierra; sabes dónde están, pero son difíciles de alcanzar",
						"Giran inesperadamente y atacan"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_IKnowAMan, DWStats.DW_CHA)
			{
				Tittle = "Conozco a un tipo...",
				PreCondition = new Consequences{
					MainText = "Cuando decidas que conoces a alguien que pueda ayudarte, nómbralo y tira +CAR",
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="sí, claro, puede ayudarte, aunque es posible que tengas que hacer que valga la pena"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "elije 1",
					Options = new List<string>
					{
						"Pueden ayudar, pero primero necesita tu ayuda",
						"Va a pedir mucho",
						"No está hecho para esto",
						"No puedes ya sabes… exactamente “confiar” en él"
					}
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "el DJ elige 1 y algo más."
				}
			},
			new DWMove (DWMovementIDs.DW_GlossOverFight, DWStats.DW_CHOSE)
			{
				Tittle = "Luchar a camara rápida",
				PreCondition = new Consequences{
					MainText = "Cuando la victoria sea clara y todos estén de acuerdo en saltarse los detalles de la pelea, describe tu papel en el conflicto y tira +STAT (por Desafiar el peligro)"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="Elige 1",
					Options = new List<string>
					{
						"Superas la pelea ileso",
						"Elija 1 de la lista 7-9, y díganos como impidió a otra persona elegir esa opción de la lista"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Elije 1",
					Options = new List<string>
					{
						"Recibe daño de tus enemigos (cuéntanos cómo sucedió)",
						"Marca una debilidad (dinos por qué)",
						"Usa un recurso: un objeto, un hechizo, tu munición, tus Suministros, etc. (dinos cómo)",
						"Sufrir algún contratiempo estratégico (pide al DJ que lo describa)"
					}
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "Elige 1 de la lista 7-9 y el DJ elige otro."
				}
			},
			new DWMove (DWMovementIDs.DW_FightAsOne, DWStats.DW_CHOSE)
			{
				Tittle = "Actuar como uno",
				PreCondition = new Consequences{
					MainText = "Cuando intenteis superar un peligro todos juntos. Di cómo lo manejas y tira +STAT"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText="puedes sacar a alguien de un aprieto, si puedes decirnos cómo."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "Haces tu parte;"
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "te metes en problemas, el DJ lo describirá. Si obtienes un 6 pero alguien te salva, no marques XP."
				}
			},
			new DWMove (DWMovementIDs.DW_RunAway, DWStats.DW_PlusZero)
			{
				Tittle = "Huir",
				PreCondition = new Consequences{
					MainText = "Cuando el grupo huya del peligro, tira y suma...",
					Options = new List<string>
					{
						"+1 si nadie lleva más de ◇ x2",
						"+1 si su ruta fue planeada con anticipación",
						"+1 si de lo que huyes es lento o constreñido",
						"-1 si alguien del grupo está sobrecargado"
					}
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "te escapas, pero eliges 1 y el DJ elige otro"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText ="te escapas, pero eliges 1",
					Options = new List<string>
					{
						"El grupo se ha dividido",
						"Perdiste algo (equipo, tesoro, PG, orientación, etc.) durante su huida",
						"Te has metido en un nuevo tipo de problema",
						"Has escapado por ahora, pero todavía están buscándote"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Scout, DWStats.DW_CHOSE)
			{
				Tittle = "Adelantarte y explorar",
				PreCondition = new Consequences{
					MainText = "Cuando vayas por tu cuenta a explorar un área peligrosa, di cómo lo haces y tira + STAT (por Desafiar el peligro)"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "regresas sano y salvo y el DJ describe lo que encontraste, Elije 1 de la lista"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText ="regresas sano y salvo y el DJ describe lo que encontraste, Elije 2 de la lista",
					Options = new List<string>
					{
						"Saliste limpio, sin levantar sospechas",
						"Notaste algo fuera de lugar o que no era lo que parecía",
						"Determinaste quién o qué estaba al cargo",
						"Viste algo valioso o útil",
						"Identificaste la mayor amenaza o peligro",
						"Pudiste sacar algo a escondidas",
						"Hiciste algunos preparativos para explotar cuando regreses"
					}
				},
				ConsequencesOn6 = new Consequences
				{
					MainText="Elije 1:",
					Options = new List<string>
					{
						"Regresas con los demás, con problemas",
						"pisándote los talones",
						"Te estás perdiendo con tanta acción, los detalles se revelarán más tarde"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_HoldBreath, DWStats.DW_CON_Plus2)
			{
				Tittle = "Mantener la respiración",
				PreCondition = new Consequences{
					MainText = "Cuando te sumerjas bajo el agua, consigue CON+2 puntos de respiración. Si tomas una respiración profunda primero, obtén un +1. Cada vez que tiras 2d6 para hacer un movimiento, elige 1 (después de tirar):",
					Options = new List<string>
					{
						"Gastar 1 punto de aliento",
						"Marcar una debilidad",
						"Tomar tu Último aliento (muere)"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Travel, DWStats.DW_WIS)
			{
				Tittle = "Viajar",
				PreCondition = new Consequences{
					MainText = "Cuando viajes por tierras peligrosas o desconocidas, indica tu ruta y tu destino (que podría ser simplemente “un lugar seguro para acampar” o “hasta donde nos lleve este sendero”). Si la ruta es difícil, elige 1. Si la ruta es peligrosa, elige 2.Después de hacer cualquier elección, quien dirija el camino tira +SAB: ",
					Options = new List<string>
					{
						"Tarda más de lo esperado",
						"Algo te sigue hasta tu destino",
						"Es un trabajo duro; 1d4 miembros del grupo deben marcar una debilidad o descartar un objeto ◇."
					},
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "ha llegado a su destino: describa lo más interesante del viaje.",
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "como un 10+, pero elige 1 extra de la lista anterior"
				},
				ConsequencesOn6 = new Consequences
				{
					MainText = "tu viaje se ve interrumpido por un obstáculo, peligro o crisis. Puede reanudar su viaje después de lidiar con él (después haz otra vez un movimiento de Viajar)"
				}
			},

			new DWMove (DWMovementIDs.DW_Barbarian_InitialChoose, DWStats.DW_None)
			{
				Tittle = "Elije o fuerzo o agilidad",
				PreCondition = new Consequences
				{
					MainText= "Elije gratis y al inicio una de los dos movimientos avanzados, o músculos poderosos o Grácia de pantera"
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Hunger, DWStats.DW_None)
			{
				Tittle = "Apetitos hercúleos",
				PreCondition = new Consequences{
					MainText = "Escoge dos: \r\nRespuestas, Venganza sangrienta, Conflicto y destrucción, Descubrimiento y asombro, Placeres mortales, Superioridad sobre los demás, Riquezas y gloria,\r\n añádelo a tu descripción.\r\n\r\n Cuando haces un movimiento en busca de tu apetitos, tira 1d6+1d8 en lugar de 2d6. Si el d6 es > que el d8, el DJ agregará una complicación relacionada con sus actividades irresponsables. \r\n En caso de ventaja o desventaja duplica el d6."
                }
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Formidable, DWStats.DW_None)
			{
				Tittle = "Formidable",
				PreCondition = new Consequences{
					MainText = "Cuando te lanzas a la batalla con arrojo, obtienes puntos igual a tu CON. Cuando dejes de pelear, dudes, o muestres cobardía, pierdes los puntos. Mientras peleas, gasta puntos 1 por 1 para:",
					Options = new List<string>
					{
						"hacer retroceder a un enemigo débil con solo mirarlo a los ojos",
						"Retar a un enemigo digno, él te tratarán como la mayor amenaza en el campo de batalla",
                        "Haz sonar tu bárbaro aullido al derribar a un enemigo; sus aliados están impresionados, asustados o consternados y actúan en consecuencia"
                    }
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Forastero, DWStats.DW_None)
			{
				Tittle = "Forastero",
				PreCondition = new Consequences{
					MainText = "Cuando hagas el campamento, pide al DJ que te haga una pregunta sobre tu gente, tu patria, o por qué lo dejaste. Si las responde, marca 1 PX"
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_UpperHand, DWStats.DW_None)
			{
				Tittle = "Mirar a la muerte a los ojos",
				PreCondition = new Consequences{
					MainText = "Cuando *tomas tu último aliento**, tienes ventaja."
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "le haces una oferta a la Muerte. si la muerte acepta, te devolverán a la vida. Si no, te mueres."
				}
			},

			new DWMove (DWMovementIDs.DW_Barbarian_Adv_Muscle, DWStats.DW_None)
			{
				Tittle = "Músculos poderosos",
				PreCondition = new Consequences{
					MainText = "Cuando infliges daño es contundente (los golpea) y brutal (sangriento y destructivo). Empieza a jugar con 5◇"
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Adv_Panter, DWStats.DW_None)
			{
				Tittle = "Gracia de pantera",
				PreCondition = new Consequences{
					MainText = "Cuando estás desarmado y no sobrecargado, impones una desventaja sobre cualquier daño que recibas que podrías esquivar o rodar."
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Adv_Impresive, DWStats.DW_None)
			{
				Tittle = "Realmente impresionante",
				PreCondition = new Consequences{
					MainText = "Cuando realizas una hazaña de destreza física, nombra un testigo a quien hayas impresionado. Ganas ventaja en tu próximo *Parlamentar** con ellos."
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Adv_Sanson, DWStats.DW_None)
			{
				Tittle = "Sansón",
				PreCondition = new Consequences{
					MainText = "Puedes marcar una debilidad para liberarte inmediatamente de una restricción física o mental."
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Adv_VoleyAll, DWStats.DW_None)
			{
				Tittle = "Tirar cualquier cosa",
				PreCondition = new Consequences{
					MainText = "Puedes *disparar** lanzando cualquier cosa que puedas recoger. Si no es adecuado para ser arrojado, tira +FUE en lugar de +DES."
				}
			},
			new DWMove (DWMovementIDs.DW_Barbarian_Adv_Instinct, DWStats.DW_None)
			{
				Tittle = "Instintos Salvajes",
				PreCondition = new Consequences{
					MainText = "Cuando *disciernes la realidad**, siempre puedes preguntar “¿A qué debería estar atento?” gratis, incluso en un 6-."
				}
			},


			new DWMove (DWMovementIDs.DW_Barb_Knowledge, DWStats.DW_None)
			{
				Tittle = "Saber bardo",
				PreCondition = new Consequences{
					MainText = "Cuando nombras una canción, un poema o un cuento que habla del tema en cuestión, gane ventaja a *Decir conocimiento**."
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Reputation, DWStats.DW_CHA)
			{
				Tittle = "Reputación",
				PreCondition = new Consequences{
					MainText = "Cuando *conoces a alguien que ha oído hablar de ti** (tú lo decides), tira +CAR:  con 7-9, di una cosa que han escuchado sobre ti, y el DJ revelará otra\r\n"
				},
				ConsequencesOn10 = new Consequences
				{
					MainText = "dile al DJ dos cosas que han oído sobre ti"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "di una cosa que han escuchado sobre ti, y el DJ revelará otra"
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Smart, DWStats.DW_None)
			{
				Tittle = "Ingenioso",
				PreCondition = new Consequences{
					MainText = "Cuando sacas un 6- en un movimiento y marcas XP, puede hacer una pregunta de la lista de *Discernir realidad**. Gana ventaja en tu primer movimiento para actuar sobre la respuesta."
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_DoWorks, DWStats.DW_CHA)
			{
				Tittle = "Realizar un Trabajo Arcano",
				PreCondition = new Consequences{
					MainText = "Cuando realices un trabajo, nombra a cualquier persona que desea *eximir** del efecto y tira +CAR:"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText ="funciona, pero el DJ elige uno:",
					Options = new List<string>
					{
						"Llamas atención no deseada",
						"Efectúas más o menos de lo que pretendías",
						"El efecto es más débil o más fuerte de lo esperado"
					}
				},
				ConsequencesOn10 =new Consequences
				{
					MainText ="funciona como se esperaba"
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Works, DWStats.DW_None)
			{
				Tittle = "Trabajos Arcanos",
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_Fascination,
						Tittle = "Fascinación",
						Description = "Dar una actuación sublime manteniendo a tu audiencia en trance"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_Cacophony,
						Tittle = "Cacofonía",
						Description = "Das o tocas una nota potente y terrible. Todos los que la escuchan deben (a su elección): Dejar caer lo que lleven y taparse los oidos o tambalearse encogerse y acobardarse",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_Counterpoint,
						Tittle = "Contrapunto",
						Description = "Entona una nota resonante que ropme los encantamientos sobre aquellos que la escuchan.",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_SweetWords,
						Tittle = "Palabras dulces",
						Description = "Recitas un verso halagador; tu audiencia piensa bien de ti hasta que le den una razón para no hacerlo.",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_HeartStrings,
						Tittle = "Cuerdas del Corazón",
						Description = "Nombra una emoción fuerte (amor, miedo, odio, esperanza, desesperación, etc.) y canta una canción para evocarlo; esta hincha en los corazones de tu audiencia",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_Lulaby,
						Tittle = "Canción de cuna",
						Description = "Canta o susurra palabras tranquilizadoras. Los que te oyen se adormecen y luego se duermen.",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_Rapsody,
						Tittle = "Rapsodia",
						Description = "Canta un cuento o canción para inspirar; los aliados que lo escuchan tienen *1punto** que pueden gastar para ganar ventaja en una tirada.",
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Bard_Works_WarSong,
						Tittle = "Canción de guerra",
						Description = "Canta un himno desafiante. Mientras tu persistas, los aliados que lo escuchen ignoran el miedo y la duda.",
					}
				}
			},


			new DWMove (DWMovementIDs.DW_Barb_Adv_Parry, DWStats.DW_None)
			{
				Tittle = "Parada de duelista",
				PreCondition = new Consequences{
					MainText = "+2 de armadura mientras haces Saja-Raja"
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Adv_MoreWorks, DWStats.DW_None)
			{
				Tittle = "Repertorio ampliado",
				PreCondition = new Consequences{
					MainText = "Aprende 2 trabajos arcanos más."
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Adv_Cute, DWStats.DW_None)
			{
				Tittle = "Irresistible",
				PreCondition = new Consequences{
					MainText = "Siempre puedes preguntar si un PNJ te encuentra atractivo (la respuesta es usualmente sí). Tienes ventaja para *Parlamentar** con él."
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Adv_Party, DWStats.DW_None)
			{
				Tittle = "Alma de la fiesta",
				PreCondition = new Consequences{
					MainText = "Cuando *ayudas a alguien a recuperarse animándolo**, él no necesita gastar Suministros. Cuando *haces campamento** e intentas mejorar el animo de todo el grupo, todos (y tú) eligen un beneficio adicional de la lista."
				}
			},
			new DWMove (DWMovementIDs.DW_Barb_Adv_SilverTonge, DWStats.DW_None)
			{
				Tittle = "Lengua de plata",
				PreCondition = new Consequences{
					MainText = "Cuando usas palabras para evitar sospechas o problemas, tira +CAR"
				},
				ConsequencesOn79 = new Consequences{ MainText = "1 punto"},
				ConsequencesOn10 = new Consequences
				{
					MainText = "3 puntos. Puede gastarlos, 1 por 1, para:",
					Options = new List<string>
					{
						"Moverte o maniobrar sin problemas",
						"Resiste al cuestionamiento directo",
						"Redirecciona la sospecha a otra parte"
					}
				}
			},


			new DWMove (DWMovementIDs.DW_Cleric_Spells, DWStats.DW_None)
			{
				Tittle = "Hechizos (5 preparados)",
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Light,
						Tittle = "Luz",
						Description = "conjuras una luz mágica. Te sigue hasta que lo descartas o lanzas otro hechizo."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Santify,
						Tittle = "Santificar",
						Description = "consagras comida o bebida, es purificada de venenos, maldiciones o enfermedad"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Bless,
						Tittle = "Bendecir",
						Description = "Nombra un aliado (tú no), mientras sigua luchando y aguantando él tiene ventaja y tú desventaja para lanzar otro hechizo"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_CureWounds,
						Tittle = "Curar heridas",
						Description = "Toca a alguien. Él gana 5PG y curas cualquier herida problemáticas."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Weapon,
						Tittle = "Arma sagrada",
						Description = "El arma que empuñas está bendita hasta que la sueltes. Ganas ventaja al daño y desventaja para lanzar otros Hechizos"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_SpeakDead,
						Tittle = "Hablar con los muertos",
						Description = "Toca un cadáver, su espíritu te responde tres preguntas honestamente."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Santuary,
						Tittle = "Santuario",
						Description = "Camina un perímetro; hasta que lo abandones, tú y todo lo que hay dentro están protegidos contra adivinación y de los ojos de los espíritus, y sabrás cuándo cualquiera entra en el área con intenciones hostiles"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_Spells_Push,
						Tittle = "Empujar el mal",
						Description = "Muestra un símbolo. Enemigos de tu dios (a tu elección) son mantenidos a raya, aquellos más débiles huyen mientras lo muestras"
					},
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_CastSpell, DWStats.DW_INT)
			{
				Tittle = "Lanzar un hechizo",
				PreCondition = new Consequences{
					MainText = "Cuando lanzas un hechizo que has preparado, tira +INT"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "lo lanzas, pero eliges 1:",
					Options = new List<string>
					{
						"Explícanos como la realidad se retuerce y marca -1 (acumulativo) para *lanzar un hechizo**",
						"Pierdes el hechizo después de lanzarlo",
						"Pierdes un favor",
						"Llamas atención no deseada o pones en peligro",
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_PrepareSpell, DWStats.DW_None)
			{
				Tittle = "Preparar hechizos",
				PreCondition = new Consequences{
					MainText = "Cuando *pasas una hora+ en comunión con tu Dios**:",
					Options = new List<string>
					{
						"Eliminar cualquier penalización por lanzar un hechizo",
						"Repón hasta 5 de tus hechizos"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_Favor, DWStats.DW_None)
			{
				Tittle = "Favor Divino",
				PreCondition = new Consequences{
					MainText = "Empiezas a jugar con Favor. Cuando gastas tu Favor para invocar a tu dios para que te guíe, muestra su voluntad a través de señales y presagios. Tú y tus aliados obtenéis ventaja en el siguiente Movimiento que cada uno haga para actuar en la voluntad de su dios."
				}
			},

			new DWMove (DWMovementIDs.DW_Cleric_Adv_Intervention, DWStats.DW_None)
			{
				Tittle = "Intervención divina",
				PreCondition = new Consequences{
					MainText = "Puedes *gastar tu Favor** cuando tú o un aliado sufre daño. Si lo haces, el daño es negado por una manifestación del dominio de tu dios."
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_Adv_Balance, DWStats.DW_None)
			{
				Tittle = "Balanzas de Vida y de Muerte",
				PreCondition = new Consequences{
					MainText = "Cuando alguien en su presencia (incluido tú) toma su último aliento, tienen ventaja."
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_Adv_Serenity, DWStats.DW_None)
			{
				Tittle = "Serenidad",
				PreCondition = new Consequences{
					MainText = "Cuando lanzas un hechizo, puedes ignorar una penalización de -1X a causa de desventajas."
				}
			},
			new DWMove (DWMovementIDs.DW_Cleric_Adv_MoreSpells, DWStats.DW_None)
			{
				Tittle = "Nuevos Hechizos",
				PreCondition = new Consequences{
					MainText = "Cuando tomas este movimineto y cada vez que usas *preparar hechizos** preparas 6 en lugar de 5."
				},
				HasSubMovements = true,
				SelectableOptions= new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_AdvSpells_Dispell,
						Tittle= "Disipar Magia",
						Description = "Elige un hechizo o efecto mágico cercano; se disipa o (si la magia es potente) se suprime en tu presencia."
					},new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_AdvSpells_Stop,
						Tittle= "Persona detenida",
						Description = "nombra a un enemigo que puedas ver. Se mantiene inmóvil hasta que se le haga daño o dejes su presencia."
					},new SubMovement
					{
						ID = DWMovementIDs.DW_Cleric_AdvSpells_See,
						Tittle= "Ver Verdadero",
						Description = "Atraviesas toda ilusión y falsedad, pero tienes desventaja para lanzar un hechizo."
					}
				}
			},

			new DWMove (DWMovementIDs.DW_Druid_ShapeShifter, DWStats.DW_CON)
			{
				Tittle = "Cambia formas",
				PreCondition = new Consequences{
					MainText = "Cuando *tomas prestada la forma de una bestia natural, una nativa de tu tierra natal**, nómbrala y tira +CON:\r\n\r\nMientras estás en tu forma prestada, tienes su armadura innata, cualidades, etiquetas y habilidades, pero usa tus propias estadísticas (podrías ser un buey, y fuerte como un buey, pero tiras tu FUE para ver cómo manejas esa fuerza).\r\n\r\nCuando actúas en contra de los instintos o la naturaleza de tu forma prestada, estás Desafiando el Peligro con SAB"
				},
				ConsequencesOn10 = new Consequences{MainText="permaneces en esa forma hasta que decidas volver a cambiar o asumir otro;"},
				ConsequencesOn79 = new Consequences{MainText="pierdes tu forma prestada la primera vez que tires un 6- (además de lo que diga el DJ), o antes si así lo desea"},
				ConsequencesOn6 = new Consequences{MainText="los instintos de la forma\r\nson particularmente fuertes (ver más abajo) y estás\r\natrapado en esa forma hasta que te calmes y\r\ntómese el tiempo para dejar la forma a un lado\r\n"}
			},
			new DWMove (DWMovementIDs.DW_Druid_SecretLanguage, DWStats.DW_WIS)
			{
				Tittle = "Lengua secreta",
				PreCondition = new Consequences{
					MainText = "Puedes comunicarte con bestias naturales, espíritus\r\nde la naturaleza, y otros que hablan La Lengua.\r\nCuando parlamentes usando la lengua secreta, tire\r\ncon SAB en lugar de CAR."
				}
			},
			new DWMove (DWMovementIDs.DW_Druid_TouchedBySpirit, DWStats.DW_None)
			{
				Tittle = "Tocado por el espíritu",
				PreCondition = new Consequences{
					MainText = "Siempre puedes preguntarle al DJ \"¿Qué espíritus están activos aquí? "
				}
			},
			new DWMove (DWMovementIDs.DW_Druid_Comunion, DWStats.DW_None)
			{
				Tittle = "Comunión",
				PreCondition = new Consequences{
					MainText = "Cuando realizas un pequeño ritual y haces una ofrenda de algo que les gustaría (whisky, incienso, sangre, etc.), los espíritus de un lugar se manifiestan, no siempre amistosos, pero al menos curiosos y dispuesto a escucharte.\r\n\r\nCuando te comunicas con el espíritu de una bestia y pides prestada su forma, te pedirá algo. Cumple con su solicitud, y en adelante podrás cambiar de forma en esa bestia, como si fuera nativo de tu patria."
				}
			},

			new DWMove (DWMovementIDs.DW_Druid_Adv_Red, DWStats.DW_None)
			{
				Tittle = "Garras y dientes rojos",
				PreCondition = new Consequences{
					MainText = "Cuando cambias de forma a la de una animal peligroso, haces 1D4 Extra de daño."
				}
			},
			new DWMove (DWMovementIDs.DW_Druid_Adv_Call, DWStats.DW_None)
			{
				Tittle = "Escucha mi llamada",
				PreCondition = new Consequences{
					MainText = "Cuando marcas una debilidad y suplicas a uno de los elementos que te asista, un espíritu elemental se manifestará de forma dramática. Haz tu demanda y Parlamenta como de costumbre, pero notarás que es inconstante y terco, con deseos y necesidades ajenos a las tuyas."
				}
			},
			new DWMove (DWMovementIDs.DW_Druid_Adv_TigerEyes, DWStats.DW_None)
			{
				Tittle = "Ojos de tigre",
				PreCondition = new Consequences{
					MainText = "Cuando marcas una bestia (con pigmento, barro, sangre, etc.), ves a través de sus ojos como si fueran tuyos, sin importar la distancia entre tú y él. Solo un animal puede estar tan marcado a la vez"
				}
			},
			new DWMove (DWMovementIDs.DW_Druid_Adv_BorrowedPowers, DWStats.DW_None)
			{
				Tittle = "Poderes prestados",
				PreCondition = new Consequences{
					MainText = "Cuando convences a un espíritu o a una bestia para que te preste su potencia, pregunta al DJ por uno de sus movimientos. Escríbelo abajo; puedes hacer ese movimiento, una vez, así como así. Solo puedes mantener un movimiento de este tipo a la vez."
				}
			},


			new DWMove (DWMovementIDs.DW_Ranger_Hunt, DWStats.DW_WIS)
			{
				Tittle = "Cazar y rastrear",
				PreCondition = new Consequences{
					MainText = "Cuando *Disciernes realidades** estudiando los signos dejados por criaturas pasajeras, tienes ventaja.\r\n\r\nCuando *sigues el rastro de una criatura**, tira +SAB:"
				},
				ConsequencesOn79 = new Consequences{MainText="sigues el rastro hasta un cambio significativo"},
				ConsequencesOn10 = new Consequences{MainText="También puedes hacer una pregunta"}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Shoot, DWStats.DW_DEX)
			{
				Tittle = "Disparo preparado",
				PreCondition = new Consequences{
					MainText = "Cuando preparas un disparo con calma, inflige daño o tira +DES"
				},
				ConsequencesOn79 = new Consequences{MainText="elige 1"},
				ConsequencesOn10 = new Consequences{MainText="elige 2",
					Options = new List<string>{
						"Ignora la armadura o inflige +1d4 de daño",
						"Aturdirlos, trabarlos o entorpecerlos",
						"Haz que suelten lo que tienen en la mano",
						"No dañas."
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Stealthy, DWStats.DW_None)
			{
				Tittle = "Sigiloso",
				PreCondition = new Consequences{
					MainText = "Cuando *Desafies el peligro**, te *adelantes y explres**  o *Luches como uno** de forma sigilosa. Tienes ventaja. No puedes usar este movimiento si estas sobrecargado"
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_FollowMe, DWStats.DW_None)
			{
				Tittle = "Sígueme",
				PreCondition = new Consequences{
					MainText = "Cuando guías al grupo mientras se aventuran, trate un 7-9 como un 10+."
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Friend, DWStats.DW_None)
			{
				Tittle = "Compañero animal (elije 1)",
				PreCondition = new Consequences{
					MainText = "Tira +Feroz para que hagan Saja-Raja.\r\nTira +Inteligente para que disciernan realidades. Y lo que mejor se ajuste para Desafiar el Peligro. Normalmente SOLO te ayudan."
				},
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Ranger_Friend_Wolf,
						Tittle = "Lobo, sabueso, coyote, hiena o chacal:",
						Description = "Feroz +1, Inteligente +1, Leal +2, 9 HP, d6 daño\r\n• Rastrear por olor • Rodear y acosar a la presa\r\n• Reprimir y tropezar/agitar"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Ranger_Friend_Lince,
						Tittle = "Puma, leopardo, jaguar, guepardo o lince:",
						Description = "Feroz +2, Inteligente +1, Leal +0, 9 HP, d8 daño\r\n• Acechar presas • Trepar, saltar y correr\r\n• Saltar, agarrar y salvaje"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Ranger_Friend_Cat,
						Tittle = "Gato, mono, mapache, zorro o comadreja:",
						Description = "Feroz +0, Inteligente +3, Leal +1, 6 HP, d4 daño\r\n• Deslizarse en algún lugar • Robar algo\r\n• Manipular un objeto • Molestar/distraer"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Ranger_Friend_Bird,
						Tittle = "Gavilán, halcón, águila, búho o ratonero",
						Description = "Feroz +1, Inteligente +2, Leal +1, 6 HP, d6 daño\r\n• Detectar desde lejos • Mirar y observar\r\n• Entrar en picado y arrebatar/dejar caer algo"
					}
				}
			},


			new DWMove (DWMovementIDs.DW_Ranger_Adv_Relatives, DWStats.DW_None)
			{
				Tittle = "Parientes y amigos",
				PreCondition = new Consequences{
					MainText = "Los gruñidos, ladridos, chirridos y llamadas de las criaturas de lo salvaje son para tí como un lenguaje."
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Adv_Naturalist, DWStats.DW_None)
			{
				Tittle = "Naturalista",
				PreCondition = new Consequences{
					MainText = "Cuando *dices conocimiento** sobre lo salvaje o lo natural bestias, tenéis ventaja."
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Adv_HideSun, DWStats.DW_None)
			{
				Tittle = "Ocultar el sol",
				PreCondition = new Consequences{
					MainText = "Cuando tiras con un arco, puedes agotar tu munición (marque el siguiente estado de su arma/munición) antes de tirar. Si es así, elige 1:",
					Options = new List<string>
					{
						"Gana ventaja en tu tirada de daño",
						"Atacar a varios objetivos cerca uno del otro; tira *Disparar** una vez, tira daño para cada uno"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Adv_Horse, DWStats.DW_None)
			{
				Tittle = "Caballo de carga",
				PreCondition = new Consequences{
					MainText = "Aumenta tu carga máxima en 2 y agréguala a tu equipo indefinido."
				}
			},
			new DWMove (DWMovementIDs.DW_Ranger_Adv_Predator, DWStats.DW_None)
			{
				Tittle = "Depredador",
				PreCondition = new Consequences{
					MainText = "Cuando *disciernes realidades**, puedes preguntarte lo siguiente y, cuando actues sobre la respuesta a cualquiera de las preguntas, inflige +1d4 de daño",
					Options = new List<string>
					{
						"¿Quién o qué aquí es la presa más fácil?",
						"¿Cómo es __ débil o vulnerable?"
					}
				}
			},

			new DWMove (DWMovementIDs.DW_Fighter_Blind, DWStats.DW_None)
			{
				Tittle = "Blindado",
				PreCondition = new Consequences{
					MainText = "Cuando uses armadura, ignora la etiqueta de torpe."
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Bend, DWStats.DW_STR)
			{
				Tittle = "Curvar barras, levantar puertas",
				PreCondition = new Consequences{
					MainText = "Cuando *uses la fuerza bruta para superar un obstáculo inanimado**, tira +FUE."
				},
				ConsequencesOn79 = new Consequences{MainText = "¡OH, SÍ! pero elige 2"},
				ConsequencesOn10 = new Consequences
				{
					MainText="¡OH, SÍ! pero elige 1",
					Options = new List<string>
					{
						"Se tarda un poco",
						"Causas daños o perjuicios no deseados",
						"Haces mucho ruido",
						"Marcar una debilidad"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Hard, DWStats.DW_CON)
			{
				Tittle = "Difícil de matar",
				PreCondition = new Consequences{
					MainText = "Cuando tomas tu *último aliento**, puedes elegir tirar +CON en lugar de +nada. Con 12+, inmediatamente recuperas 1 HP."
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Fright, DWStats.DW_CHA)
			{
				Tittle = "Intimidante",
				PreCondition = new Consequences{
					MainText = "Cuando *parlamentas usando violencia o amenazas**, tienes ventaja."
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Expert, DWStats.DW_None)
			{
				Tittle = "Especializaciones de armas",
				PreCondition = new Consequences{
					MainText = "Elije 2"
				},
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Sword,
						Tittle="Espada",
						Description ="cuando te defiendes con una y gastas puntos para devolver el golpe a un atacante, inflige daño normalmente (sin desventaja)"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Maze,
						Tittle="Maza",
						Description ="daño +1 (+2 en total) y es contundente "
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Mayal,
						Tittle="Mayal",
						Description ="con 12+, enemigo es derribado o desarmado "
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Axe,
						Tittle="Hacha",
						Description ="daño +1 (+2 en total) y es escabroso "
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Hammer,
						Tittle="Martillo",
						Description ="con 12+, enemigo se tambalea y aturde o su armadura se reduce en 1 (a elección del DJ)"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Spear,
						Tittle="Lanza",
						Description ="tienes 2 perforaciones (ignora 2 armaduras)"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Pole,
						Tittle="Asta",
						Description ="con un 12+, en lugar de elegir, infliges 1d6 de daño adicional y evitas el ataque del enemigo"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Fighter_Expert_Knife,
						Tittle="Daga o un cuchillo",
						Description ="mientras agarras a tu enemigo, ignoras su armadura a menos que sea amorfa"
					},

				}
			},

			new DWMove (DWMovementIDs.DW_Fighter_Adv_IronSkin, DWStats.DW_None)
			{
				Tittle = "Piel de hierro",
				PreCondition = new Consequences{
					MainText = "Obtienes +1 armadura, siempre (acumulable)."
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Adv_Relentless, DWStats.DW_None)
			{
				Tittle = "Despiadado",
				PreCondition = new Consequences{
					MainText = "Cuando *luchas para matar sin piedad ni vacilación**, tienes ventaja para infligir daño."
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Adv_Conscient, DWStats.DW_None)
			{
				Tittle = "Plenamente consciente",
				PreCondition = new Consequences{
					MainText = "Cuando *comience una pelea**, hazle al DJ una pregunta que podrías hacer con *discernir la realidad** y obtén ventaja para actuar según la respuesta\r\n\r\n Cuando uses *discernir la realidad**, agrega a la lista de preguntas que puede hacer:",
					Options = new List<string>
					{
						"¿Cuál es la realidad de mi enemigo?",
						"¿Quién o qué aquí es la mayor amenaza?",
						"¿Cuál es la mejor manera de  entrar/salir/pasar/cruzar?"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Adv_Cold, DWStats.DW_None)
			{
				Tittle = "Frío como el hielo",
				PreCondition = new Consequences{
					MainText = "Cuando haces algo *manteniendo la calma** y continuando, trata un 6- como un 7-9"
				}
			},
			new DWMove (DWMovementIDs.DW_Fighter_Adv_IronEyes, DWStats.DW_None)
			{
				Tittle = "Mirada de acero",
				PreCondition = new Consequences{
					MainText = "Cuando te *defiendes**, puedes gastar 1 punto para mirar a los ojos a un enemigo y obligarlo a mantenerte la mirada. Tiene desventaja en las tiradas de daño contra ti y tu defendido"
				}
			},

			new DWMove (DWMovementIDs.DW_Thief_Backstab, DWStats.DW_DEX)
			{
				Tittle = "Puñalada por la espalda",
				PreCondition = new Consequences{
					MainText = "Cuando *atacas a alguien de cerca y no lo ven venir**, puedes tira +DES"
				},
				ConsequencesOn79 = new Consequences{MainText="Elije 1"},
				ConsequencesOn10 = new Consequences{MainText="Elije 2",
					Options = new List<string>
					{
						"Inflige +1d4 de daño",
						"Golpea un punto débil, ignorando su armadura",
						"No pueden hacer ruido ni dar la alarma",
						"Te escapas antes de que puedan reaccionar",
						"Creas una oportunidad; tú o un aliado gana ventaja si actúan en consecuencia"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Thief_DangerSense, DWStats.DW_INT)
			{
				Tittle = "Sentir el peligro",
				PreCondition = new Consequences{
					MainText = "Siempre puedes preguntarle al DJ: “¿Hay una emboscada o una trampa aquí?” Si dice “sí”, tira +INT"
				},
				ConsequencesOn79 = new Consequences{MainText="Elije 1"},
				ConsequencesOn10 = new Consequences{MainText="Elije 2",
					Options = new List<string>
					{
						"¿Qué activará la trampa o la emboscada?",
						"¿Qué sucederá una vez que se active?"
					}
				},
				ConsequencesOn6 = new Consequences{MainText="no marque XP, pero todavía no sucede nada malo."}
			},
			new DWMove (DWMovementIDs.DW_Thief_Stealth, DWStats.DW_None)
			{
				Tittle = "Sigilo y escóndete en las sombras",
				PreCondition = new Consequences{
					MainText = "Cuando *desafías el peligro**, *exploras hacia adelante** o *luchas como uno** siendo sigiloso, tienes ventaja. No puedes usar este movimiento si estás cargado."
				}
			},
			new DWMove (DWMovementIDs.DW_Thief_Tricks , DWStats.DW_DEX)
			{
				Tittle = "Trucos del oficio",
				PreCondition = new Consequences{
					MainText = "Cuando *abres cerraduras o bolsillos o desactivas trampas**, tira +DES:"
				},
				ConsequencesOn10 = new Consequences{MainText = "lo haces, no hay problema"},
				ConsequencesOn79 = new Consequences{MainText = "lo haces, pero el DJ te ofrecerá dos opciones entre sospecha, peligro o coste"}
			},
			new DWMove (DWMovementIDs.DW_Thief_Poison, DWStats.DW_None)
			{
				Tittle = "Venenos",
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Tagit,
						Tittle = "Aceite de Tagit",
						Description = "hacer que lo ingieran o pincharlos con él; caen en un sueño ligero"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Bloodweed,
						Tittle = "Hierba sangrienta",
						Description = "pincharlos con ella; tienen desventaja en las tiradas de daño hasta que se curan"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Eldercry,
						Tittle = "Lamento de anciano",
						Description = "haz que lo ingieran; no recordarán la última hora ni la próxima"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Goldenroot,
						Tittle = "Goldenroot",
						Description = "haz que lo ingieran; tratarán a la próxima persona que vean como un aliado de confianza hasta que se demuestre lo contrario"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Moonkiss,
						Tittle = "Moonkiss",
						Description = "haz que lo inhalen; se confunden y alucinan durante las próximas horas"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Snake,
						Tittle = "Lágrimas de serpiente",
						Description = "cubra un arma afilada con ella; la siguiente herida que inflige quema dolorosamente y recibe 2d4 de daño unos segundos después"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Thief_Poison_Widow,
						Tittle = "Leche de viuda",
						Description = "hacer que la ingieran; se enferman durante la siguiente hora, quedan incapacitados en unas pocas horas y mortalmente enfermos en un día; si no se trata, es fatal"
					},
				}
			},

			new DWMove (DWMovementIDs.DW_Thief_Adv_Feline , DWStats.DW_None)
			{
				Tittle = "Felino",
				PreCondition = new Consequences{
					MainText = "Cuando *no tienes problemas ni sobrecarga**, impones una desventaja en cualquier daño que recibas y que puedas esquivar o rodar"
				}
			},
			new DWMove (DWMovementIDs.DW_Thief_Adv_Trickster , DWStats.DW_INT)
			{
				Tittle = "Aficionado a la magia",
				PreCondition = new Consequences{
					MainText = "Cuando *juegues con un dispositivo mágico**, tira +INT"
				},
				ConsequencesOn79 = new Consequences{MainText ="lo activas, pero solo esta vez"},
				ConsequencesOn10 = new Consequences{MainText="descubres cómo activarlo de manera confiable"}
			},
			new DWMove (DWMovementIDs.DW_Thief_Adv_Door , DWStats.DW_INT)
			{
				Tittle = "Ojo en la puerta",
				PreCondition = new Consequences{
					MainText = "Cuando tú y tus aliados *necesiten salir de aquí**, nombra tu ruta de escape y tira +INT"
				},
				ConsequencesOn79 = new Consequences{MainText ="puedes quedarte o irte, pero si te vas, te cuesta: el DJ te dirá qué (o a quién) dejas atrás o te llevas contigo"},
				ConsequencesOn10 = new Consequences{MainText="te has ido"}
			},
			new DWMove (DWMovementIDs.DW_Thief_Adv_Dirty , DWStats.DW_None)
			{
				Tittle = "Lucha sucia",
				PreCondition = new Consequences{
					MainText = "Cuando *apuñalas por la espalda**, gana ventaja en tu tirada de daño."
				}
			},
			new DWMove (DWMovementIDs.DW_Thief_Adv_Cheater , DWStats.DW_None)
			{
				Tittle = "Tramposo",
				PreCondition = new Consequences{
					MainText = "Cuando *desafías el peligro siendo engañoso**, trata un 7-9 como un 10+.\r\n\r\nCuando otro jugador Discierne Realidades o usa Parlamentar contigo, no necesitas ser honesto con tus respuestas"
				}
			},

			new DWMove (DWMovementIDs.DW_Wizard_Spells, DWStats.DW_None)
			{
				Tittle = "Hechizos (5 preparados)",
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Light,
						Tittle = "Luz",
						Description = "conjuras una luz mágica. Te sigue hasta que lo descartas o lanzas otro hechizo."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Enchant,
						Tittle = "Encantar",
						Description = "Míralos a los ojos,te tratarán como a un amigo hasta que demuestres lo contrario o sufran daños"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Spirits,
						Tittle = "Contactar con espíritus",
						Description = "Un espíritu se manifestará ante ti, está obligado a responder con veracidad a una pregunta que le formules"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Invisible,
						Tittle = "Invisibilidad",
						Description = "Toca a alguien; ¡son invisibles! Dura hasta que atacan o lanzas algún hechizo"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Misil,
						Tittle = "Misil Mágico",
						Description = "2d4 a un objetivo que puedas ver"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Mimic,
						Tittle = "Mímica",
						Description = "Tomas la apariencia de alguien a quien tocas. Pierdes poderes de mago mientras dure el efecto"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Telepathy,
						Tittle = "Telepatía",
						Description = "Toca a alguien, compartes sus sentimientos y puedes hablar de mente a mente. -1 para realizar otros hechizos mientras dure el efecto"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_CastSpell, DWStats.DW_INT)
			{
				Tittle = "Lanzar un hechizo",
				PreCondition = new Consequences{
					MainText = "Cuando lanzas un hechizo que has preparado, tira +INT"
				},
				ConsequencesOn79 = new Consequences
				{
					MainText = "lo lanzas, pero eliges 1:",
					Options = new List<string>
					{
                        "Explícanos como la realidad se retuerce y marca -1 (acumulativo) para *lanzar un hechizo**",
                        "Pierdes el hechizo después de lanzarlo",
                        "Llamas atención no deseada o pones en peligro",
                    }
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_PrepareSpell, DWStats.DW_None)
			{
				Tittle = "Preparar hechizos",
				PreCondition = new Consequences{
					MainText = "Cuando *pasas una hora o más tranquilamente estudiando tu libro de hechizos**:",
					Options = new List<string>
					{
						"Eliminar cualquier penalización por lanzar un hechizo",
						"Repón hasta 5 de tus hechizos"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_Ritual, DWStats.DW_None)
			{
				Tittle = "Ritual",
				PreCondition = new Consequences{
					MainText = "Cuando desees *tejer la magia**, di lo que buscas y cómo planeas hacerlo. El DJ dirá \"Por supuesto, pero...\" y 1-4 de los siguientes. Realiza el ritual y la magia surtirá efecto",
					Options = new List<string>
					{
						"Debes estar en un lugar de poder (como __)",
						"Debes hacerlo en un momento propicio (como __)",
						"Tomará horas/días/semanas",
						"Primero debes __",
						"Necesitarás ayuda de __",
						"Requerirás el sacrificio de __",
						"Lo mejor que puedes hacer es __",
						"Tú/tus aliados os arriesgáis al peligro de __"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_Adv_Guardian, DWStats.DW_None)
			{
				Tittle = "Guardián Arcano",
				PreCondition = new Consequences{
					MainText = "Mientras tengas al menos 2 hechizos preparados, tienes 2 Armadura."
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_Adv_Detect, DWStats.DW_None)
			{
				Tittle = "Detectar mágia",
				PreCondition = new Consequences{
					MainText = "Cuando *disciernes realidades**, puedes preguntarte \"¿Qué es mágico aquí? gratis, incluso en un 6-."
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_Adv_Logic, DWStats.DW_INT)
			{
				Tittle = "Lógica",
				PreCondition = new Consequences{
					MainText = "Cuando *disciernes realidades a través de una observación detallada y la deducción**, tira INT en lugar de SAB."
				}
			},
			new DWMove (DWMovementIDs.DW_Wizard_Adv_MoreSpells, DWStats.DW_None)
			{
				Tittle = "Nuevos Hechizos",
				PreCondition = new Consequences{
					MainText = "Requiere al menos OTRO avance. Agrega a tu libro de hechizos:"
				},
				HasSubMovements = true,
				SelectableOptions= new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_AdvSpells_Dispell,
						Tittle= "Disipar Magia",
						Description = "Elige un hechizo o efecto mágico cercano; se disipa o (si la magia es potente) se suprime en tu presencia."
					},new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_AdvSpells_Fireball,
						Tittle= "Bola de fuego",
						Description = "inflige 2d6 de daño (ignora la armadura) a un objetivo y todo lo que esté cerca."
					},new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_AdvSpells_Sleep,
						Tittle= "Dormir",
						Description = "Di una palabra y tira 1d8+INT. Ese número de los enemigos que escucharon tu palabra se quedaron dormidos (la elección del DJ en cuanto a cuál)."
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Obliged, DWStats.DW_None)
			{
				Tittle = "Obligado por una ley superior",
				PreCondition = new Consequences{
					MainText = "Marca 3 juramentos. Cuando violes uno de ellos, elige dos de tus movimientos de paladín. Pierdes esos movimientos hasta que te expíes; (pregúntale al DJ)"
				},
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_Cheat,
						Description = "No haré trampas, no mentiré ni engañaré con mis palabras"
					},
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_Protect,
						Description = "Protegeré a los débiles y ayudaré a cualquier inocente quien me lo pida"
					},
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_Crime,
						Description = "No dejaré que un crimen quede impune"
					},
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_RunAway,
						Description = "No huiré, ni negaré un llamado a la batalla"
					},
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_Misery,
						Description = "Ofreceré misericordia a cualquiera que derrote, incluso al más indigno"
					},
					new SubMovement
					{
						ID= DWMovementIDs.DW_Paladin_Oblige_Superior,
						Description = "Nunca rechazaré la orden de un superior"
					},
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Grace, DWStats.DW_CHA)
			{
				Tittle = "Gracia divina",
				PreCondition = new Consequences{
					MainText = "Cuando *Defiendes**, tira +CAR en lugar de +CON. Además de las opciones habituales, puedes gastar tus puntos en:",
					Options = new List<string>
					{
						"todos los demonios y no muertos retroceden.",
						"mantén tu posición a pesar de lo que pase"
					}
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Eyes, DWStats.DW_None)
			{
				Tittle = "ojos despejados",
				PreCondition = new Consequences{
					MainText = "Cuando oras pidiendo guía, aunque sea por un momento, puedes preguntarle al DJ \"¿qué es el mal aquí?\" y obtén una respuesta honesta"
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_NoFear, DWStats.DW_None)
			{
				Tittle = "Inmune al miedo",
				PreCondition = new Consequences{
					MainText = "Cuando tires para resistir o actuar a pesar del miedo, no tires; automáticamente tienes un 10+."
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Hurt, DWStats.DW_STR)
			{
				Tittle = "Herir",
				PreCondition = new Consequences{
					MainText = "Cuando golpees una cosa de maldad sobrenatural, tira +FUE. Haz daño y elige 1",
					Options= new List<string>
					{
						"Inflige +1d6 de daño",
						"Ignorar la armadura de la cosa u otras defensas",
						"Suprimir uno de sus poderes antinaturales",
						"Expulsarlo de su anfitrión"
					}
				},
				ConsequencesOn79 = new Consequences{MainText="también te expones a daño o atención no deseada"}
			},

			new DWMove (DWMovementIDs.DW_Paladin_Adv_Aura, DWStats.DW_None)
			{
				Tittle = "Aura de coraje",
				PreCondition = new Consequences{
					MainText = "Cuando te mantienes firme en la batalla, a aquellos aliados que pueden verte o escucharte no les afectan ni el miedo o la duda"
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Adv_Charge, DWStats.DW_None)
			{
				Tittle = "A la Carga!",
				PreCondition = new Consequences{
					MainText = "Cuando tú y quien te siga cargáis hacia la batalla, obtenéis +1 de armadura e infligís +1d4 de daño en el intercambio inicial"
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Adv_Defender, DWStats.DW_None)
			{
				Tittle = "Defensor acérrimo",
				PreCondition = new Consequences{
					MainText = "Cuando *Defiendes**, tienes +1 puntos. Incluso con un 6-, tienes 1 punto."
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Adv_Walk, DWStats.DW_None)
			{
				Tittle = "Paseo por el valle",
				PreCondition = new Consequences{
					MainText = "No te afectan los venenos ni las enfermedades."
				}
			},
			new DWMove (DWMovementIDs.DW_Paladin_Adv_Window, DWStats.DW_WIS)
			{
				Tittle = "Ventana al alma",
				PreCondition = new Consequences{
					MainText = "Cuando mires a los ojos de otro, tira +SAB. Mientras estés en su presencia, gasta puntos que consigas, 1-por-1, para preguntar a su jugador/el DJ",
					Options = new List<string>
					{
						"¿Están mintiendo o tratando de engañarme?",
						"¿Qué están sintiendo realmente?",
						"¿Qué pecado domina en su corazón?"
					}
				},
				ConsequencesOn10 = new Consequences{ MainText = "Consigues 2 puntos"},
				ConsequencesOn79 = new Consequences{MainText = "Consigues 1 punto"}
			},

			new DWMove (DWMovementIDs.DW_Wielder_Valor, DWStats.DW_None)
			{
				Tittle = "Valor",
				PreCondition = new Consequences{
					MainText = "Cuando *desafías el peligro corriendo, saltando, trepando, o dando tumbos**, tienes ventaja. No puedes usar este movimiento si estás Cargado"
				}
			},
			new DWMove (DWMovementIDs.DW_Wielder_Measure, DWStats.DW_None)
			{
				Tittle = "Tomarle las medidas",
				PreCondition = new Consequences{
					MainText = "Cuando te tomas un momento para evaluar a un PNJ, puedes preguntar al DJ \"¿Qué van a hacer?\" y obtener una respuesta honesta."
				}
			},
			new DWMove (DWMovementIDs.DW_Wielder_Weapon, DWStats.DW_None)
			{
				Tittle = "Tu arma",
				PreCondition = new Consequences{
					MainText = "Elije 1, no cuenta para la carga."
				},
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_Crom,
						Tittle="Crom Faeyr",
						Description="martillo de los reyes enanos\r\n(+1d4 de daño, contundente, ruidoso)\r\nCuando sacas 12+ a Saja-Raja retumba como un trueno, los aturde, y los manda a volar\r\n"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_EbonyBlade,
						Tittle="Ebony Blade",
						Description="una espada pesada de color negro azabache (+1 daño, escabrosa) Cuando matas una criatura viva con esta espada, recuperas 1d4 PG"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_IronFang,
						Tittle="Ironfang",
						Description="una lanza adornada de acero negro\r\n(+1 daño, alcance, lanzado) Cuando disparas con esta lanza, puedes usar FUE en lugar de DES. cuando así lo desees, la lanza vuela segura hacia tu mano abierta.\r\n"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_Meofainn,
						Tittle="Meofainn",
						Description="un hacha templada en sangre de dragón (+1 daño, escabrosa, contundente, 3 perforante) Esta hacha corta la madera como si fuera arcilla, la piedra como si fuera era madera, y acero como si fuera piedra. Cuando tiras 12+ a Saja-Raja con este hacha, destruyes algo que usan o vistan."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_Sindarin,
						Tittle="Sindarin",
						Description=", una hoja delgada como una luna creciente (+1 daño, ignora la armadura) Cuando S-R con esta cuchilla, puedes usar DES en lugar de FUE. Su borde puede cortar incluso espíritus o enemigos insustanciales."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wielder_Weapon_Urawhu,
						Tittle="Urawhu",
						Description="una hoja con púas en una larga cadena de plata (+1 daño, alcance, lanzado) Cuando S-R, puedes usar DES en lugar de FUE. con 12+ en S-R o Disparar con Urawhiu, describe cómo atrapas, haces tropezar o desarmas tu enemigo"
					},
				}
			},

			new DWMove (DWMovementIDs.DW_Wielder_Adv_Keep, DWStats.DW_None)
			{
				Tittle = "Sigue luchando!",
				PreCondition = new Consequences{
					MainText = "Cuando se reduciría a 0 PG, puedes elegir marcar una debilidad en su lugar."
				}
			},
			new DWMove (DWMovementIDs.DW_Wielder_Adv_Pain, DWStats.DW_None)
			{
				Tittle = "Siente el dolor!",
				PreCondition = new Consequences{
					MainText = "Cuando manejas Tu arma y luchas para matar, tira el daño con ventaja."
				}
			},
			new DWMove (DWMovementIDs.DW_Wielder_Adv_Voices, DWStats.DW_CHA)
			{
				Tittle = "Voces",
				PreCondition = new Consequences{
					MainText = "Cuando *consultes a los espíritus atados a Tu Arma**, tira +CAR"
				},
				ConsequencesOn79 = new Consequences{MainText ="darán una idea de la situación, pero elije 1:",
					Options = new List<string>
					{
						"La percepción es vaga, críptica o incompleta",
						"Te exigen algo"
					}
				},
				ConsequencesOn10 = new Consequences{MainText="te dan una información clara y útil sobre la situación, pero podría hacer algunas preguntas a cambio"}
			},
			new DWMove (DWMovementIDs.DW_Wielder_Adv_Power, DWStats.DW_CHA)
			{
				Tittle = "Pozo de poder",
				PreCondition = new Consequences{
					MainText = "Elige un hechizo del libreto de mago o clérigo: Cuando uses Tu arma para lanzar este hechizo, tira +CAR"
				},
				ConsequencesOn10 = new Consequences{MainText="el hechizo funciona"},
				ConsequencesOn79 = new Consequences
				{
					MainText = "funciona, pero elige 1",
					Options =new List<string>
					{
						"Te pones en peligro a ti mismo, a un aliado o a un inocente",
						"Recibes una penalización continua de -1 (acumulativa) para usa este movimiento hasta que hagas Campamento"
					}
				},
				HasSubMovements = true,
				SelectableOptions = new List<SubMovement>
				{
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Light,
						Tittle = "Luz",
						Description = "conjuras una luz mágica. Te sigue hasta que lo descartas o lanzas otro hechizo."
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Enchant,
						Tittle = "Encantar",
						Description = "Míralos a los ojos,te tratarán como a un amigo hasta que demuestres lo contrario o sufran daños"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Spirits,
						Tittle = "Contactar con espíritus",
						Description = "Un espíritu se manifestará ante ti, está obligado a responder con veracidad a una pregunta que le formules"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Invisible,
						Tittle = "Invisibilidad",
						Description = "Toca a alguien; ¡son invisibles! Dura hasta que atacan o lanzas algún hechizo"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Misil,
						Tittle = "Misil Mágico",
						Description = "2d4 a un objetivo que puedas ver"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Mimic,
						Tittle = "Mímica",
						Description = "Tomas la apariencia de alguien a quien tocas. Pierdes poderes de mago mientras dure el efecto"
					},
					new SubMovement
					{
						ID = DWMovementIDs.DW_Wizard_Spells_Telepathy,
						Tittle = "Telepatía",
						Description = "Toca a alguien, compartes sus sentimientos y puedes hablar de mente a mente. -1 para realizar otros hechizos mientras dure el efecto"
					}
				}
			},

			new DWMove (DWMovementIDs.DW_ALL_Adv_ImproveStat1, DWStats.DW_None)
			{
				Tittle = "Mejorar característica",
				PreCondition = new Consequences{
					MainText = "Aumenta una de tus estadísticas en +1 (max +2)."
				}
			},
			new DWMove (DWMovementIDs.DW_ALL_Adv_ImproveStat2, DWStats.DW_None)
			{
				Tittle = "Mejorar característica",
				PreCondition = new Consequences{
					MainText = "Aumenta una de tus estadísticas en +1 (max +2)."
				}
			},
			new DWMove (DWMovementIDs.DW_ALL_Adv_SuperiorStat, DWStats.DW_None)
			{
				Tittle = "Característica superior",
				PreCondition = new Consequences{
					MainText = "Requiere: mejorar característica y al menos otro avance\r\nAumenta una de tus estadísticas en +1(max +3)."
				}
			},

			new DWMove (DWMovementIDs.DW_RawSTR, DWStats.DW_STR)
			{
				Tittle = "Fuerza"
			},
			new DWMove (DWMovementIDs.DW_RawDEX, DWStats.DW_DEX)
			{
				Tittle = "Destreza"
			},
			new DWMove (DWMovementIDs.DW_RawCON, DWStats.DW_CON)
			{
				Tittle = "Constitución"
			},
			new DWMove (DWMovementIDs.DW_RawINT, DWStats.DW_INT)
			{
				Tittle = "Inteligencia"
			},
			new DWMove (DWMovementIDs.DW_RawWIS, DWStats.DW_WIS)
			{
				Tittle = "Sabiduria"
			},
			new DWMove (DWMovementIDs.DW_RawCHA, DWStats.DW_CHA)
			{
				Tittle = "Carisma"
			}
	};


	public override IMove GetMovement<TMovIDs, TClases>(TMovIDs _ID, TClases _class)
	{
		DWMovementIDs ID = (DWMovementIDs)(object)_ID;

		var m = AllMovements.Find(x => x.ID == ID) ?? new DWMove(DWMovementIDs.DW_NotSet, DWStats.DW_NotSet) { Tittle = "Unknown movement" };
		if (m is not null)
			return m;
		else
			return new DWMove(DWMovementIDs.DW_NotSet, DWStats.DW_NotSet) { Tittle = $"Movimiento {ID.ToUI(this)} no encontrado" };
	}
	public DWMove GetMovement(DWMovementIDs ID)
	{
		return AllMovements.Find(x => x.ID == ID) ?? new DWMove(DWMovementIDs.DW_NotSet, DWStats.DW_NotSet) { Tittle=$"Move {ID.ToString()} cannot be found"};
	}

	public override IMove GetMovement<TMovIDs>(TMovIDs _ID)
	{
		DWMovementIDs ID = (DWMovementIDs)(object)_ID;
		return AllMovements.Find(x => x.ID == ID) ?? new DWMove(DWMovementIDs.DW_NotSet, DWStats.DW_NotSet) { Tittle = "Unknown movement" };
	}
}

