namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class CellAnalyzer : ICellAnalyzer
{
   #region Constants and Fields

   private readonly IOpponentPathCalculator opponentPathCalculator;

   #endregion

   #region Constructors and Destructors

   public CellAnalyzer(IOpponentPathCalculator opponentPathCalculator)
   {
      this.opponentPathCalculator = opponentPathCalculator ?? throw new ArgumentNullException(nameof(opponentPathCalculator));
   }

   #endregion

   #region ICellAnalyzer Members

   public bool IsCellCrossedByOpponentHarvestChain(ActualCellInfo cellInfo, CellInfoPerTurn cellInfoPerTurn)
   {
      if (cellInfo == null)
      {
         throw new ArgumentNullException(nameof(cellInfo));
      }

      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      IDictionary<ActualCellInfo, IReadOnlyList<CellPath>> opponentCellPaths = opponentPathCalculator.CalculatePathsForOpponentBases(cellInfoPerTurn);

      IEnumerable<CellPath> allPathOfOpponent = opponentCellPaths.SelectMany(x => x.Value);
      CellPath? foundPath = allPathOfOpponent.FirstOrDefault(x => x.CellsAlongPath.Any(y => y.CellId == cellInfo.CellId));

      if (foundPath is null)
      {
         return false;
      }

      return foundPath.CellsCrossedByOpponentHarvestChain > 0;
   }

   #endregion
}
