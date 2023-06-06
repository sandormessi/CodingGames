namespace PowerOfThor.Core.Abstraction.InputReading;

public interface IInitialGameDataReader<out TInitialGameData>
{
    TInitialGameData ReadInitialGameData();
}