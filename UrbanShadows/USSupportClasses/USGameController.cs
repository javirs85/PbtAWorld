using PbtADBConnector;
using PbtALib;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace UrbanShadows;

public class USGameController : PbtALib.GameControllerBase<USMoveIDs, USAttributes>
{
	public List<Debt> AllDebts = new();
	public List<USFaction> AllFactions { get; set; } = new();
	private USMovesService moves;
	public USGameController(USMovesService _moves, IDataBaseController _db, LastRollViewerService lrvs) : base(_moves, _db, lrvs)
	{
		//LastRoll = new USRollReport(_moves);
		//moves = _moves;

		//People = new USPeople(_db);

		//USFaction f = new USFaction
		//{
		//	Name = "Invierno",
		//	Members = new List<PbtACharacter>
		//	{
		//		new PNJ {Name = "amparo", ID = Guid.NewGuid()},
		//		new PNJ {Name = "lolo", ID = Guid.NewGuid()},
		//		new PNJ {Name = "sergio", ID = Guid.NewGuid()},
		//		new PNJ {Name = "john", ID = Guid.NewGuid()},
		//	}
		//};
		//People.Circles[3].Factions.Add(f);
    }
	protected override void CreateNewRollReport()
	{
		LastRoll = new USRollReport(moves);
	}
	//public override void AddPlayerToPeople(PbtACharacter ch) { 
	//	if(ch is USCharacterSheet)
	//	{
	//		var usc = ch as USCharacterSheet;
	//		var c = People.Circles.Find(x => x.Name == usc.Circle.ToString());
	//		if(c != null)
	//		{
	//			c.DefaultFaction.Members.Add(usc);
	//		}
	//	}
	//}

	public override async Task StoreChangesOnCharacter(PbtACharacter ch, string notification, string? newName = null)
	{
		if (ch is USCharacterSheet)
		{
			var DWChar = (USCharacterSheet)ch;
			if (newName != null) { DWChar.Name = newName; }

			await DB.StoreChangesinCharacter(ch.ID, ch.Name, System.Text.Json.JsonSerializer.Serialize(DWChar));
			if (!string.IsNullOrEmpty(notification))
				ShowToastOnAllClients(ch.Name+": "+notification);
		}
		else
			throw new Exception("tried to store a character that is not DWCharacter at DWGameController");
	}

	public async Task LoadAllDebts()
	{
		var Folder = $"wwwroot/GameImages/{SessionID}";
		if(!Directory.Exists(Folder))
		{
			Directory.CreateDirectory(Folder);
		}
		var path = $"{Folder}/Debts.json";
		if(!File.Exists(path))
		{
            var sj = System.Text.Json.JsonSerializer.Serialize(AllDebts);
            await System.IO.File.WriteAllTextAsync(path, sj);
        } 
		var json = await File.ReadAllTextAsync(path);
		AllDebts = JsonSerializer.Deserialize<List<Debt>>(json) ?? new();
	}

	public async Task StoreDebt(Debt d) {
		if (!AllDebts.Contains(d))
		{
			AllDebts.Add(d);
			ShowToastOnAllClients($"{GetCharacterByID(d.PayingID).Name} contrajo una deuda con {GetCharacterByID(d.ReceivingID).Name}");
		}

		var Folder = $"wwwroot/GameImages/{SessionID}";
		var path = $"{Folder}/Debts.json";
		var json = System.Text.Json.JsonSerializer.Serialize(AllDebts);

		await System.IO.File.WriteAllTextAsync(path, json);

		RequestUpdateToUIOnClients();
	}
	public async Task DeleteDebt(Debt d) {
		if (AllDebts.Contains(d))
		{
			AllDebts.Remove(d);
			ShowToastOnAllClients($"{GetCharacterByID(d.PayingID).Name} pagó una deuda a {GetCharacterByID(d.ReceivingID).Name}");
		}
		RequestUpdateToUIOnClients();
	}

	public async Task StoreFaction(USFaction fac) { throw new NotImplementedException(); }
	public async Task<USCharacterSheet> DeleteCharacter(USCharacterSheet ch) { throw new NotImplementedException(); }
	public async Task<string> getImageBase64Async(Guid Id) { throw new NotImplementedException(); }
	public async Task<USCharacterSheet> CreatePlayerAtFaction(USFaction fac) { throw new NotImplementedException(); }
	public async Task CreateNewFactionAtSelectedCircle(Circles c) { throw new NotImplementedException(); }
	public List<USCharacterSheet> GetMembersOfFaction(USFaction fac) { throw new NotImplementedException(); }
	public async Task StoreImageBase64(string Data64, Guid CharacterID) { throw new NotImplementedException(); }

	
}
