namespace TheLabyrinth.Abstraction;

using System;

public class OutputManager : IOutputManager
{
   public void Move(Direction direction)
   {
      var directionString = direction.ToString().ToUpper();
      Console.WriteLine(directionString);
   }
}