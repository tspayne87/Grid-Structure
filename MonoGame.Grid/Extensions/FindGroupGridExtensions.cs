using Microsoft.Xna.Framework;
using System.Runtime.InteropServices;

namespace MonoGame.Grid.Extensions
{
  public static class FindGroupGridExtensions
  {
    /// <summary>
    /// Method is meant to find all shapes in a grid
    /// </summary>
    /// <typeparam name="TValue">The type of object that is stored in the grid</typeparam>
    /// <param name="grid">The grid we are finding shapes in</param>
    /// <param name="shapes">The shapes we are looking for</param>
    /// <returns>Will return a list of shape results found in the grid</returns>
    public static List<FindShapesResult> FindShapes<TValue>(this Grid<TValue> grid, List<IShape<TValue>> shapes)
    {
      var result = new List<FindShapesResult>();

      var foundGrid = new Grid<bool>(grid.Width, grid.Height);
      var span = grid.AsSpan();

      foreach (var shape in shapes)
      {
        for (var i = 0; i < span.Length; ++i)
        {
          if (foundGrid[i])
            continue; // Continue to the next item since this item has already been claimed by shape

          // Determines if the shape exists at this point
          var points = shape.HasShapeOnPoint(i.ToPoint(grid.Width), grid);
          if (points != null && !points.Any(x => foundGrid[x]))
          {
            foreach (var x in CollectionsMarshal.AsSpan(points))
              foundGrid[x] = true;
            result.Add(new FindShapesResult(shape.Name, points));
          }
        }
      }

      return result;
    }
  }
}
