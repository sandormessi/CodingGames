namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface IGameLogicManager
{
    void Execute(GameData gameData);
}