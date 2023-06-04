namespace SpringChallenge.Core.Abstractions.GameInfo.Initial;

using System.Collections.Generic;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;

public class ActualCellInfoEqualityComparer : IEqualityComparer<ActualCellInfo>
{
   #region IEqualityComparer<ActualCellInfo> Members

   public bool Equals(ActualCellInfo? x, ActualCellInfo? y)
   {
      if (ReferenceEquals(x, y))
      {
         return true;
      }

      if (x is null)
      {
         return false;
      }

      if (y is null)
      {
         return false;
      }

      if (x.GetType() != y.GetType())
      {
         return false;
      }

      return x.CellId == y.CellId;
   }

   public int GetHashCode(ActualCellInfo obj)
   {
      return obj.CellId;
   }

   #endregion
}