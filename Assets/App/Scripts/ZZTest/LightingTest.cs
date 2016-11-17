using UnityEngine;
using System.Collections;

public class LightingTest : MonoBehaviour {

    void Start ()
    {
        TestLight();
    }
    public Material[] maps;
    public void TestLight ()
    {
        int r = Random.Range(0, 3);
        RenderSettings.skybox = maps[r];
    }
}
