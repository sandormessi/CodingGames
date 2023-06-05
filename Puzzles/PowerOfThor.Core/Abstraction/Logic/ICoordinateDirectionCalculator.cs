namespace PowerOfThor.Core.Abstraction.Logic;

using Data;

public interface ICoordinateDirectionCalculator
{
    Directions CalculateDirectionOfCoordinates(Coordinate2D coordinate1, Coordinate2D coordinate2);
}