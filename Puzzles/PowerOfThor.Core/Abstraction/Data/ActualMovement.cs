namespace PowerOfThor.Core.Abstraction.Data;

using System;

public class ActualMovement
{
    public ActualMovement(Directions direction, Coordinate2D actualPosition)
    {
        Direction = direction;
        ActualPosition = actualPosition ?? throw new ArgumentNullException(nameof(actualPosition));
    }

    public Directions Direction { get; }
    public Coordinate2D ActualPosition { get; }
}