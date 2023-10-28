using Microsoft.AspNetCore.SignalR;
using PbtALib;
using PbtAWorldConnectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DinoIsland;

public class DinoGameController : PbtAWorldConnectivity.PbtAWorldHub
{
	public event EventHandler<string> NewInfoToast;

	public DinoTextBook TextBook = new DinoTextBook();

	public List<MapItem> MapTokens { get; set; } = new List<MapItem>();
	public List<DinoPlayer> Players { get; set; } = new();

	public string WhereAreYou { get; set; } = string.Empty;
	public string _obstaclePlayers = string.Empty;
	public string ObstaclePlayers 
	{ 
		get { return _obstaclePlayers; } 
		set {
		_obstaclePlayers = value;
			RequestUpdateToUIOnClients();
		} 
	}

	public string _obstacleMC = string.Empty;
	public string ObstacleMC
	{
		get { return _obstacleMC; }
		set
		{
			_obstacleMC = value;
			RequestUpdateToUIOnClients();
		}
	}
	public string TheWayOut { get; set; } = string.Empty;
	public string GimmickSelected { get; set; } = string.Empty;
	
	public string NPCGoalsSelected { get; set; } = string.Empty;
	public string NPCOffersSelected { get; set; } = string.Empty;
	public string WhyComing { get; set; } = string.Empty;
	

	public Mystery? SelectedMystery { get; set; }	
	public MysterySolution? SelectedSolution { get;set; }
	public ExtinctionEvent? SelectedExtinctionEvent { get; set; }

	public event EventHandler OnUIUpdate;

	public void RequestUpdateToUIOnClients()
	{
		OnUIUpdate?.Invoke(this, new EventArgs());
	}

	public void ShowToastOnAllClients(string msg)
	{
		NewInfoToast?.Invoke(this, msg);
	}

	public RollReport<DinoMoveIDs, DinoStates> LastRoll = new();
	
	public void SomeoneRolled(RollReport<DinoMoveIDs, DinoStates> roll)
	{
		LastRoll = roll;
		RequestUpdateToUIOnClients();
	}

	public List<PNJ> PNJs { get; set; } = new();

	public Random random = new Random();

	public void Roll(Guid PlayerID, DinoStates stat, DinoMove move)
	{
		var player = Players.Find(x=>x.ID == PlayerID);
		if (player is not null)
		{
			LastRoll.d1 = random.Next(1, 7);
			LastRoll.d2 = random.Next(1, 7);
			LastRoll.bonus = 0;
			if (stat == DinoStates.D_Steady) LastRoll.bonus = player.Steady;
			else if (stat == DinoStates.D_Fit) LastRoll.bonus = player.Fit;
			else if (stat == DinoStates.D_Clever) LastRoll.bonus = player.Clever;
			else if (stat == DinoStates.D_1) LastRoll.bonus = 1;
			else if (stat == DinoStates.D_0) LastRoll.bonus = 0;

			LastRoll.Roller = player.Name;
			LastRoll.LocalTittle = move.Tittle;
			LastRoll.MoveId = move.ID;
			LastRoll.Stat = stat;
		}
		RequestUpdateToUIOnClients();
	}

	public void SetRumor(Guid ID, string Rumor)
	{
		var player = Players.Find(x => x.ID == ID);

		if (player is not null) player.Rumor = Rumor;
		RequestUpdateToUIOnClients();
	}

	public void UpdateMap(MapItem UpdateInMap)
	{
		if (UpdateInMap.Action == MapActions.Add)
			MapTokens.Add(UpdateInMap);
		else if (UpdateInMap.Action == MapActions.Remove)
		{
			var item = MapTokens.Find(x => x.ID == UpdateInMap.ID);
			if(item is not null) MapTokens.Remove(item);
		}
		RequestUpdateToUIOnClients();
	}

	public void AddPlayer(DinoPlayer player)
	{
		Players.Add(player);
		RequestUpdateToUIOnClients();
	}

	protected override async Task<bool> PreProcessMessage(MessageKinds kind, string encodedMessage)
	{
		if (kind == MessageKinds.UpdateMapRequest)
		{
			var msg = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			if (msg != null)
			{
				var sender = msg.Sender;
				ParamsMessage response = new ParamsMessage
				{
					Sender = "Master",
					MessageKind = MessageKinds.UpdateMapRequest,
				};
				var seralizedMapList = JsonSerializer.Serialize(MapTokens, options);
				response.Parameters.Add("message", seralizedMapList);
				var EncodedResponse = JsonSerializer.Serialize(response, options);
				await Clients.All.SendAsync("Broadcast", kind, EncodedResponse);
			}
			return false;
		}
		else if (kind == MessageKinds.Map)
		{
			//we update our local copy of the items in the map and let the message be sent to the rest of players.

			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			var UpdateInMap = System.Text.Json.JsonSerializer.Deserialize<MapItem>(paramMessage.Parameters["message"]);
			if (UpdateInMap is not null)
			{
				if (UpdateInMap.Action == MapActions.Add)
					MapTokens.Add(UpdateInMap);
				else if (UpdateInMap.Action == MapActions.Remove)
					MapTokens.Remove(MapTokens.Find(x => x.ID == UpdateInMap.ID));
			}
			return true;
		}
		else if (kind == MessageKinds.NewRumor)
		{
			/*
			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			var rumor = paramMessage?.Parameters["message"] ?? "cannot deserialize rumor";

			var existingRumor = Rumors.Find(x => x.Owner == paramMessage.Sender);
			if (existingRumor is not null)
				existingRumor.Description = rumor;
			else
				Rumors.Add(new DinoGameController.Rumor { Owner = paramMessage.Sender, Description = rumor });
			RequestUpdateToUIOnClients();
			return false;
			*/
		}
		else if(kind == MessageKinds.UpdateInPlayer)
		{
			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<ParamsMessage>(encodedMessage);
			var UpdatedPlayer = System.Text.Json.JsonSerializer.Deserialize<DinoPlayer>(paramMessage?.Parameters["message"] ?? "");

			if(UpdatedPlayer is not null)
			{
				var player = Players.Find(x => x.ID == UpdatedPlayer.ID);
				if (player is not null)
				{
					player.Name = UpdatedPlayer.Name;
					player.Email = UpdatedPlayer.Email;
					player.Rumor = UpdatedPlayer.Rumor;
					player.AllPurchasedMoves = UpdatedPlayer.AllPurchasedMoves;
					player.Behavior = UpdatedPlayer.Behavior;
					player.Looks = UpdatedPlayer.Looks;
					player.Steady = UpdatedPlayer.Steady;
					player.Fit = UpdatedPlayer.Fit;
					player.Clever = UpdatedPlayer.Clever;
					player.Wound1 = UpdatedPlayer.Wound1;
					player.Wound2 = UpdatedPlayer.Wound2;
					player.Password = UpdatedPlayer.Password;
					player.Class = UpdatedPlayer.Class;
				}
				else
				{
					Players.Add(UpdatedPlayer);
				}

				RequestUpdateToUIOnClients();
			}			
		}
		return true;
	}
}
