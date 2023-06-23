namespace TheLabyrinth.Abstraction;

using System.Collections.Generic;

using TheLabyrinth.Abstraction.Data;

public interface IMovementAnalyzer
{
   IDictionary<Direction, MovementAnalysisResult> Analyze(ExtendedLabyrinth labyrinth, ExtendedLabyrinthCell actualPositionCell, InitialGameInfo initialGameInfo);
}