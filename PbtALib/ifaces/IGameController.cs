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
	public void AddMonsterDefinition(Monster monster);
	public void RemoveMonsterDefinition(Monster monster);

    public event EventHandler UpdateMasterMoveListRequested;
    public void UpdateMasterMoveList();

    public List<Monster> CurrentSceneEnemies { get; set; }
	public void RollMonsterDamage(Monster m);


    public BaseTextBook TextBook { get; set; }

	public void ShowImageToAllPlayers(string url);
	public event EventHandler<string> ImageToShowToAllPlayers;
}
