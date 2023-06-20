namespace TheLabyrinth;

using System;

public class LabyrinthCellReader : ILabyrinthCellReader
{
   public LabyrinthCell ReadLabyrinthCell(char cellData, int rowIndex, int columnIndex)
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

      return new LabyrinthCell(labyrinthCellType, new Position(columnIndex, rowIndex));
   }
}