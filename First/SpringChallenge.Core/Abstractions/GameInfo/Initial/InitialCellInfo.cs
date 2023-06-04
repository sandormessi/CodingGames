namespace SpringChallenge.Core.Abstractions.GameInfo.Initial;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

public class InitialCellInfo
{
   #region Constructors and Destructors

   public InitialCellInfo(int cellId, ResourceType type, int initialResourceCount,
      IEnumerable<NeighborInfo> neighbors)
   {
      CellId = cellId;
      Type = type;
      InitialResourceCount = initialResourceCount;
      Neighbors = new ReadOnlyCollection<NeighborInfo>(neighbors.ToList());
   }

   #endregion

   #region Public Properties

   public int CellId { get; }

   public int InitialResourceCount { get; }

   public IReadOnlyList<NeighborInfo> Neighbors { get; }

   public ResourceType Type { get; }

   #endregion
}