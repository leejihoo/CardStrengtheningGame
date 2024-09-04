using Enum;
using Interface;
using UnityEngine;

namespace Card
{
    public abstract class CardKeywordSO : ScriptableObject, ICardKeyword
    {
        [field: SerializeField] public virtual CardKeywordType KeywordType { get; set; }
        public virtual string Description { get; set; }
        public GameObject keywordPopupPrefab;
        public virtual void ApplyKeyword(ICard card)
        {
            var minionCard = card as RandomMinionCard;
            minionCard.AddKeyword(this);
        }

        public virtual void RemoveKeyword(ICard card)
        {
            var minionCard = card as RandomMinionCard;
            minionCard.RemoveKeyword(this);
        }
    }
}
