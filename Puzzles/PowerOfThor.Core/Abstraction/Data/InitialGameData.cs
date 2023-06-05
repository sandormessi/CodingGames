namespace PowerOfThor.Core.Abstraction.Data;

using System;

public class InitialGameData
{
    public InitialGameData(Coordinate2D thorPosition, Coordinate2D lightPosition)
    {
        ThorPosition = thorPosition ?? throw new ArgumentNullException(nameof(thorPosition));
        LightPosition = lightPosition ?? throw new ArgumentNullException(nameof(lightPosition));
    }

    public Coordinate2D ThorPosition { get; }

    public Coordinate2D LightPosition { get; }
}