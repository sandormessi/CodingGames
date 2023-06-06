using PowerOfThor.Core.Abstraction.Data;

namespace PowerOfThor.Core.Abstraction.InputReading;

public interface IGameDataPerRoundReader
{
    GameDataPerRound ReadGameDataPerRound(int round);
}