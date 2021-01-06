using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MeshTool
{

  public abstract class Indexes:List<int>
  {

  }


  public class TriangleIndexes : Indexes
  {
    private int offset = 0;

    public List<int> Indexes => new List<int>() {
      offset*3+0,
      offset*3+1,
      offset*3+2
    };



    public static TriangleIndexes operator +(TriangleIndexes A, int offset)
    {
      A.offset += offset;
      return A;
    }

    public static TriangleIndexes operator ++(TriangleIndexes A)
    {
      A.offset++;
      return A;
    }

    public TriangleIndexes(int offset=0)
    {
      this.offset = offset;
    }

  }


}

