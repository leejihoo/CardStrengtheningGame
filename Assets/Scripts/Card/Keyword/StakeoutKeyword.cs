using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    [CreateAssetMenu(menuName = "ScriptableObject/Keyword/StakeoutKeyword", fileName = "StakeoutKeyword")]
    public class StakeoutKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Stakeout;
        }
    }
}
