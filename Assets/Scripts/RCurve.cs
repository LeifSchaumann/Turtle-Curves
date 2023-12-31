using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class RCurve : TurtleCurve
{
    public int p;
    public int k;
    public int q;

    public override void UpdateSettings()
    {
        sequence = MyMath.uSeq(p, q);
        legend = new TurtleState[p * q];
        for (int x = 0; x < p; x++)
        {
            for (int y = 0; y < q; y++)
            {
                legend[x * q + y] = new TurtleState(MyMath.Rotation(360f * x / p) * MyMath.Rotation(360f * y * k / q) * Vector3.right, 0f);
            }
        }
        ResetPath();
    }
}


