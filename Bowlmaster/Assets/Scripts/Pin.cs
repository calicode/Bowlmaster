using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Pin : MonoBehaviour
{
    private float liftAmount = 40f;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    public bool IsStanding()
    {

        if (Mathf.Round(transform.rotation.eulerAngles.x) == 0)
        {
            return true;
        }
        return false;


    }
    public void Raise()

    {
        rb.useGravity = false;

        Debug.Log("Rause pins called");
        transform.Translate(0, liftAmount, 0, Space.World);

    }
    public void Lower()
    {
        Debug.Log("Lower pins called");
        transform.Translate(0, -liftAmount, 0);
        rb.useGravity = true;
    }
}
