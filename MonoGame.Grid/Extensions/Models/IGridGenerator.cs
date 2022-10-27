namespace MonoGame.Grid.Extensions
{
  /// <summary>
  /// Grid generator to fill in a grid with values
  /// </summary>
  /// <typeparam name="TValue">The type of value that will fill the grid with</typeparam>
  public interface IGridGenerator<TValue>
  {
    /// <summary>
    /// Adds a set of shapes that we want avoid adding to the grid when filling it in
    /// </summary>
    /// <typeparam name="TType">The type of shape we are working with</typeparam>
    /// <param name="shapes">The shapes we are avoiding when creating the grid</param>
    /// <returns>Will return the generator for chaining</returns>
    public IGridGenerator<TValue> WithoutShapes<TType>(params IShape<TValue, TType>[] shapes);

    /// <summary>
    /// Adds a getter to randomly set a value on the grid based on the value type
    /// </summary>
    /// <param name="randomGetter">The value getter to call when creating a new object</param>
    /// <returns>Will return the generator for chaining</returns>
    public IGridGenerator<TValue> WithRandomValue(Func<TValue> randomGetter);

    /// <summary>
    /// Will tell the generator to overwrite the whole grid and ignore nulls completely
    /// </summary>
    /// <returns>Will return the generator for chaining</returns>
    public IGridGenerator<TValue> OverwriteNoneNulls();

    /// <summary>
    /// Will generate the grid with values
    /// </summary>
    public void Generate();
  }
}
