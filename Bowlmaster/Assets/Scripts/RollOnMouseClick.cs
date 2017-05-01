using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOnMouseClick : MonoBehaviour
{
    Rigidbody rb;
    AudioSource asource;
    bool rolled = false;
    public float rollSpeed = 50;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        asource = GetComponent<AudioSource>();

    }




    void RollMe()
    {
        if (!rolled)
        {
            Debug.Log("got mouseclick");
            rolled = true;
            rb.velocity = new Vector3(0, 0, rollSpeed);
            asource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RollMe();
        }
    }
}
