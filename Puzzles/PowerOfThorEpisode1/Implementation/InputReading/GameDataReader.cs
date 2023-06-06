using System;
using PowerOfThor.Core.Abstraction.InputReading;
using PowerOfThorEpisode1.Abstraction.Data;

namespace PowerOfThorEpisode1.Implementation.InputReading;

public class GameDataReader : IGameDataReader<GameData>
{
    private readonly IInitialGameDataReader<InitialGameData> initialGameDataReader;
    private readonly IGameDataPerRoundReader<GameDataPerRound> gameDataPerRoundReader;

    public GameDataReader(IInitialGameDataReader<InitialGameData> initialGameDataReader,
        IGameDataPerRoundReader<GameDataPerRound> gameDataPerRoundReader)
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