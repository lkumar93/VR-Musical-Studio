using UnityEngine;
using System.Collections;

public class WaveGen : MonoBehaviour
{
    float scale = 0.5f;
    float speed = 2.0f;
    float noiseStrength = 5f;
    float noiseWalk = 30f;

    private Vector3[] baseHeight;

    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;

        if (baseHeight == null)
            baseHeight = mesh.vertices;

        Vector3[] vertices = new Vector3[baseHeight.Length];
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = baseHeight[i];
            vertex.y += (0.6f*Mathf.Sin(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale) + (0.4f* Mathf.Cos(Time.time * speed + baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale);
            vertex.y += Mathf.PerlinNoise(baseHeight[i].x + noiseWalk, baseHeight[i].y + (Mathf.Sin(Time.time * 0.1f)) * noiseStrength) + (Mathf.Cos(Time.time * 0.1f) *noiseStrength);
        vertices[i] = vertex;
        }
        mesh.vertices = vertices;
        mesh.RecalculateNormals();
    }
}