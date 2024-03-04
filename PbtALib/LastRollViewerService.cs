using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class LastRollViewerService
{
	public event EventHandler UpdateNeeded;
	public event EventHandler<AvailableGames> SetGame;
	public event EventHandler ShowOverlay;
	public List<IRollReport> LastRolls = new();

	public void SetGameMode(AvailableGames Game) => SetGame?.Invoke(this, Game);

	public void Show() => ShowOverlay?.Invoke(this, EventArgs.Empty);

	public void Show(IRollReport roll)
	{
		LastRolls.Insert(0, roll);
		if (LastRolls.Count > 5)
			LastRolls.RemoveAt(LastRolls.Count() - 1);

		ShowOverlay?.Invoke(this, EventArgs.Empty);
		//UpdateNeeded?.Invoke(this, EventArgs.Empty);
	}
}
