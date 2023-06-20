namespace TheLabyrinth.Abstraction.Data.Reader;

using System;
using System.Collections.Generic;

public class ExtendedLabyrinthCellReader : IExtendedLabyrinthCellReader
{
   public ExtendedLabyrinthCell ReadExtendedLabyrinthCell(InitialLabyrinth labyrinth, LabyrinthCell labyrinthCell)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (labyrinthCell == null)
      {
         throw new ArgumentNullException(nameof(labyrinthCell));
      }

      List<LabyrinthCellNeighbor> cellNeighbors = new();

      var leftNeighborPosition = new Position(labyrinthCell.Position.X - 1, labyrinthCell.Position.Y);
      var topNeighborPosition = new Position(labyrinthCell.Position.X, labyrinthCell.Position.Y + 1);
      var rightNeighborPosition = new Position(labyrinthCell.Position.X + 1, labyrinthCell.Position.Y);
      var bottomNeighborPosition = new Position(labyrinthCell.Position.X, labyrinthCell.Position.Y - 1);

      if (labyrinth.IsPositionInLabyrinth(leftNeighborPosition))
      {
         var leftNeighbor = new LabyrinthCellNeighbor(labyrinth[leftNeighborPosition], Direction.Left);
         cellNeighbors.Add(leftNeighbor);
      }

      if (labyrinth.IsPositionInLabyrinth(topNeighborPosition))
      {
         var topNeighbor = new LabyrinthCellNeighbor(labyrinth[topNeighborPosition], Direction.Up);
         cellNeighbors.Add(topNeighbor);
      }

      if (labyrinth.IsPositionInLabyrinth(rightNeighborPosition))
      {
         var rightNeighbor = new LabyrinthCellNeighbor(labyrinth[rightNeighborPosition], Direction.Right);
         cellNeighbors.Add(rightNeighbor);
      }

      if (labyrinth.IsPositionInLabyrinth(bottomNeighborPosition))
      {
         var bottomNeighbor = new LabyrinthCellNeighbor(labyrinth[bottomNeighborPosition], Direction.Down);
         cellNeighbors.Add(bottomNeighbor);
      }

      LabyrinthCellNeighborInfo neighbors = new(cellNeighbors);

      return new ExtendedLabyrinthCell(labyrinthCell.Type, labyrinthCell.Position, neighbors);
   }
}