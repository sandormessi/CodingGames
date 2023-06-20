namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ILabyrinthPathFinder
{
   LabyrinthPath FindPath(Labyrinth labyrinth, LabyrinthCell startCell, LabyrinthCell targetCell);
}