namespace PowerOfThorEpisode1.Implementation.Game;

using System;
using PowerOfThor.Core.Implementation.Game;
using PowerOfThorEpisode1.Abstraction.Game;

public class OutputManagerEpisode1 : OutputManager, IOutputManagerEpisode1
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