using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nature_saturate : MonoBehaviour {
  public float saturationLevel;

  public Material[] materials;
  public Texture2D[] texutres;

  public List<GameObject> flowers;
  public List<GameObject> leaves;

  List<GameObject> childObjects;
  //int childCount = 0;

  public bool polluted = false;
  // Start is called before the first frame update
  void Start() {
    saturationLevel = 0f;
    //leaves
    materials[0] = Instantiate<Material>(materials[0]);
    leaves = Initialize("Leaves", flowers, 0);
    //flowers
    materials[1] = Instantiate<Material>(materials[1]);
    flowers = Initialize("Flowers", flowers, 1);


  }

  private void FixedUpdate() {
    polluted = false;
  }

  // Update is called once per frame
  void Update() {
    materials[0].SetTexture("Texture2D_639B53C6", texutres[0]);
    materials[0].SetFloat("Vector1_B4184947", saturationLevel);
    materials[1].SetTexture("Texture2D_639B53C6", texutres[1]);
    materials[1].SetFloat("Vector1_B4184947", saturationLevel);

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

  List<GameObject> Initialize(string strParent, List<GameObject> list, int listIndex) {
    Transform parent = transform.Find(strParent);
    list = new List<GameObject>();

    foreach (Transform child in parent) {
      list.Add(child.gameObject);
      child.GetComponent<SpriteRenderer>().material = materials[listIndex];
    }

    return list;
  }



  private void OnTriggerStay2D(Collider2D collision) {
    if (collision.gameObject.tag == "PEA") {
      Debug.Log("Stay!");
      polluted = true;
    }
  }
}
