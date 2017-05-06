using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    int standingPinCount;
    Pin[] pinList;
    // Use this for initialization
    void Start()
    {

        pinList = GameObject.FindObjectsOfType<Pin>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    // look at level manager to figure out what i need to do to get button to see this setting static didn't fly

    public int CountStanding()
    {
        foreach (Pin pin in pinList)
        {

            if (pin.IsStanding()) { standingPinCount++; }
        }
        Debug.Log("Standing pin count is" + standingPinCount);
        return standingPinCount;
    }




}
