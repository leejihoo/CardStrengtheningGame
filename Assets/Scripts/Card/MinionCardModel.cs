using Enum;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Card
{
    public class MinionCardModel
    {
        public int Star;
        public int Attack;
        public int Hp;
        public int Cost;
        public CardAttributeType MinionAttributeType;
        public CardRatingType MinionRatingType;
        public JobType MinionJobType;
        public CardType TypeOfCard;
    }
}
