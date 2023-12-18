using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using static UnityEditorInternal.VersionControl.ListControl;

public class CurveDrawer : MonoBehaviour
{
    public TurtleCurve turtleCurve;
    public GameObject turtleObject;
    public int steps;
    public float stepTime;
    public bool animationEnabled;
    public AnimationCurve moveAC;
    public AnimationCurve turnAC;

    private CustomLineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<CustomLineRenderer>();
    }

    public void Update()
    {
        if (animationEnabled)
        {
            steps = Mathf.FloorToInt(stepTime) + 1;
            TurtleState[] path = turtleCurve.GetPath(steps);
            TurtleState startState = path[steps - 1];
            TurtleState endState = path[steps];
            float stepProgress = stepTime - steps + 1f;

            turtleObject.SetActive(true);
            if (stepProgress < 0.5f)
            {
                turtleObject.transform.localRotation = MyMath.Rotation(startState.heading);
                turtleObject.transform.localPosition = Vector3.Lerp(startState.pos, endState.pos, moveAC.Evaluate(stepProgress * 2f));
            }
            else
            {
                turtleObject.transform.localPosition = endState.pos;
                turtleObject.transform.localRotation = Quaternion.Lerp(MyMath.Rotation(startState.heading), MyMath.Rotation(endState.heading), turnAC.Evaluate(stepProgress * 2f - 1f));
            }

            Vector3[] points = (from move in path select move.pos).ToArray();
            points[points.Length - 1] = turtleObject.transform.localPosition;
            lineRenderer.SetPoints(points);
        }
        else
        {
            turtleObject.SetActive(false);

            TurtleState[] path = turtleCurve.GetPath(steps);
            Vector3[] points = (from move in path select move.pos).ToArray();
            lineRenderer.SetPoints(points);
        }
    }
}
