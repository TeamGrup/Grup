using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetToFollow;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float direction = 1;

    public float xClamp = -3f;
    public float yClamp = -4f;



    void FixedUpdate()
    {

        // if(direction != targetToFollow.transform.right.x)
        // {
        //     direction = targetToFollow.transform.right.x;
        // }
        // offset *= direction;

        Vector3 desiredPosition = targetToFollow.position + offset;

        Vector3 wallHit = new Vector3(Mathf.Clamp(desiredPosition.x,-3,xClamp)
                                        ,Mathf.Clamp(desiredPosition.y,-4,yClamp)
                                        ,desiredPosition.z);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, wallHit, smoothSpeed); // ?need to fix clamping
        
        // if(Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") == 0)
        // {
        //     Vector3 lookDownPosition = new Vector3(0,-2,-.3f);
        //     desiredPosition = targetToFollow.position + lookDownPosition;
        //     smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //     transform.position = smoothPosition;
        // }

        // if(Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") == 0)
        // {
        //     Vector3 lookDownPosition = new Vector3(0, 4, -.3f);
        //     desiredPosition = targetToFollow.position + lookDownPosition;
        //     smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //     transform.position = smoothPosition;
        // }

        transform.position = smoothPosition;
    }
}
