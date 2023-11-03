using PbtALib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Buffers.Text;
using System.Xml.Linq;

namespace PbtALib;

public static class ImagesDB
{
    private static Dictionary<string, PbtAImage> Images = new Dictionary<string, PbtAImage>();
   
    public static void Init()
    {
        Images.Clear();

        var path = "";
        LoadFolder(path);
	}

    public static List<PbtAImage> LoadFolder(string path)
    {
        List<PbtAImage> loaded = new();
        if (Directory.Exists("wwwroot/imgs/"+path))
        { 
		    var allNames = Directory.GetFiles("wwwroot/imgs/" + path);
        
		    foreach (var file in allNames)
		    {
			    if (File.Exists(file))
			    {
				    var rawName = Path.GetFileNameWithoutExtension(file);
				    var justName = Path.GetFileName(file);
				    var image = new PbtAImage
				    {
					    Name = rawName,
					    src = "imgs/"+path+"/" + justName
				    };
				    Images.Add(rawName, image);
                    loaded.Add(image);
			    }
		    }
		}
        else
        {

        }
        return loaded;
	}

    public static PbtAImage GetImage(string name)
    {
        if (Images.ContainsKey(name)) return Images[name];
        else return Images["default"];
    }

    public static string ToJson()
    {
		return System.Text.Json.JsonSerializer.Serialize(Images);
    }

    public static void AddImage(string name, string base64)
    {
        if (!Images.ContainsKey(name))
        {
            Images.Add(name, new PbtAImage { src = base64, Name = name });
        }
        else
            throw new Exception($"There is already an image named {name} in the DB");
    }

    public static void AddImage(PbtAImage img) 
    {
		if (!Images.ContainsKey(img.Name))
		{
			Images.Add(img.Name, img);
		}
		else
			throw new Exception($"There is already an image named {img.Name} in the DB");
	}

    public static List<string> GetAllNames()
    {
        return Images.Keys.ToList();
    }
}
