namespace TheLabyrinth;

using System;

public class Position
{
   public Position(int x, int y)
   {
      if (x < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(x));
      }

      if (y < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(y));
      }

      X = x;
      Y = y;
   }

   public int X { get; }

   public int Y { get; }
}