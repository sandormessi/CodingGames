namespace TheLabyrinth;

using System;

public class GameLogicManager : IGameLogicManager
{
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