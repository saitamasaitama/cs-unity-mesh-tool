using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshTool
{
  public struct Triangle:MeshableInterface
  {
    public Vector3 A, B, C;

    public static Triangle From(Vector3 A, Vector3 B, Vector3 C) => new Triangle()
    {
      A = A,
      B = B,
      C = C
    };

    public Mesh ToMesh()
    {

      throw new System.NotImplementedException();
    }

    /// <summary>
    /// 天辺をYに置いた三角形を作成
    /// </summary>
    public static Triangle BASIC => new Triangle()
    {
      A=Vector3.up * 2 / 3,
      B =Quaternion.Euler(0,0,120)*(Vector3.up * 2 / 3),
      C = Quaternion.Euler(0, 0, 240) * (Vector3.up * 2 / 3),
    };


  }



}
