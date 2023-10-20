using Blazored.Toast.Services;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PbtAWorldConnectivity;

public class PbtAWorldCommClient
{
    public bool IsConnected { get; set; } = false;
    public string UserName { get; set; } = string.Empty;

    public event EventHandler<PbtAMessage> OnNewRawMessageFromServer;
    public event EventHandler<InfoMessage> OnNewInfoMessageFromServer;
    public event EventHandler<ChatMessage> OnNewChatMessageFromServer;
    public event EventHandler<string> OnNewErrorMessage;


    private string _hubUrl = "/chat";
    private HubConnection _hubConnection;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="BaseUri">retrieve it in the page by using: navigationManager.BaseUri</param>
    /// <returns></returns>
    public async Task StartCommunication(string BaseUri, string _userName)
    {
        if (string.IsNullOrWhiteSpace(_userName))
        {
            OnNewErrorMessage?.Invoke(this, "Por favor introduzca el nombre de su personaje");
            return;
        };
        try
        {
            UserName = _userName;

            IsConnected = true;
            _hubUrl = BaseUri.TrimEnd('/') + PbtAWorldHub.HubUrl;

            _hubConnection = new HubConnectionBuilder()
                .WithUrl(_hubUrl)
                .Build();

            _hubConnection.On<MessageKinds, string>("Broadcast", ReceiveMessage);

            await _hubConnection.StartAsync();

            await SendAsync(new InfoMessage { 
                Sender = UserName,
                Body = $"{UserName} se ha incorporado al juego."
            });
        }
        catch (Exception ex)
        {
            OnNewErrorMessage?.Invoke(this, ex.Message);
            IsConnected = false;
        }
        
    }

    public void ReceiveMessage(MessageKinds kind, string EncodedMessage)
    {
        if (kind == MessageKinds.Chat)
        {
            ChatMessage msg = JsonSerializer.Deserialize<ChatMessage>(EncodedMessage) ?? throw new Exception("Cannot decode message");
            OnNewChatMessageFromServer(this, msg);
        }
        else if (kind == MessageKinds.Info)
        {
            InfoMessage msg = JsonSerializer.Deserialize<InfoMessage>(EncodedMessage) ?? throw new Exception("Cannot decode message");
            OnNewInfoMessageFromServer(this, msg);
        }
    }


    public async Task SendInfo(string msg)
    {
        await SendAsync(new InfoMessage
        {
            Body = msg
        }) ;
    }

    public async Task SendAsync(PbtAMessage message)
    {
        message.Sender = UserName;
        string errorMessage = string.Empty;
        if(!IsConnected)
        {
            errorMessage = "The communication client is not connected";
            OnNewErrorMessage?.Invoke(this, errorMessage);
            return;
        }
        
        if (!message.IsReadyToSend(out errorMessage))
        {
            OnNewErrorMessage?.Invoke(this, errorMessage);
            return;
        }

        string encoded = JsonSerializer.Serialize(message);
        await _hubConnection.SendAsync("Broadcast", message.MessageKind, encoded);
    }

    public async Task DisconnectAsync()
    {
        if (IsConnected)
        {
            await SendAsync( new InfoMessage { 
                Sender = UserName,
                Body= $"{UserName} left chat room." 
            });

            await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();

            _hubConnection = null;
            IsConnected = false;
        }
    }
}
