using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;
using static PbtALib.BaseTextBook;

namespace PbtALib;

public class MonsterManual
{//https://www.dungeonworldsrd.com/monsters/

	public static event EventHandler LoadedFinished;

    public MonsterManual()
    {
		LoadAllMonsterFiles();
	}

	public void AddNewLocation(string NewName)
	{
		AllMonsterPacks.Add(new MonsterPack { Name = NewName });
		LoadedFinished?.Invoke(this, EventArgs.Empty);

		AllMonsterPacks = AllMonsterPacks.OrderBy(x => x.Name).ToList();
	}

	public void RemoveMonster(Monster monster)
	{
		var pack = AllMonsterPacks.Find(x=> x.Monsters.Contains(monster));
		if(pack != null) { 
			pack.Monsters.Remove(monster);
		}

		SendLoadedFinishMessage();
	}

	private void SendLoadedFinishMessage() => LoadedFinished?.Invoke(this, EventArgs.Empty);

	public List<MonsterPack> AllMonsterPacks = new List<MonsterPack>
	{
	};

	public async Task LoadAllMonsterFiles()
	{
		try
		{
			string basePath = $"./wwwroot/DW/Monsters/";
			var files = Directory.GetFiles(basePath);
			AllMonsterPacks.Clear();

			foreach (var file in files)
			{
				var pack = await MonsterPack.CreateFromFile(file);
				if (pack is not null)
				{
					AllMonsterPacks.Add(pack);
				}
					
			}

			AllMonsterPacks = AllMonsterPacks.OrderBy(x=>x.Name).ToList();

			LoadedFinished?.Invoke(this, EventArgs.Empty);
		}
		catch (Exception e)
		{
			Console.WriteLine(e.Message);
		}
	}

	public void RemoveMonsterPack(MonsterPack pack)
	{
		AllMonsterPacks.Remove(pack);
		var FilePath = $"./wwwroot/DW/Monsters/{pack.ID.ToString()}.json";
		if(File.Exists(FilePath))
		{
			File.Delete(FilePath);
		}
	}

	public void AddMonsterPackFromJson(string json)
	{
		var pack = JsonSerializer.Deserialize<MonsterPack>(json);
		if(pack is not null)
		{
			AllMonsterPacks.Add(pack);
		}
		File.WriteAllText($"./wwwroot/DW/Monsters/{pack.ID.ToString()}.json", json);	
	}

	public Monster? FindMonsterByID(string id)
	{
		foreach(var pack in AllMonsterPacks)
		{
			foreach(var monster in pack.Monsters)
			{
				if (monster.ID.ToLower() == id.ToLower())
				{
					return monster;
				}
			}
		}
		return null;
	}

}

public class MonsterPack
{
	public Guid ID { get; set; } = Guid.NewGuid();
	public string Name { get; set; } = "";
	public List<Monster> Monsters { get; set; } = new List<Monster>();

	public void AddEmptyMonster()
	{
		Monster m = new Monster();
		m.Attacks.Clear();
		m.Name = "__Name__";
		m.Attacks.Add(
			new AttackDef { 
				AttackName = "New attack", 
				Dices = new List<DiceTypes> { DiceTypes.d6} 
		});

		Monsters.Add(m);

		Monsters = Monsters.OrderBy(x => x.Name).ToList();
	}

	public async Task SaveToFile()
	{
		try
		{
			string newFilePath = $"./wwwroot/DW/Monsters/{ID.ToString()}.json";

			var str = JsonSerializer.Serialize(this);
			await File.WriteAllTextAsync(newFilePath, str);
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public static async Task<MonsterPack?> CreateFromFile(string filePath)
	{
		try
		{
			var encoded = await File.ReadAllTextAsync(filePath);
			return JsonSerializer.Deserialize<MonsterPack>(encoded) ?? null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
			return null;
		}
	}
}
