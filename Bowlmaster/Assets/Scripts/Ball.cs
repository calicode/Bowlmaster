using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    AudioSource asource;
    public bool rolled;
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



    public void ResetBall()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
        transform.position = new Vector3(0, 15, 48);
        rb.useGravity = false;
        rolled = false;
    }
    // Update is called once per frame
}
