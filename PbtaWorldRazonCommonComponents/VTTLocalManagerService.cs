using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtaWorldRazonCommonComponents;

public class VTTLocalManagerService
{
	VTTService service;
    public VTTLocalManagerService(VTTService _service)
    {
        service = _service;
    }


	public Token? SelectedToken = null;

	public event EventHandler UpdateUI;
	public bool IsMaster = false;
	private bool _isIvisible;
	public bool IsVisible	
	{
		get { return _isIvisible; }
		set
		{
			if (_isIvisible != value)
			{
				_isIvisible = value;
				Update();
			}
		}
	}

	public void Show() => IsVisible = true;
	public void Show(PbtACharacter Char)
	{
		IsVisible = true;
		IsMaster = false;
		SelectedToken = service.Tokens.Find(x => x.Character?.ID == Char.ID);
	}

	public event EventHandler CloseRequested;

	public void Hide()
	{
		IsVisible = false;
		Update();
		CloseRequested?.Invoke(this, EventArgs.Empty);
	}

	void Update() => UpdateUI?.Invoke(this, EventArgs.Empty);
}
