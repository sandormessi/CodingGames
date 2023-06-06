namespace PowerOfThor.Core.Abstraction.InputReading;

public interface IGameDataReader<out TGameData>
{
    TGameData ReadGameData(int round);
}