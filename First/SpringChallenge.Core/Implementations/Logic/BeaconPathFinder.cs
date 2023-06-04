namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class BeaconPathFinder : IBeaconPathFinder
{
   #region Constants and Fields

   private static readonly ActualCellInfoEqualityComparer ActualCellInfoEqualityComparer = new();

   private readonly IAntCounter antCounter;

   private readonly IMaximumHarvestCollectionCalculator maximumHarvestCollectionCalculator;

   private readonly IMostHarvestingCollectionCalculator mostHarvestingCalculator;

   private readonly IResourceReachPathFinder resourceReachPathFinder;

   #endregion

   #region Constructors and Destructors

   public BeaconPathFinder(IAntCounter antCounter, IResourceReachPathFinder resourceReachPathFinder, IMostHarvestingCollectionCalculator mostHarvestingCalculator,
      IMaximumHarvestCollectionCalculator maximumHarvestCollectionCalculator)
   {
      this.antCounter = antCounter ?? throw new ArgumentNullException(nameof(antCounter));
      this.resourceReachPathFinder = resourceReachPathFinder ?? throw new ArgumentNullException(nameof(resourceReachPathFinder));
      this.mostHarvestingCalculator = mostHarvestingCalculator ?? throw new ArgumentNullException(nameof(mostHarvestingCalculator));
      this.maximumHarvestCollectionCalculator = maximumHarvestCollectionCalculator ?? throw new ArgumentNullException(nameof(maximumHarvestCollectionCalculator));
   }

   #endregion

   #region IBeaconPathFinder Members

   public IEnumerable<CellPath> GetCellsForBeacon(IReadOnlyList<CellPath> allPaths, CellInfoPerTurn cellInfoPerTurn, ResourceType resourceTypeToTakePrecedence)
   {
      if (allPaths is null)
      {
         throw new ArgumentNullException(nameof(allPaths));
      }

      if (cellInfoPerTurn is null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      IReadOnlyList<CellPath> resourceCellPaths = resourceReachPathFinder.GetResourceRichOrderedCellPaths(cellInfoPerTurn, allPaths, resourceTypeToTakePrecedence).ToArray();

      return GetBeaconCellCollection(cellInfoPerTurn, resourceCellPaths, resourceTypeToTakePrecedence);
   }

   #endregion

   #region Methods

   private static int CountCellsAlongCellPaths(MaximumHarvestCellPath maximumHarvestCellPath)
   {
      return maximumHarvestCellPath.PathsToHarvest
         .SelectMany(x => x.CellsAlongPath)
         .Distinct(ActualCellInfoEqualityComparer)
         .Count();
   }

   private static IEnumerable<CellPath> GetHarvestingPaths(int myAntCount, IOrderedEnumerable<MaximumHarvestCellPath> maximumHarvestCellPaths)
   {
      return maximumHarvestCellPaths.First(x => CountCellsAlongCellPaths(x) <= myAntCount).PathsToHarvest;
   }

   private static IEnumerable<CellPath> SelectMostHarvestingForEggs(IEnumerable<MaximumHarvestCellPath> paths, int myAntCount)
   {
      IOrderedEnumerable<MaximumHarvestCellPath> maximumHarvestCellPaths =
         paths
            .OrderByDescending(x => x.MaximumResourceToHarvest)
            .ThenByDescending(x => x.PathsToHarvest.Sum(y => y.CrystalsCellsAlongPath));

      return GetHarvestingPaths(myAntCount, maximumHarvestCellPaths);
   }

   private static IEnumerable<CellPath> SelectMostHarvestingForResources(IEnumerable<MaximumHarvestCellPath> paths, int myAntCount)
   {
      IOrderedEnumerable<MaximumHarvestCellPath> maximumHarvestCellPaths =
         paths
            .OrderByDescending(x => x.MaximumResourceToHarvest)
            .ThenByDescending(x => x.PathsToHarvest.Sum(y => y.EggCellsAlongPath));

      return GetHarvestingPaths(myAntCount, maximumHarvestCellPaths);
   }

   private IEnumerable<CellPath> GetBeaconCellCollection(CellInfoPerTurn cellInfoPerTurn, IReadOnlyCollection<CellPath> resourceCellPaths, ResourceType resourceTypeToTakePrecedence)
   {
      IReadOnlyList<MaximumHarvestCellPath> maximumSelectedResourceType =
         mostHarvestingCalculator
            .CalculateMaximumHarvestForCellPaths(cellInfoPerTurn, resourceCellPaths, resourceTypeToTakePrecedence)
            .ToArray();

      int myAntCount = antCounter.CountAllMyAnts(cellInfoPerTurn);

      IEnumerable<MaximumHarvestCellPath> paths = maximumSelectedResourceType;
      if (!paths.Any())
      {
         paths = maximumHarvestCollectionCalculator.CalculateMaximumHarvestForCellPaths(cellInfoPerTurn, resourceCellPaths);
         return SelectMostHarvestingForResources(paths, myAntCount);
      }

      return SelectMostHarvestingForEggs(paths, myAntCount);
   }

   #endregion
}