namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class AntCounter : IAntCounter
{
   #region IAntCounter Members

   public int CountAllMyAnts(CellInfoPerTurn cellInfoPerTurn)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      return cellInfoPerTurn.Cells.Sum(x => x.MyAntCount) / cellInfoPerTurn.MyBases.Count;
   }

   public int CountMyAntsInCells(IEnumerable<ActualCellInfo> cells)
   {
      if (cells == null)
      {
         throw new ArgumentNullException(nameof(cells));
      }

      return cells.Sum(actualCellInfo => actualCellInfo.MyAntCount);
   }

   public int CountOpponentAntsAlongPath(IEnumerable<ActualCellInfo> cellsAlongPath)
   {
      if (cellsAlongPath == null)
      {
         throw new ArgumentNullException(nameof(cellsAlongPath));
      }

      return cellsAlongPath.Sum(actualCellInfo => actualCellInfo.OpponentAntCount);
   }

   #endregion
}