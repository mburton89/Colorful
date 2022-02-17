using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogScroller : MonoBehaviour
{
    public Material Fog;
    public Color fogColor;
    public float scrollRate;


    // Start is called before the first frame update
    void Awake()
    {
        RenderSettings.skybox = Fog;
        RenderSettings.skybox.SetColor("_Tint", fogColor);
    }

    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * scrollRate);
    }
}
