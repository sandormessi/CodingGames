namespace TheLabyrinth.Abstraction.Data;

using System;

public class TargetCells
{
   public TargetCells(LabyrinthCell actualCell, LabyrinthCell targetCell1, LabyrinthCell targetCell2)
   {
      ActualCell = actualCell ?? throw new ArgumentNullException(nameof(actualCell));
      TargetCell1 = targetCell1 ?? throw new ArgumentNullException(nameof(targetCell1));
      TargetCell2 = targetCell2 ?? throw new ArgumentNullException(nameof(targetCell2));
   }

   public LabyrinthCell ActualCell { get; }

   public LabyrinthCell TargetCell1 { get; }

   public LabyrinthCell TargetCell2 { get; }
}