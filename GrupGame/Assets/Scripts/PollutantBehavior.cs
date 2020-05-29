using UnityEngine;

public class PollutantBehavior : MonoBehaviour
{
    protected virtual void Float() { }

    [Header("Player Damage")]
    public float pushbackForce = 10f;

    // Position Storage Variables
    protected Vector3 posOffset = new Vector3();
    protected Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Float();
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Deleting");
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();

            var directionFaced = col.contacts[0].normal;
            PushPlayerBack(rb, directionFaced);
        }
    }

    // pushes player back some when it hits a pollutant
    void PushPlayerBack(Rigidbody2D player, Vector2 dir)
    {
        player.AddForce((dir + (Vector2)(transform.up * -1)) * -pushbackForce, ForceMode2D.Impulse);
    }
}
