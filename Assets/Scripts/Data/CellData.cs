using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class CellData
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _mainSprite;
        [SerializeField] private Vector3 _localEulerAngles = Vector3.zero;

        public string ID => _id;
        public Sprite MainSprite => _mainSprite;
        public Quaternion LocalRotation => Quaternion.Euler(_localEulerAngles);
    }
}