using System.Collections.Generic;
using UnityEngine;
using Util;

namespace Interface
{
    public interface IRandomChoicePlacer
    {
        public RandomChoicePlaceSO Model { get; set; }
        public void Place(List<GameObject> choices);
    }
}
