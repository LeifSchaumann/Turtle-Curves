using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ThueMorseCurve : TurtleCurve
{
    public int p;
    public float[] turns;
    public Vector2[] moves;

    public override void UpdateSettings()
    {
        sequence = MyMath.TM(p);
        legend = new TurtleState[p];
        for (int i = 0; i < p; i++)
        {
            legend[i] = new TurtleState(moves[i], turns[i]);
        }
        ResetPath();
    }
}

