using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinCounter : MonoBehaviour
{
    Pin[] pinArray;
    int lastStandingCount = -1;
    int lastSettledCount = 10;
    float lastChangeTime;
    bool ballEnteredBox;

    public GameManager gameManager;


    Animator anim;
    Ball ball;



    void Start()

    {
        anim = GetComponent<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
    }


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
            PinsHaveSettled();
        }

    }


    void PinsHaveSettled()
    {
        ActionMaster.Action nextAction = gameManager.GetNextAction();
        Debug.Log("Nextaction is " + nextAction.ToString());
        switch (nextAction)
        {
            case ActionMaster.Action.Tidy:
                anim.SetTrigger("clearPins");
                break;
            case ActionMaster.Action.Refresh:
            case ActionMaster.Action.EndTurn:
                anim.SetTrigger("refreshPins");
                break;
        }

        Invoke("ball.ResetBall()", 1);

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
