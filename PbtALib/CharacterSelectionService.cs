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

	public IPeopleCast? People = null;
	public List<PbtACharacter> Players = new();
	public void SetPeople(IPeopleCast _people) => People = _people;

	TaskCompletionSource<ICharacter> tcs = new();


	public async Task<ICharacter> StartSelection(SelectionModes mode = SelectionModes.character)
	{
		CurrentMode = mode;
		Show(this, SelectionModes.character);
		tcs = new();
		return await tcs.Task;
	}

	public void FinishSelection(ICharacter character)
	{
		Hide.Invoke(this, EventArgs.Empty);
		CurrentMode = SelectionModes.none;
		try
		{
			tcs.SetResult(character);
		}catch (Exception ex)
		{

		}
		
	}
}