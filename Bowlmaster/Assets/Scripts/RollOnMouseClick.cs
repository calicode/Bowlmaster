using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOnMouseClick : MonoBehaviour
{
    Rigidbody rb;
    AudioSource asource;
    bool rolled;
    public Vector3 launchVelocity = new Vector3(0, 0, 400); //default speed
    void Start()
    {
        rolled = false;
        rb = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();
        rb.useGravity = false;

    }




    public void RollMe(Vector3 velocity)
    {
        if (!rolled)
        {
            rolled = true;
            rb.useGravity = true;
            rb.velocity = velocity;
            asource.Play();
        }
    }
    // Update is called once per frame
}
