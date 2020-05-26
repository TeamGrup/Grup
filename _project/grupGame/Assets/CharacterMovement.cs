using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Horizontal Movement")]
    public float speed = 10.0f;
    public Vector2 movement;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;

    [Header("Components")]
    public Rigidbody2D rb;
    public LayerMask groundLayer;
    
    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.Raycast(transform.position, Vector2.down, groundLength, groundLayer);
        
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        // if(Input.GetAxis("Horizontal") > 0 )
        //     movement = new Vector2(Input.GetAxis("Horizontal"), 0);

        if(Input.GetButtonDown("Jump") && onGround)
        {
            Jump();
        }

    }

    void FixedUpdate()
    {
        moveCharacter(movement.x);
    }

    void moveCharacter(float direction)
    {
        rb.AddForce(Vector2.right * direction * speed);
        Debug.Log(Vector2.right * direction * speed);
        // rb.MovePosition((Vector2)transform.position + (direction * speed * Time.deltaTime));
        // rb.AddForce(direction*10);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        Debug.Log(Vector2.up * jumpSpeed);
        Debug.Log(rb.velocity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down*groundLength);
    }
}
