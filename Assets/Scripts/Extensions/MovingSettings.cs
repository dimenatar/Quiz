using DG.Tweening;
using UnityEngine;

[System.Serializable]
public struct MovingSettings
{
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Vector3 endPosition;
    [SerializeField] public float moveInDuration;
    [SerializeField] public float moveOutDuration;
    [SerializeField] public Ease moveInEase;
    [SerializeField] public Ease moveOutEase;
}
