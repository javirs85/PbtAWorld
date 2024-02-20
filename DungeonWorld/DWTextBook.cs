using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class DWTextBook : BaseTextBook
{
	public List<MasterMove> MasterMoves = new List<MasterMove>{
		new MasterMove("Usa un movimiento de monstruo, peligro o localización"),
		new MasterMove("Revela una verdad incomoda"),
		new MasterMove("Muestra signos de una amenaza que se aproxima"),
		new MasterMove("Hazles daño"),
		new MasterMove("Gasta sus recursos"),
		new MasterMove("Usa su movimiento en su contra"),
		new MasterMove("Sepáralos"),
		new MasterMove("Ofrece una oportunidad que se ajuste a las habilidades de una clase"),
		new MasterMove("Muestra una desventaja de su clase, raza o equipo"),
		new MasterMove("Ofrece una oportunidad con un coste"),
		new MasterMove("Pon a alguien en una situación complicada"),
		new MasterMove("Diles los requerimientos o las consecuencias, y pregunta.")
	};

	public List<MasterMove> MasterDungeonMoves = new List<MasterMove>{
		new MasterMove("Cambia el entorno"),
		new MasterMove("Señala a una amenaza inminente"),
		new MasterMove("Introduce una nueva facción o tipo de criatura"),
		new MasterMove("Usa una característica de una facción que ya exista"),
		new MasterMove("Barra el paso, hazlos retroceder"),
		new MasterMove("Presenta riquezas con su precio"),
		new MasterMove("Presenta un desafío a uno de los PJ")
	};
	public List<MasterMove> MasterFightMotivations = new List<MasterMove>{
		new MasterMove("Matar"),
		new MasterMove("Robar"),
		new MasterMove("Defender"),
		new MasterMove("Capturar"),
		new MasterMove("Retrasar"),
	};

	public MonsterManual Monsters = new MonsterManual();
}
