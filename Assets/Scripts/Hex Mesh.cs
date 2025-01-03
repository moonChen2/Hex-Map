using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour
{
    private Mesh hexMesh;
    private List<Vector3> vertices;
    List<int> triangles;
    List<Color> colors;

    private MeshCollider mehsCollider;
    private void Awake()
    {
        GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
        mehsCollider = gameObject.AddComponent<MeshCollider>();
        
        hexMesh.name = "Hex Mesh";
        vertices = new List<Vector3>();
        triangles = new List<int>();
        colors = new List<Color>();
    }

    public void Triangulate(HexCell[] cells)
    {
        hexMesh.Clear();
        vertices.Clear();
        triangles.Clear();
        colors.Clear();

        for (int i = 0; i < cells.Length; i++)
        {
            Triangulate(cells[i]);
        }
        hexMesh.vertices = vertices.ToArray();
        hexMesh.colors = colors.ToArray();
        hexMesh.triangles = triangles.ToArray();
        hexMesh.RecalculateNormals();
        
        mehsCollider.sharedMesh = hexMesh;

    }

    void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.position;
        for (int i = 0; i < 5; i++)
        {
            AddTriangle(center,
                center + HexMetrics.corners[i],
                center + HexMetrics.corners[i+1]);
            AddTriangleColor(cell.color);

        }
        AddTriangle(center,
            center + HexMetrics.corners[5],
            center + HexMetrics.corners[0]);
        AddTriangleColor(cell.color);
    }

    void AddTriangle(Vector3 v1, Vector3 v2, Vector3 v3)
    {
        int vertexIndex = vertices.Count;
        vertices.Add(v1);
        vertices.Add(v2);
        vertices.Add(v3);
        triangles.Add(vertexIndex);
        triangles.Add(vertexIndex+1);
        triangles.Add(vertexIndex+2);
    }
    
    void AddTriangleColor (Color color) {
        colors.Add(color);
        colors.Add(color);
        colors.Add(color);
    } 
}