using PbtADBConnector;
using PbtALib;

namespace UrbanShadows;

public class USGameController : PbtALib.GameControllerBase<USMoveIDs, USAttributes>
{
	public List<Debt> AllDebts = new();
	public List<Faction> AllFactions { get; set; } = new();
	public USGameController(USMovesService moves, DataBaseController _db) : base(moves, _db)
	{
		LastRoll = new USRollReport(moves);

		People = new People();
		People.Circles.Clear();
		People.Circles.Add(new Circle
		{
			Name = "Mortalis",
			Factions = new List<PbtALib.Faction>
			{
				new PbtALib.Faction
				{
					Name = "Autónomos en Mortales"
				}
			}
		});
		People.Circles.Add(new Circle
		{
			Name = "Noche",
			Factions = new List<PbtALib.Faction>
			{
				new PbtALib.Faction
				{
					Name = "Autónomos en Noche"
				}
			}
		});
		People.Circles.Add(new Circle
		{
			Name = "Poder",
			Factions = new List<PbtALib.Faction>
			{
				new PbtALib.Faction
				{
					Name = "Autónomos en poder"
				}
			}
		});
		People.Circles.Add(new Circle
		{
			Name = "Velo",
			Factions = new List<PbtALib.Faction>
			{
				new PbtALib.Faction
				{
					Name = "Autónomos en Velo",
					Members =new List<ICharacter>
					{
						new PNJ {Name = "amparo"},
						new PNJ {Name = "lolo"},
						new PNJ {Name = "sergio"},
						new PNJ {Name = "john"},
					}
				}
			}
		});

	}

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

	public async Task StoreDebt(Debt d) {
		if (!AllDebts.Contains(d))
		{
			AllDebts.Add(d);
		}
		RequestUpdateToUIOnClients();
	}
	public async Task DeleteDebt(Debt d) {
		if (AllDebts.Contains(d))
		{
			AllDebts.Remove(d);
		}
		RequestUpdateToUIOnClients();
	}

	public async Task StoreFaction(Faction fac) { throw new NotImplementedException(); }
	public async Task<USCharacterSheet> DeleteCharacter(USCharacterSheet ch) { throw new NotImplementedException(); }
	public async Task<string> getImageBase64Async(Guid Id) { throw new NotImplementedException(); }
	public async Task<USCharacterSheet> CreatePlayerAtFaction(Faction fac) { throw new NotImplementedException(); }
	public async Task CreateNewFactionAtSelectedCircle(Circles c) { throw new NotImplementedException(); }
	public List<USCharacterSheet> GetMembersOfFaction(Faction fac) { throw new NotImplementedException(); }
	public async Task StoreImageBase64(string Data64, Guid CharacterID) { throw new NotImplementedException(); }
}
