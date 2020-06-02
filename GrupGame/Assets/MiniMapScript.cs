using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniMapScript : MonoBehaviour {
  public GameObject levelParent;
  public GameObject[] levels;
  List<Image> spriteRenderers;

  public float frequency = 2f;
  // Start is called before the first frame update
  void Start() {
    InitializeLevels();
  }

  // Update is called once per frame
  void Update() {
    AnimateLevels();
  }

  void InitializeLevels() {
    
    spriteRenderers = new List<Image>();
    for (int child = 0; child < levels.Length; child++) {
      spriteRenderers.Add(levels[child].GetComponent<Image>());
    }
  }

  void AnimateLevels() {
    foreach (Image child in spriteRenderers) {
      Color color = child.color;
      color.a = Mathf.Clamp(Mathf.Sin(Time.time * frequency), 0.2f, 1.0f);
      child.color = color;
    }
  }
}
