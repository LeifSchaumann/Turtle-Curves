using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class MyMath
{
    public static Quaternion Rotation(float angle)
    {
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public static int IntPow(int x, uint pow)
    {
        int ret = 1;
        while (pow != 0)
        {
            if ((pow & 1) == 1)
                ret *= x;
            x *= x;
            pow >>= 1;
        }
        return ret;
    }
    public static int TM(int n)
    {
        string binary = Convert.ToString(n, 2);
        int output = 0;
        foreach (char c in binary)
        {
            if (c == '1')
            {
                output = (output + 1) % 2;
            }
        }
        return output;
    }
}
