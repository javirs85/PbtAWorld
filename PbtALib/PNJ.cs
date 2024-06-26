﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PbtALib;

public class ICharacter
{
    public Guid ID { get; set; }
	public string Name { get; set; } = string.Empty;
	//blic PbtAImage Image { get; set; } = new();
	public string Image { get; set; } = string.Empty;
    public string Goal { get; set; } = string.Empty;
    public string CanOffer { get; set; } = string.Empty;

	public string WhatWants { get; set; } = string.Empty;
	public string WhatDoesNotWant { get; set; } = string.Empty;
	public string Complication { get; set; } = string.Empty;

	public bool IsKnownByPlayers { get; set; } = false;

	public int EncodedClass { get; set; }
	public virtual int HP { get; set; }
	public int MaxHP { get; set; }
	public string ClassString { get; set; } = string.Empty;

}

public class PNJ : ICharacter
{
}

public class PNJs
{
	public List<PNJ> AvailablePNJs { get; set; } = new();
	public PNJs()
	{
		var images = ImagesDB.LoadFolder("pnjs");
		foreach(var image in images)
		{
			//AvailablePNJs.Add(new PNJ { Name = image.Name, Image = image });
		}
	}

}