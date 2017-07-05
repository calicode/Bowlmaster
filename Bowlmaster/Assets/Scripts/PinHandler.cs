using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private Pin[] pinArray;
    private float lastChangeTime;
    public GameObject pinsPrefab;




    public void RefreshPins()
    {

        Instantiate(pinsPrefab, new Vector3(0, 2, 0), Quaternion.identity);

    }

    public Pin[] GetPinArray()
    {
        pinArray = GameObject.FindObjectsOfType<Pin>();
        return pinArray;

    }
    public void RaisePins()
    {

        foreach (Pin pin in GetPinArray())
        {

            if (pin.IsStanding())
            {
                pin.transform.eulerAngles = new Vector3(0, 0, 0);
                pin.Raise();
            }
        }


    }
    public void LowerPins()
    {
        foreach (Pin pin in GetPinArray())
        {
            pin.Lower();
        }


    }





}
