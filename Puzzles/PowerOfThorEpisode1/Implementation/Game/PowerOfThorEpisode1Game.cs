namespace PowerOfThorEpisode1.Implementation.Game;

using System;
using PowerOfThor.Core.Abstraction.Game;
using PowerOfThor.Core.Abstraction.InputReading;

public class PowerOfThorEpisode1Game : IPowerOfThorGame
{
    private readonly IGameDataReader gameDataReader;

    public PowerOfThorEpisode1Game(IGameDataReader gameDataReader)
    {
        this.gameDataReader = gameDataReader ?? throw new ArgumentNullException(nameof(gameDataReader));
    }

    public void Execute()
    {
        while (true)
        {
            var gameData = gameDataReader.ReadGameData();
        }
    }
}