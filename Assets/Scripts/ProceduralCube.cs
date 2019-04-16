using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ProceduralCube : MonoBehaviour
{
    private Mesh mesh;                  // Holds a reference to the mesh.
    private List<Vector3> vertices;     // List that holds our vertices, we send these to the mesh.
    private List<int> triangles;        // List that holds our triangles, we send these to the mesh.

    public float scale = 1f;            // Handles the scaling of our cubes.
    public int posX, posY, posZ;        // The x,y,z positions of the cubes.

    private float adjustedScale;        // The normal scale / 2.

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        adjustedScale = scale * 0.5f;
    }

    void Start()
    {
        MakeCube(adjustedScale, new Vector3((float)posX * scale, (float)posY * scale, (float)posZ * scale));
        UpdateMesh();
    }

    // Creates the cube by calling MakeFace multiple times. (Ones for each face)
    private void MakeCube(float cubeScale, Vector3 cubePos)
    {
        vertices = new List<Vector3>();
        triangles = new List<int>();

        for (int i = 0; i < 6; i++)
        {
            MakeFace(i, cubeScale, cubePos);
        }
    }

    // Creates one face/side of our cube
    private void MakeFace(int dir, float faceScale, Vector3 facePos)
    {
        // With AddRange() you can add an array to a list.
        // Via de FaceVertices() die in de CubeMeshData class staat, returnen we een array.
        vertices.AddRange(CubeMeshData.FaceVertices(dir, faceScale, facePos));

        int vCount = vertices.Count;

        triangles.Add(vCount - 4);     // (0) The first time our vCount will be 4.
        triangles.Add(vCount - 4 + 1);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4);
        triangles.Add(vCount - 4 + 2);
        triangles.Add(vCount - 4 + 3);

    }

    // Updates our mesh
    private void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();
    }
}