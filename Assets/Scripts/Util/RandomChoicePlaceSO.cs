using UnityEngine;

namespace Util
{
    [CreateAssetMenu(menuName = "ScriptableObject/RandomChoicePlace", fileName = "RandomChoicePlace")]
    public class RandomChoicePlaceSO : ScriptableObject
    {
        public int ChoiceCount;
        public float ChoiceWidth;
        public float ChoiceHeight;
        public UIPositionSO[] ChoicesPos;
    }
}
