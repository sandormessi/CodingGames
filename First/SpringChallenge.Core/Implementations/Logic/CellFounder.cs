namespace SpringChallenge.Core.Implementations.Logic;

using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.Logic;

public class CellFounder : ICellFounder
{
   #region ICellFounder Members

   public IEnumerable<ActualCellInfo> FindCellsWithBothAnts(CellInfoPerTurn cellInfoPerTurn)
   {
      return cellInfoPerTurn.Cells.Where(x => (x.MyAntCount > 0) && (x.OpponentAntCount > 0));
   }

   #endregion
}