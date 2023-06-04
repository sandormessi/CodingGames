namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;

public interface IMaximumHarvestCalculator
{
   #region Public Methods and Operators

   MaximumHarvestCellPath CalculateMaximumHarvestForCellPaths(IEnumerable<CellPath> cellPathsToCheck, int myAntCount);

   #endregion
}