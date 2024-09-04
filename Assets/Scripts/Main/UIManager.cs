
using Enum;
using UnityEngine;

namespace Main
{
    public class UIManager : MonoBehaviour
    {
        private bool _isCardExist;

        public int PlayerMana
        {
            get => _mainUIModel.PlayerMana;
            set
            { 
                _mainUIModel.PlayerMana = value;
                _mainUIView.PlayerMana.text = $"x{value}";
            }
        }

        public int Cost
        {
            get => _mainUIModel.Cost;
            set
            {
                _mainUIModel.Cost = value;
                _mainUIView.Cost.text = $"x{value}";
            }
        }

        public int Price
        {
            get => _mainUIModel.Price;
            set
            {
                _mainUIModel.Price = value;
                _mainUIView.Price.text = $"x {value.ToString()}";
            }
        }

        public int StrengthProbability
        {
            get => _mainUIModel.StrengthProbability;
            set
            {
                _mainUIModel.StrengthProbability = value;
                _mainUIView.StrengthProbability.text = $"강화 확률: {value.ToString()}%";
            }
        }

        public bool IsCardExist
        {
            get => _isCardExist;
            set
            {
                _isCardExist = value;
                ChangeUISetting(value);
            }
        }

        private MainUIModel _mainUIModel;
        [SerializeField] private PopupManager _popupManager;
        [SerializeField] private MainUIView _mainUIView;
        [SerializeField] private CardManager _cardManager;

        private void Awake()
        {
            _mainUIModel = new MainUIModel();
            SetCreationButtonEvent();
            SetSellButtonEvent();
            SetStrengthButtonEvent();
            GameManager.Instance.OnGameStart += InitPlayerMana;
            GameManager.Instance.OnGameClear += CreateGameClearPopup;
            GameManager.Instance.OnGameOver += CreateGameOverPopup;
            GameManager.Instance.ChangeState(GameManagerStateType.Playing);
        }

        private void OnDestroy()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.OnGameStart -= InitPlayerMana;
                GameManager.Instance.OnGameClear -= CreateGameClearPopup;
                GameManager.Instance.OnGameOver -= CreateGameOverPopup;
            }
        }

        public PopupManager GetPopupManager()
        {
            return _popupManager;
        }

        public CardManager GetCardManager()
        {
            return _cardManager;
        }

        public void CreateGameOverPopup()
        {
            Debug.Log("패배 팝업 생성됨");
            _popupManager.CreatePopup(FactoryType.GameOverPopup);
        }

        public void CreateGameClearPopup()
        {
            _popupManager.CreatePopup(FactoryType.GameClearPopup);
        }
        
        public GameObject CreateRandomChoicePopup()
        {
            return _popupManager.CreatePopup(FactoryType.RandomChoicePopup);
        }

        public void CreateTimeOutPopup()
        {
            _popupManager.CreatePopup(FactoryType.TimeOutPopup);
        }

        public void CreateStrengthFailPopup()
        {
            _popupManager.CreatePopup(FactoryType.StrengthFailPopup);
        }

        private void SetCreationButtonEvent()
        {
            _mainUIView.CreationButton.onClick.AddListener(() => _cardManager.CreateCard(this));
        }
        
        private void SetSellButtonEvent()
        {
            _mainUIView.SellButton.onClick.AddListener(() => _cardManager.SellCard(this));
        }
        
        private void SetStrengthButtonEvent()
        {
            _mainUIView.StrengthButton.onClick.AddListener(() => _cardManager.StrengthenCard(this));
        }

        private void ChangeUISetting(bool isCardExist)
        {
            _mainUIView.CreationButton.gameObject.SetActive(!isCardExist);
            _mainUIView.StrengthButton.gameObject.SetActive(isCardExist);
            _mainUIView.SellButton.interactable = isCardExist;
            _mainUIView.StrengthProbability.gameObject.SetActive(isCardExist);
            _mainUIView.Price.gameObject.SetActive(isCardExist);
        }

        private void InitPlayerMana()
        {
            PlayerMana = 30;
            Cost = 1;
        }
    }
}
