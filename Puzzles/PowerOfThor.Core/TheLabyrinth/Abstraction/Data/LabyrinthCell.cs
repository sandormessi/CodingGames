namespace TheLabyrinth;

using System;

public class LabyrinthCell
{
   public LabyrinthCell(LabyrinthCellType type, Position position)
   {
      Type = type;
      Position = position ?? throw new ArgumentNullException(nameof(position));
   }

   public Position Position { get; }

   public LabyrinthCellType Type { get; }
}