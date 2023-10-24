using Microsoft.AspNetCore.SignalR;
using PbtAWorldConnectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DinoIsland;

public class DinoGameController : PbtAWorldConnectivity.PbtAWorldHub
{
	public List<MapItem> MapTokens { get; set; } = new List<MapItem>();
	public List<Rumor> Rumors { get; set; } = new();

	public List<DinoPlayer> Players { get; set; } = new();

	public class Rumor
	{
		public string Owner { get; set; }
		public string Description { get; set; }
	}

	public event EventHandler OnUIUpdate;

	internal void RequestUpdateToUIOnClients()
	{
		OnUIUpdate?.Invoke(this, new EventArgs());
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
			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			var rumor = paramMessage?.Parameters["message"] ?? "cannot deserialize rumor";

			var existingRumor = Rumors.Find(x => x.Owner == paramMessage.Sender);
			if (existingRumor is not null)
				existingRumor.Description = rumor;
			else
				Rumors.Add(new DinoGameController.Rumor { Owner = paramMessage.Sender, Description = rumor });
			RequestUpdateToUIOnClients();
			return false;
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
