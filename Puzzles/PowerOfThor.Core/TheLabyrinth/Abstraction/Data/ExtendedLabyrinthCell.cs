namespace TheLabyrinth;

using System;

using TheLabyrinth.Abstraction.Data;

public class ExtendedLabyrinthCell : LabyrinthCell
{
   public ExtendedLabyrinthCell(LabyrinthCellType type, Position position, LabyrinthCellNeighborInfo neighbors)
      : base(type, position)
   {
      Neighbors = neighbors ?? throw new ArgumentNullException(nameof(neighbors));
   }

   public LabyrinthCellNeighborInfo Neighbors { get; }
}