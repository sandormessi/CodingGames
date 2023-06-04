namespace SpringChallenge.Core.Abstractions.GameInfo;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

[DebuggerDisplay("Cell1: {ActualCell1}, Cell2:{ActualCell2}, D:{CellsAlongPath.Count}")]
public class CellPath
{
   #region Constructors and Destructors

   public CellPath(IEnumerable<ActualCellInfo> cellsAlongPath, int eggCellsAlongPath, int crystalsCellsAlongPath,
      int opponentAntAlongPath)
   {
      if (cellsAlongPath == null)
      {
         throw new ArgumentNullException(nameof(cellsAlongPath));
      }

      if (eggCellsAlongPath < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(eggCellsAlongPath));
      }

      if (crystalsCellsAlongPath < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(crystalsCellsAlongPath));
      }

      if (opponentAntAlongPath < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(opponentAntAlongPath));
      }

      EggCellsAlongPath = eggCellsAlongPath;
      CrystalsCellsAlongPath = crystalsCellsAlongPath;
      OpponentAntAlongPath = opponentAntAlongPath;

      AllResourceCellsAlongPath = EggCellsAlongPath + CrystalsCellsAlongPath;

      CellsAlongPath = new ReadOnlyCollection<ActualCellInfo>(cellsAlongPath.ToList());
      CellsCrossedByOpponentHarvestChain = CellsAlongPath.Count(x => x.CellCrossedByOpponentHarvestChain);
   }

   #endregion

   #region Public Properties

   public ActualCellInfo ActualCell1 => CellsAlongPath.First();

   public ActualCellInfo ActualCell2 => CellsAlongPath.Last();

   public int AllResourceCellsAlongPath { get; }

   public IReadOnlyList<ActualCellInfo> CellsAlongPath { get; }

   public int CrystalsCellsAlongPath { get; }

   public int EggCellsAlongPath { get; }

   public int OpponentAntAlongPath { get; }

   public int CellsCrossedByOpponentHarvestChain { get; }

   #endregion
}