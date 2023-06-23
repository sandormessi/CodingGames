namespace TheLabyrinth.Abstraction.Logic;

using System;
using System.Collections.Generic;

using TheLabyrinth.Abstraction.Data;

public class LabyrinthExplorer : ILabyrinthExplorer
{
   private const int FieldOfView = 5;

   private readonly IOutputManager outputManager;

   private readonly ICellFinder cellFinder;

   private readonly IMovementAnalyzer movementAnalyzer;

   private TargetCells? targetCells;

   public LabyrinthExplorer(IOutputManager outputManager, ICellFinder cellFinder, IMovementAnalyzer movementAnalyzer)
   {
      this.outputManager = outputManager ?? throw new ArgumentNullException(nameof(outputManager));
      this.cellFinder = cellFinder ?? throw new ArgumentNullException(nameof(cellFinder));
      this.movementAnalyzer = movementAnalyzer ?? throw new ArgumentNullException(nameof(movementAnalyzer));
   }

   public TargetCells? ExploreLabyrinth(ExtendedLabyrinth labyrinth, InitialGameInfo initialGameInfo, RoundGameInfo roundGameInfo)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      if (targetCells is not null)
      {
         return targetCells;
      }

      if (cellFinder.IsTargetVisible(labyrinth))
      {
         ExtendedLabyrinthCell myPosition = cellFinder.GetActualPositionCell(labyrinth);
         ExtendedLabyrinthCell targetCell = cellFinder.GetTargetCell(labyrinth)!;

         ExtendedLabyrinthCell startCell = labyrinth[roundGameInfo.StartPosition];
         targetCells = new TargetCells(myPosition, targetCell, startCell);
      }
      else
      {
         Move(labyrinth, initialGameInfo, roundGameInfo);
      }

      return targetCells;
   }

   private void Move(ExtendedLabyrinth labyrinth, InitialGameInfo initialGameInfo, RoundGameInfo roundGameInfo)
   {
      IDictionary<Direction, MovementAnalysisResult> analysisResult = movementAnalyzer.Analyze(labyrinth, labyrinth[roundGameInfo.MyPosition], TODO);

   }
}