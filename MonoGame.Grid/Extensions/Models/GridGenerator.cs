namespace MonoGame.Grid.Extensions
{
  /// <summary>
  /// Implmentation of <see cref="IGridGenerator{TValue}" />
  /// </summary>
  /// <typeparam name="TValue">The current value that is stored in the grid</typeparam>
  internal class GridGenerator<TValue> : IGridGenerator<TValue>
  {
    /// <summary>
    /// The current grid we are filling in
    /// </summary>
    private readonly IGrid<TValue> _grid;

    /// <summary>
    /// The current shapes we are currently trying to avoid making
    /// </summary>
    private readonly List<IBaseShape<TValue>> _shapesToAvoid;

    /// <summary>
    /// The getter function to get a random value to be put in the grid
    /// </summary>
    private Func<TValue>? _randomGetter;

    /// <summary>
    /// The empty value we want to use when determining if the value should be filled
    /// </summary>
    private TValue? _emptyValue;

    /// <summary>
    /// Builds the generator constructor to fill a grid in
    /// </summary>
    /// <param name="grid">The current grid we are filling in</param>
    public GridGenerator(IGrid<TValue> grid)
    {
      _grid = grid;
      _shapesToAvoid = new List<IBaseShape<TValue>>();
      _randomGetter = null;
      _emptyValue = default;
    }

    /// <inheritdoc />
    public void Generate()
    {
      if (_randomGetter == null)
        throw new ArgumentNullException("randomGetter", "Cannot fill a grid if values are not configured");

      var span = _grid.AsSpan();
      for (var i = span.Length - 1; i >=0; --i)
      {
        if ((span[i] == null && _emptyValue == null) || span[i]?.Equals(_emptyValue) == true)
        {
          var point = i.ToPoint(_grid.Width);

          do
          { // TODO: Figure out a better way to calculate the new item that should be put on the grid
            //       Right now this is very inefficient
            _grid[point] = _randomGetter();
          } while (_shapesToAvoid.Count > 0 && _shapesToAvoid.Any(x => x.HasShapeOnPoint(point, _grid) != null));
        }
      }
    }

    /// <inheritdoc />
    public IGridGenerator<TValue> WithoutShapes<TType>(params IShape<TValue, TType>[] shapes)
    {
      _shapesToAvoid.AddRange(shapes);
      return this;
    }

    /// <inheritdoc />
    public IGridGenerator<TValue> OverwriteNoneNulls()
    {
      _grid.Clear();
      return this;
    }

    /// <inheritdoc />
    public IGridGenerator<TValue> EmptyValue(TValue value)
    {
      _emptyValue = value;
      return this;
    }

    /// <inheritdoc />
    public IGridGenerator<TValue> WithRandomValue(Func<TValue> randomGetter)
    {
      _randomGetter = randomGetter;
      return this;
    }
  }
}
