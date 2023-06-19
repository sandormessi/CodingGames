using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth;

public interface ILabyrinthReader
{
   Labyrinth ReadLabyrinth(IEnumerable<string> labyrinthCellStrings);
}