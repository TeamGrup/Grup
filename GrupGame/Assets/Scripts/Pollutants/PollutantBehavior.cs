using UnityEngine;

public class PollutantBehavior : MonoBehaviour
{
    protected virtual void Float() { }

    [Header("Player Damage")]
    public float pushbackForce = 10f;

    // Position Storage Variables
    protected Vector3 posOffset = new Vector3();
    protected Vector3 tempPos = new Vector3();

    public GameObject Emitter;
    GameObject EmitterClone;
    bool ORisActive = false;

    public bool PSisactive = false;
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
                DestroyEffect();
                Destroy(gameObject);
            }
        }
    }

    void PlayEffect()
    {
        if (!ORisActive)
        {
            EmitterClone = Instantiate(Emitter, transform.position, Quaternion.identity);
            ORisActive = true;
        }
    }

    void DestroyEffect()
    {
        Destroy(EmitterClone);
        ORisActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayEffect();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            DestroyEffect();
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
