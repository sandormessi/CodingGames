using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth.Abstraction.Data.Reader;

public interface IExtendedLabyrinthCellReader
{
   ExtendedLabyrinthCell ReadExtendedLabyrinthCell(InitialLabyrinth labyrinth, LabyrinthCell labyrinthCell);
}