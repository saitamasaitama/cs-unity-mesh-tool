using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshTool
{
  public struct Edge
  {
    public Vector3 A, B;

    public static Edge From(Vector3 A, Vector3 B) => new Edge()
    {
      A=A,
      B=B
    };

    public Vector3 Center => Vector3.Lerp(A, B, 0.5f);

    
  }

}

