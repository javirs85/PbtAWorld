using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PbtALib;

public class Clock
{
	public int Status { get; set; } = 0;
	public int Steps { get; set; } = 3;
	public string Title { get; set; } = string.Empty;
	public string EventAt12 { get; set; } = String.Empty;
}
