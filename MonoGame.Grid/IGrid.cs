using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Grid
{
  /// <summary>
  /// Grid interface meant to create a grid type object
  /// </summary>
  /// <typeparam name="TValue">The type of object stored on the grid</typeparam>
  public interface IGrid<TValue> : IEnumerable<TValue>
  {
    /// <summary>
    /// Internal grid meant to store the items for the grid
    /// </summary>
    public int Width { get; }

    /// <summary>
    /// The current height of the grid
    /// </summary>
    public int Height { get; }

    /// <summary>
    /// Gets the grid value that exists at a specific x and y index
    /// </summary>
    /// <param name="x">The x position for the value</param>
    /// <param name="y">The y position for the value</param>
    /// <returns>Will return a value based on the x and y position given</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Will return an out of range exception if either x is between 0 and width of
    /// grid and x is between 0 and height of grid
    /// </exception>
    public TValue this[int x, int y] { get; set; }

    /// <summary>
    /// Overloaded operator to get a item at the specific index on the grid based on a 1d array
    /// </summary>
    /// <param name="i">The index in the array</param>
    /// <returns>The item found at the index position</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Will return an out of range exception if either x is between 0 and width of
    /// grid and x is between 0 and height of grid
    /// </exception>
    public TValue this[int i] { get; set; }

    /// <summary>
    /// Overloaded operator to get and set data at a specific point on the grid
    /// </summary>
    /// <param name="point">The point on the grid we need to get or set</param>
    /// <returns>Will return the value at a specific point or set it</returns>
    /// <exception cref="IndexOutOfRangeException">
    /// Will return an out of range exception if either x is between 0 and width of
    /// grid and x is between 0 and height of grid
    /// </exception>
    public TValue this[Point point] { get; set; }

    /// <summary>
    /// Gets a read only span of the grid, in a single based array where x = i % width and y = i / width
    /// </summary>
    /// <returns>Returns a span of the grid</returns>
    public ReadOnlySpan<TValue> AsSpan();

    /// <summary>
    /// Adds a set of items to the grid one row at a time
    /// </summary>
    /// <param name="items">The row of items we are currently adding</param>
    /// <remarks>
    /// This will mainly be used during the construction of the object
    /// so that it is easier to see the grid based on putting it in code
    /// </remarks>
    public void Add(params TValue[] items);

    /// <summary>
    /// Clears the grid and assigns all values with null
    /// </summary>
    public void Clear();

    /// <summary>
    /// Helper method meant to determine if a point exists in the grid
    /// </summary>
    /// <param name="point">The point we are looking for</param>
    /// <returns>Will return a true or false based on if the point exists in the grid</returns>
    public bool Contains(Point point);
  }
}
