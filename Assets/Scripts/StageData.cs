using Scriptables;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    [System.Serializable]
    public class StageData
    {
        [SerializeField] private List<int> _columnCount;

        public List<int> ColumnCount => new List<int>(_columnCount);
    }
}