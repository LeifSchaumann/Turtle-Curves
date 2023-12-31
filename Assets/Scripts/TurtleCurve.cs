using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class TurtleCurve : MonoBehaviour
{
    public Func<int, int> sequence;
    public TurtleState[] legend;
    private List<TurtleState> path;
    public Rect bounds;

    private void Awake()
    {
        UpdateSettings();
    }
    public virtual void UpdateSettings()
    {
        ResetPath();
    }
    public void ResetPath()
    {
        this.path = new List<TurtleState> { new TurtleState(0, 0, 0) };
        this.bounds = new Rect(Vector2.zero, Vector2.zero);
    }
    public TurtleState[] GetPath(int steps)
    {
        if (path.Count <= steps)
        {
            for (int i = path.Count - 1; i < steps; i++)
            {
                TurtleState newTS = path[i] + legend[sequence(i)];
                path.Add(newTS);
                ExtendBounds(newTS.pos);
            }
        }
        return path.Take(steps + 1).ToArray();
    }
    private void ExtendBounds(Vector3 pos)
    {
        bounds.xMax = Mathf.Max(bounds.xMax, pos.x);
        bounds.xMin = Mathf.Min(bounds.xMin, pos.x);
        bounds.yMax = Mathf.Max(bounds.yMax, pos.y);
        bounds.yMin = Mathf.Min(bounds.yMin, pos.y);
    }
}