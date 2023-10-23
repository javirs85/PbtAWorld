using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PbtAWorldConnectivity;

public enum MessageKinds { Raw, Info, Chat, Roll, Map,
	UpdateMapRequest,
	NewRumor,
	UpdateInPlayer
}
public class PbtAMessage
{
    public PbtAMessage() { }

    public string Sender { get; set; } = string.Empty;
    public MessageKinds MessageKind { get; set; } = MessageKinds.Raw;

    internal bool IsReadyToSend(out string errorMessage)
    {
        if (string.IsNullOrEmpty(Sender) || string.IsNullOrWhiteSpace(Sender))
        {
            errorMessage = "sender cannot be empty";
            return false;
        }    
        errorMessage = "";

        return IsReadyToSendInternal(out errorMessage);
    }

    public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();
    

    public virtual void FromRawText(string rawMessage) => throw new NotImplementedException();
    public virtual bool IsReadyToSendInternal(out string errorMessage) => throw new NotImplementedException();
    public virtual string Encode(out string errorMessage) => throw new NotImplementedException();
}


public class ParamsMessage : PbtAMessage
{
    public ParamsMessage() { }
	public ParamsMessage(MessageKinds kind)
	{
		MessageKind = kind;
	}
    public ParamsMessage(MessageKinds _kind, string PayLoad)
    {
        MessageKind = _kind;
        Parameters.Add("message", PayLoad);
    }


	public override bool IsReadyToSendInternal(out string errorMessage)
	{
		var msg = Parameters["message"];
		if (msg is null || string.IsNullOrEmpty(msg))
		{
			errorMessage = "the message is null or empty";
			return false;
		}
		errorMessage = "";
		return true;
	}
}

public class SimpleCommandMessage : PbtAMessage
{
	public override bool IsReadyToSendInternal(out string errorMessage)
	{
        errorMessage = "";
        return true;
	}
}