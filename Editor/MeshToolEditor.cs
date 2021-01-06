using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using MeshTool;


[CustomEditor(typeof(MeshToolCreator))]
public class MeshToolEditor:Editor
{

  public override void OnInspectorGUI()
  {

    MeshToolCreator target = this.target as MeshToolCreator;
    base.OnInspectorGUI();
    if (GUILayout.Button("Button"))
    {
      TriangleObject.From(MeshTool.Triangle.BASIC);


    }
    
  }  
}
