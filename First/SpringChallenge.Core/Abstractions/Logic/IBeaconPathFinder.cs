namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IBeaconPathFinder
{
   #region Public Methods and Operators

   IEnumerable<CellPath> GetCellsForBeacon(IReadOnlyList<CellPath> allPaths, CellInfoPerTurn cellInfoPerTurn, ResourceType resourceTypeToTakePrecedence);

   #endregion
}