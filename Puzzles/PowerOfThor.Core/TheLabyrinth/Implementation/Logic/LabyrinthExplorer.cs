namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class LabyrinthExplorer : ILabyrinthExplorer
{
   private readonly IOutputManager outputManager;

   public LabyrinthExplorer(IOutputManager outputManager)
   {
      this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
   }

   public TargetCells? ExploreLabyrinth(Labyrinth labyrinth, InitialGameInfo initialGameInfo)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      throw new NotImplementedException();
   }
}