using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellView : ClickableMonobehaviour, IPointerUpHandler
{
    [SerializeField] private SpriteRenderer _mainSpriteRenderer;
    [SerializeField] private SpriteRenderer _backgroundSpriteRenderer;

    [SerializeField] private float _strength = 1f;
    [SerializeField] private float _duration = 0.2f;
    [SerializeField] private int _vibrato = 5;

    public CellData CellData { get; private set; }

    private Vector3 _mainSpriteStartLocalPosition;
    private Tween _currentTween;

    public void Initialise(CellData cellData)
    {
        CellData = cellData;
        _mainSpriteRenderer.sprite = cellData.MainSprite;
        _mainSpriteStartLocalPosition = _mainSpriteRenderer.transform.localPosition;
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

    public void PlayBounceAnimation()
    {
        _currentTween?.Kill();
        _mainSpriteRenderer.transform.localPosition = _mainSpriteStartLocalPosition;
        _currentTween = _mainSpriteRenderer.transform.DOShakePosition(_duration, _mainSpriteRenderer.transform.right * _strength, _vibrato, 0);
    }

    public void ScaleIn()
    {
        _currentTween?.Kill();
        _currentTween = transform.ScaleIn();
    }
}