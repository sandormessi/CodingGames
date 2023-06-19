using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth
{
   public class Labyrinth
   {
      public Labyrinth(IReadOnlyList<IReadOnlyList<LabyrinthCell>> cells)
      {
         Cells = cells ?? throw new ArgumentNullException(nameof(cells));
      }

      public IReadOnlyList<IReadOnlyList<LabyrinthCell>> Cells { get; }
   }
}