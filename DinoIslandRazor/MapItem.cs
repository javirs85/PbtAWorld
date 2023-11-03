using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinoIsland;

public enum MapActions { NoteSet, Add, Remove }

public class MapItem
{
	public Guid ID { get; set; } = Guid.NewGuid();
	public float x { get; set; } = 0;
	public float y { get; set; } = 0;
	public string xValue => $"{x}%";
	public string yValue => $"{y}%";
	public DinoMapTokens Token { get; set; } = DinoMapTokens.Empty;
	public MapActions Action { get; set; } = MapActions.NoteSet;
}
