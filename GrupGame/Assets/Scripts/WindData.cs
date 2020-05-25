using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Wind Data")]
public class WindData : ScriptableObject {
  public Vector2 Movement;
  [Range(0f, 5f)]
  public float windStrength = 1f;
  [Range(0f, 1.0f)]
  public float windDensity = 0.25f;
}
