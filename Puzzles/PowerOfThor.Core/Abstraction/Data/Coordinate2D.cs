﻿namespace PowerOfThor.Core.Abstraction.Data;

public class Coordinate2D
{
    public Coordinate2D(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }

    public int Y { get; }
}