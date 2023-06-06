namespace PowerOfThor.Core.Abstraction.Data;

using CodingGames.Core.Abstraction.Data;
using System;

public class GameDataPerRound: GameDataPerRoundBase
{
    public GameDataPerRound(int remainingTurns, int round) : base(round)
    {
        if (remainingTurns < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(remainingTurns));
        }

        RemainingTurns = remainingTurns;
    }

    public int RemainingTurns { get; }
}