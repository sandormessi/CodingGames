namespace PowerOfThor.Core.Implementation.Game;

using System;
using Abstraction.Data;
using PowerOfThor.Core.Abstraction.Game;

public class OutputManager : IOutputManager
{
    public void MoveThor(Directions direction)
    {
        Console.WriteLine(direction.ToString());
    }
}