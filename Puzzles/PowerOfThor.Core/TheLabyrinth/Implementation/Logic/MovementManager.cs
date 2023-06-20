namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class MovementManager : IMovementManager
{
   private readonly IOutputManager outputManager;

   public MovementManager(IOutputManager outputManager)
   {
      this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
   }

   public void Move(TargetCells targetCells)
   {
      if (targetCells == null)
      {
         throw new ArgumentNullException(nameof(targetCells));
      }

      throw new NotImplementedException();
   }
}