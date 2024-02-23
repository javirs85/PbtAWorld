using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoard;

public class WhiteBoardService
{
	public event EventHandler<EventArgs> WhiteBoardChanged;

	public List<DrawnLine> DrawnLines = new();
	public void AddLine(DrawnLine line)
	{
		DrawnLines.Add(line);
		WhiteBoardChanged?.Invoke(this, EventArgs.Empty);
	}

	public void ClearLines() { 
		DrawnLines.Clear();
		WhiteBoardChanged?.Invoke(this, EventArgs.Empty);
	}

}
