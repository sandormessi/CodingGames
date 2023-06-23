namespace TheLabyrinth;

using System;

using TheLabyrinth.Abstraction.Data;
using TheLabyrinth.Abstraction.Logic;

public class GameLogicManager : IGameLogicManager
{
   private readonly ILabyrinthExplorer labyrinthExplorer;

   private readonly IMovementManager movementManager;

   private TargetCells? targetCells;

   public GameLogicManager(ILabyrinthExplorer labyrinthExplorer, IMovementManager movementManager)
   {
      this.labyrinthExplorer = labyrinthExplorer ?? throw new ArgumentNullException(nameof(labyrinthExplorer));
      this.movementManager = movementManager ?? throw new ArgumentNullException(nameof(movementManager));
   }

   public void ExecuteLogic(InitialGameInfo initialGameInfo, RoundGameInfo roundGameInfo)
   {
      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      if (roundGameInfo == null)
      {
         throw new ArgumentNullException(nameof(roundGameInfo));
      }

      targetCells ??= labyrinthExplorer.ExploreLabyrinth(roundGameInfo.Labyrinth, initialGameInfo, roundGameInfo);

      if (targetCells is not null)
      {
         movementManager.Move(roundGameInfo.Labyrinth, targetCells);
      }
   }
}