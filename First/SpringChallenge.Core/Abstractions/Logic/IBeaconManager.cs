namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IBeaconManager
{
   #region Public Methods and Operators

   void PlaceBeacons(IDictionary<ActualCellInfo, IEnumerable<CellPath>> pathsToPlaceBeacon, IDictionary<ActualCellInfo, IEnumerable<CellPath>> allPathsForBaseCells, CellInfoPerTurn cellInfoPerTurn);

   #endregion
}