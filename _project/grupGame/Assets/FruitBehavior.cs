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

    public float CharacterFace;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        IsHeld = true;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
        
        col = gameObject.GetComponent<BoxCollider2D>();
        col.enabled = false;


        player = GameObject.Find("playerCub");
        CharacterFace = player.transform.right.x;

    }

    // Update is called once per frame
    void Update()
    {   
        if(!IsHeld)
        {
            timer += Time.deltaTime;

            // 5 / scale
            //  (timer / 5) / scale



            Vector3 scale = transform.localScale;
            Debug.Log((timer/5)/scale.x);

            // scale.x = scale.x/timer;
            // scale.y = scale.y/timer;
            // transform.localScale = scale;

            if(timer >= 5)
            {
                Debug.Log("5 seconds");
                player.GetComponent<FruitPick>().ObjectInWorld = null;
                Destroy(gameObject);
            }
        }
    }

    void FixedUpdate()
    {
        if(IsHeld)
        {   
            SetPosition();
        }
    }

    void SetPosition()
    {
        var playerFacing = player.transform.right;
        var playerPosition = player.transform.position;
        transform.right = playerFacing;

            if(CharacterFace != player.transform.right.x)
            {
                CharacterFace = player.transform.right.x;
                position = position * -1;
            }

        transform.position = playerPosition + position;
    }
}
