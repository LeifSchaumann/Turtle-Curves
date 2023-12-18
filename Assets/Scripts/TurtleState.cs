using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TurtleState
{
    public Vector3 pos;
    public float heading;

    public TurtleState(float x, float y, float heading)
    {
        this.pos = new Vector3(x, y);
        this.heading = heading;
    }
    public static TurtleState operator +(TurtleState start, TurtleState add)
    {
        return new TurtleState { pos = start.pos + Quaternion.AngleAxis(start.heading, Vector3.forward) * add.pos, heading = (start.heading + add.heading) % 360f };
    }
    public override string ToString()
    {
        return $"(pos: ({pos.x}, {pos.y}), heading: {heading})";
    }
}