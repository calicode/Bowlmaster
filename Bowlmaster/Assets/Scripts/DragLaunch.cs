using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour
{

    private EventSystem eventSys;
    private Vector3 dragPositionStart, dragPositionEnd;
    private float dragEndTime, dragStartTime;
    private Ball ball;
    private float nudgeAmount = 5f;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<Ball>();
        eventSys = EventSystem.current;
    }


    public void MoveStart(int nudgeSignFromUIButton)
    {
        float xNudge = nudgeAmount * nudgeSignFromUIButton;
        if (!ball.rolled)
        {
            float newX = Mathf.Clamp(transform.position.x + xNudge, -52f, +52f);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }

    }

    public void DragStart()
    {
        dragPositionStart = Input.mousePosition;
        dragStartTime = Time.time;
        // capture time & position of drag start
        Debug.Log("Drag start position is" + dragPositionStart.ToString());
        Debug.Log("Drag start time is" + dragStartTime.ToString());
    }

    public void DragEnd()
    {
        Vector3 launchVector;
        dragEndTime = Time.time;
        float dragDeltaTime = dragEndTime - dragStartTime;

        dragPositionEnd = Input.mousePosition;
        //        dragPositionDelta = dragPositionEnd - dragPositionStart;
        /* 
                Debug.Log("Drag end position is" + dragPositionEnd.ToString());
                Debug.Log("Drag end time is" + dragEndTime.ToString());
                Debug.Log("Drag delta position is" + dragPositionDelta.ToString());
                Debug.Log("Drag delta time is" + dragDeltaTime.ToString());
        */


        // launch the ball

        launchVector.z = (dragPositionEnd.y - dragPositionStart.y) / dragDeltaTime;

        launchVector.x = (dragPositionEnd.x - dragPositionStart.x) / dragDeltaTime;
        launchVector.y = 0;
        Debug.Log("Launch vector is" + launchVector.ToString());
        ball.RollMe(launchVector);
    }


}
