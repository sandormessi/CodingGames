namespace TheLabyrinth.Abstraction.Data;

using System;

public class MovementAnalysisResult
{
   public MovementAnalysisResult(bool canMove, int cellsToExplore)
   {
      if (cellsToExplore < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(cellsToExplore));
      }

      CanMove = canMove;
      CellsToExplore = cellsToExplore;
   }

   public bool CanMove { get; }

   public int CellsToExplore { get; }
}