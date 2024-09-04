using Enum;
using Interface;
using UnityEngine;
using Util;

namespace Card
{
    [CreateAssetMenu(menuName = "ScriptableObject/Factory/MinionCardFactory", fileName = "MinionCardFactory")]
    public class MinionCardFactory : ScriptableFactory
    {
        private CardAttributeType BringRandomCardAttributeType()
        {
            var randomNum = Random.Range(0, 6);
            return (CardAttributeType)randomNum;
        }

        private CardRatingType BringRandomCardRatingType()
        {
            var randomNum = Random.Range(0, 4);
            return (CardRatingType)randomNum;
        }

        private JobType BringRandomJobType()
        {
            var randomNum = Random.Range(0, 9);
            return (JobType)randomNum;
        }

        private void InitCardModel(RandomMinionCard randomMinionCard)
        {
            randomMinionCard.Attack = 1;
            randomMinionCard.Hp = 1;
            randomMinionCard.Cost = 1;
            randomMinionCard.Star = 1;
            randomMinionCard.MinionAttributeType = BringRandomCardAttributeType();
            randomMinionCard.MinionRatingType = BringRandomCardRatingType();
            randomMinionCard.MinionJobType = BringRandomJobType();
            randomMinionCard.TypeOfCard = CardType.Minion;
        }

        public override IProduct Produce()
        {
            var prefab = Instantiate(Prefab,GameObject.Find("Canvas").transform,false);
            var randomMinionCard = prefab.GetComponent<RandomMinionCard>();
            InitCardModel(randomMinionCard);
            
            return randomMinionCard;
        }
    }
}
