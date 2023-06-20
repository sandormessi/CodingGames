using System.Collections.Generic;

namespace TheLabyrinth;

public interface ILabyrinthReader
{
   Labyrinth ReadLabyrinth(IEnumerable<string> labyrinthCellStrings);
}