using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST : MonoBehaviour
{
    MeshFilter meshRenderer;

    void Start()
    {
        meshRenderer = GetComponent<MeshFilter>();
        Debug.Log(meshRenderer.mesh.vertices.Length);
        Debug.Log(meshRenderer.mesh.triangles.Length);
    }
}
