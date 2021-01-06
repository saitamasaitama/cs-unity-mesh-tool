using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace MeshTool
{
  [CustomEditor(typeof(TrianglesObject))]
  public class TrianglesObjectEditor : Editor
  {
    public override void OnInspectorGUI()
    {

      TrianglesObject target = this.target as TrianglesObject;
      base.OnInspectorGUI();
      if (GUILayout.Button("More Divide"))
      {
        TrianglesObject.From(target.triangles.Divide());
      }

    }
  }

}

