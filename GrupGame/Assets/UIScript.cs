using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour {
  public GameObject pollutantCounter;
  TextMeshProUGUI text;
  
  public GameObject pollutants;

  // Start is called before the first frame update
  void Start() {
    text = pollutantCounter.GetComponent<TextMeshProUGUI>();
  }

  // Update is called once per frame
  private void Update() {
    UpdateText();
  }

  void UpdateText() {
    text.text = pollutants.transform.childCount.ToString();
  }
}
