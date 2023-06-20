namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface IMovementManager
{
   void Move(ExtendedLabyrinth labyrinth, TargetCells targetCells);
}