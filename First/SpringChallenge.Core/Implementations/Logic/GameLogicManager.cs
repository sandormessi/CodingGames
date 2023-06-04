namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.ActionManagement;
using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class GameLogicManager : IGameLogicManager
{
   #region Constants and Fields

   private readonly IActionManager actionManager;

   private readonly IBeaconManager beaconManager;

   private readonly IBeaconPathFinder beaconPathFinder;

   private readonly IPathCalculator pathCalculator;

   #endregion

   #region Constructors and Destructors

   public GameLogicManager(IActionManager actionManager, IPathCalculator pathCalculator, IBeaconPathFinder beaconPathFinder,
      IBeaconManager beaconManager)
   {
      this.actionManager = actionManager ?? throw new ArgumentNullException(nameof(actionManager));
      this.pathCalculator = pathCalculator ?? throw new ArgumentNullException(nameof(pathCalculator));
      this.beaconPathFinder = beaconPathFinder ?? throw new ArgumentNullException(nameof(beaconPathFinder));
      this.beaconManager = beaconManager ?? throw new ArgumentNullException(nameof(beaconManager));
   }

   #endregion

   #region IGameLogicManager Members

   public void ExecuteLogic(CellInfoPerTurn cellInfoPerTurn)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      Dictionary<ActualCellInfo, IEnumerable<CellPath>> pathsToBeacon = new(cellInfoPerTurn.MyBases.Count);
      Dictionary<ActualCellInfo, IEnumerable<CellPath>> allPathsForBaseCells = new(cellInfoPerTurn.MyBases.Count);

      var resourceTypeToTakePrecedence = ResourceType.Egg;
      foreach (ActualCellInfo baseCellInfo in cellInfoPerTurn.MyBases)
      {
         IReadOnlyList<CellPath> allPaths = pathCalculator.CalculatePath(new[] { baseCellInfo }).ToArray();
         IEnumerable<CellPath> cellsToBeacon = beaconPathFinder.GetCellsForBeacon(allPaths, cellInfoPerTurn, resourceTypeToTakePrecedence).ToArray();

         allPathsForBaseCells.Add(baseCellInfo, allPaths);
         pathsToBeacon.Add(baseCellInfo, cellsToBeacon);

         resourceTypeToTakePrecedence = ResourceType.All;
      }

      beaconManager.PlaceBeacons(pathsToBeacon, allPathsForBaseCells, cellInfoPerTurn);
   }

   #endregion
}