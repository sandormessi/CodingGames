namespace TheLabyrinth;

using System;

public class LabyrinthCellReader : ILabyrinthCellReader
{
   public LabyrinthCell ReadLabyrinthCell(char cellData)
   {
      return cellData switch
      {
         '#' => new LabyrinthCell(LabyrinthCellType.Wall),
         '.' => new LabyrinthCell(LabyrinthCellType.Empty),
         'T' => new LabyrinthCell(LabyrinthCellType.MyPosition),
         'C' => new LabyrinthCell(LabyrinthCellType.Target),
         '?' => new LabyrinthCell(LabyrinthCellType.Unknown),
         _ => throw new ArgumentOutOfRangeException("Invalid input data.")
      };
   }
}