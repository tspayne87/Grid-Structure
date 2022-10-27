using Microsoft.Xna.Framework;

namespace MonoGame.Grid.Extensions
{
  public interface IBaseShape<TValue>
  {
    /// <summary>
    /// Helper method is meant to calculate a list of points that come from top right corner of the shape
    /// </summary>
    /// <param name="point">The starting top right corner of the shape</param>
    /// <param name="grid">The grid we are checking against</param>
    /// <returns>Will return a list of points that represent this shape or null if none was found</returns>
    public List<Point>? HasShapeOnPoint(Point point, IGrid<TValue> grid);
  }

  /// <summary>
  /// The shape we are searching for when looking on a grid
  /// </summary>
  /// <typeparam name="TValue">The type of value that exists in the grid that we want to find a shape for</typeparam>
  /// <typeparam name="TType">The type of shape this is</typeparam>
  public interface IShape<TValue, TType> : IBaseShape<TValue>
  {
    /// <summary>
    /// The name of the shape we found
    /// </summary>
    public TType Type { get; }
  }
}
