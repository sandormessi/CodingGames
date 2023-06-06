namespace CodingGames.Core.Abstraction.Data;

using System;

public class GameDataPerRoundBase
{
    public GameDataPerRoundBase(int round)
    {
        if (round < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(round));
        }

        Round = round;
    }

    public int Round { get; }
}