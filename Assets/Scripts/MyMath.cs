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
    public static Func<int, int> TM(int p)
    {
        Func<int, int> tp = null;
        tp = (int n) =>
        {
            if (n == 0) { return 0; }
            return (tp(n / p) + n) % p;
        };
        return tp;
    }

    public static Func<int, int> uSeq(int p, int q)
    {
        Func<int, int> tp = TM(p);
        return (int n) =>
        {
            return q * tp(n) + (n % q);
        };
    }
}
