using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 20.0f;

    [HideInInspector]
    public bool canClimb = false;

    Rigidbody2D rb2d;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if (!canClimb)
        {
            yAxis = 0;
        }

        rb2d.MovePosition(rb2d.position + (new Vector2(xAxis, yAxis) * speed) * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddRelativeForce(new Vector2(50, 50), ForceMode2D.Impulse);
        }
    }
}