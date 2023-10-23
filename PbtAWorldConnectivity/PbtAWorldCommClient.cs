using Blazored.Toast.Services;
using Microsoft.AspNetCore.SignalR.Client;
using PbtALib;
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
    public event EventHandler<ParamsMessage> OnNewMessageToPlayer;
    public event EventHandler<string> OnNewRollFromServer;
    public event EventHandler<string> OnNewErrorMessage;
    public event EventHandler<Tuple<string, string>> OnNewRumor;


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

            await SendInfo($"{UserName} se ha unido al juego");
        }
        catch (Exception ex)
        {
            OnNewErrorMessage?.Invoke(this, ex.Message);
            IsConnected = false;
        }
        
    }

    public void ReceiveMessage(MessageKinds kind, string EncodedMessage)
    {

        switch (kind)
        {
            case MessageKinds.Raw:
            case MessageKinds.Chat:
                break;
            case MessageKinds.Roll:
                OnNewRollFromServer(this, EncodedMessage);
				break;
            case MessageKinds.Map:
            case MessageKinds.UpdateMapRequest:
            case MessageKinds.NewRumor:
			case MessageKinds.Info:
				ParamsMessage msg = JsonSerializer.Deserialize<ParamsMessage>(EncodedMessage) ?? throw new Exception("Cannot decode message");
                OnNewMessageToPlayer(this, msg);
				break;
            default:
                break;
        }
	}


    public async Task SendInfo(string msg)
    {
        await SendAsync(new ParamsMessage(MessageKinds.Info, msg));
    }

    public async Task SendRollReport(string EncodedRollReport)
    {
        ParamsMessage msg = new ParamsMessage
        {
            MessageKind = MessageKinds.Roll
        };
        msg.Parameters.Add("message", EncodedRollReport);
        await SendAsync(msg);
	}

    public async Task SendSimpleCommandMessage(MessageKinds kind)
    {
		SimpleCommandMessage msg = new SimpleCommandMessage { MessageKind = kind };
        await SendAsync(msg);
    }

    public async Task SendParamsMessage(MessageKinds kind, string payload)
    {
		ParamsMessage msg = new ParamsMessage
		{
			MessageKind = kind
		};
		msg.Parameters.Add("message", payload);
		await SendAsync(msg);
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

		var options = new JsonSerializerOptions
		{
			// Set PropertyNamingPolicy or other options as needed
			WriteIndented = true,  // For better readability (optional)
			Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
		};

		string encoded = JsonSerializer.Serialize(message, options);
        await _hubConnection.SendAsync("Broadcast", message.MessageKind, encoded);
    }

    public async Task DisconnectAsync()
    {
        if (IsConnected)
        {
            await SendInfo($"{UserName} left chat room.");

			await _hubConnection.StopAsync();
            await _hubConnection.DisposeAsync();

            _hubConnection = null;
            IsConnected = false;
        }
    }
}
