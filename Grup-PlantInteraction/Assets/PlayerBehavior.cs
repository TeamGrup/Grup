using System;
using UnityEditor;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;
    public bool canClimb = false;
    public float climbModifier = 2.0f;

    [Header("Horizontal Movement")]
    public float speed = 10.0f;
    public Vector2 direction;

    [Header("Components")]
    public Rigidbody2D rb2d;
    public LayerMask groundLayer;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;

    private void Update()
    {
        onGround = Physics2D.Raycast(transform.position + colliderOffset, Vector2.down, groundLength, groundLayer) ||
                   Physics2D.Raycast(transform.position - colliderOffset, Vector2.down, groundLength, groundLayer);

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }

        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        MoveCharacter(direction.x, direction.y);
        
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        ModifyPhysics();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawLine(transform.position+ colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
    }

    private void Jump()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }

    private void MoveCharacter(float horizontal, float vertical)
    {
        if (!canClimb)
        {
            vertical = 0f;
        }

        rb2d.AddForce(Vector2.up * vertical * speed * climbModifier);
        rb2d.AddForce(Vector2.right * horizontal * speed);

        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }
    }

    private void ModifyPhysics()
    {
        bool changeDirection = (direction.x > 0 && rb2d.velocity.x < 0) || (direction.x < 0 && rb2d.velocity.x > 0);

        if (onGround || canClimb)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changeDirection)
            {
                rb2d.drag = linearDrag;
            }
            else
            {
                rb2d.drag = 0;
            }

            rb2d.gravityScale = 0f;
        }
        else
        {
            rb2d.gravityScale = gravity;
            rb2d.drag = linearDrag * 0.15f;

            if (rb2d.velocity.y < 0)
            {
                rb2d.gravityScale = gravity * fallMultiplier;
            }
            else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb2d.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
}