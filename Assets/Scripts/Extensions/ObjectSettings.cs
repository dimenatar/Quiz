using Extensions;
using System;
using UnityEngine;

[Serializable]
public struct ObjectSettings
{
    [SerializeField] private MyVector3 _position;
    [SerializeField] private MyVector3 _eulerAngles;
    [SerializeField] private MyVector3 _scale;

    public MyVector3 Position { get => _position; set => _position = value; }
    public MyVector3 EulerAngles { get => _eulerAngles; set => _eulerAngles = value; }
   // public Quaternion Rotation { get => Quaternion.Euler(_eulerAngles.ToUnityVector3()); set => _eulerAngles = value.eulerAngles.ToMyVector3(); }
    public MyVector3 Scale { get => _scale; set => _scale = value; }
}
