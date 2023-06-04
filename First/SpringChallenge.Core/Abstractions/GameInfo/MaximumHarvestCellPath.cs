namespace SpringChallenge.Core.Abstractions.GameInfo;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

[DebuggerDisplay("Max: {MaximumResourceToHarvest}")]
public class MaximumHarvestCellPath
{
   #region Constructors and Destructors

   public MaximumHarvestCellPath(IEnumerable<CellPath> pathToHarvest, int maximumResourceToHarvest)
   {
      PathsToHarvest = new ReadOnlyCollection<CellPath>(pathToHarvest.ToArray());
      MaximumResourceToHarvest = maximumResourceToHarvest;
   }

   #endregion

   #region Public Properties

   public int MaximumResourceToHarvest { get; }

   public IReadOnlyList<CellPath> PathsToHarvest { get; }

   #endregion
}