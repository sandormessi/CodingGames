namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ITargetPathsCalculator
{
   TargetPaths CalculateTargetPaths(Labyrinth labyrinth, TargetCells targetCells);
}