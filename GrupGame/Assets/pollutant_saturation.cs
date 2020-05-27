using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pollutant_saturation : MonoBehaviour {

  public Collider[] hitColliders;

  [Range(1f, 10f)]
  public float pollutionEffectRadius = 5f;

  private void Start() {
    transform.GetChild(0).GetComponent<CircleCollider2D>().radius = pollutionEffectRadius;
  }

  private void OnTriggerEnter2D(Collider2D collision) {
    
  }
}
