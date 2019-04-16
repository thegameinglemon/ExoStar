using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CubeMeshData
{
    static int x;
    static int y;

    // All the vertex positions for a simple cube. (8 in total)
    public static Vector3[] vertices = {
        new Vector3(1, 1, 1),
        new Vector3(-1, 1, 1),
        new Vector3(-1, -1, 1),
        new Vector3(1, -1, 1),
        new Vector3(-1, 1, -1),
        new Vector3(1, 1, -1),
        new Vector3(1, -1, -1),
        new Vector3(-1, -1, -1)
    };

    // Holds all face triangles for each quad. (6 in total for 1 cube)
    public static int[][] faceTriangles =
    {
        new int[] {0, 1, 2, 3 },
        new int[] {5, 0, 3, 6 },
        new int[] {4, 5, 6, 7 },
        new int[] {1, 4, 7, 2 },
        new int[] {5, 4, 1, 0 },
        new int[] {3, 2, 7, 6 },
    };

    // Returns a Vector3[] based on the dir and i count.
    public static Vector3[] FaceVertices(int dir, float scale, Vector3 pos)
    {
        Vector3[] fv = new Vector3[4];
        for (int i = 0; i < fv.Length; i++)
        {
            // So the first time i will be 0 and when dir is also zero we get the first example below:
            // and the number of faceTriangles on pos [0][0] is alzo zero. The pos on [1][0] = 5;
            // fv[0] = vertices[faceTriangles[0][0]];  
            // fv[1] = vertices[faceTriangles[0][1]];
            // fv[2] = vertices[faceTriangles[0][2]];
            // fv[3] = vertices[faceTriangles[0][3]];
            // So we return an ARRAY of VECTOR3's where each Vector3 is a point(VERTEX) in space.
            fv[i] = (vertices[faceTriangles[dir][i]] * scale) + pos;

        }
        return fv;
    }

}