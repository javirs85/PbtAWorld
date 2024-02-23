using Microsoft.AspNetCore.Components.Web;
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

	int DrawingStep = 7000;

	public List<DrawnLine> DrawnLines = new();
	public void AddLine(DrawnLine line)
	{
		if(line.Points.Count <= 3)
		{
			return;
		}
		DrawnLines.Add(line);
		WhiteBoardChanged?.Invoke(this, EventArgs.Empty);
	}

	public void ClearLines() { 
		DrawnLines.Clear();
		WhiteBoardChanged?.Invoke(this, EventArgs.Empty);
	}

	public bool isDrawing = false;
	public DrawnLine CurrentDrawing = new();


	public void MouseDown(MouseEventArgs e)
	{
		if (!isDrawing)
		{
			isDrawing = true;
			CurrentDrawing.Points.Clear();
			CurrentDrawing.Points.Add(new Point((int)e.OffsetX, (int)e.OffsetY));
			CurrentDrawing.IsFilledIn = false;
		}
	}
	public void MouseUp()
	{
		if (isDrawing)
		{
			if (CurrentDrawing.Points.Last().DistanceTo(CurrentDrawing.Points.First()) <= DrawingStep)
			{
				CurrentDrawing.IsFilledIn = true;
			}
			isDrawing = false;
			AddLine(CurrentDrawing);
			CurrentDrawing = new DrawnLine();
		}
	}
	public void MouseMove(MouseEventArgs e)
	{
		if (isDrawing)
		{
			var lastPoint = CurrentDrawing.Points.Last();
			var newPoint = new Point((int)e.OffsetX, (int)e.OffsetY);

			if (newPoint.DistanceTo(lastPoint) >= DrawingStep)
				CurrentDrawing.Points.Add(newPoint);

			WhiteBoardChanged?.Invoke(this, EventArgs.Empty);
		}
	}

}
