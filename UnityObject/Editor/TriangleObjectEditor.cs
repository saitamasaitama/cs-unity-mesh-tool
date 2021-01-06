using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MeshTool;

[CustomEditor(typeof(TriangleObject))]
public class TriangleObjectEditor:Editor
{

  public override void OnInspectorGUI()
  {

    TriangleObject target = this.target as TriangleObject;
    base.OnInspectorGUI();
    if (GUILayout.Button("Divide"))
    {
      Triangles tris = target.triangle.Divide();
      Debug.Log($"TRIS={tris.Count}");
      TrianglesObject.From(tris);      
    }
    
  }  
}
