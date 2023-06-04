namespace SpringChallenge.Core.Abstractions.GameInfo;

using System;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public class ResourceCellInfo
{
   #region Constructors and Destructors

   public ResourceCellInfo(int cellIndex, ActualCellInfo actualCellInfo)
   {
      CellIndex = cellIndex;
      ActualCellInfo = actualCellInfo ?? throw new ArgumentNullException(nameof(actualCellInfo));
   }

   #endregion

   #region Public Properties

   public ActualCellInfo ActualCellInfo { get; }

   public int CellIndex { get; }

   #endregion
}