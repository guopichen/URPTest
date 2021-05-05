using UnityEngine;

namespace HudTest
{
    public class HudShow : MonoBehaviour
    {
        Hud hud;

        Rect rect = new Rect(10, 10, 100, 30);
        float val = 0.2f;

        public int HubCount = 0;

        void Start()
        {
            for(int i=0;i< HubCount; ++i)
                new Hud(0.3f);
            gameObject.SetActive(false);
 
        }


        private void OnGUI()
        {
            val = GUI.HorizontalSlider(rect, val, 0f, 1f);
            hud.UpdateHud(val);
        }


        ////辅助绘制顶点
        //private void OnDrawGizmos()
        //{
        //    if (hud == null && hud.vertices == null)
        //    {
        //        return;
        //    }
        //    Gizmos.color = Color.black;
        //    for (int i = 0; i < hud.vertices.Length; i++)
        //    {
        //        Gizmos.DrawSphere(hud.vertices[i], 0.1f);
        //    }
        //}
    }
}

