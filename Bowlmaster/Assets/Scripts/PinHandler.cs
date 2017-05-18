using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private Pin[] pinArray;
    private bool ballEnteredBox = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;
    private Ball ball;
    private Animator anim;
    public GameObject pinsPrefab;

    // Use this for initialization
    void Start()

    {
        anim = GetComponent<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ballEnteredBox) { CheckPinsSettled(); }
    }


    // look at level manager to figure out what i need to do to get button to see this setting static didn't fly

    public int CountStanding()
    {
        int standingPinCount = 0;

        foreach (Pin pin in GetPinArray())
        {

            if (pin.IsStanding()) { standingPinCount++; }
        }
        return standingPinCount;
    }




    //this method does too much
    public void CheckPinsSettled()
    {
        int currentStandingCount = CountStanding();

        if (currentStandingCount != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStandingCount;
            return;
        }

        float settleTime = 3f;

        if ((Time.time - lastChangeTime) > settleTime)
        {
            if (currentStandingCount == 0)
            {
                anim.SetTrigger("refreshPins");

            }
            else anim.SetTrigger("clearPins");
            CountPinsAndResetBall();
        }
    }




    public void CountPinsAndResetBall()
    {

        Debug.Log("Ball reset, pins left are " + lastStandingCount);
        lastStandingCount = -1;
        ball.ResetBall();
        ballEnteredBox = false;

    }


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

            if (pin.IsStanding()) { pin.Raise(); }
        }


    }
    public void LowerPins()
    {
        Debug.Log("Lower pins called from pinhandler");
        foreach (Pin pin in GetPinArray())
        {
            pin.Lower();
        }


    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Ball")
        {
            ballEnteredBox = true;
        }
    }



    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "Pin_Collider")
        {
            Debug.Log("pin left collider it should destroy");
            Destroy(collider.transform.parent.gameObject);
        }
    }




}
