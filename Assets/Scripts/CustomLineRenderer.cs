using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class CustomLineRenderer : MonoBehaviour
{
    private Mesh mesh;
    private List<Vector3> points;
    public float thickness;

    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetPoints(Vector3[] newPoints)
    {
        points = new List<Vector3> { newPoints[0] };
        for (int i = 1; i < newPoints.Length; i++)
        {
            if (Vector3.Distance(newPoints[i], newPoints[i - 1]) > 0.001f)
            {
                points.Add(newPoints[i]);
            }
        }
        Draw();
    }

    void Draw()
    {
        if (points == null || points.Count < 2)
        {
            mesh.Clear();
            return;
        }

        Vector3[] vertices = new Vector3[(points.Count - 1) * 4];
        int[] triangles = new int[(points.Count - 1) * 6 + (points.Count - 2) * 6];

        int vertexIndex = 0;
        int triangleIndex = 0;

        for (int i = 0; i < points.Count - 1; i++)
        {
            Vector3 side = Vector3.Cross(Vector3.forward, points[i + 1] - points[i]);
            side.Normalize();
            side *= thickness / 2f;

            vertices[vertexIndex++] = points[i] + side;
            vertices[vertexIndex++] = points[i] - side;
            vertices[vertexIndex++] = points[i + 1] + side;
            vertices[vertexIndex++] = points[i + 1] - side;

            triangles[triangleIndex++] = vertexIndex - 1;
            triangles[triangleIndex++] = vertexIndex - 3;
            triangles[triangleIndex++] = vertexIndex - 2;

            triangles[triangleIndex++] = vertexIndex - 2;
            triangles[triangleIndex++] = vertexIndex - 3;
            triangles[triangleIndex++] = vertexIndex - 4;

            if (i > 0)
            {
                triangles[triangleIndex++] = vertexIndex - 3;
                triangles[triangleIndex++] = vertexIndex - 5;
                triangles[triangleIndex++] = vertexIndex - 4;

                triangles[triangleIndex++] = vertexIndex - 3;
                triangles[triangleIndex++] = vertexIndex - 6;
                triangles[triangleIndex++] = vertexIndex - 4;
            }
        }

        mesh.Clear();
        mesh.vertices = vertices;
        mesh.SetIndices(triangles, MeshTopology.Triangles, 0);
        mesh.RecalculateBounds();
    }
}
