namespace PowerOfThor.Core.Implementation.InputReading;

using System;
using Abstraction.Data;
using PowerOfThor.Core.Abstraction.InputReading;

public class GameDataReader : IGameDataReader
{
    private readonly IInitialGameDataReader initialGameDataReader;
    private readonly IGameDataPerRoundReader gameDataPerRoundReader;

    public GameDataReader(IInitialGameDataReader initialGameDataReader, IGameDataPerRoundReader gameDataPerRoundReader)
    {
        this.initialGameDataReader =
            initialGameDataReader ?? throw new ArgumentNullException(nameof(initialGameDataReader));
        this.gameDataPerRoundReader =
            gameDataPerRoundReader ?? throw new ArgumentNullException(nameof(gameDataPerRoundReader));
    }

    public GameData ReadGameData(int round)
    {
        var initialGameData = initialGameDataReader.ReadInitialGameData();
        var gameDataPerRound = gameDataPerRoundReader.ReadGameDataPerRound(round);

        return new GameData(initialGameData, gameDataPerRound);
    }
}