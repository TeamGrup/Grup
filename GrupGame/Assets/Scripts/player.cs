﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code source referenced:
// https://pressstart.vip/tutorials/2019/10/15/104/character-jumping.html
public class player : MonoBehaviour {
    [Header("Horizontal Movement")]
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingRight = true;

    [Header("Vertical Movement")]
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;
    public bool canClimb = false;
    public float climbModifier = 2.0f;


    [Header("Components")]
    public Rigidbody2D rb;
    public Animator animator;
    public LayerMask groundLayer;
    // public GameObject characterHolder;

    [Header("Physics")]
    public float maxSpeed = 7f;
    public float linearDrag = 4f;
    public float gravity = 1f;
    public float fallMultiplier = 5f;

    [Header("Collision")]
    public bool onGround = false;
    public float groundLength = 0.6f;
    public Vector3 colliderOffset;
    public Vector3 colliderCenter;
    public bool hitSomething = false;

    private Vector3 origin;
    // Temporary, possibly move to trampoline script
    public float trampolineSpeed = 20f;
    public int numberOfJumps = 0;

    // Used to prevent character sticking to wall
    private float originalObjectFriction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GetComponent<SpriteRenderer>().enabled = false;

        Debug.Log($"Spawn Point: {StaticSceneInfo.GetSpawnPoint()}");
        origin = GameObject.FindGameObjectWithTag(StaticSceneInfo.GetSpawnPoint()).transform.position;
        gameObject.transform.position = origin;
    }

    // Update is called once per frame
    void Update() {
        // bool wasOnGround = onGround; ? is this needed?

        DetectJump();

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        animator.SetFloat("horizontal", Mathf.Abs(direction.x));
        animator.SetFloat("vertical", Mathf.Abs(direction.y));
        animator.SetBool("canClimb", canClimb);
        animator.SetBool("onGround", onGround);
        animator.SetFloat("velocity", rb.velocity.y);

        if (onGround)
        {
            numberOfJumps = 0;
            trampolineSpeed = 20f;
        }

    }

    void FixedUpdate() {
        moveCharacter(direction.x, direction.y);

        if(jumpTimer > Time.time && onGround){
            Jump();
        }

        modifyPhysics();
    }

    void DetectJump()
    {
        // These detect if the player is currently on the ground
        bool RightRaycast = Physics2D.Raycast(transform.position + colliderOffset - colliderCenter, Vector2.down, groundLength, groundLayer);
        bool LeftRaycast = Physics2D.Raycast(transform.position - colliderOffset - colliderCenter, Vector2.down, groundLength, groundLayer);

        // If either are on ground, jump is good to go
        onGround = RightRaycast || LeftRaycast;

        // Allows player to input jump button before touchdown, and still jump
        // jumpTimer user in fixedUpdate
        if (Input.GetButtonDown("Jump")){
            jumpTimer = Time.time + jumpDelay;
        }
    }

    void moveCharacter(float horizontal, float vertical) {
        // If the character is not able to climb, then no vertical force will be applied.
        if (!canClimb)
        {
            vertical = 0f;
        }
        rb.AddForce(Vector2.up * vertical * moveSpeed * climbModifier);

        // Controls the players forwared movement
        rb.AddForce(Vector2.right * horizontal * moveSpeed, ForceMode2D.Impulse);

        // When changing direction, flip where player is facing
        if ((horizontal > 0 && !facingRight) || (horizontal < 0 && facingRight)) {
            Flip();
        }

        if (Mathf.Abs(rb.velocity.x) > maxSpeed) {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
    }

    void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }

    void modifyPhysics() {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if((onGround && rb.velocity.y == 0) || canClimb){
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections) {
                rb.drag = linearDrag;
            } else {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else{
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;

            if(rb.velocity.y < 1){
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if(rb.velocity.y > 0 && !Input.GetButton("Jump")){
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }

        }
    }

    void Flip() {
        facingRight = !facingRight;
        transform.rotation = Quaternion.Euler(0, facingRight ? 0 : 180, 0);
        colliderCenter *= -1;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + colliderOffset - colliderCenter, transform.position + colliderOffset - colliderCenter + Vector3.down * groundLength);
        Gizmos.DrawLine(transform.position - colliderOffset - colliderCenter, transform.position - colliderOffset - colliderCenter + Vector3.down * groundLength);
    }

    public void ResetOrigin()
    {
        rb.velocity = new Vector2(0, 0);
        gameObject.transform.position = origin;
    }

    // Added for temporary Trampoline action
    void OnCollisionEnter2D(Collision2D col)
    {
        var objectCollided = col.gameObject;
        var objectTag = objectCollided.tag;

        //if player collides with a trampoline
        if (objectTag == "Trampoline")
        {
            //if (rb.position.x >= -1.2 && rb.position.y >= -2.0) //checks if player if above flower
            //{
                TrampolineJump(trampolineSpeed); //calls jump function
                numberOfJumps++;
                if (numberOfJumps < 5) //player jumps higher the more they bounce
                {
                    trampolineSpeed += 4;
                }
            //}
        }else{
            // originalObjectFriction = objectCollided.GetComponent<Collider2D>().friction;
            // objectCollided.GetComponent<Collider2D>().friction = 0;
            // var originalObjectFriction = gameObject.GetComponent<Collider2D>().friction;
            // gameObject.GetComponent<Collider2D>().friction = 0;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        // var objectCollided = col.gameObject.GetComponent<Collider2D>();

    }

    // Added for temporary Trampoline action
    void TrampolineJump(float charJumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * charJumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
    }
}