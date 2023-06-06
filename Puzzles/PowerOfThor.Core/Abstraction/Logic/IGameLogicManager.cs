namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface IGameLogicManager<in TGameData, out TAction> 
{
    TAction Execute(TGameData gameData, Coordinate2D lastPosition);
}