using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;

public class DinoGameController
{
	public List<MapItem> MapTokens { get; set; } = new List<MapItem>();
	public List<Rumor> Rumors { get; set; } = new();

	public class Rumor
	{
		public string Owner { get; set; }
		public string Description { get; set; }
	}

	public event EventHandler OnUIUpdate;

	internal void RequestUpdateToUIOnClients()
	{
		OnUIUpdate?.Invoke(this , new EventArgs());	
	}
}
