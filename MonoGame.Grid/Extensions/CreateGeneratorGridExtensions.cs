using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame.Grid.Extensions
{
  public static class CreateGeneratorGridExtensions
  {
    /// <summary>
    /// Will create a genertor to define how the grid will be generated with
    /// </summary>
    /// <typeparam name="TValue">The type of object that will be assigned in the grid</typeparam>
    /// <param name="grid">The current grid we need to generate values in</param>
    /// <returns>Will return a generator to fill in a grid</returns>
    public static IGridGenerator<TValue> CreateGenerator<TValue>(this IGrid<TValue> grid)
    {
      return new GridGenerator<TValue>(grid);
    }
  }
}
