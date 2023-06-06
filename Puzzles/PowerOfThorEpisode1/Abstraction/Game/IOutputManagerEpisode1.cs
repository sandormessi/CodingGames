namespace PowerOfThorEpisode1.Abstraction.Game;

using PowerOfThor.Core.Abstraction.Game;

public interface IOutputManagerEpisode1 : IOutputManager
{
    void DoNothing();

    void Strike();
}