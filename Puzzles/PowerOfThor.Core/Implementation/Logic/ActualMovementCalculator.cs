namespace PowerOfThor.Core.Implementation.Logic;

using System;
using Abstraction.Data;
using PowerOfThor.Core.Abstraction.Logic;

public class ActualMovementCalculator : IActualMovementCalculator
{
    private static readonly Directions[][] directions =
    {
        new[] { Directions.NW, Directions.N, Directions.NE },
        new[] { Directions.W, Directions.None, Directions.E },
        new[] { Directions.SW, Directions.S, Directions.SE }
    };

    public ActualMovement CalculateActualMovement(Coordinate2D coordinate1, Coordinate2D coordinate2)
    {
        if (coordinate1 == null)
        {
            throw new ArgumentNullException(nameof(coordinate1));
        }

        if (coordinate2 == null)
        {
            throw new ArgumentNullException(nameof(coordinate2));
        }

        var startPoint = coordinate1;
        var endPoint = coordinate2;

        var xDistance = startPoint.X - endPoint.Y;
        var yDistance = startPoint.Y - endPoint.X;

        int x = 1;
        int y = 1;

        var signOfX = Math.Sign(xDistance);
        var signOfY = Math.Sign(yDistance);

        x -= signOfY;
        y -= signOfX;

        Coordinate2D actualPosition = null;
        return new ActualMovement(directions[x][y], actualPosition);
    }
}