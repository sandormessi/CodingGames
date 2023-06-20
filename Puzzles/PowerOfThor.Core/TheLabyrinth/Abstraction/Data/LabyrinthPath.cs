using System;
using System.Collections.Generic;

namespace TheLabyrinth.Abstraction.Data;

using System.Linq;

public class LabyrinthPath
{
   public LabyrinthPath(IReadOnlyList<LabyrinthCell> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));

      StartCell = cells[0];
      TargetCell = cells.Last();
      Distance = cells.Count;
   }

   public LabyrinthCell StartCell { get; }

   public IReadOnlyList<LabyrinthCell> Cells { get; }

   public LabyrinthCell TargetCell { get; }

   public int Distance { get; }
}