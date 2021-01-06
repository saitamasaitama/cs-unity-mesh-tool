using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MeshTool
{
  public struct Triangle : MeshableInterface
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
      Mesh result = new Mesh();

      result.SetVertices(new List<Vector3>() { A, B, C });
      result.SetTriangles(new int[] { 0, 1, 2 }, 0);

      return result;
    }

    public List<Vector3> Vertices =>new List<Vector3>(){
      A,
      B,
      C
    };

    public TriangleIndexes IndexesOrder => new TriangleIndexes();


    /// <summary>
    /// 天辺をYに置いた三角形を作成
    /// </summary>
    public static Triangle BASIC => new Triangle()
    {
      A = Vector3.up * 2 / 3,
      B = Quaternion.Euler(0, 0, 120) * (Vector3.up * 2 / 3),
      C = Quaternion.Euler(0, 0, 240) * (Vector3.up * 2 / 3),
    };

    public List<Edge> ToEdges() => new List<Edge>()
    {
      Edge.From(A,B),
      Edge.From(A,C),
      Edge.From(B,C)
    };

    public Triangles Divide(){
      /* 三角形を分割する
       * 頂点を追加
       * AB AC BC 
       * 
        ABC => 
          A AB AC
          B AB BC
          C AC BC
          AB AC BC      
      の四つに分割
      */
      
      var AB = Edge.From(A, B).Center;
      var AC = Edge.From(A, C).Center;
      var BC = Edge.From(B, C).Center;

      var result = new Triangles() { 
        Triangle.From(A,AB,AC),
        Triangle.From(BC,AB,B),
        Triangle.From(BC,C,AC),
        Triangle.From(AC,AB,BC),
      };

      foreach (Triangle t in result)
      {
        Debug.Log($"V1={t.A} V2={t.B} V2={t.C}");
      }


      return result;
    } 


  }

  public class Triangles : List<Triangle>, MeshableInterface
  {
    public Mesh ToMesh()
    {
      Mesh result = new Mesh();
      result.name = $"TRIANGLES( {this.Count}) ";

      result.SetVertices(
        this.Select(
          triangle => triangle.Vertices
        ).Aggregate(new List<Vector3>(), (carry, item) => {
          carry.AddRange(item);
          return carry;
        })
      );

      result.SetTriangles(
        this.Select((triangle,index)=>(triangle.IndexesOrder+index).Indexes)
        .Aggregate(new List<int>(), (carry, item) =>
        {
          carry.AddRange(item);
          return carry;
        })
        ,0
      );

      Debug.Log($"V={result.vertices.Count()} T={result.triangles.Count()}");


      return result;

    }

    public Triangles Divide() {

      Debug.Log("Divide 2");
      return this.Select(t => {

        Debug.Log(t);
        return t.Divide();
      }).Aggregate(new Triangles(),
        (carry, item) =>
        {
          Debug.Log(item);
          carry.AddRange(item);
          return carry;
        });
    }
  }
}
