namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ILabyrinthExplorer
{
   TargetCells? ExploreLabyrinth(Labyrinth labyrinth, InitialGameInfo initialGameInfo);
}