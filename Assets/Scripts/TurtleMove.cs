using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TurtleMove
{
    public Vector3 pos;
    public float heading;

    public TurtleMove(float x, float y, float heading)
    {
        this.pos = new Vector3(x, y);
        this.heading = heading;
    }
    public static TurtleMove operator +(TurtleMove start, TurtleMove add)
    {
        return new TurtleMove { pos = start.pos + Quaternion.AngleAxis(start.heading, Vector3.forward) * add.pos, heading = (start.heading + add.heading) % 360f };
    }
    public override string ToString()
    {
        return $"(pos: ({pos.x}, {pos.y}), heading: {heading})";
    }
}