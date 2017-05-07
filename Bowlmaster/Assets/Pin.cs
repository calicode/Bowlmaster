using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{

    public bool IsStanding()
    {

        if (Mathf.Round(transform.rotation.eulerAngles.x) == 0)
        {
            return true;
        }
        // Debug.Log("Pin" + gameObject.name + " Is not standing its euler angles are" + transform.rotation.eulerAngles.x);
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
