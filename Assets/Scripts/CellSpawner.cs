using Data;
using System.Collections.Generic;
using UnityEngine;

public class CellSpawner
{
     private CellView _cellPrefab;
     private Transform _cellParent;

     private float _spacing;

    private List<CellView> _spawnedCells;

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
        float totalWidth = 0f;
        float totalHeight = 0f;

        float prefabWidth = _cellPrefab.GetWidth();
        float prefabHeight = _cellPrefab.GetHeight();

        totalHeight = columns.Count * prefabHeight + _spacing * columns.Count - 1;

        totalWidth = GetTotalWidth(columns, totalWidth, prefabWidth);

        float startX = _cellParent.transform.position.x - totalWidth / 2f;
        float currentY = _cellParent.transform.position.y - totalHeight / 2f;

        for (int i = 0; i < columns.Count; i++)
        {
            float currentX = startX;

            for (int j = 0; j < columns[i]; j++)
            {
                var copy = Object.Instantiate(_cellPrefab, _cellParent);
                SetupCell(cellDatas, currentY, currentX, copy);
                _spawnedCells.Add(copy);
                currentX += prefabWidth + _spacing;
            }
            currentY = currentY - prefabHeight - _spacing;
        }

        return _spawnedCells;
    }

    private static void SetupCell(List<CellData> cellDatas, float currentY, float currentX, CellView copy)
    {
        copy.transform.localPosition = new Vector3(currentX, currentY, 0);
        var randomCellData = cellDatas.GetRandom();
        cellDatas.Remove(randomCellData);
        copy.Initialise(randomCellData);
    }

    private float GetTotalWidth(List<int> columns, float totalWidth, float prefabWidth)
    {
        columns.ForEach(column =>
        {
            totalWidth += prefabWidth * column + _spacing * column - 1;
        });
        return totalWidth;
    }

}
