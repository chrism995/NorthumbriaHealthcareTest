# NorthumbriaHealthcareTest

---

## Battleships technical test

OVERVIEW One-sided game of Battleships implemented as part of a technical test. The application is a console-based game where a single human player competes against the computer. The game needs to demonstrates clean code practices, adhere to SOLID principles, and future scalability. Provide a good level of test coverage but within time constraints.

## FEATURES

- 10x10 grid with ships placed randomly:
- 1x Battleship (5 squares)
- 2x Destroyers (4 squares each)
- Accepts user input in the format A5 to target grid cells.
- Provides feedback on hits, misses, and when ships are sunk.
- Focused on maintainability, readability, and testability.
- Built with C# .NET 8.
- Add basic unit testing given time constraint

## REQUIREMENTS

.NET 8 SDK installed on your machine.
A terminal to run the console application.

## HOW TO RUN THE GAME

1. Clone the repository: git clone https://github.com/chrism995/NorthumbriaHealthcareTest.git
2. Navigate to the project directory: cd BattleShips
3. Run the following command in the terminal: dotnet run

## HOW TO RUN THE UNIT TESTS

1. Navigate to the project directory: cd BattleShips.Tests
2. run the follllowing command in the terminal - dotnet test

## TIME SPENT

2.5 hours

## FUTURE REVISIONS

1. Displaying a GUI to the user showing what areas have already been targeted with M for Miss and H for Hit
2. Simulate the user playing against another user with two boards
3. Implement different placement stratergies which can be swapped in and out
4. Allow for additional ships of varying sizes to be added
5. Allow for different board sizes to be played on rather than set to 10x10
