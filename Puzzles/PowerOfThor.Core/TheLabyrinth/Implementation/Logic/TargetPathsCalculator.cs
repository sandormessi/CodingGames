namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class TargetPathsCalculator : ITargetPathsCalculator
{
   private readonly ILabyrinthPathFinder labyrinthPathFinder;

   public TargetPathsCalculator(ILabyrinthPathFinder labyrinthPathFinder)
   {
      this.labyrinthPathFinder = labyrinthPathFinder ?? throw new ArgumentNullException(nameof(labyrinthPathFinder));
   }

   public TargetPaths CalculateTargetPaths(Labyrinth labyrinth, TargetCells targetCells)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (targetCells == null)
      {
         throw new ArgumentNullException(nameof(targetCells));
      }

      var pathToTargetCell = labyrinthPathFinder.FindPath(labyrinth, targetCells.ActualCell, targetCells.TargetCell1);
      var pathToStartCell = labyrinthPathFinder.FindPath(labyrinth, targetCells.ActualCell, targetCells.TargetCell2);

      return new TargetPaths(pathToTargetCell, pathToStartCell);
   }
}