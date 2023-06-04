namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using SpringChallenge.Core.Abstractions.ActionManagement;
using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class PathCalculator : IPathCalculator
{
   #region Constants and Fields

   private readonly IActionManager actionManager;

   private readonly IResourceSelector resourceSelector;

   private readonly IResourcePathCounter resourcePathCounter;

   private readonly IAntCounter antCounter;

   #endregion

   #region Constructors and Destructors

   public PathCalculator(IActionManager actionManager, IResourceSelector resourceSelector, IResourcePathCounter resourcePathCounter, IAntCounter antCounter)
   {
      this.actionManager = actionManager ?? throw new ArgumentNullException(nameof(actionManager));
      this.resourceSelector = resourceSelector ?? throw new ArgumentNullException(nameof(resourceSelector));
      this.resourcePathCounter = resourcePathCounter ?? throw new ArgumentNullException(nameof(resourcePathCounter));
      this.antCounter = antCounter ?? throw new ArgumentNullException(nameof(antCounter));
   }

   #endregion

   #region IPathCalculator Members

   public IEnumerable<CellPath> CalculatePath(IEnumerable<ActualCellInfo> baseCell)
   {
      #region Parameter validation

      if (baseCell == null)
      {
         throw new ArgumentNullException(nameof(baseCell));
      }

      #endregion

      ActualCellInfo[] actualCellInfos = baseCell as ActualCellInfo[] ?? baseCell.ToArray();
      if (actualCellInfos.Length == 1)
      {
         return FindShortestPathsToResourceCellsFromBase(actualCellInfos.First()).Select(ExtractCellPath);
      }

      IEnumerable<PathCellInfo> resourceCellPaths = actualCellInfos
         .Select(FindShortestPathsToResourceCellsFromBase)
         .SelectMany(x => x);

      IEnumerable<CellPath> calculatePath = resourceCellPaths.Select(ExtractCellPath);
      IEnumerable<IGrouping<int, CellPath>> groupByTarget = calculatePath.GroupBy(x => x.ActualCell2.CellId);
      IEnumerable<CellPath> allPath = groupByTarget.Select(x => x.OrderBy(y => y.CellsAlongPath.Count).First());
      
      return allPath;
   }

   #endregion

   #region Methods

   private  CellPath ExtractCellPath(PathCellInfo pathCellInfo)
   {
      List<ActualCellInfo> cellsAlongPath = new() { pathCellInfo.CellInfo };

      PathCellInfo? actualCellToCheck = pathCellInfo.Parent;
      while (actualCellToCheck is not null)
      {
         cellsAlongPath.Add(actualCellToCheck.CellInfo);

         actualCellToCheck = actualCellToCheck.Parent;
      }

      int eggsOnPath = resourcePathCounter.CountResourceALongPath(cellsAlongPath, ResourceType.Egg);
      int crystalsOnPath = resourcePathCounter.CountResourceALongPath(cellsAlongPath, ResourceType.Crystal);
      int opponentAntAlongPath = antCounter.CountOpponentAntsAlongPath(cellsAlongPath);

      cellsAlongPath.Reverse();

      return new CellPath(cellsAlongPath, eggsOnPath, crystalsOnPath, opponentAntAlongPath);
   }

   private IEnumerable<PathCellInfo> FindShortestPathsToResourceCellsFromBase(ActualCellInfo startCellInfo)
   {
      PathCellInfo start = new(startCellInfo) { Parent = null, Weight = 0 };

      IEnumerable<PathCellInfo> actualCells = new[] { start };

      IEnumerable<PathCellInfo> cellsSoFar = actualCells;

      while (actualCells.Any())
      {
         IEnumerable<PathCellInfo> part = Enumerable.Empty<PathCellInfo>();

         foreach (PathCellInfo actualCircleCellInfo in actualCells)
         {
            List<ActualCellInfo> neighbors = actualCircleCellInfo.CellInfo.Neighbors.Select(x => x.Cell).ToList();

            neighbors.RemoveAll(x => cellsSoFar.Any(y => y.CellInfo.CellId == x.CellId));

            IEnumerable<PathCellInfo> neighborsPathCellInfo = neighbors.Select(x => new PathCellInfo(x)
            {
               Parent = actualCircleCellInfo, 
               Weight = actualCircleCellInfo.Weight + 1
            }).ToArray();

            cellsSoFar = cellsSoFar.Union(neighborsPathCellInfo).ToArray();

            part = part.Union(neighborsPathCellInfo);
         }

         actualCells = part.ToArray();
      }

      PathCellInfo[] resources = cellsSoFar.Where(GetResourceCells).ToArray();

      return resources;
   }

   private bool GetResourceCells(PathCellInfo pahPathCellInfo)
   {
      ActualCellInfo cellInfo = pahPathCellInfo.CellInfo;
    
      return resourceSelector.IsResource(cellInfo);
   }

   #endregion

   [DebuggerDisplay("{CellInfo}, {Weight}")]
   private class PathCellInfo
   {
      #region Constructors and Destructors

      public PathCellInfo(ActualCellInfo cellInfo)
      {
         CellInfo = cellInfo;
      }

      #endregion

      #region Public Properties

      public ActualCellInfo CellInfo { get; }

      public PathCellInfo? Parent { get; set; }

      public int Weight { get; set; }

      #endregion
   }
}