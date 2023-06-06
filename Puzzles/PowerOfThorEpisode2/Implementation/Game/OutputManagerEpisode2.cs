namespace PowerOfThorEpisode2.Implementation.Game;

using System;
using PowerOfThor.Core.Implementation.Game;
using PowerOfThorEpisode2.Abstraction.Game;

public class OutputManagerEpisode2 : OutputManager, IOutputManagerEpisode2
{
    public void DoNothing()
    {
        Console.WriteLine("WAIT");
    }

    public void Strike()
    {
        Console.WriteLine("STRIKE");
    }
}