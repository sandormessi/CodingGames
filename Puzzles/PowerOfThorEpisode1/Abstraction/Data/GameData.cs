using System;

namespace PowerOfThorEpisode1.Abstraction.Data;

public class GameData
{
    public GameData(InitialGameData initialGameData, GameDataPerRound gameDataPerRound)
    {
        InitialGameData = initialGameData ?? throw new ArgumentNullException(nameof(initialGameData));
        GameDataPerRound = gameDataPerRound ?? throw new ArgumentNullException(nameof(gameDataPerRound));
    }

    public InitialGameData InitialGameData { get; }

    public GameDataPerRound GameDataPerRound { get; }
}