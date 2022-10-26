using MonoGame.Grid.Extensions;
using MonoGame.Grid.Test.Shapes;

namespace MonoGame.Grid.Test
{
  public class GridTests
  {
    [Fact]
    public void NoShapesFoundTest()
    {
      var grid = new Grid<string>()
      {
        { "O", "X", "X" },
        { "O", "O", "X" },
        { "O", "X", "O" }
      };

      var shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });

      Assert.Empty(shapes);
    }

    [Fact]
    public void ShapeTests()
    {
      var grid = new Grid<string>()
      {
        { "O", "X", "X" },
        { "O", "X", "X" },
        { "O", "X", "O" }
      };

      var shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });

      Assert.Single(shapes);
      Assert.Equal("square", shapes[0].Name);

      grid = new Grid<string>()
      {
        { "X", "X", "X" },
        { "O", "X", "X" },
        { "O", "O", "O" }
      };

      shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });

      Assert.Single(shapes);
      Assert.Equal("square", shapes[0].Name);

      grid = new Grid<string>()
      {
        { "X", "X", "X" },
        { "X", "X", "O" },
        { "O", "O", "O" }
      };

      shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });
      Assert.Single(shapes);
      Assert.Equal("square", shapes[0].Name);

      grid = new Grid<string>()
      {
        { "X", "O", "O" },
        { "X", "X", "O" },
        { "X", "X", "O" }
      };

      shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });
      Assert.Single(shapes);
      Assert.Equal("square", shapes[0].Name);
    }

    [Fact]
    public void MultipleShapeTests()
    {
      var grid = new Grid<string>()
      {
        { "X", "O", "O", "X", "X", "X", "O", "O", "O", "O" },
        { "X", "O", "O", "O", "O", "O", "O", "X", "O", "O" },
        { "X", "O", "O", "O", "X", "X", "O", "X", "O", "O" },
        { "O", "O", "O", "O", "X", "X", "O", "X", "O", "O" },
        { "O", "O", "O", "O", "O", "O", "O", "O", "O", "O" },
        { "O", "O", "O", "O", "O", "O", "O", "O", "O", "O" },
        { "X", "X", "X", "O", "O", "O", "O", "O", "O", "O" },
        { "O", "O", "X", "X", "O", "O", "O", "X", "O", "O" },
        { "O", "O", "X", "X", "O", "O", "O", "X", "O", "O" },
        { "O", "O", "X", "X", "O", "O", "O", "X", "O", "O" }
      };

      var shapes = grid.FindShapes(new List<IShape<string>>() { new SquareShape(), new LineShape() });

      Assert.Equal(7, shapes.Count);
      Assert.Equal(2, shapes.Count(x => x.Name == "square"));
      Assert.Equal(5, shapes.Count(x => x.Name == "line"));
    }
  }
}