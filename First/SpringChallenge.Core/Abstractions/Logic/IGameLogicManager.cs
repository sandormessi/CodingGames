namespace SpringChallenge.Core.Abstractions.Logic;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

internal interface IGameLogicManager
{
   #region Public Methods and Operators

   void ExecuteLogic(CellInfoPerTurn cellInfoPerTurn);

   #endregion
}