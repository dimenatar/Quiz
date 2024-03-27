using UnityEngine;

[System.Serializable]
public class CellData
{
    [SerializeField] private string _id;
    [SerializeField] private Sprite _mainSprite;

    public string ID => _id;
    public Sprite MainSprite => _mainSprite;
}