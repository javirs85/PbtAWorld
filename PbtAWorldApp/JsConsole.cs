using Microsoft.JSInterop;

namespace PbtAWorldApp;

public class JsConsole
{
	private readonly IJSRuntime JsRuntime;
	public JsConsole(IJSRuntime jSRuntime)
	{
		this.JsRuntime = jSRuntime;
	}

	public async Task LogAsync(object message)
	{
		await this.JsRuntime.InvokeVoidAsync("console.log", message);
	}
}
