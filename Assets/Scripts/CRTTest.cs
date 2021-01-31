using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CRTTest : MonoBehaviour {
 
    public Material material;
    // Use this for initialization
    void Start () {
        material = new Material (Shader.Find ("Hidden/CRT"));
    }

    public void OnRenderImage (RenderTexture source, RenderTexture destination) {
        material.SetTexture ("_MainTex", source);
        Graphics.Blit (source, destination, material);
    }
}