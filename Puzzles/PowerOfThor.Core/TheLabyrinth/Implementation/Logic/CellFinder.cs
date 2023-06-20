namespace TheLabyrinth.Abstraction.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

public class CellFinder : ICellFinder
{
   public LabyrinthCell? GetTargetCell(Labyrinth labyrinth)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      var foundTargetCell = GetAllCells(labyrinth).FirstOrDefault(x => x.Type == LabyrinthCellType.Target);

      return foundTargetCell;
   }

   private static IEnumerable<LabyrinthCell> GetAllCells(Labyrinth labyrinth)
   {
      return labyrinth.Cells.SelectMany(x => x);
   }

   public bool IsTargetVisible(Labyrinth labyrinth)
   {
      return GetTargetCell(labyrinth) is not null;
   }

   public LabyrinthCell GetActualPositionCell(Labyrinth labyrinth)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      var foundMyPositionCell = GetAllCells(labyrinth).First(x => x.Type == LabyrinthCellType.MyPosition);

      return foundMyPositionCell;
   }
}