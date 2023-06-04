namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class MostHarvestingCalculator : IMostHarvestingCollectionCalculator
{
   #region Constants and Fields

   private readonly IMaximumHarvestCollectionCalculator maximumHarvestCalculator;

   #endregion

   #region Constructors and Destructors

   public MostHarvestingCalculator(IMaximumHarvestCollectionCalculator maximumHarvestCalculator)
   {
      this.maximumHarvestCalculator = maximumHarvestCalculator ?? throw new ArgumentNullException(nameof(maximumHarvestCalculator));
   }

   #endregion

   #region IMostEggHarvestingCollectionCalculator Members

   public IEnumerable<MaximumHarvestCellPath> CalculateMaximumHarvestForCellPaths(CellInfoPerTurn cellInfoPerTurn, IEnumerable<CellPath> cellPathsToCheck, ResourceType resourceType)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      if (cellPathsToCheck == null)
      {
         throw new ArgumentNullException(nameof(cellPathsToCheck));
      }

      IEnumerable<CellPath> cellPathsToEggs = cellPathsToCheck.Where(x => resourceType.HasFlag(x.ActualCell2.Type));
      return maximumHarvestCalculator.CalculateMaximumHarvestForCellPaths(cellInfoPerTurn, cellPathsToEggs);
   }

   #endregion
}