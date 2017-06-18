using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxRotate : MonoBehaviour
{
    Skybox sb;
    // Use this for initialization
    void Start()
    {
        sb = GetComponent<Skybox>();
    }

    // Update is called once per frame
    void Update()
    {// not working yet. also tried transform.rotate, it just moved the whole camera
     // sb.transform.Translate(Vector3.left * 20);
    }
}
