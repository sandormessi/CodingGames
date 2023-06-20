namespace TheLabyrinth.Abstraction;

public interface ICellMovementDirectionCalculator
{
   Direction CalculateDirection(LabyrinthCell labyrinthCell1, LabyrinthCell labyrinthCell2);
}