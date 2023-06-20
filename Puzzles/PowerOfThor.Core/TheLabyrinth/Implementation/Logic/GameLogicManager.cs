namespace TheLabyrinth;

using System;

using TheLabyrinth.Abstraction;

public class GameLogicManager : IGameLogicManager
{
   private readonly IInputManager inputManager;

   public GameLogicManager(IInputManager inputManager)
   {
      this.inputManager = inputManager ?? throw new ArgumentNullException(nameof(inputManager));
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

      throw new NotImplementedException();
   }
}