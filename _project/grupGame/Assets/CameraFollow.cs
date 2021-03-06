﻿using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetToFollow;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;



    void FixedUpdate()
    {
        Vector3 desiredPosition = targetToFollow.position + offset;
        Vector3 wallHit = new Vector3(Mathf.Clamp(desiredPosition.x,-3f,3f)
                                        ,Mathf.Clamp(desiredPosition.y,-4f,4f)
                                        ,desiredPosition.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, wallHit, smoothSpeed);
        
        if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            Vector3 lookDownPosition = new Vector3(0,-2,-.3f);
            desiredPosition = targetToFollow.position + lookDownPosition;
            smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }

        if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            Vector3 lookDownPosition = new Vector3(0, 4, -.3f);
            desiredPosition = targetToFollow.position + lookDownPosition;
            smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothPosition;
        }

        transform.position = smoothPosition;
    }
}
