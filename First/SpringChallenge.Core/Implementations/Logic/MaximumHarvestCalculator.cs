namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class MaximumHarvestCalculator : IMaximumHarvestCalculator
{
   #region Constants and Fields

   private static readonly CellPathItemEqualityComparer cellPathItemEqualityComparer = new();

   #endregion

   #region IMaximumHarvestCalculator Members

   public MaximumHarvestCellPath CalculateMaximumHarvestForCellPaths(IEnumerable<CellPath> cellPathsToCheck, int myAntCount)
   {
      if (cellPathsToCheck == null)
      {
         throw new ArgumentNullException(nameof(cellPathsToCheck));
      }

      if (myAntCount < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(myAntCount));
      }

      IEnumerable<CellPath> pathToHarvest = cellPathsToCheck as CellPath[] ?? cellPathsToCheck.ToArray();

      IReadOnlyList<ExtendedCellPathWithCellPathItem> paths = pathToHarvest
         .Select(x => new ExtendedCellPathWithCellPathItem(x.CellsAlongPath.Select(y => new CellPathItem(y))))
         .ToArray();

      int distance = paths.Max(x => x.CellsAlongPath.Count);

      CountMaxHarvest(myAntCount, distance, paths);

      IEnumerable<CellPathItem> allCellPathItemALongPath = paths.SelectMany(x => x.CellsAlongPath);

      IEnumerable<CellPathItem> cellPathItems = allCellPathItemALongPath
         .Where(x => !x.Cell.Type.HasFlag(ResourceType.Empty))
         .Distinct(cellPathItemEqualityComparer);

      int maximumResourceToHarvest = cellPathItems.Sum(x => x.AntCount);

      int unusedAnt = 
      return new MaximumHarvestCellPath(pathToHarvest, maximumResourceToHarvest, unusedAnt);
   }

   #endregion

   #region Methods

    private int CountUnusedAnt(ExtendedCellPathWithCellPathItem extendedCellPath)
    {
        int unusedAnts = 0;
        var maxAntAlongPath = extendedCellPath.CellsAlongPath.Max(x => x.AntCount);
        IReadOnlyList<CellPathItem> cellPathItems = extendedCellPath.CellsAlongPath.Reverse().ToArray();
        for (int i = 0; i < cellPathItems.Count; i++)
        {
            CellPathItem cellPathItem = cellPathItems[i];

            if (cellPathItem.Cell.Type.HasFlag(ResourceType.Empty) && cellPathItem.AntCount > maxAntAlongPath)
            {
                int unusedAntInCell = cellPathItem.AntCount - maxAntAlongPath;
                var cellsWithUnusedAnts = cellPathItems.Skip(i).TakeWhile(x => x.Cell.Type.HasFlag(ResourceType.Empty)).ToArray();
                foreach (var cell in cellsWithUnusedAnts)
                {
                    cell.AntCount -= unusedAntInCell;
                }

                unusedAnts += cellsWithUnusedAnts.Length * unusedAntInCell;
            }
        }

        return unusedAnts;
    }

    private int CountUnusedAnt2(ExtendedCellPathWithCellPathItem extendedCellPath)
    {
        int unusedAnts = 0;
        var maxAntAlongPath = extendedCellPath.CellsAlongPath.Max(x => x.AntCount);
        IReadOnlyList<CellPathItem> cellPathItems = extendedCellPath.CellsAlongPath.Reverse().ToArray();
        for (int i = 0; i < cellPathItems.Count; i++)
        {
            CellPathItem cellPathItem = cellPathItems[i];

            var actualAntCount = cellPathItem.AntCount;
            while (cellPathItem.AntCount == actualAntCount)
            {

            }
        }

        return unusedAnts;
    }
    private static void CountMaxHarvest(int antsRemained, int distance, IReadOnlyList<ExtendedCellPathWithCellPathItem> paths)
   {
      const int change = 1;
      while (antsRemained >= 0)
      {
         for (var i = 0; i < distance; i++)
         {
            List<CellPathItem> itemsToPlaceAnt = new();
            foreach (ExtendedCellPathWithCellPathItem cellPath in paths)
            {
               if (cellPath.CellsAlongPath.Count <= i)
               {
                  continue;
               }
               
               CellPathItem cellPathItem = cellPath.CellsAlongPath[i];
               if (itemsToPlaceAnt.Any(x => x.Cell.CellId == cellPathItem.Cell.CellId))
               {
                  continue;
               }

               itemsToPlaceAnt.Add(cellPathItem);
            }

            foreach (CellPathItem cellPathItem in itemsToPlaceAnt)
            {
               antsRemained -= change;
               if (antsRemained < 0)
               {
                  return;
               }

               cellPathItem.AntCount += change;
            }
         }
      }
   }

   #endregion

   private class CellPathItem
   {
      #region Constructors and Destructors

      public CellPathItem(ActualCellInfo cell)
      {
         Cell = cell;
      }

      #endregion

      #region Public Properties

      public int AntCount { get; set; }

      public ActualCellInfo Cell { get; }

      public int UnusedAnts { get; set; }

      #endregion
   }

   private class CellPathItemEqualityComparer : IEqualityComparer<CellPathItem>
   {
      #region IEqualityComparer<CellPathItem> Members

      public bool Equals(CellPathItem? x, CellPathItem? y)
      {
         if (ReferenceEquals(x, y))
         {
            return true;
         }

         if (x is null)
         {
            return false;
         }

         if (y is null)
         {
            return false;
         }

         return (x.GetType() == y.GetType()) && x.Cell.CellId.Equals(y.Cell.CellId);
      }

      public int GetHashCode(CellPathItem obj)
      {
         return obj.Cell.CellId.GetHashCode();
      }

      #endregion
   }

   private class ExtendedCellPathWithCellPathItem
   {
      #region Constructors and Destructors

      public ExtendedCellPathWithCellPathItem(IEnumerable<CellPathItem> cellsALongPath)
      {
         CellsAlongPath = cellsALongPath.ToArray();
      }

      #endregion

      #region Public Properties

      public IReadOnlyList<CellPathItem> CellsAlongPath { get; }

      #endregion
   }
}