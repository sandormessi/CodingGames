using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth
{
   public class Labyrinth
   {
      public IReadOnlyList<IReadOnlyList<LabyrinthCell>> Cells { get; }
   }
}