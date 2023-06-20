namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class LabyrinthExplorer : ILabyrinthExplorer
{
   private readonly IOutputManager outputManager;

   private readonly ICellFinder cellFinder;

   public LabyrinthExplorer(IOutputManager outputManager, ICellFinder cellFinder)
   {
      this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
      this.cellFinder = cellFinder ?? throw new ArgumentNullException(nameof(cellFinder));
   }

   public TargetCells ExploreLabyrinth(ExtendedLabyrinth labyrinth, InitialGameInfo initialGameInfo)
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