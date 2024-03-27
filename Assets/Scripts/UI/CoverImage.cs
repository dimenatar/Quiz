using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CoverImage : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField, Range(0f, 1f)] private float _halfTransparency;
    [SerializeField] private float _animationDuration = 0.5f;

    private GameplayFlow _gameplayFlow;
    private Resetter _resetter;

    private Tween _tween;

    [Inject]
    private void Construct(GameplayFlow gameplayFlow, Resetter resetter)
    {
        _gameplayFlow = gameplayFlow;
        _resetter = resetter;
    }

    private void Awake()
    {
        _gameplayFlow.CompeltedAllStages += OnCompletedAllStages;
        _resetter.Resetted += OnResetted;
    }

    private void OnDestroy()
    {
        _gameplayFlow.CompeltedAllStages -= OnCompletedAllStages;
        _resetter.Resetted -= OnResetted;
    }

    private void OnCompletedAllStages()
    {
        SetTransparency(_halfTransparency);
    }

    private Tween SetTransparency(float targetAlpha)
    {
        _tween?.Kill();
        var targetColor = _image.color;
        targetColor.a = targetAlpha;

        _tween = _image.DOColor(targetColor, _animationDuration);
        return _tween;
    }

    private void OnResetted()
    {
        Sequence sequence = DOTween.Sequence();
        _tween = sequence
            .Append(SetTransparency(1f))
            .Append(SetTransparency(0f));
    }
}
