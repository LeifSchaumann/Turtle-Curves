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
    }
    public TurtleState[] GetPath(int steps)
    {
        if (path.Count <= steps)
        {
            for (int i = path.Count - 1; i < steps; i++)
            {
                path.Add(path[i] + legend[sequence(i)]);
            }
        }
        return path.Take(steps + 1).ToArray();
    }
}