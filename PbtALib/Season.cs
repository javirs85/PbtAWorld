using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class Season
{
	public Guid Guid { get; set; } = Guid.NewGuid();
	public AvailableGames GameID { get; set; } = AvailableGames.NotSet;
	public string Name { get; set; } = string.Empty;
	public List<PbtACharacter> Players { get; set; } = new();
	public List<Chapter> Chapters { get; set; } = new();
}

public class Chapter
{
	public Guid Guid { get; set; } = Guid.NewGuid();
	public string Summary { get; set; } = string.Empty;
	public DateTime Date { get; set; } = DateTime.Now;
}
