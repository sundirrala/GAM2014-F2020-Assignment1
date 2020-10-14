using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GridPoints
{
    public int X { get; set; }

    public int Y { get; set; }

    public GridPoints(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
}
