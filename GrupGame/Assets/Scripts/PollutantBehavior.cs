using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutantBehavior : MonoBehaviour {
  [Header("Float Scale")]
  public float amplitude = 0.5f;
  public float frequency = 1f;

  [Header("Player Damage")]
  public float pushbackForce = 10f;

  

  // Position Storage Variables
  Vector3 posOffset = new Vector3();
  Vector3 tempPos = new Vector3();

  

  // Use this for initialization
  void Start() {
    // Store the starting position & rotation of the object
    posOffset = transform.position;
    // pushbackForce = Mathf.Abs(pushbackForce);
  }

  // Update is called once per frame
  void Update() {
    Float();
    }

  //FLOAT CODE SOURCE:
  //http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
  void Float() {
    // Float up/down with a Sin()
    tempPos = posOffset;
    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

    transform.position = tempPos;
  }

  void OnTriggerStay2D(Collider2D col) {
    if (col.gameObject.tag == "Player") {
      if (Input.GetKeyDown("e")) {
        Debug.Log("Deleting");
        Destroy(gameObject);
      }
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
    Vector2 aaa = new Vector2(-10, -10);
    player.AddForce((dir + (Vector2)(transform.up * -1)) * -pushbackForce, ForceMode2D.Impulse);
  }

  
}
