using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUp : MonoBehaviour
{
    public float Up = 3f;
    public float Down = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        {
            transform.position += transform.up * Down;

            // Vector3 lookDownPosition = new Vector3(0,-2,-.3f);
            // desiredPosition = targetToFollow.position + lookDownPosition;
            // smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // transform.position = smoothPosition;
        }

        if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        {
            // Vector3 lookDownPosition = new Vector3(0, 4, -.3f);
            // desiredPosition = targetToFollow.position + lookDownPosition;
            // smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            // transform.position = smoothPosition;
        }
    }
}
