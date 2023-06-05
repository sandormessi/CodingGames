namespace PowerOfThor.Core.Abstraction.Data;

using System;

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