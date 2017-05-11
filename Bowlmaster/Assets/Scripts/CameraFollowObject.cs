using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour
{
    public GameObject objectToFollow;
    private Vector3 viewOffset;
    private float cutoffPoint = 1800f; // before pin 1 in bowling game
    void Start()
    {
        viewOffset = new Vector3(0, -30, 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow.transform.position.z < cutoffPoint)
        {
            transform.position = objectToFollow.transform.position - viewOffset;
        }
    }
}
