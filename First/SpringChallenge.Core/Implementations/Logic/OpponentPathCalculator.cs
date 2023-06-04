namespace SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class OpponentPathCalculator : IOpponentPathCalculator
{
   #region Constants and Fields

   private readonly IPathCalculator pathCalculator;

   #endregion

   #region Constructors and Destructors

   public OpponentPathCalculator(IPathCalculator pathCalculator)
   {
      this.pathCalculator = pathCalculator ?? throw new ArgumentNullException(nameof(pathCalculator));
   }

   #endregion

   #region IOpponentPathCalculator Members

   public IDictionary<ActualCellInfo, IReadOnlyList<CellPath>> CalculatePathsForOpponentBases(CellInfoPerTurn cellInfoPerTurn)
   {
      if (cellInfoPerTurn == null)
      {
         throw new ArgumentNullException(nameof(cellInfoPerTurn));
      }

      Dictionary<ActualCellInfo, IReadOnlyList<CellPath>> opponentCellPaths = new();
      foreach (ActualCellInfo opponentBaseCell in cellInfoPerTurn.OpponentBases)
      {
         IReadOnlyList<CellPath> opponentCellPath = pathCalculator.CalculatePath(new[] { opponentBaseCell }).ToArray();
         opponentCellPaths.Add(opponentBaseCell, opponentCellPath);
      }

      return opponentCellPaths;
   }

   #endregion
}