using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(VineGrow))]
public class VineGrowEditor : Editor {
 public override void OnInspectorGUI() {
    //DrawDefaultInspector();
    VineGrow myScript = (VineGrow)target;

    // growth curve
    myScript.growCurve = EditorGUILayout.CurveField("Growth Curve", myScript.growCurve);

    // growth speed
    myScript.growSpeed = EditorGUILayout.Slider("Growth Speed", myScript.growSpeed, 0.1f, 1.0f);

    // axis scales
    myScript.constantAxis = GUILayout.Toggle(myScript.constantAxis, "Use Constant Axis");
    if (!myScript.constantAxis) {

      myScript.axisScale = EditorGUILayout.Vector3Field("Axis Scales", myScript.axisScale);
    }
  }
}