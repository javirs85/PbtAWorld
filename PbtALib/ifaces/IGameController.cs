using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib.ifaces;

public interface IGameController
{
	public event EventHandler UpdateUI;
	public event EventHandler<string> ShowToastEvent;
	public Guid SessionID { get; set; }
	public List<PbtACharacter> Players { get; set; }
	public void Update();
	public List<Monster> MonsterDefinitionsInCurrentScene { get; set; }
	public void AddMonsterDefinition(Monster monster);
	public void RemoveMonsterDefinition(Monster monster);

    public event EventHandler UpdateMasterMoveListRequested;
    public void UpdateMasterMoveList();
	public List<SessionSummary> SessionSummaries { get; set; }
	public Task StoreSessionSummaries();
	public Task LoadSessionSummaries();


	public List<Monster> CurrentSceneEnemies { get; set; }
	public void RollMonsterDamage(Monster m);

	public Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null);

	public void ShowToast(string message);


	public BaseTextBook TextBook { get; set; }

	public People People { get; set; }
	public event EventHandler UpdatePeopleViewerInAllClientsEvent;
	public void UpdatePeopleViewerInAllClients();

	public void ShowImageToAllPlayers(string url);
	public event EventHandler<string> ImageToShowToAllPlayers;
}
