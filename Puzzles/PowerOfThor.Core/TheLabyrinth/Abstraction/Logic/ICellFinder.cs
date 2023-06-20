namespace TheLabyrinth.Abstraction.Logic;

public interface ICellFinder
{
   LabyrinthCell? GetTargetCell(Labyrinth labyrinth);

   bool IsTargetVisible(Labyrinth labyrinth);

   LabyrinthCell GetActualPositionCell(Labyrinth labyrinth);
}