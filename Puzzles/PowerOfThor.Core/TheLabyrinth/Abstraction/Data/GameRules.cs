namespace TheLabyrinth.Abstraction.Data;

using System;

public class GameRules
{
   public GameRules(int fieldOfView)
   {
      if (fieldOfView <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(fieldOfView));
      }

      FieldOfView = fieldOfView;
   }

   public int FieldOfView { get; }
}