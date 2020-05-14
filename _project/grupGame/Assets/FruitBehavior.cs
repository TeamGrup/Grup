using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitBehavior : MonoBehaviour
{
    public bool IsHeld;

    public Rigidbody2D rb;
    public BoxCollider2D col;

    public GameObject player;

    public Vector3 position = new Vector3(1.3f,0,0);

    // Start is called before the first frame update
    void Start()
    {
        IsHeld = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;


        player = GameObject.Find("playerCub");

    }

    // Update is called once per frame
    void Update()
    {       
        var playerFacing = player.transform.right;
        var playerPosition = player.transform.position;
        transform.right = playerFacing;


        transform.position = playerPosition + position;
    }
}
