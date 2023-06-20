namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ILabyrinthPathFinder
{
   LabyrinthPath FindPath(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell startCell, ExtendedLabyrinthCell targetCell);
}