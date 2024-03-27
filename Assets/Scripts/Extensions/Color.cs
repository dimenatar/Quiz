using System;
using UnityEngine;

namespace Extensions
{
    [Serializable]
    public class Color
    {
        public float r;
        public float g;
        public float b;
        public float a;

        public Color() { }

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public static Color FromUnityColor(UnityEngine.Color color)
        {
            return new Color(color.r, color.g, color.b, color.a);
        }

        public static UnityEngine.Color ToUnityColor(Color color)
        {
            var uColor = UnityEngine.Color.white;
            uColor.r = color.r;
            uColor.g = color.g;
            uColor.b = color.b;
            uColor.a = color.a;
            return uColor;
        }

        public UnityEngine.Color ToUnityColor()
        {
            var uColor = UnityEngine.Color.white;
            uColor.r = r;
            uColor.g = g;
            uColor.b = b;
            uColor.a = a;
            return uColor;
        }
    }
}
