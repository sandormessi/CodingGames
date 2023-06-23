namespace TheLabyrinth.Implementation.Logic;

using System;
using System.Collections.Generic;
using System.Linq;

using TheLabyrinth.Abstraction;
using TheLabyrinth.Abstraction.Data;

public class MovementAnalyzer : IMovementAnalyzer
{
   public IDictionary<Direction, MovementAnalysisResult> Analyze(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell,
      InitialGameInfo initialGameInfo)
   {
      if (labyrinth == null)
      {
         throw new ArgumentNullException(nameof(labyrinth));
      }

      if (actualPositionCell == null)
      {
         throw new ArgumentNullException(nameof(actualPositionCell));
      }

      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      List<KeyValuePair<Direction, MovementAnalysisResult>> analysisResults = new();

      AnalyzeLeft(labyrinth, actualPositionCell, initialGameInfo, analysisResults);
      AnalyzeRight(labyrinth, actualPositionCell, initialGameInfo, analysisResults);
      AnalyzeUp(labyrinth, actualPositionCell, initialGameInfo, analysisResults);
      AnalyzeDown(labyrinth, actualPositionCell, initialGameInfo, analysisResults);

      return analysisResults
         .OrderByDescending(x => x.Value.CanMove)
         .ThenByDescending(x => x.Value.CellsToExplore)
         .ToDictionary(x => x.Key, x => x.Value);
   }

   private void AnalyzeDown(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell, InitialGameInfo initialGameInfo, IList<KeyValuePair<Direction, MovementAnalysisResult>> analysisResults)
   {
      throw new NotImplementedException();
   }

   private void AnalyzeUp(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell, InitialGameInfo initialGameInfo, IList<KeyValuePair<Direction, MovementAnalysisResult>> analysisResults)
   {
      throw new NotImplementedException();
   }

   private void AnalyzeRight(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell, InitialGameInfo initialGameInfo, IList<KeyValuePair<Direction, MovementAnalysisResult>> analysisResults)
   {
      throw new NotImplementedException();
   }

   private void AnalyzeLeft(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell, InitialGameInfo initialGameInfo,
      IList<KeyValuePair<Direction, MovementAnalysisResult>> analysisResults)
   {
      throw new NotImplementedException();
   }
}