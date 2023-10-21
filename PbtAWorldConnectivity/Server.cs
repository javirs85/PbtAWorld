namespace PbtAWorldConnectivity;

using Microsoft.AspNetCore.SignalR;
using System.Runtime.CompilerServices;
using System.Text.Json;

public class PbtAWorldHub : Hub
{
    public const string HubUrl = "/chat";

    public async Task Broadcast(MessageKinds kind, string EncodedMessage)
    {
        if(await PreProcessMessage(kind, EncodedMessage))
        {
			await Clients.All.SendAsync("Broadcast", kind, EncodedMessage);
		}

    }

    /// <summary>
    /// returns true if the message will be broadcasted to all clients. False if the communication is stopped and controlled by derived server from here on.
    /// </summary>
    /// <param name="kind">the kind of message being sent</param>
    /// <param name="encodedMessage">actual content</param>
    /// <returns>false if the communication is halted by the server, true if the message needs to be boardcasted</returns>
	protected virtual async Task<bool> PreProcessMessage(MessageKinds kind, string encodedMessage)
	{
        return true;
	}

	public override Task OnConnectedAsync()
    {
        Console.WriteLine($"{Context.ConnectionId} connected");
        return base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? e)
    {
        Console.WriteLine($"Disconnected {e?.Message} {Context.ConnectionId}");
        await base.OnDisconnectedAsync(e);
    }

	protected JsonSerializerOptions options = new JsonSerializerOptions
	{
        //allow for nested serialized objects
		WriteIndented = true,  // For better readability (optional)
		Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
	};
}