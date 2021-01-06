using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshTool;

namespace MeshTool
{
  [RequireComponent(typeof(MeshRenderer))]
  [RequireComponent(typeof(MeshFilter))]
  public class TriangleObject : MonoBehaviour
  {

    public MeshTool.Triangle triangle;
    // Start is called before the first frame update

    private void Awake()
    {
      this.triangle = MeshTool.Triangle.BASIC;
      this.GetComponent<MeshFilter>().mesh = this.triangle.ToMesh();

    }

    private void OnDrawGizmos()
    {

    }

    public static TriangleObject From(Triangle triangle)
    {
      GameObject o = new GameObject("Triangle");
      TriangleObject result = o.AddComponent<TriangleObject>();
      result.triangle = triangle;
      o.GetComponent<MeshFilter>().mesh = triangle.ToMesh();

      return result;
    }

  }

}
