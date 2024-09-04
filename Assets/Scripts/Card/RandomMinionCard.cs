using System;
using System.Collections.Generic;
using Enum;
using Interface;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Card
{
    public class RandomMinionCard : MonoBehaviour, IMinionCard
    {
        public int Attack
        {
            get => _minionCardModel.Attack;
            set
            {
                _minionCardModel.Attack = value;
                _minionCardView.Attack.text = value.ToString();
            }
        }
        
        public int Hp
        {
            get => _minionCardModel.Hp;
            set
            {
                _minionCardModel.Hp = value;
                _minionCardView.Hp.text = value.ToString();
            }
        }

        public int Cost
        {
            get => _minionCardModel.Cost;
            set
            {
                _minionCardModel.Cost = value;
                _minionCardView.Cost.text = value.ToString();
            }
        }
        
        public Sprite CardSprite { get; set; }

        public int Star
        {
            get => _minionCardModel.Star;
            set
            {
                _minionCardModel.Star = value;
                AddStar(value);
            }
        }
        
        [SerializeField] private GameObject starFrame;
        [SerializeField] private GameObject starImage;
        
        public CardAttributeType MinionAttributeType
        {
            get => _minionCardModel.MinionAttributeType;
            set
            {
                _minionCardModel.MinionAttributeType = value;
                SetMinionAttributeText(value);
            }
        }
        
        public string Name { get; set; }
        
        public CardRatingType MinionRatingType
        {
            get => _minionCardModel.MinionRatingType;
            set
            {
                _minionCardModel.MinionRatingType = value;
                SetMinionRatingFrameColor(value);
            }
        }

        public JobType MinionJobType
        {
            get => _minionCardModel.MinionJobType;
            set
            {
                _minionCardModel.MinionJobType = value;
                SetForegroundColor(value);
            }
        }
        public CardType TypeOfCard { get; set; }
        
        private MinionCardModel _minionCardModel;
        [SerializeField] private MinionCardView _minionCardView;
        private Dictionary<CardKeywordType,CardKeywordSO> _cardKeywordDictionary;
        private List<GameObject> _popupList;
        [SerializeField] private GameObject popupView;
        private void Awake()
        {
            //_minionCardView = new MinionCardView();
            _minionCardModel = new MinionCardModel();
            _cardKeywordDictionary = new Dictionary<CardKeywordType, CardKeywordSO>();
            _popupList = new List<GameObject>();
        }

        public bool IsExistKeyword(CardKeywordSO cardKeywordSo)
        {
            return _cardKeywordDictionary.ContainsKey(cardKeywordSo.KeywordType);
        }

        public void AddKeyword(CardKeywordSO cardKeywordSo)
        {
            _cardKeywordDictionary[cardKeywordSo.KeywordType] = cardKeywordSo;
            var popup = Instantiate(cardKeywordSo.keywordPopupPrefab, popupView.GetComponent<ScrollRect>().content.transform, false);
            _popupList.Add(popup);
        }

        public void RemoveKeyword(CardKeywordSO cardKeywordSo)
        {
            _cardKeywordDictionary.Remove(cardKeywordSo.KeywordType);
            foreach (var popup in _popupList)
            {
                if (popup.name == cardKeywordSo.keywordPopupPrefab.name)
                {
                    _popupList.Remove(popup);
                    Destroy(popup);
                }
            }
        }

        public void AddBuff(StatableSO statableSo)
        {
            var popup = Instantiate(statableSo.statBuffPopupPrefab, popupView.GetComponent<ScrollRect>().content.transform, false);
            _popupList.Add(popup);
        }

        private void SetForegroundColor(JobType jobType)
        {
            switch (jobType)
            {
                case JobType.Warrior:
                    _minionCardView.CardForeground.color = Color.red;
                    break;
                case JobType.Warlock:
                    _minionCardView.CardForeground.color = ChangeHexToColor("7000E0");
                    break;
                case JobType.Shaman:
                    _minionCardView.CardForeground.color = ChangeHexToColor("0040A0");
                    break;
                case JobType.Thief:
                    _minionCardView.CardForeground.color = Color.gray;
                    break;
                case JobType.Priest:
                    _minionCardView.CardForeground.color = ChangeHexToColor("F8F8F8");
                    break;
                case JobType.Paladin:
                    _minionCardView.CardForeground.color = ChangeHexToColor("FFD43B");
                    break;
                case JobType.Wizard:
                    _minionCardView.CardForeground.color = ChangeHexToColor("86E9FF");
                    break;
                case JobType.Hunter:
                    _minionCardView.CardForeground.color = ChangeHexToColor("008A16");
                    break;
                case JobType.Druid:
                    _minionCardView.CardForeground.color = ChangeHexToColor("B86E00");
                    break;
            }
        }
        
        private void SetMinionRatingFrameColor(CardRatingType cardRatingType)
        {
            switch (cardRatingType)
            {
                case CardRatingType.General:
                    _minionCardView.MinionRatingFrame.color = Color.white;
                    break;
                case CardRatingType.Rare:
                    _minionCardView.MinionRatingFrame.color = Color.blue;
                    break;
                case CardRatingType.Hero:
                    _minionCardView.MinionRatingFrame.color = ChangeHexToColor("A100ED");
                    break;
                case CardRatingType.Legend:
                    _minionCardView.MinionRatingFrame.color = ChangeHexToColor("EBB700");
                    break;
            }    
        }
        
        private void AddStar(int starCount)
        {
            var currentStarCount = starFrame.transform.childCount;
            for (int i = 0; i < starCount - currentStarCount; i++)
            {
                Instantiate(starImage, starFrame.transform, false);
            }
        }

        private void SetMinionAttributeText(CardAttributeType cardAttributeType)
        {
            switch (cardAttributeType)
            {
                case CardAttributeType.Undead:
                    _minionCardView.MinionAttribute.text = "언데드";
                    break;
                case CardAttributeType.Machine:
                    _minionCardView.MinionAttribute.text = "기계";
                    break;
                case CardAttributeType.Spirit:
                    _minionCardView.MinionAttribute.text = "정령";
                    break;
                case CardAttributeType.Demon:
                    _minionCardView.MinionAttribute.text = "악마";
                    break;
                case CardAttributeType.Beast:
                    _minionCardView.MinionAttribute.text = "야수";
                    break;
                case CardAttributeType.Dragon:
                    _minionCardView.MinionAttribute.text = "드래곤";
                    break;
                default:
                    _minionCardView.MinionAttribute.text = "종족";
                    break;
            }
        }

        private Color ChangeHexToColor(string hex)
        {
            ColorUtility.TryParseHtmlString("#" + hex, out Color color);
            return color;
        }
        
        public void OnPointerClick(PointerEventData eventData)
        {
            popupView.SetActive(!popupView.activeSelf);
        }
        
        
    }
}
