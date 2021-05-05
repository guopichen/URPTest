using UnityEngine;
using UnityEngine.Rendering;

namespace HudTest
{

    public class Hud
    {
        private GameObject hud;
        private Vector3[] vertices;
        float x = 2f, y = 0.1f, z = 0f;

        public Hud(float hud)
        {
            var mesh = CreateBlood();
            GenerateVectices(mesh, hud);
            GenerateTriangles(mesh);
        }


        void GenerateVectices(Mesh mesh,float val)
        {
            // 以左下角的顶点为原点
            // bg
            var dot0 = new Vector3(0, 0, z);
            var dot1 = new Vector3(x, 0, z);
            var dot2 = new Vector3(x, y, z);
            var dot3 = new Vector3(0, y, z);

            //
            vertices = new[]
            {
                dot0,
                dot1,
                dot2,
                dot3,
                // hud
                dot0,
                new Vector3(x*val, 0, z),
                new Vector3(x*val, y, z),
                dot3,
            };

            mesh.vertices = vertices;
            // uv
            var uvs = new Vector2[8];
            uvs[0] = new Vector2(0, 0);
            uvs[1] = new Vector2(1, 0);
            uvs[2] = new Vector2(1, 1);
            uvs[3] = new Vector2(0, 1);
            //
            uvs[4] = new Vector2(0, 0);
            uvs[5] = new Vector2(1, 0);
            uvs[6] = new Vector2(1, 1);
            uvs[7] = new Vector2(0, 1);
            mesh.uv = uvs;
        }
        void GenerateTriangles(Mesh mesh)
        {
            mesh.triangles = new[]
            {
                0,3,2,    
                0,2,1,
                //
                4,7,6,
                4,6,5,
            };
        }

        private Mesh CreateBlood()
        {
            hud = new GameObject("hud");
            //hud.transform.rotation = Quaternion.Euler(0, 180, 0);
            hud.transform.position = new Vector3(0, 0, 0);
            var filter = hud.AddComponent<MeshFilter>();
            var render = hud.AddComponent<MeshRenderer>();
            render.material = Resources.Load<Material>("HudMaterial");
            render.shadowCastingMode = ShadowCastingMode.Off;
            render.receiveShadows = false;
            render.lightProbeUsage = LightProbeUsage.Off;
            render.reflectionProbeUsage = ReflectionProbeUsage.Off;
            return filter.mesh;

        }


        

        public void UpdateHud(float v)
        {
            float val = x * v;
            vertices[5].Set(val, 0, z);
            vertices[6].Set(val, y, z);

            var mesh = hud.GetComponent<MeshFilter>().mesh;
            mesh.vertices = vertices;
        }
    }

}
