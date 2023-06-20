namespace TheLabyrinth;

using System;

public class Position : IEquatable<Position>
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

   public bool Equals(Position? other)
   {
      if (other is null)
      {
         return false;
      }

      if (ReferenceEquals(this, other))
      {
         return true;
      }

      return X == other.X && Y == other.Y;
   }

   public override bool Equals(object? obj)
   {
      if (obj is null)
      {
         return false;
      }

      if (ReferenceEquals(this, obj))
      {
         return true;
      }

      if (obj.GetType() != this.GetType())
      {
         return false;
      }

      return Equals((Position)obj);
   }

   public override int GetHashCode()
   {
      unchecked
      {
         return (X * 397) ^ Y;
      }
   }
}