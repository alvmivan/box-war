using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Features.UI
{
    public static class UIMeshUtils
    {
        public static void CreateTriangle(this VertexHelper vh, Triangle t)
        {
            var count = vh.currentVertCount;
            
            vh.AddVert(new UIVertex
            {
                color = t.Color,
                position = t.A,
                uv0 = t.UV0A,
                uv1 = t.UV1A,
            });
            vh.AddVert(new UIVertex
            {
                color = t.Color,
                position = t.B,
                uv0 = t.B,
                uv1 = t.B,
            });
            vh.AddVert(new UIVertex
            {
                color = t.Color,
                position = t.C,
                uv0 = t.UV0C,
                uv1 = t.UV1C,
            });
            vh.AddTriangle(count,count+1,count+2);
        }
    }

    public struct Triangle
    {
        public Vector2 A;
        public Vector2 B;
        public Vector2 C;
        public Vector2 UV0A;
        public Vector2 UV0B;
        public Vector2 UV0C;
        public Vector2 UV1A;
        public Vector2 UV1B;
        public Vector2 UV1C;
        public Color Color;

        public Triangle(Vector2 a, Vector2 b, Vector2 c)
        {
            A = a;
            B = b;
            C = c;
            
            UV0A = default;
            UV0B = default;
            UV0C = default;
            
            UV1A = default;
            UV1B = default;
            UV1C = default;
            Color = Color.white;
        }
        
    }
}