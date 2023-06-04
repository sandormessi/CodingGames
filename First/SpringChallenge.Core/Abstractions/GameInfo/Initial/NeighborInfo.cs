namespace SpringChallenge.Core.Abstractions.GameInfo.Initial;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public class NeighborInfo
{
   #region Constructors and Destructors

   public NeighborInfo(NeighborDirection direction, int neighborId)
   {
      Direction = direction;
      NeighborId = neighborId;
   }

   #endregion

   #region Public Properties

   public ActualCellInfo Cell { get; set; }

   public NeighborDirection Direction { get; }

   public int NeighborId { get; }

   #endregion
}