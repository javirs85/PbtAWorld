using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PbtALib;

public class Clock
{
	public Clock() { }

	public event EventHandler? UpdateRequested;
	public void UpdateUI() => UpdateRequested?.Invoke(this, EventArgs.Empty);

	public Clock(string title, int steps)
	{
		Title = title;
		Steps = new List<StepItem>();
		for (int i = 0; i < steps; i++) Steps.Add(new StepItem { Id = i + 1, Text = "" });
	}

	public ClocksManager Controller { get; set; } = new();

	public int Status { get; set; } = 0;
	public string Title { get; set; } = string.Empty;
	public List<StepItem> Steps { get; set; } = new();
	public string LastEvent => Steps.Last().Text;
	public int Count => Steps.Count;
	public string Color { get; set; } = "red";

	public void MoveStatusUp()
	{
		if (Status < Steps.Count - 1) Status++;
		Controller.ForceUpdateInAllClients();
	}
	public void MoveStatusDown()
	{
		if (Status >= 0) Status--;
		Controller.ForceUpdateInAllClients();
	}

	public void AddStep() => AddStep("");

	public void AddStep(string body = "")
	{
		Steps.Add(new StepItem { 
			Id = Steps.Count+1, 
			Text = body });
	}

	public void Remove(int Id)
	{
		Steps.RemoveAt(Id-1);

		for(int i = 0; i < Steps.Count; i++)
		{
			Steps[i].Id = i+1;
		}
	}
	public void ForceUpdateInAllClients() => Controller.ForceUpdateInAllClients();
}

public class StepItem
{
	public int Id { get; set; }
	public string Text { get; set; } = string.Empty;
}

public class ClocksManager
{
	private Guid _gameID = Guid.Empty;
	public event EventHandler? UpdateAllInstances;


	public Guid GameID
	{
		get { return _gameID; }
		set
		{
			_gameID = value;
			LoadJson();
		}
	}

	public List<Clock> Clocks { get; set; } = new();

	public void AddNewClock()
	{
		Clocks.Add(new Clock
		{
			Title = "New Clock",
			Steps = new List<StepItem> { 
				new StepItem { Id = 1, Text = "" },
				new StepItem { Id = 2, Text = "" },
				new StepItem { Id = 3, Text = "" },
				new StepItem { Id = 4, Text = "" },
			},
			Controller = this
		}) ;
	}

	public void Remove(Clock c)
	{
		Clocks.Remove(c);
		ForceUpdateInAllClients() ;
	}

	public async void LoadJson()
	{
		try
		{
			string newFilePath = $"./wwwroot/Clocks/{GameID.ToString()}.json";
			var encoded = await File.ReadAllTextAsync(newFilePath);

			Clocks = JsonSerializer.Deserialize<List<Clock>>(encoded) ?? new();
			ForceUpdateInAllClients();

		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}

	}
	public async Task SaveToJson()
	{
		try
		{
			string newFilePath = $"./wwwroot/Clocks/{GameID.ToString()}.json";
			//await using FileStream fs = new(newFilePath, FileMode.Create);
			await File.WriteAllTextAsync(newFilePath, JsonSerializer.Serialize(Clocks));
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
	public void ForceUpdateInAllClients()
	{
		UpdateAllInstances?.Invoke(this, new EventArgs());
	}
}
