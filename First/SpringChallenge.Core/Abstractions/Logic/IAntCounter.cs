namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IAntCounter
{
   #region Public Methods and Operators

   int CountAllMyAnts(CellInfoPerTurn cellInfoPerTurn);

   int CountMyAntsInCells(IEnumerable<ActualCellInfo> cells);

   int CountOpponentAntsAlongPath(IEnumerable<ActualCellInfo> cellsAlongPath);

   #endregion
}