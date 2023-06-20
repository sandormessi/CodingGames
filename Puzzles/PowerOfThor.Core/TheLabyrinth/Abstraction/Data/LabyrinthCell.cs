namespace TheLabyrinth;

using System;

public class LabyrinthCell : IEquatable<LabyrinthCell>
{
   public LabyrinthCell(LabyrinthCellType type, Position position)
   {
      Type = type;
      Position = position ?? throw new ArgumentNullException(nameof(position));
   }

   public Position Position { get; }

   public LabyrinthCellType Type { get; }

   public bool Equals(LabyrinthCell? other)
   {
      if (other is null)
      {
         return false;
      }

      if (ReferenceEquals(this, other))
      {
         return true;
      }

      return Position.Equals(other.Position) && Type == other.Type;
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

      return obj.GetType() == GetType() && Equals((LabyrinthCell)obj);
   }

   public override int GetHashCode()
   {
      unchecked
      {
         return (Position.GetHashCode() * 397) ^ (int)Type;
      }
   }
}