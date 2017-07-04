using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    PinHandler pinHandler;
    Ball ball;
    public List<int> pinFalls = new List<int>();
    bool ballHasLeftBox = false;

    ActionMaster.Action nextAction;


    public void UpdatePinFalls(int pins)
    {
        pinFalls.Add(pins);

        SetNextAction(ref pinFalls);
        pinHandler.NextAction();

        BallHasLeftBox(false);
        ball.ResetBall();
        // move reset out somewhere else

    }

    public void SetNextAction(ref List<int> pinFalls)
    {
        nextAction = ActionMaster.NextAction(pinFalls);
    }

    public ActionMaster.Action GetNextAction()
    {
        return nextAction;
    }


    public void BallHasLeftBox(bool hasLeftBox)
    {
        ballHasLeftBox = hasLeftBox;

    }

    public bool HasBallLeftBox()
    {
        return ballHasLeftBox;

    }





    // Use this for initialization
    void Start()
    {
        pinHandler = GameObject.FindObjectOfType<PinHandler>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
