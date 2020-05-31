using UnityEngine;

public class CameraFollowLevelGenerator : MonoBehaviour {
  public GameObject targetToFollow;

  public float smoothSpeed = 0.125f;
  public Vector3 offset;

  public float direction = 1;

  public float xClamp = -3f;
  public float yClamp = -4f;

  public float Up = 3f;
  public float Down = 3f;
  private Vector3 smoothLookPos;


  private void Start() {
    targetToFollow = GameObject.Find("mainCharacter");
  }

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

    Vector3 wallHit = new Vector3(Mathf.Clamp(desiredPosition.x, -3, xClamp)
                                    , Mathf.Clamp(desiredPosition.y, -4, yClamp)
                                    , desiredPosition.z);

    Vector3 smoothPosition = Vector3.Lerp(transform.position, wallHit, smoothSpeed);

    transform.position = smoothPosition;
  }

  void LookUpAndDown() {
    if (Input.GetAxis("Vertical") < -.4) {
      Vector3 newPosition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + -Mathf.Abs(Down), -4, yClamp), 0); // ? dont declare new variable here
      smoothLookPos = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
      transform.position = smoothLookPos;
    }

    if (Input.GetAxis("Vertical") > .4) {
      Vector3 newPosition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y + Mathf.Abs(Up), -4, yClamp), 0);
      smoothLookPos = Vector3.Lerp(transform.position, newPosition, smoothSpeed);
      transform.position = smoothLookPos;
    }
  }
}
