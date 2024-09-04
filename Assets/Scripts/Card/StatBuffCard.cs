using Interface;
using Main;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Card
{
    public class StatBuffCard : MonoBehaviour, IStrengthCard
    {
        public int Cost { get; set; }
        public string Effect { get; set; }
        [field: SerializeField] public Sprite CardSprite { get; set; }
        [field: SerializeField] public StatableSO StatSo { get; set; }
        public string Name { get; set; }
        public ICard Target { get; set; }
        public GameObject myself { get; set; }
        public UIManager UIManager { get; set; }

        private void Awake()
        {
            myself = gameObject;
        }

        public void AttachEffect(ICard card)
        {
            var minionCard = card as RandomMinionCard;
            minionCard.Attack += StatSo.Attack;
            minionCard.Hp += StatSo.Hp;
            minionCard.AddBuff(StatSo);
        }

        public void DetachEffect(ICard card)
        {
            throw new System.NotImplementedException();
        }



        public void OnPointerClick(PointerEventData eventData)
        {
            //Target = CardManager.TempCard;
            var isSucceed = UIManager.GetCardManager().IsSucceedStrength();
            if (isSucceed)
            {
                AttachEffect(Target);
                UIManager.GetCardManager().SuccessStrength(UIManager);
            }
            else
            {
                UIManager.GetCardManager().FailStrength(UIManager);
            }
            //UIManager.GetPopupManager().RemoveTopPopup();
        }
    }
}
