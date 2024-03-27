using System;
using UnityEngine;

namespace Extensions
{
    [Serializable]
    public struct MyVector3
    {
        public float x;
        public float y;
        public float z;

        public MyVector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static MyVector3 FromUnityVector3(Vector3 vector)
        {
            return new MyVector3
            {
                x = vector.x,
                y = vector.y,
                z = vector.z
            };
        }

        public static Vector3 FromMyVector3(MyVector3 myVector3)
        {
            var vector3 = Vector3.zero;
            vector3.x = myVector3.x;
            vector3.y = myVector3.y;
            vector3.z = myVector3.z;
            return vector3;
        }
    }
}