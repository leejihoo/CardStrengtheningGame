using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    [CreateAssetMenu(menuName = "ScriptableObject/Keyword/RushKeyword", fileName = "RushKeyword")]
    public class RushKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Rush;
        }
    }
}
