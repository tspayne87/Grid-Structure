using Microsoft.Xna.Framework;

namespace MonoGame.Grid.Extensions
{
  public static class PointExtensions
  {
    /// <summary>
    /// Helper method meant convert a point into an array index on a 1d array grid
    /// </summary>
    /// <param name="point">The current point being converted</param>
    /// <param name="width">The width of the grid</param>
    /// <returns>The index that was calculated based on the point</returns>
    public static int ToIndex(this Point point, int width)
    {
      return point.Y * width + point.X;
    }
  }
}
