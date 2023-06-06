namespace PowerOfThorEpisode1.Abstraction.Data;

using PowerOfThor.Core.Abstraction.Data;
using System;

public class InitialGameData : InitialGameDataBasic
{
    public InitialGameData(Coordinate2D thorPosition, Coordinate2D lightPosition) : base(thorPosition)
    {
        LightPosition = lightPosition ?? throw new ArgumentNullException(nameof(lightPosition));
    }

    public Coordinate2D LightPosition { get; }
}