using System;
using System.Collections.Generic;

namespace TheLabyrinth;

public class Labyrinth<TCell>
   where TCell : LabyrinthCell
{
   public Labyrinth(IReadOnlyList<IReadOnlyList<TCell>> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
   }

   public TCell this[Position position] => Cells[position.Y][position.X];

   public IReadOnlyList<IReadOnlyList<TCell>> Cells { get; }
}