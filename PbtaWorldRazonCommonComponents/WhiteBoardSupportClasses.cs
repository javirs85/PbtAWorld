using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoard;

public class DrawnLine
{
	public List<Point> Points = new();
	public Point AnchorPoint => Points[0] ?? new Point(0, 0);
	public bool IsFilledIn = false;

	public string GeneratePolyline()
	{
		string str = "";
		foreach (var p in Points)
			str += $"{p.X},{p.Y} ";
		return str.TrimEnd();
	}

	public string GenerateMonotonePath()
	{
		if (Points == null || Points.Count < 4)
			return string.Empty;

		var path = new StringBuilder();
		path.Append($"M {Points[0].X} {Points[0].Y}");

		for (int i = 1; i < Points.Count - 2; i++)
		{
			var x0 = Points[i - 1].X;
			var y0 = Points[i - 1].Y;
			var x1 = Points[i].X;
			var y1 = Points[i].Y;
			var x2 = Points[i + 1].X;
			var y2 = Points[i + 1].Y;
			var x3 = Points[i + 2].X;
			var y3 = Points[i + 2].Y;

			for (int t = 1; t <= 10; t++)
			{
				double tt = t / 10.0;
				double tt2 = tt * tt;
				double tt3 = tt2 * tt;

				var xi = 0.5 * ((2 * x1) + (-x0 + x2) * tt + (2 * x0 - 5 * x1 + 4 * x2 - x3) * tt2 + (-x0 + 3 * x1 - 3 * x2 + x3) * tt3);
				var yi = 0.5 * ((2 * y1) + (-y0 + y2) * tt + (2 * y0 - 5 * y1 + 4 * y2 - y3) * tt2 + (-y0 + 3 * y1 - 3 * y2 + y3) * tt3);

				// Apply tension
				xi = x1 + (xi - x1);
				yi = y1 + (yi - y1);

				path.Append($" L {xi} {yi}");
			}
		}

		// Add the last point
		path.Append($" L {Points[Points.Count - 1].X} {Points[Points.Count - 1].Y}").Replace(',', '.');

		return path.ToString();
	}
}



public class Point
{
	public Point(int x, int y)
	{
		X = x; Y = y;
	}
	public int X;
	public int Y;

	public int DistanceTo(Point other)
	{
		int deltaX = other.X - X;
		int deltaY = other.Y - Y;
		return deltaX * deltaX + deltaY * deltaY;
	}
}
