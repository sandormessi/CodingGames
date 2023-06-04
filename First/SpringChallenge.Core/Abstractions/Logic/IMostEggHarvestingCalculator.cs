namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IMostHarvestingCollectionCalculator
{
   #region Public Methods and Operators

   IEnumerable<MaximumHarvestCellPath> CalculateMaximumHarvestForCellPaths(CellInfoPerTurn cellInfoPerTurn,IEnumerable<CellPath> cellPathsToCheck, ResourceType resourceType);

   #endregion
}

