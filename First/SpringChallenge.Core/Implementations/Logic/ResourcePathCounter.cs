namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class ResourcePathCounter : IResourcePathCounter
{
   #region IResourcePathCounter Members

   public int CountResourceALongPath(IEnumerable<ActualCellInfo> cellsAlongPath, ResourceType resourceType)
   {
      if (cellsAlongPath == null)
      {
         throw new ArgumentNullException(nameof(cellsAlongPath));
      }

      return cellsAlongPath.Count(x =>resourceType.HasFlag(x.Type));
   }

   public int CountResourceALongPath(IEnumerable<ActualCellInfo> cellsAlongPath)
   {
      return CountResourceALongPath(cellsAlongPath, ResourceType.All);
   }

   #endregion
}