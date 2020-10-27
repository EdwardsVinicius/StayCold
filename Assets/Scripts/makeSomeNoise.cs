using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class makeSomeNoise : MonoBehaviour
{
    public float power;
    public float scale;
    public float timeScale;
    private float xOffset;
    private float yOffset;
    private MeshFilter meshFilter;
    // Start is called before the first frame update
    void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        MakeNoise();
    }

    // Update is called once per frame
    void Update()
    {
        MakeNoise();
        xOffset += Time.deltaTime * timeScale;
        yOffset += Time.deltaTime * timeScale;
    }

    void MakeNoise()
    {
        Vector3[] verticies = meshFilter.mesh.vertices;

        for(int i = 0; i < verticies.Length; i++)
        {
            verticies[i].y = CalculateHeight(verticies[i].x, verticies[i].z) * power;
        }

        meshFilter.mesh.vertices = verticies;
    }

    float CalculateHeight(float x, float y)
    {
        float xCord = x * scale + xOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
