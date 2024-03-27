using Cells;
using Data;
using DG.Tweening;
using Resetters;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Hint : MonoBehaviour, IResettable
    {
        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private string _format;

        [SerializeField] private float _animationDuration = 0.5f;

        private bool _isShowingWithAnimation = true;
        private CellAnswerDecider _cellAnswerDecider;

        [Inject]
        private void Construct(CellAnswerDecider cellAnswerDecider)
        {
            _cellAnswerDecider = cellAnswerDecider;
        }

        private void Awake()
        {
            SetID(_cellAnswerDecider.RightAnswerID);
            _cellAnswerDecider.RightAnswerPicked += OnRightAnswerPicked;
        }

        private void OnDestroy()
        {
            _cellAnswerDecider.RightAnswerPicked -= OnRightAnswerPicked;
        }

        private void OnRightAnswerPicked(CellData cellData)
        {
            SetID(cellData.ID);
        }

        private void SetID(string id)
        {
            _textMesh.SetText(string.Format(_format, id));
            if (_isShowingWithAnimation)
            {
                var startColor = _textMesh.color;
                var targetColor = startColor;
                startColor.a = 0f;
                _textMesh.DOColor(targetColor, _animationDuration);
            }
            _isShowingWithAnimation = false;
        }

        public void Reset()
        {
            _isShowingWithAnimation = true;
        }
    }
}