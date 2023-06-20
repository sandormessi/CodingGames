namespace TheLabyrinth.Abstraction;

using System;
using System.Collections.Generic;

public class LabyrinthWithMoveCost
{
   public LabyrinthWithMoveCost(IReadOnlyList<IReadOnlyList<LabyrinthCellWithMoveCost>> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
   }

   public IReadOnlyList<IReadOnlyList<LabyrinthCellWithMoveCost>> Cells { get; }
}