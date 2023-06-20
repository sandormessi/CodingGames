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

      var pathToTarget1 = new TargetPath(pathToTargetCell, 0);
      var pathToTarget2 = new TargetPath(pathToStartCell, 0);

      return new TargetPaths(pathToTarget1, pathToTarget2);
   }
}