using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeTest
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class CubeWithUV : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            mesh.name = "MyMesh";
            GenerateVectices();
            GenerateTriangles();
            // 使用一个默认材质
            //var mat = new Material(Shader.Find("Standard")) { name = "Default-Material" };
            //GetComponent<MeshRenderer>().material = mat;
            GetComponent<MeshRenderer>().material = Resources.Load<Material>("New Material");
        }

        // 创建三角形
        void GenerateTriangles()
        {
            mesh.triangles = new[]
           {
                0,2,1,    //底面三角形1
                0,3,2,    //底面三角形2
                4,6,5,    //背面三角形1
                4,7,6,    //背面三角形2
                8,10,9,   //顶面三角形1
                8,11,10,  //顶面三角形2
                12,14,13, //正面三角形1
                12,15,14, //正面三角形2
                16,18,17, //左面三角形1
                16,19,18, //左面三角形2
                20,22,21, //右面三角形1
                20,23,22  //右面三角形2
            };
        }

        // 创建顶点
        // 如果只创建8个顶点, 那么只有top和bottom面会被贴上贴图,
        // 因为uv坐标的数组长度要跟顶点坐标数组的长度相同并且是一一对应的关系
        // 而一个cube需要6个面都贴上纹理, 那么应该需要顶点坐标共: 4x6个顶点 (一个面4个顶点,共6个面)
        void GenerateVectices()
        {
            vertices = new Vector3[8];
            // 以左下角的顶点为原点
            var dot1 = new Vector3(0, 0, 0);
            var dot2 = new Vector3(1, 0, 0);
            var dot3 = new Vector3(1, 0, 1);
            var dot4 = new Vector3(0, 0, 1);
            var dot5 = new Vector3(0, 1, 0);
            var dot6 = new Vector3(1, 1, 0);
            var dot7 = new Vector3(1, 1, 1);
            var dot8 = new Vector3(0, 1, 1);
            //
            vertices = new[]
            {
                //底面
                dot1,
                dot4,
                dot3,
                dot2,
                //背面
                dot4,
                dot8,
                dot7,
                dot3,
                //顶面
                dot8,
                dot5,
                dot6,
                dot7,
                //正面
                dot1,
                dot2,
                dot6,
                dot5,

                //左面
                dot4,
                dot1,
                dot5,
                dot8,
             
                //右面
                dot2,
                dot3,
                dot7,
                dot6,
            };
            var uvs = new Vector2[24];
            //用循环给六个面贴上纹理贴图
            for (int i = 0; i < 24; i += 4)
            {
                uvs[i] = new Vector2(0, 0);
                uvs[i + 1] = new Vector2(1, 0);
                uvs[i + 2] = new Vector2(1, 1);
                uvs[i + 3] = new Vector2(0, 1);
            }
            mesh.vertices = vertices;
            mesh.uv = uvs;

        }

        //辅助绘制顶点
        private void OnDrawGizmos()
        {
            if (vertices == null)
            {
                return;
            }
            Gizmos.color = Color.black;
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }

        Vector3[] vertices;// 顶点数据
        Mesh mesh;// 存放MeshFileter的mesh
    }
}



