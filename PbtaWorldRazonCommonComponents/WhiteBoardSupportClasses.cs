using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace WhiteBoard;



public class Line
{
	public Point Start { get; set; }
	public Point End { get; set; }
}

public class DrawnLine
{
	public List<Point> Points { get; set; } = new();
	public Point AnchorPoint => Points[0] ?? new Point(0, 0);
	public bool IsFilledIn { get; set; } = false;

	public string GeneratePolyline()
	{
		string str = "";
		foreach (var p in Points)
			str += $"{p.X},{p.Y} ";
		return str.TrimEnd();
	}

	public string GenerateMonotonePath()
	{
		if (Points == null || Points.Count < 1)
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
	public Point()
	{

	}
	public Point(int x, int y)
	{
		X = x; Y = y;
	}

	public Point(MouseEventArgs e)
	{
		X = (int)e.OffsetX;
		Y = (int)e.OffsetY;
	}

	public override string ToString()
	{
		return $"({X}, {Y})";
	}
	public int X { get; set; }
	public int Y { get; set; }

	public int DistanceTo(Point other)
	{
		int deltaX = other.X - X;
		int deltaY = other.Y - Y;
		return (int)Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
	}

	public Point FindClosestPoint(List<Point> points)
	{
		if (points == null || points.Count == 0)
		{
			throw new ArgumentException("Points list cannot be null or empty.");
		}

		Point closestPoint = points[0];
		double minDistance = this.DistanceTo(closestPoint);

		foreach (var point in points)
		{
			double distance = this.DistanceTo(point);
			if (distance < minDistance)
			{
				minDistance = distance;
				closestPoint = point;
			}
		}

		return closestPoint;
	}
}

public class VisibilityCalculator
{
	private int angle = 0;
	int resolution = 5;
	Point characterPosition = new Point(0, 0);
	List<Point> visibilityPoints = new();
	List<Line> ProcessedWalls = new();

	public string GetVisibilityArea(int x, int y, List<DrawnLine> Walls)
	{
		characterPosition = new Point(x, y);
		visibilityPoints = new List<Point>();
		resolution = 2;
		angle = 0;
		SplitWalls(Walls);

		for (angle = 0; angle < 360; angle += resolution)
		{
			visibilityPoints.Add(CalculateOneLine());
		}

		var VisibilityArea = "";
		foreach (var p in visibilityPoints)
		{
			VisibilityArea += $"{p.X}, {p.Y} ";
		}

		return VisibilityArea;
	}

	private void SplitWalls(List<DrawnLine> Walls)
	{
		ProcessedWalls.Clear();
		foreach (var wall in Walls)
		{
			for (int i = 0; i < wall.Points.Count - 1; i++)
			{
				Point wallStart = wall.Points[i];
				Point wallEnd = wall.Points[i + 1];

				if (wallStart.X != wallEnd.X || wallStart.Y != wallEnd.Y)
					ProcessedWalls.Add(new Line { End = wallStart, Start = wallEnd });
			}
		}
	}
	private Point CalculateOneLine()
	{
		double radians = angle * Math.PI / 180.0;
		int endX = characterPosition.X + (int)(Math.Cos(radians) * 2000); // Assuming a sufficiently large value for line length
		int endY = characterPosition.Y + (int)(Math.Sin(radians) * 2000); // Assuming a sufficiently large value for line length


		Point collisionPoint = new Point(endX, endY); // Default to end point if no collision

		bool didTouch = false;
		List<Point> ContactPoints = new();
		foreach (var l in ProcessedWalls)
		{
			if (DoIntersect(characterPosition, collisionPoint, l.Start, l.End))
			{
				didTouch = true;
				ContactPoints.Add(GetIntersectionPoint(characterPosition, collisionPoint, l.Start, l.End));
			}
		}
		if (ContactPoints.Count == 1)
			collisionPoint = ContactPoints[0];
		else if (ContactPoints.Count > 1)
			collisionPoint = characterPosition.FindClosestPoint(ContactPoints);

		return collisionPoint;
	}


	private Point GetCollisionPoint(Point start, Point end)
	{
		Point collisionPoint = end; // Default to end point if no collision

		foreach (var l in ProcessedWalls)
		{
			if (DoIntersect(start, end, l.Start, l.End))
			{
				collisionPoint = GetIntersectionPoint(start, end, l.Start, l.End);
				break;
			}
		}

		return collisionPoint;
	}

	private static bool DoIntersect(Point p1, Point q1, Point p2, Point q2)
	{
		int o1 = Orientation(p1, q1, p2);
		int o2 = Orientation(p1, q1, q2);
		int o3 = Orientation(p2, q2, p1);
		int o4 = Orientation(p2, q2, q1);

		if (o1 != o2 && o3 != o4)
			return true;

		return false;
	}

	private static int Orientation(Point p, Point q, Point r)
	{
		int val = (q.Y - p.Y) * (r.X - q.X) - (q.X - p.X) * (r.Y - q.Y);

		if (val == 0) return 0; // colinear
		return (val > 0) ? 1 : 2; // clock or counterclock wise
	}

	private static Point GetIntersectionPoint(Point p1, Point q1, Point p2, Point q2)
	{
		int A1 = q1.Y - p1.Y;
		int B1 = p1.X - q1.X;
		int C1 = A1 * p1.X + B1 * p1.Y;

		int A2 = q2.Y - p2.Y;
		int B2 = p2.X - q2.X;
		int C2 = A2 * p2.X + B2 * p2.Y;

		int det = A1 * B2 - A2 * B1;

		int x = (B2 * C1 - B1 * C2) / det;
		int y = (A1 * C2 - A2 * C1) / det;

		return new Point(x, y);
	}
}
