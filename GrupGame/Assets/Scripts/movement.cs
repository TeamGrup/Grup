//includes the movement player requires to use trampoline plant

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 charMove;
    private Rigidbody2D rb;
    public float jumpSpeed = 15f;
    public float trampolineSpeed = 20f;
    public int numberOfJumps = 0; //keeps track of how many times player jumped on trampoline

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        charMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Jump"))
        {
            Jump(jumpSpeed);
        }
    }

    void FixedUpdate()
    {
        moveCharacter(charMove.x);
    }

    //moves character left or right
    void moveCharacter(float direction)
    {
        rb.AddForce(Vector2.right * direction * speed);
    }

    //character jumps
    void Jump(float charJumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * charJumpSpeed, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //if player collides with a trampoline
        if (col.gameObject.tag == "Trampoline")
        {
            if(rb.position.x >= -1.2 && rb.position.y >= -2.0) //checks if player if above flower
            {
                Jump(trampolineSpeed); //calls jump function
                numberOfJumps++;
                if (numberOfJumps < 5) //player jumps higher the more they bounce
                {
                    trampolineSpeed += 1;
                }
            }
        }
    }
}
