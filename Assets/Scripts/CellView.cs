using UnityEngine;
using UnityEngine.EventSystems;

public class CellView : ClickableMonobehaviour, IPointerUpHandler
{
    [SerializeField] private SpriteRenderer _mainSpriteRenderer;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;

    public CellData CellData { get; private set; }

    public void Initialise(CellData cellData)
    {
        CellData = cellData;
        _mainSpriteRenderer.sprite = cellData.MainSprite;
    }

    public float GetWidth()
    {
        return _backgroundSpriteRenderer.sprite.bounds.size.x * _backgroundSpriteRenderer.transform.lossyScale.x;
    }

    public float GetHeight()
    {
        return _backgroundSpriteRenderer.sprite.bounds.size.y * _backgroundSpriteRenderer.transform.lossyScale.y;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Click();
    }
}