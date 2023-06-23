namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface ILabyrinthExplorer
{
   TargetCells? ExploreLabyrinth(ExtendedLabyrinth labyrinth, InitialGameInfo initialGameInfo, RoundGameInfo roundGameInfo);
}