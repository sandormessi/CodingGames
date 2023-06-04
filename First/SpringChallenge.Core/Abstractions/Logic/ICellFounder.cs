namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface ICellFounder
{
   #region Public Methods and Operators

   IEnumerable<ActualCellInfo> FindCellsWithBothAnts(CellInfoPerTurn cellInfoPerTurn);

   #endregion
}