namespace TheLabyrinth.Abstraction.Logic;

using TheLabyrinth.Abstraction.Data;

public interface IMovementManager
{
   void Move(TargetCells targetCells);
}