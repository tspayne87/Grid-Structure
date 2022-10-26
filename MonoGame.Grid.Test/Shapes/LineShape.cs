using MonoGame.Grid.Extensions;
using Microsoft.Xna.Framework;

namespace MonoGame.Grid.Test.Shapes
{
  internal class LineShape : IShape<string>
  {
    private int _size = 2;

    /// <inheritdoc />
    public string Name => "line";

    /// <inheritdoc />
    public List<Point>? HasShapeOnPoint(Point point, Grid<string> grid)
    {
      var checks = new List<List<Point>>();
      if (point.X + _size < grid.Width)
        checks.Add(CreateLine(point, new Point(1, 0), _size));
      if (point.Y + _size < grid.Height)
        checks.Add(CreateLine(point, new Point(0, 1), _size));

      foreach(var check in checks)
      {
        var found = true;
        foreach(var item in check)
        {
          if (grid[item] != "X")
          {
            found = false;
            break;
          }
        }

        if (found)
          return check;
      }

      return null;
    }

    private List<Point> CreateLine(Point point, Point vel, int size)
    {
      var points = new List<Point>();
      for (var i = 0; i <= size; ++i)
        points.Add(new Point(vel.X * i, vel.Y * i) + point);
      return points;
    }
  }
}
