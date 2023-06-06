using System;

namespace PowerOfThor.Core.Abstraction.Data;

public class InitialGameDataBasic
{
    public InitialGameDataBasic(Coordinate2D thorPosition)
    {
        ThorPosition = thorPosition ?? throw new ArgumentNullException(nameof(thorPosition));
    }

    public Coordinate2D ThorPosition { get; }
}