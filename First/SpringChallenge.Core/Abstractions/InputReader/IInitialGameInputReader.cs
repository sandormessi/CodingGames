namespace SpringChallenge.Core.Abstractions.InputReader;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;

public interface IInitialGameInputReader
{
   #region Public Methods and Operators

   InitialGameInfo ReadGameInfo();

   #endregion
}