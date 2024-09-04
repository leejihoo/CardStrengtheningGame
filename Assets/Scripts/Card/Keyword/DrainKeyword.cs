using System;
using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    [CreateAssetMenu(menuName = "ScriptableObject/Keyword/DrainKeyword", fileName = "DrainKeyword")]
    public class DrainKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Drain;
        }
    }
}
