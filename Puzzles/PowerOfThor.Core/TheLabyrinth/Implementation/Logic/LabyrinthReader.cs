namespace TheLabyrinth;

using System;
using System.Collections.Generic;
using System.Linq;

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

      var cellStrings = labyrinthCellStrings.ToArray();
      List<IReadOnlyList<LabyrinthCell>> cells = cellStrings
         .Select((labyrinthCellString, rowIndex) => labyrinthCellString.Select((cellData, columnIndex) => labyrinthCellReader.ReadLabyrinthCell(cellData, rowIndex, columnIndex)).ToList())
         .Cast<IReadOnlyList<LabyrinthCell>>()
         .ToList();

      return new Labyrinth(cells);
   }
}