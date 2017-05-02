using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(RollOnMouseClick))]
public class DragLaunch : MonoBehaviour
{

    private Vector3 dragPositionStart, dragPositionEnd;
    private float dragEndTime, dragStartTime;
    private RollOnMouseClick ball;
    // Use this for initialization
    void Start()
    {
        ball = GetComponent<RollOnMouseClick>();
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
