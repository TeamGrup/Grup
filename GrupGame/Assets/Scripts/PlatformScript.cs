using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {
  [Header("Movement")]
  public float amplitude = 0.25f;
  public float frequency = 0.5f;


  protected Vector3 tempPos = new Vector3();

  Vector3 position;
  // Start is called before the first frame update
  void Start() {
    amplitude = 0.25f;
    frequency = 0.5f;
    position = transform.position;
  }

  // Update is called once per frame
  void Update() {
    Float();
  }

  void Float() {
    // Float up/down with a Sin()
    tempPos = position;
    tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

    transform.position = tempPos;
  }
}
