namespace TheLabyrinth.Abstraction.Logic;

using System;

using TheLabyrinth.Abstraction.Data;

public class LabyrinthPathFinder : ILabyrinthPathFinder
{
   public LabyrinthPath FindPath(Labyrinth labyrinth, LabyrinthCell startCell, LabyrinthCell targetCell)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (startCell == null)
      {
         throw new ArgumentNullException(nameof(startCell));
      }

      if (targetCell == null)
      {
         throw new ArgumentNullException(nameof(targetCell));
      }

      throw new NotImplementedException();
   }
}