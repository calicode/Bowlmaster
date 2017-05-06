using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public bool IsStanding()
    {

        if (transform.rotation.eulerAngles.x == 0)
        {
            return true;
        }
        return false;


    }
    public void PinLift()
    {


    }
    public void PinDrop()
    {
        transform.Translate(0, -20, 0);
    }
}
