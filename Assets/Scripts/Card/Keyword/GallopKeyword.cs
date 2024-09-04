using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    [CreateAssetMenu(menuName = "ScriptableObject/Keyword/GallopKeyword", fileName = "GallopKeyword")]
    public class GallopKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Gallop;
        }
    }
}
