namespace SpringChallenge.Core.Abstractions.Logic;

using SpringChallenge.Core.Abstractions.GameInfo;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface ICellAnalyzer
{
   #region Public Methods and Operators

   bool IsCellCrossedByOpponentHarvestChain(ActualCellInfo cellInfo, CellInfoPerTurn cellInfoPerTurn);

   #endregion
}