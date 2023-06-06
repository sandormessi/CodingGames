namespace PowerOfThor.Core.Implementation.InputReading;

using System;
using Abstraction.Data;
using CodingGames.Core.Abstraction;
using PowerOfThor.Core.Abstraction.InputReading;

public class GameDataPerRoundReader : IGameDataPerRoundReader
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