using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour
{
    GameManager gameManager;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name.Contains("Ball"))
        {

            gameManager.BallHasLeftBox(true);

        }

    }


    // Update is called once per frame
    void Update()
    {

    }
}
