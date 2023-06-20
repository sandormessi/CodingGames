namespace TheLabyrinth;

using System.Collections.Generic;

public class ExtendedLabyrinth : Labyrinth<ExtendedLabyrinthCell>
{
   public ExtendedLabyrinth(IReadOnlyList<IReadOnlyList<ExtendedLabyrinthCell>> cells)
      : base(cells)
   {
   }
}