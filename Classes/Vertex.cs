using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MeshTool
{
  public struct Vertex
  {
    public Vector3 point3d;
    public int index;


    /*
    public Vertex From(Vector3 v)
    {

    }

    public Vertex From(int f)\\
    */

    private static int sequense = 0;
    public static int Sequense => sequense;

  }
}

