using Data;
using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(order = 41)]
    public class StagesConfig : ScriptableObject
    {
        [SerializeField] private List<StageData> _stageDatas;

        public List<StageData> StageDatas => new List<StageData>(_stageDatas);
    }
}