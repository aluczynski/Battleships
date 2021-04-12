# Battleships
> Simple implementation of Battleships Game as a console application. This is one sided game, where you 
> try to destroy 3 ships randomly placed by computer.

## Table of contents
* [Setup](#Setup)
* [Key Information](#key-information)
* [Code Examples](#Code-examples) 
* [Licence](#Licence)

## Setup
Download and Install .NET SDK 5.0 or above.

Download or Clone the repository.

Open the project with your favorite IDE (VS Code, Visual Studio, Atom, etc).

Run the app with your IDE or these commands:

````
$ cd /your-local-path/Battleships
````
Then:
````
$ dotnet run
````

## Key Information
* Code coverage: 71%
* 2 character input for target - A-J for column (not case sensitive) and 0-9 for row (for sake of simplicity) i.e. "C2"
* Feedback for invalid input
* Prints " X " for hit, " 0 " for miss, " . " for not checked space
* Class Ship - ships differ by size (2 ships of size 4, one of size 5)
* Played until 13 hits

## Code Examples

Past hits are marked as hits again, to allow for anything that does not shoot ship to be marked as miss.
````
if (map[column, row] == State.HiddenShip || map[column, row] == State.Hit)
{
    if (map[column, row] == State.HiddenShip) IncreaseScore(1);
    map[column, row] = State.Hit;
}
else
{
    map[column, row] = State.Miss;
}
````

## Licence [![PyPI license](https://img.shields.io/pypi/l/ansicolortags.svg)](https://pypi.python.org/pypi/ansicolortags/)
