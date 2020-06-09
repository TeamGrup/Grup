using UnityEngine;

public class CameraFollow : MonoBehaviour {
  public GameObject targetToFollow;

  public float smoothSpeed = 0.125f;
  public Vector3 offset;

  public float direction = 1;

  public float xClampMax = 10f;
  public float yClampMax = 10f;

  public float xClampMin = -4f;
  public float yClampMin = -4f;

  public float Up = 3f;
  public float Down = 3f;
  private Vector3 smoothLookPos;

  /* this is for the level generatr -- scott
  private void Start() {
    targetToFollow = GameObject.Find("mainCharacter");
  }
  */
  void FixedUpdate() {
    CameraMove();
    if (Input.GetAxis("Horizontal") == 0) {
      player playerChar = targetToFollow.GetComponent<player>(); // ? optomize this to be set in start
      if (!playerChar.canClimb && playerChar.onGround)
        LookUpAndDown();
    }
  }

  void CameraMove() {

    Vector3 desiredPosition = targetToFollow.transform.position + offset;

    //Vector3 wallHit = new Vector3(Mathf.Clamp(desiredPosition.x, xClampMin, xClampMax)
    //                                , Mathf.Clamp(desiredPosition.y, yClampMin, yClampMax)
    //                                , desiredPosition.z);
    Vector3 wallHit = new Vector3(Mathf.Clamp(desiredPosition.x, xClampMin, xClampMax)
                                    , Mathf.Clamp(desiredPosition.y, yClampMin, yClampMax)
                                    , -1);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, wallHit, smoothSpeed);

    transform.position = smoothPosition;
  }

  void LookUpAndDown() {
    if (Input.GetAxis("Vertical") < -.4) {
      Vector3 newPosition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + -Mathf.Abs(Down), yClampMin, yClampMax), -1); // ? dont declare new variable here
      smoothLookPos = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
      transform.position = smoothLookPos;
    }

    if (Input.GetAxis("Vertical") > .4) {
      Vector3 newPosition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Mathf.Abs(Up), yClampMin, yClampMax), -1);
      smoothLookPos = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
      transform.position = smoothLookPos;
    }
  }
}
