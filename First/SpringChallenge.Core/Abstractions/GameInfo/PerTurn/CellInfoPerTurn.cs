namespace SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class CellInfoPerTurn
{
   #region Constructors and Destructors

   public CellInfoPerTurn(IEnumerable<ActualCellInfo> cells, int round, IEnumerable<ActualCellInfo> myBases,
      IEnumerable<ActualCellInfo> opponentBases, int allEggs, int initialEggCount)
   {
      if (cells == null)
      {
         throw new ArgumentNullException(nameof(cells));
      }

      if (round <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(round));
      }

      if (myBases == null)
      {
         throw new ArgumentNullException(nameof(myBases));
      }

      if (opponentBases == null)
      {
         throw new ArgumentNullException(nameof(opponentBases));
      }

      if (allEggs < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(allEggs));
      }

      if (initialEggCount < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(initialEggCount));
      }

      Round = round;
      AllEggs = allEggs;
      InitialEggCount = initialEggCount;
      MyBases = new ReadOnlyCollection<ActualCellInfo>(myBases.ToList());
      OpponentBases = new ReadOnlyCollection<ActualCellInfo>(opponentBases.ToList());
      Cells = new ReadOnlyCollection<ActualCellInfo>(cells.ToList());
   }

   #endregion

   #region Public Properties

   public IReadOnlyList<ActualCellInfo> Cells { get; }

   public IReadOnlyList<ActualCellInfo> MyBases { get; }

   public IReadOnlyList<ActualCellInfo> OpponentBases { get; }

   public int Round { get; }

   public bool IsDuplicatedBeaconCommandPossible => true;

   public int AllEggs { get; }

   public int InitialEggCount { get; }

   #endregion
}