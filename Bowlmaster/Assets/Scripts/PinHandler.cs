using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinHandler : MonoBehaviour
{
    private Pin[] pinArray;
    private float lastChangeTime;
    private Ball ball;
    private Animator anim;
    public GameObject pinsPrefab;

    public GameManager gameManager;
    // Use this for initialization
    void Start()

    {
        anim = GetComponent<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
    }







    //this method does too much
    public void NextAction()
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

        ball.ResetBall();
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
