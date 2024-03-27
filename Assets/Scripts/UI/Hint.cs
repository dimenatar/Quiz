using Cells;
using Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private string _format;

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
        }
    }
}