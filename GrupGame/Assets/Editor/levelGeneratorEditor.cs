using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(levelGenerator))]
public class levelGeneratorEditor : Editor
{
  public override void OnInspectorGUI() {
    DrawDefaultInspector();

    levelGenerator myScript = (levelGenerator)target;
    if (GUILayout.Button("Generate Level")) {
      myScript.GenerateLevel();
    }
    
  }
}
