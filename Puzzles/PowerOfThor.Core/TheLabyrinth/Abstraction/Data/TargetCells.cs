namespace TheLabyrinth.Abstraction.Data;

using System;

public class TargetCells
{
   public TargetCells(ExtendedLabyrinthCell actualCell, ExtendedLabyrinthCell targetCell1, ExtendedLabyrinthCell targetCell2)
   {
      ActualCell = actualCell ?? throw new ArgumentNullException(nameof(actualCell));
      TargetCell1 = targetCell1 ?? throw new ArgumentNullException(nameof(targetCell1));
      TargetCell2 = targetCell2 ?? throw new ArgumentNullException(nameof(targetCell2));
   }

   public ExtendedLabyrinthCell ActualCell { get; }

   public ExtendedLabyrinthCell TargetCell1 { get; }

   public ExtendedLabyrinthCell TargetCell2 { get; }
}