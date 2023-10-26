using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PbtALib;

public class PNJ
{
	public string Name { get; set; } = string.Empty;
	public PbtAImage Image { get; set; } = new();
}

public class PNJs
{
	public List<PNJ> PNJList { get; set; } = new();
	public PNJs()
	{
		var path = "wwwroot/imgs/pnjs";
		var allNames = Directory.GetFiles(path);
		foreach (var file in allNames)
		{
			if (File.Exists(file))
			{
				var rawName = Path.GetFileNameWithoutExtension(file);
				var justName = Path.GetFileName(file);

				var img = new PbtAImage { Name =rawName, src = "imgs/pnjs/" + justName};
				ImagesDB.AddImage(img);
				PNJList.Add(new PNJ { Name =rawName, Image =img });	
			}
		}

	}

}