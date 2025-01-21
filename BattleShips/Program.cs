using Microsoft.Extensions.DependencyInjection;
using BattleShips.Core.Interfaces;
using BattleShips.Core.Models;
using BattleShips.UserInterface.Interfaces;
using BattleShips.UserInterface.Models;


// Set up dependency injection
var serviceProvider = new ServiceCollection()
    .AddSingleton<IGrid>(new Grid(10)) // Create a 10x10 grid, could be swapped to allow user input for grid size
    .AddSingleton<IShipFactory, ShipFactory>()
    .AddSingleton<IGame, Game>() // Only one game instance howeve could be changed to transient if needed to support multiple games
    .AddSingleton<IConsoleInput, ConsoleInput>() // Could be swapped for a different input method
    .AddSingleton<IConsoleOutput, ConsoleOutput>() // Could be swapped for a different output method
    .AddSingleton<IRandom, RandomWrapper>() 
    .AddSingleton<IShipPlacementStrategy, RandomShipPlacementStrategy>() // Could be swapped for a different strategy
    .AddSingleton<ICoordinateParser, CoordinateParser>()
    .BuildServiceProvider();

// Get the game from the service provider and start it
var game = serviceProvider.GetService<IGame>();
game.Start();