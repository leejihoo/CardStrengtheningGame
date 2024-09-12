using System;
using System.Collections.Generic;
using Abstract;
using Enum;
using UnityEngine;

namespace Main
{
    public class GameManagerStateMachine : StateMachine
    {
        private Dictionary<GameManagerStateType,CardStrengthGameState> _cardStrengthGameStateDictionary;
        
        [SerializeField] private List<CardStrengthGameState> cardStrengthGameStateList;
        private void Awake()
        {
            InitDictionary();
        }

        private void Start()
        {
            Initialize(_cardStrengthGameStateDictionary[GameManagerStateType.Ready]);
        }
        
        public void ChangeState(GameManagerStateType stateType)
        {
            TransitionTo(_cardStrengthGameStateDictionary[stateType]);
        }

        private void InitDictionary()
        {
            _cardStrengthGameStateDictionary = new Dictionary<GameManagerStateType, CardStrengthGameState>();
            
            foreach (var state in cardStrengthGameStateList)
            {
                _cardStrengthGameStateDictionary[state.StateType] = state;
            }
        }
    }
}
