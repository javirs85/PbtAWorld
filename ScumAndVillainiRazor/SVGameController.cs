using ScumAndVillainy.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PbtALib;
using PbtADBConnector;
using PbtALib.ifaces;
using System.Text.Encodings.Web;
using System.Text.Json;
using ScumAndVillainy;

namespace ScumAndVillainy;

public class SVGameController : GameControllerBase<ScumAndVillainy.SVClasses, SVStats>, IGameController
{
	public event EventHandler OpenSharedRoll;

	public SVShip Ship { get; set; } = new SVShip { ShipType = ShipTypes.NotSet};
	private SVMovesService movesService;

	public SVGameController(SVMovesService moves, IDataBaseController _db, LastRollViewerService _lastRollViewerService) : base(moves, _db, _lastRollViewerService)
	{
		movesService = moves;
		LastRoll = new SVRollReport(moves);
		TextBook = new SVTextBook();
	}

	public async Task StoreShip(string notification)
	{
		var Folder = $"wwwroot/GameImages/{SessionID}";
		
		if (!Path.Exists(Folder))
			Directory.CreateDirectory(Folder);

		var path = $"{Folder}/Ship.json";
		var json = JsonSerializer.Serialize(Ship);

		await File.WriteAllTextAsync(path, json);
		ShowToast(notification);
	}


	public async Task LoadShip()
	{
		var Folder = $"wwwroot/GameImages/{SessionID}";
		var path = $"{Folder}/Ship.json";

		if (File.Exists(path))
		{
			var json = await File.ReadAllTextAsync(path);
			Ship = JsonSerializer.Deserialize<SVShip>(json);
		}
	}

	public override async Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		if (ch is SVCharacter)
		{
			var DWChar = (SVCharacter)ch;
			if (newName != null) { DWChar.Name = newName; }

			await DB.StoreChangesinCharacter(ch.ID, ch.Name, System.Text.Json.JsonSerializer.Serialize(DWChar));
			if (!string.IsNullOrEmpty(notification))
				ShowToastOnAllClients(ch.Name + ": " + notification);
		}
		else
			throw new Exception("tried to store a character that is not DWCharacter at DWGameController");
	}

	protected override void CreateNewRollReport()
	{
		LastRoll = new SVRollReport(movesService);
	}

	public async Task StartShip(ShipTypes type)
	{
		Ship = new SVShip();
		Ship.ShipType = type;
		Ship.InitShip();

		await StoreShip($"Se ha creado un {type.ToUI()}");
	}

	


	public SVRollReport? CurrentRoll;
	public void StartSharedRoll(SVCharacter player, SVStats stat)
	{
		CurrentRoll = new SVRollReport(movesService);
		CurrentRoll.Player = player;
		CurrentRoll.Stat = stat;
		OpenSharedRoll.Invoke(this, EventArgs.Empty);	
	}

	public void UpdateSharedRollInAllClients()
	{
		OpenSharedRoll.Invoke(this, EventArgs.Empty);
	}
}
