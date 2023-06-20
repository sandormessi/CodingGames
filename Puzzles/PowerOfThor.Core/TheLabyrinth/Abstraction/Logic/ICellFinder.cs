namespace TheLabyrinth.Abstraction.Logic;

public interface ICellFinder
{
   ExtendedLabyrinthCell? GetTargetCell(ExtendedLabyrinth labyrinth);

   bool IsTargetVisible(ExtendedLabyrinth labyrinth);

   ExtendedLabyrinthCell GetActualPositionCell(ExtendedLabyrinth labyrinth);
}