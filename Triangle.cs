using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshTool
{
  public struct Triangle
  {
    public Vector3 A, B, C;

    public static Triangle From(Vector3 A, Vector3 B, Vector3 C) => new Triangle()
    {
      A = A,
      B = B,
      C = C
    };

    /// <summary>
    /// 天辺をYに置いた三角形を作成
    /// </summary>
    public static Triangle BASIC => new Triangle()
    {

    };
  }

}
