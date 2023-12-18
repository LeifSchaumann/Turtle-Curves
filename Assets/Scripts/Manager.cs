using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        TurtleCurve myCurve = new TurtleCurve(Sequences.TM, new TurtleMove[] { new TurtleMove(1, 0, 0), new TurtleMove(0, 0, 90) }, 8);
        foreach (TurtleMove move in myCurve.path)
        {
            Debug.Log(move);
        }
    }
}
