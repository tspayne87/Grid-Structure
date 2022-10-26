using MonoGame.Grid.Extensions;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Grid.Test.Shapes
{
  internal class SquareShape : IShape<string>
  {
    private Point[] _checks = new Point[] { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) };

    /// <inheritdoc />
    public string Name => "square";

    /// <inheritdoc />
    public List<Point>? HasShapeOnPoint(Point point, Grid<string> grid)
    {
      foreach(var check in _checks)
        if (!grid.Contains(check + point) || grid[check + point] != "X")
          return null;
      return _checks.Select(x => x + point).ToList();
    }
  }
}
