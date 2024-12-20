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
	public event EventHandler CloseShareRoll;

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
		var position = (LastRoll as SVRollReport).Position; 
		LastRoll = new SVRollReport(movesService);
		(LastRoll as SVRollReport).Position = position;
	}

	public void RollCurrentRoll()
	{
		if(CurrentRoll is not null)
		{
			CurrentRoll.Dices.Clear();
			if(CurrentRoll.TotalDices == 0)
			{
				var a = RollD6();
				var b = RollD6();
				CurrentRoll.Dices.Add(new Tuple<DiceTypes, int>(DiceTypes.d6, a));
				CurrentRoll.Dices.Add(new Tuple<DiceTypes, int>(DiceTypes.d6, b));

				CurrentRoll.Dices = CurrentRoll.Dices.OrderByDescending(x => x.Item2).ToList();

				int useme = CurrentRoll.Dices[1].Item2;

				if (useme >= 6) CurrentRoll.Result = SVRollResult.Success;
				else if (useme >= 4) CurrentRoll.Result = SVRollResult.Mild;
				else CurrentRoll.Result = SVRollResult.Fatal;

				return;
			}

			for (int i = 0; i < CurrentRoll.TotalDices; ++i)
			{
				CurrentRoll.Dices.Add(new Tuple<DiceTypes, int>(DiceTypes.d6, RollD6()));
			}
			bool isCritic = CurrentRoll.Dices.Count(dice => dice.Item2 == 6) >= 2;
			if(isCritic)
			{
				CurrentRoll.Result = SVRollResult.Critic;
				return;
			}

			int maxRoll = CurrentRoll.Dices.Any() ? CurrentRoll.Dices.Max(dice => dice.Item2) : 0;

			if(maxRoll >= 6)
			{
				CurrentRoll.Result = SVRollResult.Success;
				return;
			}
			if (maxRoll >= 4)
			{
				CurrentRoll.Result = SVRollResult.Mild;
				return;
			}
			else
			{
				CurrentRoll.Result = SVRollResult.Fatal;
				return;
			}
		}		
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
		SVPositions position = SVPositions.NotSet;
		if (CurrentRoll is not null)
			position = CurrentRoll.Position;
		else
			position = SVPositions.Risky;

		CurrentRoll = new SVRollReport(movesService);
		CurrentRoll.Position = position;
		CurrentRoll.Player = player;
		CurrentRoll.Stat = stat;
		OpenSharedRoll.Invoke(this, EventArgs.Empty);	
	}

	public void CloseCurrentRollWindowInAllClients()
	{
		CloseShareRoll.Invoke(this, EventArgs.Empty);
	}

	public void UpdateSharedRollInAllClients()
	{
		OpenSharedRoll.Invoke(this, EventArgs.Empty);
	}
}
