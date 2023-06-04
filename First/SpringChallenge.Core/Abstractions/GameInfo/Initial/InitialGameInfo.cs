namespace SpringChallenge.Core.Abstractions.GameInfo.Initial;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class InitialGameInfo
{
   #region Constructors and Destructors

   public InitialGameInfo(int cellCount, IEnumerable<InitialCellInfo> cells, int baseCount,
      IEnumerable<int> myBaseIndexes, IEnumerable<int> opponentBaseIndexes, int initialEggCount)
   {
      if (cells == null)
      {
         throw new ArgumentNullException(nameof(cells));
      }

      if (myBaseIndexes == null)
      {
         throw new ArgumentNullException(nameof(myBaseIndexes));
      }

      if (opponentBaseIndexes == null)
      {
         throw new ArgumentNullException(nameof(opponentBaseIndexes));
      }

      if (baseCount <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(baseCount));
      }

      if (cellCount <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(cellCount));
      }

      if (initialEggCount < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(initialEggCount));
      }

      CellCount = cellCount;
      Cells = new ReadOnlyCollection<InitialCellInfo>(cells.ToList());
      BaseCount = baseCount;
      InitialEggCount = initialEggCount;
      MyBaseIndexes = new ReadOnlyCollection<int>(myBaseIndexes.ToList());
      OpponentBaseIndexes = new ReadOnlyCollection<int>(opponentBaseIndexes.ToList());
      MyBases = new ReadOnlyCollection<InitialCellInfo>(Cells.Where(x => MyBaseIndexes.Any(y => x.CellId == y)).ToList());
      OpponentBases = new ReadOnlyCollection<InitialCellInfo>(Cells.Where(x => OpponentBaseIndexes.Any(y => x.CellId == y)).ToList());
   }

   #endregion

   #region Public Properties
   public int InitialEggCount { get; }
   public int BaseCount { get; }

   public int CellCount { get; }

   public IReadOnlyList<InitialCellInfo> Cells { get; }

   public IReadOnlyList<int> MyBaseIndexes { get; }

   public IReadOnlyList<InitialCellInfo> MyBases { get; }

   public IReadOnlyList<int> OpponentBaseIndexes { get; }

   public IReadOnlyList<InitialCellInfo> OpponentBases { get; }

   #endregion
}