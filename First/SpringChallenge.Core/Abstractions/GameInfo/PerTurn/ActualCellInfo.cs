namespace SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

using System.Collections.Generic;
using System.Diagnostics;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;

[DebuggerDisplay("Id: {CellId}, RC:{ActualResourceCount}, T:{Type}")]
public class ActualCellInfo : InitialCellInfo
{
   #region Constructors and Destructors

   public ActualCellInfo(int cellId, ResourceType type, int initialResourceCount,
      IEnumerable<NeighborInfo> neighbors, int actualResourceCount, int myAntCount,
      int opponentAntCount)
      : base(cellId, type, initialResourceCount, neighbors)
   {
      ActualResourceCount = actualResourceCount;
      MyAntCount = myAntCount;
      OpponentAntCount = opponentAntCount;
   }

   #endregion

   #region Public Properties

   public int ActualResourceCount { get; }

   public int MyAntCount { get; }

   public int OpponentAntCount { get; }

   public bool CellCrossedByOpponentHarvestChain { get; set; }

   #endregion
}