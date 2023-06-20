namespace TheLabyrinth.Abstraction.Data.Reader;

public interface IExtendedLabyrinthCellReader
{
   ExtendedLabyrinthCell ReadExtendedLabyrinthCell(InitialLabyrinth labyrinth, LabyrinthCell labyrinthCell);
}