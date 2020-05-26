using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 destroy particle systems: https://answers.unity.com/questions/219609/auto-destroying-particle-system.html
 https://docs.unity3d.com/ScriptReference/RequireComponent.html
 
   */

[RequireComponent(typeof(BoxCollider2D))]
public class VineGrow : MonoBehaviour {
  BoxCollider2D bc2D;
  bool growable = false;
  bool grown = false;

  // inspector values
  [Header("Growth Values")]
  public AnimationCurve growCurve = new AnimationCurve();
  [Header("(in seconds)")]
  [Range(0.1f, 3.0f)]
  public float growSpeed = 0.5f;

  [Header("Particle System")]
  public bool useParticleSystem = true;
  public ParticleSystem growParticleSystem = null;

  List<GameObject> growParts;
  int vineSize;
  GameObject[] leaves;
  

  private void Start() {
    bc2D = GetComponent<BoxCollider2D>();
    bc2D.enabled = true;
    growParts = new List<GameObject>();
    initailizeGrowObject();
  }

  private void Update() {
    if (Input.GetKeyDown(KeyCode.E)) {
      if (growable && !grown) {
        Debug.Log("Growing Vine");
        StartCoroutine(Curve(0));
        grown = true;
      }
    }
  }

  void initailizeGrowObject() {
    foreach (Transform child in transform) {
      child.gameObject.SetActive(false);
      growParts.Add(child.gameObject);
    }
    vineSize = growParts.Count;
  }

  IEnumerator Curve(int vineIndex) {
    if (vineIndex >= vineSize) {
      Debug.Log("End of Vines");
      yield break;
    }

    Debug.Log("Vine " + vineIndex);
    GameObject vine = growParts[vineIndex];
    StartCoroutine(Grow(vine));

    float totalGrowth = growCurve.Evaluate((float)(vineIndex + 1) / growParts.Count);
    Debug.Log("Growth % " + totalGrowth);
    //yield return new WaitForSeconds(growSpeed * totalGrowth);
    yield return new WaitForSeconds((1 - totalGrowth) * growSpeed);

    StartCoroutine(Curve(vineIndex + 1));
  }


  IEnumerator Grow(GameObject obj) {
    Vector3 finalScale = obj.transform.localScale;
    Vector2 initialScale = new Vector2(0f, 0f);
    obj.transform.localScale = initialScale;
    bool playParticleSystem = false;

    /*
    if (growParticleSystem != null && useParticleSystem) {
      ParticleSystem particleSystemCopy = Instantiate(growParticleSystem, obj.transform.position, Quaternion.identity);
      particleSystemCopy.Play();

    }*/
    obj.SetActive(true);

    float scale = 0.01f;
    while (scale <= 1.0f) {

      scale += 0.05f;
      yield return new WaitForSeconds(0.05f);
      obj.transform.localScale = Vector2.Lerp(initialScale, finalScale, growCurve.Evaluate(scale));
      if (scale > 0.5f && !playParticleSystem) {
        if (growParticleSystem != null && useParticleSystem) {
          ParticleSystem particleSystemCopy = Instantiate(growParticleSystem, obj.transform.position, Quaternion.identity);
          particleSystemCopy.Play();
          playParticleSystem = true;
        }
      }
    }
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    if (collision.gameObject.tag == "Player") {
      Debug.Log("Plant is now growable.");
      growable = true;
    }
  }

  private void OnTriggerExit2D(Collider2D collision) {
    if (collision.gameObject.tag == "Player") {
      Debug.Log("Plant is not growable anymore.");
      growable = false;
    }
  }
}
