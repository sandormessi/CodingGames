namespace SpringChallenge.Core.Abstractions.Logic;

using System.Collections.Generic;
using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IResourceReachPathFinder
{
   #region Public Methods and Operators

   IEnumerable<CellPath> GetResourceRichOrderedCellPaths(CellInfoPerTurn cellInfoPerTurn, IEnumerable<CellPath> allCellPaths, ResourceType resourceTypeToTakePrecedence);

   #endregion
}