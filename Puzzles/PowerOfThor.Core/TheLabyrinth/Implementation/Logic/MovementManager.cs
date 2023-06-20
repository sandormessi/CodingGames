namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class MovementManager : IMovementManager
{
   private readonly IOutputManager outputManager;

   private readonly ITargetPathsCalculator targetPathsCalculator;

   private TargetPaths? targetPaths;

   public MovementManager(IOutputManager outputManager, ITargetPathsCalculator targetPathsCalculator)
   {
      this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
      this.targetPathsCalculator = targetPathsCalculator ?? throw new ArgumentNullException(nameof(targetPathsCalculator));
   }

   public void Move(ExtendedLabyrinth labyrinth, TargetCells targetCells)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (targetCells == null)
      {
         throw new ArgumentNullException(nameof(targetCells));
      }

      targetPaths ??= targetPathsCalculator.CalculateTargetPaths(labyrinth, targetCells);



      throw new NotImplementedException();
   }
}