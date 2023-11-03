using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonWorld;

public class Background
{
	public string Title { get; set; } = "";
	public List<string> Movements { get; set; } = new();
	public List<string> InitialQuestions { get; set; } = new();
}

public class Points
{
	public string Tittle { get; set; } = "";
	public int Value { get; set; } = 0;
}