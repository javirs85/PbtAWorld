using Microsoft.AspNetCore.SignalR;
using PbtALib;
using PbtAWorldConnectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DinoIsland;

public class DinoServer : PbtAWorldHub
{
	private DinoGameController Game;
	public DinoServer(DinoGameController _game)
	{
		Game = _game;
	}

	protected override async Task<bool> PreProcessMessage(MessageKinds kind, string encodedMessage)
	{
		if(kind == MessageKinds.UpdateMapRequest)
		{
			var msg = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			if(msg != null)
			{
				var sender = msg.Sender;
				ParamsMessage response = new ParamsMessage
				{
					Sender = "Master",
					MessageKind = MessageKinds.UpdateMapRequest,
				};
				var seralizedMapList = JsonSerializer.Serialize(Game.MapTokens, options);
				response.Parameters.Add("message", seralizedMapList);
				var EncodedResponse = JsonSerializer.Serialize(response, options);
				await Clients.All.SendAsync("Broadcast", kind, EncodedResponse);
			}
			return false;
		}
		else if(kind == MessageKinds.Map)
		{
			//we update our local copy of the items in the map and let the message be sent to the rest of players.

			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			var UpdateInMap = System.Text.Json.JsonSerializer.Deserialize<MapItem>(paramMessage.Parameters["message"]);
			if (UpdateInMap is not null)
			{
				if (UpdateInMap.Action == MapActions.Add)
					Game.MapTokens.Add(UpdateInMap);
				else if (UpdateInMap.Action == MapActions.Remove)
					Game.MapTokens.Remove(Game.MapTokens.Find(x=>x.ID == UpdateInMap.ID));
			}
			return true;
		}
		else if(kind == MessageKinds.NewRumor)
		{
			var paramMessage = System.Text.Json.JsonSerializer.Deserialize<PbtAMessage>(encodedMessage);
			var rumor = paramMessage?.Parameters["message"] ?? "cannot deserialize rumor";
			
			var existingRumor = Game.Rumors.Find(x => x.Owner == paramMessage.Sender);
            if (existingRumor is not null) 
				existingRumor.Description = rumor;
			else
				Game.Rumors.Add(new DinoGameController.Rumor { Owner = paramMessage.Sender, Description = rumor});
			Game?.RequestUpdateToUIOnClients();
			return false; 
		}
		return true;
	}

}
