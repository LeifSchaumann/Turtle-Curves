using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurveDrawer : MonoBehaviour
{
    public TurtleCurve turtleCurve;

    private LineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void Draw()
    {

    }
}
