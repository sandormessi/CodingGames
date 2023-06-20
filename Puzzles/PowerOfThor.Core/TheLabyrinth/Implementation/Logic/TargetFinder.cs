namespace TheLabyrinth.Abstraction.Logic;

using System;
using System.Linq;

public class TargetFinder : ITargetFinder
{
   public LabyrinthCell? GetTargetCell(Labyrinth labyrinth)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      var foundTargetCell = labyrinth.Cells.SelectMany(x => x).FirstOrDefault(x => x.Type == LabyrinthCellType.Target);

      return foundTargetCell;
   }

   public bool IsTargetVisible(Labyrinth labyrinth)
   {
      return GetTargetCell(labyrinth) is not null;
   }
}