using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib.ifaces;

public interface IGameController
{
	public event EventHandler UpdateUI;
	public void Update();
	public List<Monster> MonsterDefinitionsInCurrentScene { get; set; }
	public List<Monster> CurrentSceneEnemies { get; set; } 
}
