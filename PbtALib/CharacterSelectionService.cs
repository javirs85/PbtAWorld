using PbtALib.ifaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class CharacterSelectorService
{
	public enum SelectionModes { faction, character, none};
	public SelectionModes CurrentMode { get; set; } = SelectionModes.none;
	public event EventHandler<SelectionModes> Show;
	public event EventHandler Hide;
	public event EventHandler ForceUIUpdate;

	public IGameController Game;
	public List<PbtACharacter> Players = new();
	public void SetPeople(IPeopleCast _people) => Game.People = (People)_people;

	TaskCompletionSource<ICharacter> tcs = new();


	public async Task<ICharacter> StartSelection(SelectionModes mode = SelectionModes.character)
	{
		CurrentMode = mode;
		ForceUIUpdate?.Invoke(this, EventArgs.Empty);
		Show(this, SelectionModes.character);
		tcs = new();
		return await tcs.Task;
	}

	public void ForceUIInAllClients()
	{
		ForceUIUpdate?.Invoke(this, EventArgs.Empty);
	}

	public void FinishSelection(ICharacter character)
	{
		if(CurrentMode != SelectionModes.none)
		{
			Hide.Invoke(this, EventArgs.Empty);
			CurrentMode = SelectionModes.none;
			try
			{
				tcs.SetResult(character);
			}
			catch (Exception ex)
			{

			}
		}
	}
}