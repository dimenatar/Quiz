using Data;
using Resetters;
using System.Collections.Generic;
using UnityEngine;

namespace Cells
{
    public class CellSpawner : IResettable
    {
        private CellView _cellPrefab;
        private Transform _cellParent;

        private float _spacing;

        private List<CellView> _spawnedCells;
        private bool _isSpawnWithAnimation = true;

        public CellSpawner(CellView cellPrefab, float spacing)
        {
            _cellPrefab = cellPrefab;
            _spacing = spacing;

            _spawnedCells = new List<CellView>();
        }

        public void SetCellParent(Transform parent)
        {
            _cellParent = parent;
        }

        public void DestroyCells()
        {
            _spawnedCells.ForEach(cell => Object.Destroy(cell.gameObject));
            _spawnedCells.Clear();
        }

        public List<CellView> CreateCells(StageData stageData, List<CellData> cellDatas)
        {
            List<int> columns = stageData.ColumnCount;

            float totalHeight = 0f;

            float prefabWidth = _cellPrefab.GetWidth();
            float prefabHeight = _cellPrefab.GetHeight();

            totalHeight = columns.Count * prefabHeight + _spacing * columns.Count - 1;

            float currentY = (totalHeight - prefabHeight) / 2f;

            for (int i = 0; i < columns.Count; i++)
            {
                float totalWidth = prefabWidth * columns[i] + _spacing * (columns[i] - 1);

                float startX = -((totalWidth - prefabWidth) / 2f);
                //float startX = (-totalWidth / 2f);
                float currentX = startX;

                for (int j = 0; j < columns[i]; j++)
                {
                    var copy = Object.Instantiate(_cellPrefab, _cellParent);
                    SetupCell(cellDatas, currentY, currentX, copy);

                    if (_isSpawnWithAnimation)
                    {
                        copy.ScaleIn();
                    }

                    _spawnedCells.Add(copy);
                    currentX += prefabWidth + _spacing;
                }
                currentY = currentY - prefabHeight - _spacing;
            }
            _isSpawnWithAnimation = false;
            return _spawnedCells;
        }

        private static void SetupCell(List<CellData> cellDatas, float currentY, float currentX, CellView copy)
        {
            copy.transform.localPosition = new Vector3(currentX, currentY, 0);
            var randomCellData = cellDatas.GetRandom();
            cellDatas.Remove(randomCellData);
            copy.Initialise(randomCellData);
        }

        public void Reset()
        {
            _isSpawnWithAnimation = true;
        }
    }
}