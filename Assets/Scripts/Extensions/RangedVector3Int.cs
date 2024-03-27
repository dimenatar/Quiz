using System;
using UnityEngine;

[Serializable]
public struct RangedVector3Int
{
    [SerializeField, Range(-1, 1)] public int x;
    [SerializeField, Range(-1, 1)] public int y;
    [SerializeField, Range(-1, 1)] public int z;

    public static Vector3 operator * (Vector3 vector, RangedVector3Int rangedVector3)
    {
        return new Vector3(vector.x * rangedVector3.x, vector.y * rangedVector3.y, vector.z * rangedVector3.z);
    }
}
