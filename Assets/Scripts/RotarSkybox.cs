using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarSkybox : MonoBehaviour
{
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time);
    }
}
