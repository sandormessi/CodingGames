namespace TheLabyrinth.Abstraction.Logic;

public interface ITargetFinder
{
   LabyrinthCell? GetTargetCell(Labyrinth labyrinth);

   bool IsTargetVisible(Labyrinth labyrinth);
}