namespace PbtAWorldConnectivity;

using Microsoft.AspNetCore.SignalR;


public class PbtAWorldHub : Hub
{
    public const string HubUrl = "/chat";

    public async Task Broadcast(MessageKinds kind, string EncodedMessage)
    {
        await Clients.All.SendAsync("Broadcast", kind, EncodedMessage);
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
}