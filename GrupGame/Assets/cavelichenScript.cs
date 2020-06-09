using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cavelichenScript : MonoBehaviour {

  public float saturationLevel;

  public Material material;
  public Texture2D texture;
  public Color emissionColor;
  [Range(0f, 0.1f)]
  public float twinkle = 0.05f;
  public bool polluted = false;
  // Start is called before the first frame update
  void Start() {
    saturationLevel = 0f;
    material = Instantiate<Material>(material);
    GetComponent<SpriteRenderer>().material = material;
  }

  private void FixedUpdate() {
    polluted = false;
  }

  // Update is called once per frame
  void Update() {
    material.SetTexture("Texture2D_DE84BA06", texture);
    material.SetFloat("Vector1_407DB84D", saturationLevel);
    material.SetColor("Color_B91E747C", emissionColor);
    material.SetFloat("Color_B91E747C", twinkle);

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

  private void OnTriggerStay2D(Collider2D collision) {
    if (collision.gameObject.tag == "PEA") {
      //Debug.Log("Stay!");
      polluted = true;
    }
  }
}
