using System;
using CodingGames.Core.Abstraction;
using PowerOfThor.Core.Abstraction.InputReading;
using PowerOfThorEpisode1.Abstraction.Data;

namespace PowerOfThorEpisode1.Implementation.InputReading;

public class GameDataPerRoundReader : IGameDataPerRoundReader<GameDataPerRound>
{
    private readonly IInputReader inputReader;

    public GameDataPerRoundReader(IInputReader inputReader)
    {
        this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
    }

    public GameDataPerRound ReadGameDataPerRound(int round)
    {
        var input = inputReader.ReadInput();
        var inputData = int.Parse(input);

        return new GameDataPerRound(inputData, round);
    }
}