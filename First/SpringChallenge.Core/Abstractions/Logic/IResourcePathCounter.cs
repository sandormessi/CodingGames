namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IResourcePathCounter
{
   #region Public Methods and Operators

   int CountResourceALongPath(IEnumerable<ActualCellInfo> cellsAlongPath, ResourceType resourceType);

   int CountResourceALongPath(IEnumerable<ActualCellInfo> cellsAlongPath);

   #endregion
}