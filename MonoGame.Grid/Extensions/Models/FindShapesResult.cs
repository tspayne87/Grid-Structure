using Microsoft.Xna.Framework;

namespace MonoGame.Grid.Extensions
{
  /// <summary>
  /// Result object meant to group results together to give information on what shapes were found
  /// </summary>
  public sealed class FindShapesResult
  {
    /// <summary>
    /// The name of the of the shape that was found
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// The points on the grid that make up the shape
    /// </summary>
    public List<Point> Points { get; set; }

    /// <summary>
    /// Will create a find result that specifies what type of shape was found during the search
    /// </summary>
    /// <param name="name">The name of the of the shape that was found</param>
    /// <param name="points">The points on the grid that make up the shape</param>
    internal FindShapesResult(string name, List<Point> points)
    {
      Name = name;
      Points = points;
    }
  }
}
