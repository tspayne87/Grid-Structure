# Monogame Grid
A grid structure that is meant to be used with monogame projects to help store information about a grid object
in a grid.  It is also meant to add common functions that will be used on a grid whether it be a turned based game
to a match three game.

## Installation
#### Package Manager
```bash
    Install-Package MonoGame.Grid
```
#### .NET CLI
```bash
    dotnet add package MonoGame.Grid
```
#### Paket CLI
```bash
    paket add MonoGame.Grid
```

## Usage
```csharp
  var grid = new Grid<string>()
  {
    { "O", "X", "X" },
    { "O", "O", "X" },
    { "O", "X", "O" }
  };

  var item1 = grid[1, 2]; // -- "X"
  var item2 = grid[3]; // Is equal to 1, 0 which will return "O";
  var item3 = grid[new Point(1, 2)] // Will use the monogame point structure and will use the x and y like above which will return "X"
```

## 