using Clickables;
using Data;
using DG.Tweening;
using UnityEngine;

namespace Cells
{
    public class CellView : ClickableMonobehaviour
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
            _mainSpriteRenderer.transform.localRotation = cellData.LocalRotation;
            _mainSpriteStartLocalPosition = _mainSpriteRenderer.transform.localPosition;
        }

        public void SetBackgroundColor(Color color)
        {
            _backgroundSpriteRenderer.color = color;
        }

        public float GetWidth()
        {
            return _backgroundSpriteRenderer.sprite.bounds.size.x * _backgroundSpriteRenderer.transform.lossyScale.x;
        }

        public float GetHeight()
        {
            return _backgroundSpriteRenderer.sprite.bounds.size.y * _backgroundSpriteRenderer.transform.lossyScale.y;
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
}