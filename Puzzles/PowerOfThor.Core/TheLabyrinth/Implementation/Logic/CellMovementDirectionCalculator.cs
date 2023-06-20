namespace TheLabyrinth.Abstraction;

using System;

public class CellMovementDirectionCalculator : ICellMovementDirectionCalculator
{
   public Direction CalculateDirection(LabyrinthCell labyrinthCell1, LabyrinthCell labyrinthCell2)
   {
      if (labyrinthCell1 == null)
      {
         throw new ArgumentNullException(nameof(labyrinthCell1));
      }

      if (labyrinthCell2 == null)
      {
         throw new ArgumentNullException(nameof(labyrinthCell2));
      }

      throw new NotImplementedException();
   }
}