using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class DCurve : TurtleCurve
{
    public ThueMorseCurve parentTMC;
    public int k;
    public int q;
    public override void UpdateSettings()
    {
        parentTMC.UpdateSettings();
        int p = parentTMC.p;
        sequence = MyMath.uSeq(p, q);
        legend = new TurtleState[p * q];
        for (int x = 0; x < p; x++)
        {
            TurtleState phiState = new TurtleState(0, 0, 0);
            for (int i = x; i < p + x; i++)
            {
                phiState += parentTMC.legend[i % p];
            }
            for (int y = 0; y < q; y++)
            {
                legend[x * q + y] = new TurtleState(MyMath.Rotation(360f * y * k / q) * phiState.pos, 0f);
            }
        }
        ResetPath();
    }
}

