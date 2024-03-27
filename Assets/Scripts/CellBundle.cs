using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(order = 40)]
    public class CellBundle : ScriptableObject
    {
        [SerializeField] private List<CellData> _cellDatas;

        public List<CellData> CellDatas => new List<CellData>(_cellDatas);
    }
}