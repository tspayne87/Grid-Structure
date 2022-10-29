using Microsoft.Xna.Framework;
using System.Collections;
using System.Runtime.CompilerServices;

namespace MonoGame.Grid
{
  public class Grid<TValue> : IGrid<TValue>
  {
    /// <summary>
    /// Internal grid meant to store the items for the grid
    /// </summary>
    private TValue[] _grid;

    /// <inheritdoc />
    public int Width { get; private set; }

    /// <inheritdoc />
    public int Height { get; private set; }

    /// <summary>
    /// Creates a grid object with the current width and height
    /// </summary>
    /// <param name="width">The width of the grid</param>
    /// <param name="height">The height of the grid</param>
    public Grid(int width, int height)
    {
      if (width <= 0 || height <= 0) throw new IndexOutOfRangeException();
      _grid = new TValue[width * height];

      Width = width;
      Height = height;
    }

    /// <summary>
    /// Basic grid constructor that will make an empty grid
    /// </summary>
    public Grid()
    {
      Width = 0;
      Height = 0;
      _grid = new TValue[0];
    }

    /// <inheritdoc />
    public TValue this[int x, int y]
    {
      get
      {
        if (Width <= x || x < 0) throw new IndexOutOfRangeException($"${x} is out of range of width");
        if (Height <= y || y < 0) throw new IndexOutOfRangeException($"${y} is out of range of height");
        return _grid[y * Width + x];
      }

      set
      {
        if (Width <= x || x < 0) throw new IndexOutOfRangeException($"${x} is out of range of width");
        if (Height <= y || y < 0) throw new IndexOutOfRangeException($"${y} is out of range of height");
        _grid[y * Width + x] = value;
      }
    }

    /// <inheritdoc />
    public TValue this[int i]
    {
      get => _grid[i];
      set => _grid[i] = value;
    }

    /// <inheritdoc />
    public TValue this[Point point]
    {
      get => this[point.X, point.Y];
      set => this[point.X, point.Y] = value;
    }

    /// <inheritdoc />
    public ReadOnlySpan<TValue> AsSpan()
    {
      return new ReadOnlySpan<TValue>(_grid);
    }

    /// <inheritdoc />
    public void Add(params TValue[] items)
    {
      if (_grid.Length == 0) // We only worry about the first item added to calculate the width
        Width = items.Length;

      Array.Resize(ref _grid, _grid.Length + Width); // Resize the array and add the new items to the end of the newly resized array
      Height++; // Update the height since we are working with the next row
      for (int i = 0; i < Math.Min(items.Length, Width); i++)
        _grid[Width * (Height - 1) + i] = items[i];
    }

    /// <inheritdoc />
    public void Clear()
    {
      _grid = new TValue[Width * Height];
    }

    /// <inheritdoc />
    public bool Contains(Point point)
    {
      return Width > point.X && point.X >= 0 && Height > point.Y && point.Y >= 0;
    }

    /// <inheritdoc />
    public IEnumerator<TValue> GetEnumerator()
    {
      return _grid.AsEnumerable().GetEnumerator();
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator()
    {
      return _grid.GetEnumerator();
    }
  }
}