namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface IGameLogicManager
{
    ActualMovement Execute(GameData gameData, Coordinate2D lastPosition);
}