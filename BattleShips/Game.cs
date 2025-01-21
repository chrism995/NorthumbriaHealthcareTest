using BattleShips.Core.Enums;
using BattleShips.Core.Interfaces;
using BattleShips.Core.Models;
using BattleShips.UserInterface.Interfaces;

public class Game : IGame
{
    private readonly IGrid _grid;
    private readonly IConsoleInput _input;
    private readonly IConsoleOutput _output;
    private readonly IShipFactory _shipFactory;
    private readonly IRandom _random;
    private readonly IShipPlacementStrategy _shipPlacementStrategy;
    private readonly ICoordinateParser _coordinateParser;

    public Game(IGrid grid, IConsoleInput input, IConsoleOutput output, IShipFactory shipFactory, IRandom random, IShipPlacementStrategy shipPlacementStrategy, ICoordinateParser coordinateParser)
    {
        _grid = grid;
        _input = input;
        _output = output;
        _shipFactory = shipFactory;
        _random = random;
        _shipPlacementStrategy = shipPlacementStrategy;
        _coordinateParser = coordinateParser;
    }

    public void Start()
    {
        PlaceShips();
        _output.WriteLine("Welcome to Battleships!");
        _output.WriteLine("Enter coordinates to fire (Between A1-10 / J1-10):");

        while (!_grid.AllShipsSunk())
        {
            string input = _input.ReadLine().ToUpper();
            if (TryParseCoordinate(input, out Coordinate coordinate))
            {
                try
                {
                    ShotResult result = _grid.Shoot(coordinate);
                    switch (result)
                    {
                        case ShotResult.Miss:
                            _output.WriteLine("Miss!");
                            break;
                        case ShotResult.Hit:
                            _output.WriteLine("Hit!");
                            break;
                        case ShotResult.Sink:
                            _output.WriteLine("You sunk a ship!");
                            break;
                    }
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    _output.WriteLine(ex.Message);
                }
            }
            else
            {
                _output.WriteLine("Invalid input. Please enter coordinates in the format A5.");
            }
        }

        _output.WriteLine("Congratulations! You sunk all the ships!");
    }

    public void PlaceShips()
    {
        _shipPlacementStrategy.PlaceShips(_grid, _shipFactory);
    }

    public bool TryParseCoordinate(string input, out Coordinate coordinate)
    {
        return _coordinateParser.TryParse(input, out coordinate);
    }
}