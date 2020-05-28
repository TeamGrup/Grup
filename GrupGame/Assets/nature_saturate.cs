using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nature_saturate : MonoBehaviour {
  public Material material;
  public float saturationLevel;
  public Texture2D _MainTex;

  List<GameObject> childObjects;
  int childCount = 0;

  public bool polluted = false;
  [Range(1.0f, 10f)]
  public float effectedRadius = 10f;
  public Collider[] pollutedColliders;

  // Start is called before the first frame update
  void Start() {
    saturationLevel = 0f;
    material = Instantiate<Material>(material);
    Initialize();
  }

  private void FixedUpdate() {
    polluted = false;
  }

  // Update is called once per frame
  void Update() {
    material.SetTexture("Texture2D_639B53C6", _MainTex);
    material.SetFloat("Vector1_B4184947", saturationLevel);


    if (polluted) {
      if (saturationLevel >= 0f) {
        saturationLevel -= 0.01f;
      }
    } else {
      if (saturationLevel <= 1.0f) {
        saturationLevel += 0.01f;

      }
    }
  }


  public void Polluted(bool isPolluted) {
    polluted = isPolluted;
  }

  void Initialize() {
    childObjects = new List<GameObject>();
    foreach (Transform child in transform) {
      childObjects.Add(child.gameObject);
      child.GetComponent<SpriteRenderer>().material = material;
    }

    childCount = childObjects.Count;
  }

  /*
  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "PEA") {
      Debug.Log("Polluted!");
      polluted = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.tag == "PEA") {
      Debug.Log("Clean!");
      polluted = false;
    }
  }
  */

  private void OnTriggerStay2D(Collider2D collision) {
    if (collision.gameObject.tag == "PEA") {
      Debug.Log("Stay!");
      polluted = true;
    }
  }
}
