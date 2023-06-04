namespace SpringChallenge.Core.Abstractions.Logic;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public interface IResourceSelector
{
   #region Public Methods and Operators

   bool IsResource(ActualCellInfo cellInfo, ResourceType resourceType);

   bool IsResource(ActualCellInfo cellInfo);

   #endregion
}