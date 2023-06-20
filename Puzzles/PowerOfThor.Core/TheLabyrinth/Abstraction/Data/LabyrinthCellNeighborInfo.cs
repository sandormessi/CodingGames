namespace TheLabyrinth.Abstraction.Data;

using System;
using System.Collections.Generic;

public class LabyrinthCellNeighborInfo
{
   public LabyrinthCellNeighborInfo(IReadOnlyList<LabyrinthCellNeighbor> cellNeighbors)
   {
      CellNeighbors = cellNeighbors ?? throw new ArgumentNullException(nameof(cellNeighbors));
   }

   public IReadOnlyList<LabyrinthCellNeighbor> CellNeighbors { get; }
}