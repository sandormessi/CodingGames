using System;
using System.Collections.Generic;
using System.Text;

namespace TheLabyrinth;

public interface ILabyrinthCellReader
{
   LabyrinthCell ReadLabyrinthCell(char cellData, int rowIndex, int columnIndex);
}