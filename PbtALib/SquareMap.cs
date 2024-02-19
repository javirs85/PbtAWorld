using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class SquareMap
{
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
                        BackgroundImageUrl = "";
                        break;
                    case GenericPlaces.wood:
						Color = "#c9e3c8";
						BackgroundImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.es%2Fpin%2F700098704573176142%2F&psig=AOvVaw1AIkM6fYwJtPiOcfSw6FwU&ust=1708449092784000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCICVtv3yt4QDFQAAAAAdAAAAABAE";
						break;
					case GenericPlaces.desert:
						Color = "#eddfca";
						BackgroundImageUrl = "https://images.unsplash.com/photo-1470364798856-7a74180378dc?q=80&w=1000&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxleHBsb3JlLWZlZWR8OXx8fGVufDB8fHx8fA%3D%3D";
						break;
					case GenericPlaces.mountains:
						Color = "#eddfca";
						BackgroundImageUrl = "https://media.istockphoto.com/id/476098860/vector/wonderful-morning-in-the-blue-mountains.jpg?s=612x612&w=0&k=20&c=0nuLvsWKXPReu01RvbXTKIwlUYxOQvoXD_qVBrsapxc=";
						break;
					case GenericPlaces.city:
						Color = "#caccca";
						BackgroundImageUrl = "https://storage.googleapis.com/pai-images/0205b0f142e442078259e27693a78f14.jpeg";
						break;
					case GenericPlaces.ruins:
						Color = "#929491";
						BackgroundImageUrl = "https://as2.ftcdn.net/v2/jpg/05/34/86/67/1000_F_534866761_tQhZafK0980HBazx8XSphOp18h85vtRr.jpg";
						break;
					case GenericPlaces.farmland:
						Color = "#dcedce";
						BackgroundImageUrl = "https://i.imgur.com/2nvogOy.jpeg";
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
	public string BackgroundImageUrl { get; set; } = "";
	public int X { get; set; }
	public int Y { get; set; }
}
