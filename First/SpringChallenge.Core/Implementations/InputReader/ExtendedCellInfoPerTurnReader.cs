namespace SpringChallenge.Core.Implementations.InputReader;

using System;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.InputReader;
using SpringChallenge.Core.Abstractions.Logic;

public class ExtendedCellInfoPerTurnReader : IExtendedCellInfoPerTurnReader
{
   #region Constants and Fields

   private readonly ICellAnalyzer cellAnalyzer;

   private readonly ICellInfoPerTurnReader cellInfoPerTurnReader;

   #endregion

   #region Constructors and Destructors

   public ExtendedCellInfoPerTurnReader(ICellInfoPerTurnReader cellInfoPerTurnReader, ICellAnalyzer cellAnalyzer)
   {
      this.cellInfoPerTurnReader = cellInfoPerTurnReader ?? throw new ArgumentNullException(nameof(cellInfoPerTurnReader));
      this.cellAnalyzer = cellAnalyzer ?? throw new ArgumentNullException(nameof(cellAnalyzer));
   }

   #endregion

   #region Public Methods and Operators

   public CellInfoPerTurn ReadCellInfoPerTurn(InitialGameInfo initialGameInfo, int round)
   {
      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      if (round < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(round));
      }

      CellInfoPerTurn cellInfoPerTurn = cellInfoPerTurnReader.ReadCellInfoPerTurn(initialGameInfo, round);

      foreach (ActualCellInfo actualCellInfo in cellInfoPerTurn.Cells)
      {
         bool isCellCrossedByOpponentHarvestChain = cellAnalyzer.IsCellCrossedByOpponentHarvestChain(actualCellInfo, cellInfoPerTurn);
         actualCellInfo.CellCrossedByOpponentHarvestChain = isCellCrossedByOpponentHarvestChain;
      }

      return cellInfoPerTurn;
   }

   #endregion
}