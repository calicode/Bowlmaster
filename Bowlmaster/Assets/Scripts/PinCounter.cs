using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour
{
    private Pin[] pinArray;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    public GameManager gameManager;
    bool ballEnteredBox;




    public Pin[] GetPinArray()
    {
        pinArray = GameObject.FindObjectsOfType<Pin>();
        return pinArray;

    }



    public int CountStanding()
    {
        int standingPinCount = 0;

        foreach (Pin pin in GetPinArray())
        {

            if (pin.IsStanding()) { standingPinCount++; }
        }
        return standingPinCount;
    }

    public void CheckPinsSettled()
    {

        float settleTime = 3f;
        int currentStandingCount = CountStanding();




        if (currentStandingCount != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStandingCount;
        }

        if ((Time.time - lastChangeTime) > settleTime)
        {
            int pinfall = lastSettledCount - lastStandingCount;
            lastSettledCount = currentStandingCount;
            Debug.Log("Sending pinfall of" + pinfall + " to gamemanager");
            gameManager.UpdatePinFalls(pinfall);
            lastStandingCount = -1;

        }

    }




    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Pin_Collider")
        {
            Destroy(collider.transform.parent.gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {

        if (gameManager.HasBallLeftBox())
        {


            CheckPinsSettled();
        }
    }
}
