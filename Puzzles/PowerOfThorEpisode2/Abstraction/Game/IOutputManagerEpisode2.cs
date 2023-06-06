using PowerOfThor.Core.Abstraction.Game;

namespace PowerOfThorEpisode2.Abstraction.Game;

public interface IOutputManagerEpisode2 : IOutputManager
{
    void DoNothing();

    void Strike();
}