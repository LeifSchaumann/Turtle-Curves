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
        this.heading = heading % 360f;
    }
    public TurtleState(Vector3 pos, float heading)
    {
        this.pos = pos;
        this.heading = heading % 360f;
    }
    public TurtleState(Vector2 pos, float heading)
    {
        this.pos = new Vector3(pos.x, pos.y);
        this.heading = heading % 360f;
    }
    public static TurtleState operator +(TurtleState start, TurtleState add)
    {
        return new TurtleState { pos = start.pos + MyMath.Rotation(start.heading) * add.pos, heading = (start.heading + add.heading) % 360f };
    }
    public override string ToString()
    {
        return $"(pos: ({pos.x}, {pos.y}), heading: {heading})";
    }
}