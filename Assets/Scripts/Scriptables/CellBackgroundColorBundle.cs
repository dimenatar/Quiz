using System.Collections.Generic;
using UnityEngine;

namespace Scriptables
{
    [CreateAssetMenu(order = 42)]
    public class CellBackgroundColorBundle : ScriptableObject
    {
        [SerializeField] private List<Color> _colors;

        public List<Color> Colors => new List<Color>(_colors);
    }
}