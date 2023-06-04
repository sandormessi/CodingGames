namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IPathCalculator
{
   #region Public Methods and Operators

   IEnumerable<CellPath> CalculatePath(IEnumerable<ActualCellInfo> baseCell);

   #endregion
}