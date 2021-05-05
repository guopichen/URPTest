using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeTest
{
    [RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
    public class MyFirstCube : MonoBehaviour
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
            var mat = new Material(Shader.Find("Standard")) { name = "Default-Material" };
            GetComponent<MeshRenderer>().material = mat;
        }

        // 创建三角形
        void GenerateTriangles()
        {
            // 6个面, 每个面2个三角形, 每个三角形3个顶点
            int[] triangles = new int[6 * 2 * 3];
            // 三角形的顶点索引
            // 1
            triangles[0] = 0;
            triangles[1] = 4;
            triangles[2] = 1;
            // 2
            triangles[3] = 4;
            triangles[4] = 5;
            triangles[5] = 1;
            // 3
            triangles[6] = 5;
            triangles[7] = 6;
            triangles[8] = 2;
            // 4
            triangles[9] = 5;
            triangles[10] = 2;
            triangles[11] = 1;
            // 5
            triangles[12] = 7;
            triangles[13] = 6;
            triangles[14] = 3;
            // 6
            triangles[15] = 3;
            triangles[16] = 6;
            triangles[17] = 2;
            // 7
            triangles[18] = 4;
            triangles[19] = 7;
            triangles[20] = 5;
            // 8
            triangles[21] = 7;
            triangles[22] = 6;
            triangles[23] = 5;

            // 9
            triangles[24] = 0;
            triangles[25] = 3;
            triangles[26] = 1;
            //
            triangles[27] = 1;
            triangles[28] = 3;
            triangles[29] = 2;


            // 11
            triangles[30] = 1;
            triangles[31] = 4;
            triangles[32] = 3;
            // 12
            triangles[33] = 3;
            triangles[34] = 4;
            triangles[35] = 7;
            mesh.triangles = triangles;
        }

        // 创建顶点
        void GenerateVectices()
        {
            vertices = new Vector3[8];
            // 以左下角的顶点为原点
            vertices[0] = new Vector3(0, 0, 0);
            vertices[1] = new Vector3(1, 0, 0);
            vertices[2] = new Vector3(1, 0, 1);
            vertices[3] = new Vector3(0, 0, 1);
            vertices[4] = new Vector3(0, 1, 0);
            vertices[5] = new Vector3(1, 1, 0);
            vertices[6] = new Vector3(1, 1, 1);
            vertices[7] = new Vector3(0, 1, 1);
            //
            mesh.vertices = vertices;
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


