using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public CurveDrawer curveDrawer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        curveDrawer.turtleCurve = new TurtleCurve(MyMath.TM, new TurtleState[] { new TurtleState(2, 0, -60), new TurtleState(1, 0, 90) });
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            curveDrawer.stepTime += Time.deltaTime * 5;
        }
    }
}
