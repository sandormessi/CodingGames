namespace TheLabyrinth;

using System;

public class LabyrinthCellReader : ILabyrinthCellReader
{
   public LabyrinthCell ReadLabyrinthCell(char cellData)
   {
      var labyrinthCellType = cellData switch
      {
         '#' => LabyrinthCellType.Wall,
         '.' => LabyrinthCellType.Empty,
         'T' => LabyrinthCellType.MyPosition,
         'C' => LabyrinthCellType.Target,
         '?' => LabyrinthCellType.Unknown,
         _ => throw new ArgumentOutOfRangeException("Invalid input data.")
      };

      return new LabyrinthCell(labyrinthCellType);
   }
}