using System;
using System.Collections.Generic;

namespace TheLabyrinth;

using System.Linq;

public abstract class Labyrinth<TCell>
   where TCell : LabyrinthCell
{
   public Labyrinth(IReadOnlyList<IReadOnlyList<TCell>> cells)
   {
      Cells = cells ?? throw new ArgumentNullException(nameof(cells));
   }

   public TCell this[Position position] => Cells[position.Y][position.X];

   public TCell this[int x, int y] => Cells[y][x];

   public bool IsPositionInLabyrinth(Position position)
   {
      if (position == null)
      {
         throw new ArgumentNullException(nameof(position));
      }

      return position.X >= 0 && position.X < Cells.First().Count && position.Y >= 0 && position.X < Cells.Count;
   }

   public IReadOnlyList<IReadOnlyList<TCell>> Cells { get; }
}