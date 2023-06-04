namespace SpringChallenge.Core.Abstractions.InputReader;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface ICellInfoPerTurnReader
{
   #region Public Methods and Operators

   CellInfoPerTurn ReadCellInfoPerTurn(InitialGameInfo initialGameInfo, int round);

   #endregion
}