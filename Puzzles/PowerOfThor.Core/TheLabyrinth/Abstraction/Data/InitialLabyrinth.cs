namespace TheLabyrinth;

using System.Collections.Generic;

public class InitialLabyrinth : Labyrinth<LabyrinthCell>
{
   public InitialLabyrinth(IReadOnlyList<IReadOnlyList<LabyrinthCell>> cells)
      : base(cells)
   {
   }
}