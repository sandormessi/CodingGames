namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IOpponentPathCalculator
{
   #region Public Methods and Operators

   IDictionary<ActualCellInfo, IReadOnlyList<CellPath>> CalculatePathsForOpponentBases(CellInfoPerTurn cellInfoPerTurn);

   #endregion
}