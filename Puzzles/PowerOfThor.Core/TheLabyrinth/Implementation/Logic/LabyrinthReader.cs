namespace TheLabyrinth;

using System;
using System.Collections.Generic;

public class LabyrinthReader : ILabyrinthReader
{
   private readonly ILabyrinthCellReader labyrinthCellReader;

   public LabyrinthReader(ILabyrinthCellReader labyrinthCellReader)
   {
      this.labyrinthCellReader = labyrinthCellReader ?? throw new ArgumentNullException(nameof(labyrinthCellReader));
   }

   public Labyrinth ReadLabyrinth(IEnumerable<string> labyrinthCellStrings)
   {
      if (labyrinthCellStrings == null)
      {
         throw new ArgumentNullException(nameof(labyrinthCellStrings));
      }

      List<IReadOnlyList<LabyrinthCell>> cells = new();
      foreach (var labyrinthCellString in labyrinthCellStrings)
      {
         List<LabyrinthCell> actualLabyrinthRow = new();
         foreach (var cellData in labyrinthCellString)
         {
            var labyrinthCell = labyrinthCellReader.ReadLabyrinthCell(cellData);
            actualLabyrinthRow.Add(labyrinthCell);
         }

         cells.Add(actualLabyrinthRow);
      }

      return new Labyrinth(cells);
   }
}