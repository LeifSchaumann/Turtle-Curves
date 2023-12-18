using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Sequences
{
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
