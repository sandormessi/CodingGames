namespace SpringChallenge.Core.Implementations.Logic;

using System;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class ResourceSelector : IResourceSelector
{
   #region IResourceSelector Members

   public bool IsResource(ActualCellInfo cellInfo, ResourceType resourceType)
   {
      if (cellInfo == null)
      {
         throw new ArgumentNullException(nameof(cellInfo));
      }

      return resourceType.HasFlag(cellInfo.Type) && (cellInfo.ActualResourceCount > 0);
   }

   public bool IsResource(ActualCellInfo cellInfo)
   {
      return IsResource(cellInfo, ResourceType.All);
   }

   #endregion
}