namespace TheLabyrinth.Abstraction;

using System;

public class InputManager : IInputManager
{
   public void Move(Direction direction)
   {
      var directionString = direction.ToString().ToUpper();
      Console.WriteLine(directionString);
   }
}