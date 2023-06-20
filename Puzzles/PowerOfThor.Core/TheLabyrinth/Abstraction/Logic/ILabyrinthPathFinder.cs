namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ILabyrinthPathFinder
{
   LabyrinthPath FindPath(LabyrinthCell startCell, LabyrinthCell targetCell);
}