namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class MaximumHarvestCollectionCalculator : IMaximumHarvestCollectionCalculator
{
   #region Constants and Fields

   private readonly IAntCounter antCounter;

   private readonly IMaximumHarvestCalculator maximumHarvestCalculator;

   #endregion

   #region Constructors and Destructors

   public MaximumHarvestCollectionCalculator(IMaximumHarvestCalculator maximumHarvestCalculator, IAntCounter antCounter)
   {
      this.maximumHarvestCalculator = maximumHarvestCalculator ?? throw new ArgumentNullException(nameof(maximumHarvestCalculator));
      this.antCounter = antCounter ?? throw new ArgumentNullException(nameof(antCounter));
   }

   #endregion

   #region IMaximumHarvestCollectionCalculator Members

   public IEnumerable<MaximumHarvestCellPath> CalculateMaximumHarvestForCellPaths(CellInfoPerTurn cellInfoPerTurn, IEnumerable<CellPath> cellPathsToCheck)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      if (cellPathsToCheck == null)
      {
         throw new ArgumentNullException(nameof(cellPathsToCheck));
      }

      CellPath[] paths = cellPathsToCheck.ToArray();

      int pathCount = paths.Length;

      List<MaximumHarvestCellPath> extendedCellPaths = new();

      int myAntCount = antCounter.CountAllMyAnts(cellInfoPerTurn);

      myAntCount /= cellInfoPerTurn.MyBases.Count;

      for (var i = 1; i <= pathCount; i++)
      {
         IEnumerable<CellPath> cellPathsToCheck2 = paths.Take(i);

         MaximumHarvestCellPath maximumHarvestCellPath = maximumHarvestCalculator.CalculateMaximumHarvestForCellPaths(cellPathsToCheck2, myAntCount);
         extendedCellPaths.Add(maximumHarvestCellPath);
      }

      return extendedCellPaths;
   }

   #endregion
}