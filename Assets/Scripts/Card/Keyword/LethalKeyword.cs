using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    [CreateAssetMenu(menuName = "ScriptableObject/Keyword/LethalKeyword", fileName = "LethalKeyword")]
    public class LethalKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Lethal;
        }
    }
}
