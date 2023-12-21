using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using static UnityEditorInternal.VersionControl.ListControl;

public class TurtleCurveDrawer : MonoBehaviour
{
    private TurtleCurve turtleCurve;
    public GameObject turtleObject;
    public int steps;
    public float stepTime;
    public bool animationEnabled;
    public bool showTurtle;
    public AnimationCurve moveAC;
    public AnimationCurve turnAC;
    public float speed;

    private CustomLineRenderer lineRenderer;

    private void Awake()
    {
        lineRenderer = GetComponent<CustomLineRenderer>();
        turtleCurve = GetComponent<TurtleCurve>();
    }

    public void Update()
    {
        stepTime += Time.deltaTime * speed * Manager.instance.globalSpeed;
        steps = Mathf.FloorToInt(stepTime) + 1;
        turtleObject.SetActive(showTurtle);
        TurtleState[] path = turtleCurve.GetPath(steps);
        if (steps < 1 || steps > path.Length - 1)
        {
            Debug.Log(steps);
        }
        TurtleState startState = path[steps - 1];
        TurtleState endState = path[steps];
        if (animationEnabled)
        {
            float stepProgress = stepTime - steps + 1f;
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
            turtleObject.transform.localRotation = MyMath.Rotation(endState.heading);
            turtleObject.transform.localPosition = endState.pos;
            Vector3[] points = (from move in path select move.pos).ToArray();
            lineRenderer.SetPoints(points);
        }
    }
}
