namespace SpringChallenge.Core.Abstractions.GameInfo;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

[DebuggerDisplay("Max: {MaximumResourceToHarvest}")]
public class MaximumHarvestCellPath
{
    #region Constructors and Destructors

    public MaximumHarvestCellPath(IEnumerable<CellPath> pathToHarvest, int maximumResourceToHarvest, int unusedAnts)
    {
        PathsToHarvest = new ReadOnlyCollection<CellPath>(pathToHarvest.ToArray());
        MaximumResourceToHarvest = maximumResourceToHarvest;
        UnusedAnts = unusedAnts;
    }

    #endregion

    #region Public Properties

    public int MaximumResourceToHarvest { get; }

   public IReadOnlyList<CellPath> PathsToHarvest { get; }

   public int UnusedAnts { get; }

   #endregion
}