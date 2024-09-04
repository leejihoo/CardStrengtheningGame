using Enum;
using Interface;
using UnityEngine;

namespace Card.Keyword
{
    public abstract class SallyKeyword : CardKeywordSO
    {
        private void OnValidate()
        {
            KeywordType = CardKeywordType.Sally;
        }
    }
}
