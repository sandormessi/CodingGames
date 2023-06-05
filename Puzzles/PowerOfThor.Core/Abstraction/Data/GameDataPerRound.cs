namespace PowerOfThor.Core.Abstraction.Data;

using System;

public class GameDataPerRound
{
    public GameDataPerRound(int remainingTurns)
    {
        if (remainingTurns < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(remainingTurns));
        }

        RemainingTurns = remainingTurns;
    }

    public int RemainingTurns { get; }
}