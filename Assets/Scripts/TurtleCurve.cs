using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TurtleCurve
{
    public Func<int, int> sequence;
    public TurtleMove[] legend;
    public TurtleMove[] path;
    public int steps;

    public TurtleCurve(Func<int, int> sequence, TurtleMove[] legend, int steps)
    {
        this.sequence = sequence;
        this.legend = legend;
        this.steps = steps;

        CalculatePath();
    }

    private void CalculatePath()
    {
        path = new TurtleMove[steps + 1];
        path[0] = new TurtleMove { pos = Vector3.zero, heading = 0f };

        for (int i = 0; i < steps; i++)
        {
            path[i + 1] = path[i] + legend[sequence(i)];
        }
    }
}
