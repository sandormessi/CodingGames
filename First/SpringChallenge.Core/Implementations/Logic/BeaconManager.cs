namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.ActionManagement;
using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class BeaconManager : IBeaconManager
{
   #region Constants and Fields

   private readonly IActionManager actionManager;

   #endregion

   #region Constructors and Destructors

   public BeaconManager(IActionManager actionManager)
   {
      this.actionManager = actionManager ?? throw new ArgumentNullException(nameof(actionManager));
   }

   #endregion

   #region IBeaconManager Members

   public void PlaceBeacons(IDictionary<ActualCellInfo, IEnumerable<CellPath>> pathsToPlaceBeacon, IDictionary<ActualCellInfo, IEnumerable<CellPath>> allPathsForBaseCells,
      CellInfoPerTurn cellInfoPerTurn)
   {
      if (pathsToPlaceBeacon == null)
      {
         throw new ArgumentNullException(nameof(pathsToPlaceBeacon));
      }

      if (allPathsForBaseCells == null)
      {
         throw new ArgumentNullException(nameof(allPathsForBaseCells));
      }

      PlaceBeaconsToNearestBase(pathsToPlaceBeacon, allPathsForBaseCells);
      return;

      //const int beaconStrength = 1;
      //foreach (KeyValuePair<ActualCellInfo, IEnumerable<CellPath>> cellPathsForBase in pathsToPlaceBeacon)
      //{
      //   ActualCellInfo baseCell = cellPathsForBase.Key;

      //   IEnumerable<CellPath> cellPathsToBeacons = cellPathsForBase.Value;
      //   if (cellInfoPerTurn.IsDuplicatedBeaconCommandPossible)
      //   {
      //      foreach (CellPath cellPathToBeacon in cellPathsToBeacons)
      //      {
      //         ActualCellInfo targetCell = cellPathToBeacon.ActualCell2;
      //         foreach (ActualCellInfo cellToPlaceBeacon in cellPathToBeacon.CellsAlongPath)
      //         {
      //            actionManager.PlaceBeacon(cellToPlaceBeacon.CellId, beaconStrength);
      //         }
      //      }
      //   }
      //   else
      //   {
      //      PlaceBeaconsForAllCell(cellPathsToBeacons, beaconStrength);
      //   }
      //}
   }

   private void PlaceBeaconsForAllCell(IEnumerable<CellPath> cellPathsToBeacons, int beaconStrength)
   {
      IEnumerable<ActualCellInfo> allCellsToPlaceBeacon = cellPathsToBeacons.SelectMany(x => x.CellsAlongPath).Distinct(new ActualCellInfoEqualityComparer());
      foreach (ActualCellInfo cellInfoToPlaceBeacon in allCellsToPlaceBeacon)
      {
            var neighborCells = cellInfoToPlaceBeacon.Neighbors.Select(x => x.Cell);
            foreach (var neighborCell in neighborCells)
            {
                if (ResourceType.All.HasFlag(neighborCell.Type))
                {
                    actionManager.PlaceBeacon(neighborCell.CellId, beaconStrength);
                }
            }

            actionManager.PlaceBeacon(cellInfoToPlaceBeacon.CellId, beaconStrength);
        }
   }

   private void PlaceBeaconsToNearestBase(IDictionary<ActualCellInfo, IEnumerable<CellPath>> pathsToPlaceBeacon, IDictionary<ActualCellInfo, IEnumerable<CellPath>> allPathsForBaseCells)
   {
      IEnumerable<CellPath> allAllPreSelectedPaths = pathsToPlaceBeacon.SelectMany(x => x.Value);
      IReadOnlyList<CellPath> allPossibleCellPathsForAllBase = allPathsForBaseCells.SelectMany(x => x.Value).ToArray();

      List<CellPath> pathsToBeacons = new(16);
      foreach (CellPath cellPath in allAllPreSelectedPaths)
      {
         IEnumerable<CellPath> foundPathToTargetCell = allPossibleCellPathsForAllBase.Where(x => x.ActualCell2.CellId == cellPath.ActualCell2.CellId);
         IOrderedEnumerable<CellPath> foundPathToTargetCellOrderedByDistance = foundPathToTargetCell.OrderBy(x => x.CellsAlongPath.Count);

         CellPath shortestTargetCellPath = foundPathToTargetCellOrderedByDistance.First();
         pathsToBeacons.Add(shortestTargetCellPath);
      }

      PlaceBeaconsForAllCell(pathsToBeacons, 1);
   }

   #endregion
}