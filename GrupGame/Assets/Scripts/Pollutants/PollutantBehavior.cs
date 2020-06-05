using UnityEngine;

public class PollutantBehavior : MonoBehaviour {
  protected virtual void Float() { }
  [Header("Magic Prefabs")]
  public GameObject greenOrb; //green gets rid of ground pollutants
  public GameObject blueOrb; // blue gets rid of water pollutants
  public GameObject purpleOrb; // purple gets rid of air pollutants

  [Header("Player Damage")]
  public float pushbackForce = 10f;

  // Position Storage Variables
  protected Vector3 posOffset = new Vector3();
  protected Vector3 tempPos = new Vector3();

  public GameObject Emitter;
  GameObject EmitterClone;
  bool ORisActive = false;
  //ParticleSystem orbPS;

  public bool PSisactive = false;
  void Start() {
    purpleOrb = GameObject.Find("purple orb");
    blueOrb = GameObject.Find("blue orb");
    greenOrb = GameObject.Find("green orb");

    // Store the starting position & rotation of the object
    posOffset = transform.position;

    //PS starts off

  }

  // Update is called once per frame
  void Update() {
    Float();
  }

  void OnTriggerStay2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      if (Input.GetKeyDown("e")) {
        if (this.gameObject.name == "AirPollutant") {
          //Debug.Log("helloooo i am air");
          createMagicOrb(purpleOrb, col);
        }
        if (this.gameObject.name == "WaterPollutant") {
          //Debug.Log("helloooo i am water");
          createMagicOrb(blueOrb, col);
        }
        if (this.gameObject.name == "ground_pollutant") {
          //Debug.Log("helloooo i am ground");
          createMagicOrb(greenOrb, col);
        }
        Destroy(gameObject);
      }
    }
  }

  void PlayEffect() {
    if (!ORisActive) {
      EmitterClone = Instantiate(Emitter, transform.position, Quaternion.identity);
      ORisActive = true;
    }
  }

  void DestroyEffect() {
    Destroy(EmitterClone);
    ORisActive = false;
  }



  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.tag == "Player") {
      PlayEffect();
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.tag == "Player") {
      DestroyEffect();
    }
  }


  void OnCollisionEnter2D(Collision2D col) {
    if (col.gameObject.tag == "Player") {
      Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
      var directionFaced = col.contacts[0].normal;
      PushPlayerBack(rb, directionFaced);

    }
  }

  // pushes player back some when it hits a pollutant
  void PushPlayerBack(Rigidbody2D player, Vector2 dir) {
    player.AddForce((dir + (Vector2)(transform.up * -1)) * -pushbackForce, ForceMode2D.Impulse);
  }

  void createMagicOrb(GameObject orb, Collider2D col) {
    Vector3 one = new Vector3(1, 0, 0);
    Vector3 two = new Vector3(1, 1, 0);
    Vector3 three = new Vector3(0, 1, 0);
    //Vector3 four = new Vector3(-1, 1, 0);
    //Vector3 five = new Vector3(-1, 0, 0);

    GameObject proj1 = Instantiate(orb, col.transform.position + one, col.transform.rotation);
    GameObject proj2 = Instantiate(orb, col.transform.position + two, col.transform.rotation);
    GameObject proj3 = Instantiate(orb, col.transform.position + three, col.transform.rotation);
    //GameObject proj4 = Instantiate(orb, col.transform.position + four, col.transform.rotation);
    //GameObject proj5 = Instantiate(orb, col.transform.position + five, col.transform.rotation);

    Destroy(proj1, 1);
    Destroy(proj2, 1);
    Destroy(proj3, 1);
    //Destroy(proj4, 2);
    //Destroy(proj5, 2);
  }
}
