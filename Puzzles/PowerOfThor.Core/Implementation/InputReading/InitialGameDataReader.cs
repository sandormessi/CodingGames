using System;
using CodingGames.Core.Abstraction;
using PowerOfThor.Core.Abstraction.Data;
using PowerOfThor.Core.Abstraction.InputReading;

namespace PowerOfThor.Core.Implementation.InputReading;

public class InitialGameDataReader : IInitialGameDataReader
{
    private readonly IInputReader inputReader;

    private const char InputLineDataSeparator = ' ';
    private InitialGameData? initialGameData;

    public InitialGameDataReader(IInputReader inputReader)
    {
        this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
    }

    public InitialGameData ReadInitialGameData()
    {
        if (initialGameData is not null)
        {
            return initialGameData;
        }

        var input = inputReader.ReadInput();

        var inputs = input.Split(InputLineDataSeparator);

        int lightX = int.Parse(inputs[0]);
        int lightY = int.Parse(inputs[1]);

        int initialTx = int.Parse(inputs[2]);
        int initialTy = int.Parse(inputs[3]);

        Coordinate2D thorPosition = new(initialTx, initialTy);
        Coordinate2D lightPosition = new(lightX, lightY);

        return initialGameData = new InitialGameData(thorPosition, lightPosition);
    }
}