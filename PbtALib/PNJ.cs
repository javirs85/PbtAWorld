using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PbtALib;

public class ICharacter
{
	public string Name { get; set; }
}

public class PNJ : ICharacter
{
	public PbtAImage Image { get; set; } = new();
	public string Goal { get; set; } = string.Empty;
	public string CanOffer { get; set; } = string.Empty;
}

public class PNJs
{
	public List<PNJ> AvailablePNJs { get; set; } = new();
	public PNJs()
	{
		var images = ImagesDB.LoadFolder("pnjs");
		foreach(var image in images)
		{
			AvailablePNJs.Add(new PNJ { Name = image.Name, Image = image });
		}
	}

}