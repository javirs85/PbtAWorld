using Blazored.Toast.Services;

namespace UrbanShadows;

public class CharacterSelectionService
{
	public event EventHandler StartSelection;
    public event EventHandler UI_ForceUpdate;
    public event EventHandler UI_Show;
	public event EventHandler UI_Hide;
    public bool IsVisible { get; set; }

	public string HeaderMessage { get; set; } = "";
	public bool AllowExit { get; set; } = true;



    private IToastService Toaster;
	private USGameController Game { get; set; }
	private USCharacterSheet DefaultCharacter;

	public CharacterSelectionService(IToastService _toaster, USGameController _db)
	{
		Toaster = _toaster;
		Game = _db;
	}

    TaskCompletionSource<USCharacterSheet> tcs;
    
	public void Show()
	{
		IsVisible = true;
		UI_Show?.Invoke(this, EventArgs.Empty);
	}

	public void Hide()
	{
		IsVisible = false;
		UI_Hide.Invoke(this, EventArgs.Empty);
	}

	public async Task<USCharacterSheet> SelectViaSelector(string _headerMessage = "", bool _allowExit = true)
	{
		HeaderMessage = _headerMessage;
		AllowExit = _allowExit;

		var _default = Game.Players[0] as USCharacterSheet;
		if(_default != null)
		{
			try
			{
				Show();
				var selected = await SelectViaSelectorInternal();
				Hide();
				return selected;
			}
			catch (OperationCanceledException)
			{
				return _default;
			}
			catch (Exception ex)
			{
				Toaster.ShowError(ex.Message);
				return _default;
			}
		}
		else
		{
			throw new Exception("Game.Players is empty");
		}
    }

	public async Task<USCharacterSheet> SelectViaSelector(USCharacterSheet _default)
	{
		try
		{
			Show();
			var selected = await SelectViaSelectorInternal();
			Hide();
			return selected;
		}
		catch(OperationCanceledException)
		{
            Hide();
            return _default;
		}
		catch (Exception ex)
		{
			Toaster.ShowError(ex.Message);
            return _default;
        }
	}

    private Task<USCharacterSheet> SelectViaSelectorInternal()
    {
		tcs = new TaskCompletionSource<USCharacterSheet>();
        return tcs.Task;
    }

	public void Selected(USCharacterSheet ch)
	{
		tcs.SetResult(ch);
	}
	public void CancelSelection()
	{
		Hide();
		tcs.SetCanceled();
	}

}
