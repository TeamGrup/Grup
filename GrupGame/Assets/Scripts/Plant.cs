using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Resources: 
 * https://www.youtube.com/watch?v=IQ7qnMv01Vs
   */

public class Plant : MonoBehaviour {
  public WindData windData;

  [Header("Colors")]
  public Color alive;
  public Color dead;

  public Material material;
  public float saturationLevel;

  [Header("(in seconds)")]
  [Range(1f, 5f)]
  public float saturationSpeed = 1f;

  List<GameObject> childLeaves;
  Vector3 growthScale;
  float scaleFactor;

  int gatherIndex = 3;
  int childCount;

  public bool polluted = false;
  Transform pollutant = null;

  void Start() {
    scaleFactor = transform.localScale.x;
    growthScale = new Vector3(1f, 0.3f, 1f);


    // set local scale
    transform.localScale = growthScale * scaleFactor;

    saturationLevel = 0f;
    material = Instantiate<Material>(material);
    


    childLeaves = new List<GameObject>();
    foreach (Transform child in transform) {
      childLeaves.Add(child.gameObject);
      child.GetComponent<MeshRenderer>().material = material;
    }

    childCount = childLeaves.Count;
  }

  // Update is called once per frame
  void Update() {
    if (Input.GetKeyDown(KeyCode.S)) {
      StartCoroutine(Saturate());
      StartCoroutine(Grow());
    }
    if (Input.GetKeyDown(KeyCode.E)) {
      if (gatherIndex < childCount) {
        childLeaves[gatherIndex].SetActive(false);
        gatherIndex++;
      }
    }
    material.SetFloat("Vector1_F75E29FD", saturationLevel);
    material.SetColor("Color_455FDAC4", alive);
    material.SetColor("Color_6B591CB1", dead);
    material.SetFloat("Vector1_FB1FF921", windData.windStrength);
    material.SetFloat("Vector1_31FA20E7", windData.windDensity);
    material.SetVector("Vector2_1E5C768D", windData.Movement);

  }

  private void FixedUpdate() {
    
  }


  private void OnTriggerEnter(Collider other) {
      Debug.Log("Collide!");


    if (other.gameObject.tag == "Pollutant") {
      Debug.Log("Polluted!");
      pollutant = other.transform;
      polluted = true;
    }
  }

  IEnumerator Saturate() {
    float step = 100f;

    while (saturationLevel <= 1.0f) {
      yield return new WaitForSeconds(saturationSpeed / step);
      saturationLevel += (saturationSpeed / step);
      material.SetFloat("Vector1_F75E29FD", saturationLevel);

    }
  }

  IEnumerator Grow() {
    float step = 100f;
    while (growthScale.y <= 1.0f) {
      yield return new WaitForSeconds(saturationSpeed / step);
      growthScale.y += (saturationSpeed / step);
      transform.localScale = growthScale * scaleFactor;

    }

  }
}
