using Microsoft.Xna.Framework;

namespace Grid.Structure.Extensions
{
  public static class IntExtensions
  {
    /// <summary>
    /// Helper method that turns an integer into a point
    /// </summary>
    /// <param name="i">The index on the 1d array grid</param>
    /// <param name="width">The width of the grid</param>
    /// <returns>Will return the x, y position based on the array index</returns>
    public static Point ToPoint(this int i, int width)
    {
      return new Point(i % width, i / width);
    }
  }
}
