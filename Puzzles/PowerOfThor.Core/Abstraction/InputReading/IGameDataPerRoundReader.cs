namespace PowerOfThor.Core.Abstraction.InputReading;

public interface IGameDataPerRoundReader<out TGameDataPerRound>
{
    TGameDataPerRound ReadGameDataPerRound(int round);
}