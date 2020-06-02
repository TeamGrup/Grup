using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {
  public Texture2D map;

  Dictionary<Color, List<GameObject>> prefabsInScene;
  Dictionary<string, GameObject> parents;
  public List<GameObject> allPrefabs;
  public ColorToPrefab[] colorMappings;
  // Start is called before the first frame update
  bool player = false;

  void InitializeLists() {
    parents = new Dictionary<string, GameObject>();
    prefabsInScene = new Dictionary<Color, List<GameObject>>();
    foreach (ColorToPrefab element in colorMappings) {
      List<GameObject> prefabs = new List<GameObject>();
      prefabsInScene.Add(element.color, prefabs);
      GameObject prefabParent = new GameObject(element.prefabName);
      prefabParent.transform.parent = this.transform;
      parents.Add(element.prefabName, prefabParent);

      allPrefabs = new List<GameObject>();
    }
  }

  public void GenerateLevel() {
    bool player = false;
    InitializeLists();
    for (int x = 0; x < map.width; x++) {
      for (int y = 0; y < map.height; y++) {
        GenerateTile(x, y);
      }
    }
  }

  private void GenerateTile(int x, int y) {
    Color pixelColor = map.GetPixel(x, y);

    //is transparent?
    if (pixelColor.a == 0) {
      return;
    }

    foreach (ColorToPrefab colorMapping in colorMappings) {

      Vector2 position = new Vector2(x, y);
      if (colorMapping.color.Equals(pixelColor)) {
        //spawned a player?
        if (colorMapping.color.Equals(Color.blue) && player) {
          continue;
        }

        if (colorMapping.color.Equals(Color.blue)) {
          player = true;
        }

        // instantiate object based on player
        Instantiate(colorMapping.prefab, position, Quaternion.identity, parents[colorMapping.prefabName].transform);
        prefabsInScene[pixelColor].Add(colorMapping.prefab);
        allPrefabs.Add(colorMapping.prefab);

      }
    }

  }

}
