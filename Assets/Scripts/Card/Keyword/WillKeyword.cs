using System;
using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    public abstract class WillKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Will;
        }
    }
}
