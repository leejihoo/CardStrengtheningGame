using System;
using System.Collections.Generic;
using Card;
using Interface;
using UnityEngine;
using Util;
using Random = UnityEngine.Random;

namespace Main
{
    public class CardManager : MonoBehaviour
    {
        private ICard _targetCard;
        [SerializeField] private ThreeChoicePlacer _threeChoicePlacer;
        [SerializeField] private MinionCardFactory _minionCardFactory;
        [SerializeField] private ScriptableFactory[] scriptableFactories;
        //public static ICard TempCard;
        
        public void CreateCard(UIManager uiManager)
        {
            var card = _minionCardFactory.Produce() as RandomMinionCard;
            _targetCard = card;
            uiManager.IsCardExist = true;
            uiManager.Price = CalculatePrice(card.Cost, card.Star, (int)card.MinionRatingType + 1);
            uiManager.StrengthProbability = CalculateProbability(card.Star);
            uiManager.PlayerMana -= uiManager.Cost;

            //TempCard = card;
        }

        public void RemoveCard(UIManager uiManager)
        {
            if (_targetCard == null)
            {
                Debug.LogError("제거할 카드가 없습니다.");
                return;
            }
            Destroy((_targetCard as RandomMinionCard)?.gameObject);
            _targetCard = null;
            uiManager.IsCardExist = false;
        }

        public void StrengthenCard(UIManager uiManager)
        {
            if (uiManager.PlayerMana - uiManager.Cost < 0)
            {
                Debug.Log("비용이 부족합니다.");
                return;
            }
            
            uiManager.PlayerMana -= uiManager.Cost;
            
            var popup = uiManager.CreateRandomChoicePopup();
            List<GameObject> cards = new List<GameObject>();
            HashSet<int> hashSet = new HashSet<int>();
            for (int i = 0; i < 3; i++)
            {
                var card = CreateRandomStrengthCard(hashSet,out int number);
                hashSet.Add(number);
                card.GetComponent<IStrengthCard>().UIManager = uiManager;
                card.transform.SetParent(popup.transform);
                cards.Add(card);
            }
            
            _threeChoicePlacer.Place(cards);
            
        }

        private GameObject CreateRandomStrengthCard(HashSet<int> hashSet, out int number)
        {
            var count = scriptableFactories.Length;
            bool isExist;
            bool isExistChoice;
            int randomNum;
            
            // 비효율적인 코드 바꾸면 좋음
            do
            {
                isExist = false;
                randomNum = Random.Range(0, count);
                
                isExistChoice = hashSet.Contains(randomNum);
                
                // 0,1,2는 스텟 버프
                if (randomNum > 2)
                {
                    isExist = (_targetCard as RandomMinionCard).IsExistKeyword(scriptableFactories[randomNum].Prefab
                        .GetComponent<KeywordGrantCard>().cardKeywordSo);
                }
            } while (isExist || isExistChoice);

            var product = scriptableFactories[randomNum].Produce();
            (product as IStrengthCard).Target = _targetCard;
            number = randomNum;
            
            return (product as IStrengthCard).myself;
        }

        public void SellCard(UIManager uiManager)
        {
            uiManager.PlayerMana += uiManager.Price;
            uiManager.Cost = 1;
            RemoveCard(uiManager);
            uiManager.CreateTimeOutPopup();
        }

        public void FailStrength(UIManager uiManager)
        {
            uiManager.Cost = 1;
            RemoveCard(uiManager);
            uiManager.GetPopupManager().RemoveTopPopup();
            uiManager.CreateStrengthFailPopup();
            
            var isGameOver = CheckGameOver(uiManager);
            if (isGameOver)
            {
                Debug.Log("게임 오버됨");
                GameManager.Instance.AnnounceGameOver();
            }
        }

        public void SuccessStrength(UIManager uiManager)
        {
            var card = _targetCard as RandomMinionCard;
            card.Star++;
            card.Cost++;
            uiManager.GetPopupManager().RemoveTopPopup();
            uiManager.Price = CalculatePrice(card.Cost, card.Star, (int)card.MinionRatingType + 1);
            uiManager.StrengthProbability = CalculateProbability(card.Star);
            uiManager.Cost = card.Star;
            
            if (card.Star == 10)
            {
                GameManager.Instance.AnnounceGameClear();
            }
        }

        public bool CheckCardStar(ICard card)
        {
            return false;
        }

        public ICard CreateStrengthCard()
        {
            return null;
        }

        public bool CheckGameOver(UIManager uiManager)
        {
            return uiManager.PlayerMana == 0 && _targetCard == null;
        }

        private int CalculatePrice(int cost, int star, int cardRating)
        {
            return cost * star * cardRating;
        }

        private int CalculateProbability(int star)
        {
            return (10 - star) * 10;
        }

        public bool IsSucceedStrength()
        {
            var probability = CalculateProbability((_targetCard as RandomMinionCard).Star);
            var randomNum = Random.Range(0f, 100f);
            Debug.Log("랜덤 숫자: " + randomNum + "확률:" + probability);
            return probability >= randomNum && 0 <= randomNum;
        }
    }
}
