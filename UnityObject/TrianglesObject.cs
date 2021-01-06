using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshTool;

namespace MeshTool
{
  [RequireComponent(typeof(MeshRenderer))]
  [RequireComponent(typeof(MeshFilter))]
  public class TrianglesObject : MonoBehaviour
  {

    public MeshTool.Triangles triangles = new Triangles();
    // Start is called before the first frame update


    private void OnDrawGizmos()
    {


    }

    public static TrianglesObject From(Triangles triangles)
    {
      GameObject o = new GameObject("Triangles");
      TrianglesObject result= o.AddComponent<TrianglesObject>();
      result.triangles = triangles;
      o.GetComponent<MeshFilter>().mesh = triangles.ToMesh();
      return result;
    }

  }
}
