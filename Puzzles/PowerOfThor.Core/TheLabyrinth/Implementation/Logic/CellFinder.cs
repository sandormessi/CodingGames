namespace TheLabyrinth.Abstraction.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

public class CellFinder : ICellFinder
{
   public ExtendedLabyrinthCell? GetTargetCell(ExtendedLabyrinth labyrinth)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      var foundTargetCell = GetAllCells(labyrinth).FirstOrDefault(x => x.Type == LabyrinthCellType.Target);

      return foundTargetCell;
   }

   public bool IsTargetVisible(ExtendedLabyrinth labyrinth)
   {
      return GetTargetCell(labyrinth) is not null;
   }

   public ExtendedLabyrinthCell GetActualPositionCell(ExtendedLabyrinth labyrinth)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      var foundMyPositionCell = GetAllCells(labyrinth).First(x => x.Type == LabyrinthCellType.MyPosition);

      return foundMyPositionCell;
   }

   private static IEnumerable<ExtendedLabyrinthCell> GetAllCells(ExtendedLabyrinth labyrinth)
   {
      return labyrinth.Cells.SelectMany(x => x);
   }
}