using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGenerator : MonoBehaviour {
  public Texture2D map;

  public ColorToPrefab[] colorMappings;
  // Start is called before the first frame update
  void Start() {
    GenerateLevel();
  }

  private void GenerateLevel() {
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
        Instantiate(colorMapping.prefab, position, Quaternion.identity, this.transform);
      }
    }

  }
}
