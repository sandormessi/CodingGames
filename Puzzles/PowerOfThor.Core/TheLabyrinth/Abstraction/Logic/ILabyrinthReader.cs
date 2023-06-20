using System.Collections.Generic;

namespace TheLabyrinth;

public interface ILabyrinthReader
{
   InitialLabyrinth ReadLabyrinth(IEnumerable<string> labyrinthCellStrings);
}