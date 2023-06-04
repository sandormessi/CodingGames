namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;
using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class ResourceReachPathFinder : IResourceReachPathFinder
{
   #region IResourceReachPathFinder Members

   public IEnumerable<CellPath> GetResourceRichOrderedCellPaths(CellInfoPerTurn cellInfoPerTurn, IEnumerable<CellPath> allCellPaths, ResourceType resourceTypeToTakePrecedence)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      if (allCellPaths == null)
      {
         throw new ArgumentNullException(nameof(allCellPaths));
      }

      IOrderedEnumerable<CellPath> pathOrderedByDistance = allCellPaths
         .OrderBy(x => x.CellsAlongPath.Count)
         .ThenBy(x => x.CellsCrossedByOpponentHarvestChain);

      return resourceTypeToTakePrecedence switch
      {
         ResourceType.Empty => throw new InvalidOperationException("Illogical decision."),
         ResourceType.Egg => pathOrderedByDistance.ThenByDescending(x => x.EggCellsAlongPath).ThenByDescending(x => x.CrystalsCellsAlongPath),
         ResourceType.Crystal => pathOrderedByDistance.ThenByDescending(x => x.CrystalsCellsAlongPath).ThenByDescending(x => x.AllResourceCellsAlongPath),
         ResourceType.All => pathOrderedByDistance.ThenByDescending(x => x.AllResourceCellsAlongPath).ThenByDescending(x => x.CrystalsCellsAlongPath),
         _ => throw new ArgumentOutOfRangeException(nameof(resourceTypeToTakePrecedence), resourceTypeToTakePrecedence, null)
      };
   }

   #endregion
}