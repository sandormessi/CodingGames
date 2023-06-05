namespace PowerOfThorEpisode1.Implementation.Game;

using System;
using CodingGames.Core.Abstraction;
using PowerOfThorEpisode1.Abstraction.Game;

public class PowerOfThorEpisode1Game : IPowerOfThorEpisode1Game
{
    private readonly IInputReader inputReader;

    public PowerOfThorEpisode1Game(IInputReader inputReader)
    {
        this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
    }

    public void Execute()
    {
    }
}