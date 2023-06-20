namespace TheLabyrinth.Abstraction.Data;

using System;

public class LabyrinthCellNeighbor
{
   public LabyrinthCellNeighbor(LabyrinthCell neighbor, Direction direction)
   {
      Neighbor = neighbor ?? throw new ArgumentNullException(nameof(neighbor));
      Direction = direction;
   }

   public LabyrinthCell Neighbor { get; }

   public Direction Direction { get; }
}