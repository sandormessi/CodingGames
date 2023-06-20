using System;
using System.Collections.Generic;

namespace TheLabyrinth;

public class Labyrinth
{
   public Labyrinth(IReadOnlyList<IReadOnlyList<LabyrinthCell>> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
   }

   public LabyrinthCell this[Position position] => Cells[position.Y][position.X];

   public IReadOnlyList<IReadOnlyList<LabyrinthCell>> Cells { get; }
}