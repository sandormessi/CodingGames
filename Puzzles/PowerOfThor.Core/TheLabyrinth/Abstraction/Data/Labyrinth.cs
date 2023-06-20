using System;
using System.Collections.Generic;

namespace TheLabyrinth;

public abstract class Labyrinth<TCell>
   where TCell : LabyrinthCell
{
   public Labyrinth(IReadOnlyList<IReadOnlyList<TCell>> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
   }

   public TCell this[Position position] => Cells[position.Y][position.X];

   public TCell this[int x, int y] => Cells[y][x];

   public IReadOnlyList<IReadOnlyList<TCell>> Cells { get; }
}