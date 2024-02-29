using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PbtALib;

public class SquareMap
{
	public static string ImagesPath = "/imgs/DW/SquareMap";
	public event EventHandler UpdateAllInstances;
	private Guid _gameID = Guid.Empty;

	public Guid GameID
	{
		get { return _gameID; }
		set { _gameID = value;
			LoadJson();
		}
	}


    public SquareMap()
    {
		int i = 0;
		for(i = 0; i < 6;  i++)
		{
			var row = new List<SquareMapTile>();
			Tiles.Add(row);

            for (int j = 0; j < 6; j++)
            {
                row.Add(new SquareMapTile { Place = SquareMapTile.GenericPlaces.empty, X = i, Y = j });
            }
        }

		Tiles[2][2].Name = "Initial tile";
		Tiles[2][2].Place = SquareMapTile.GenericPlaces.initial;
    }
    public List<List<SquareMapTile>> Tiles = new();

	public void ForceUpdateInAllClients()
	{
		UpdateAllInstances?.Invoke(this, new EventArgs());
	}

	public async void LoadJson() {
		try
		{
            string newFilePath = $"./wwwroot/SquareMaps/{GameID.ToString()}.json";
			var encoded = await File.ReadAllTextAsync(newFilePath);
			
			Tiles = JsonSerializer.Deserialize<List<List<SquareMapTile>>>(encoded);
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
            string newFilePath = $"./wwwroot/SquareMaps/{GameID.ToString()}.json";
            //await using FileStream fs = new(newFilePath, FileMode.Create);
            await File.WriteAllTextAsync(newFilePath, JsonSerializer.Serialize(Tiles));
        }
		catch (Exception ex)
		{
            Console.WriteLine(ex.Message);
        }
	}


}

public class SquareMapTile
{
	public enum GenericPlaces { wood, desert, mountains, city, farmland, ruins, custom, empty, initial}
	private GenericPlaces _place;

	public GenericPlaces Place
	{
		get { return _place; }
		set { _place = value; 
			if(_place != GenericPlaces.custom)
			{
				switch (value)
				{
                    case GenericPlaces.empty:
                        Color = "#fbfcfa";
                        break;
                    case GenericPlaces.wood:
						Color = "#c9e3c8";
						break;
					case GenericPlaces.desert:
						Color = "#eddfca";
						break;
					case GenericPlaces.mountains:
						Color = "#eddfca";
						break;
					case GenericPlaces.city:
						Color = "#caccca";
						break;
					case GenericPlaces.ruins:
						Color = "#929491";
						break;
					case GenericPlaces.farmland:
						Color = "#dcedce";
						break;
					case GenericPlaces.custom:
						break;
					default:
						break;
				}
			}
		}
	}

	public string Color { get; set; } = "#FFFFFF";
	public string Name { get; set; } = "New Tile";
	public string FileName { get; set; } = string.Empty;
	public string BackgroundImageUrl => SquareMap.ImagesPath+"/"+FileName;
	public int X { get; set; }
	public int Y { get; set; }
}
