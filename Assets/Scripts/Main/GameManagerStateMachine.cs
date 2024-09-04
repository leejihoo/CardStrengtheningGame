using System;
using Abstract;
using Enum;
using UnityEngine;

namespace Main
{
    public class GameManagerStateMachine : StateMachine
    {
        private CardStrengthGameState _currentState;
        [SerializeField] private GameReadyState _gameReadyState;
        [SerializeField] private GamePlayingState _gamePlayingState;
        [SerializeField] private GameClearState _gameClearState;
        [SerializeField] private GameOverState _gameOverState;
        private GameManagerStateType _gameManagerStateType;

        private void Start()
        {
            Initialize(_gameReadyState);
        }

        public void Initialize(CardStrengthGameState startingState)
        {
            _currentState = startingState;
            _currentState.Enter();
        }

        public void TransitionTo(CardStrengthGameState nextState)
        {
            _currentState.Exit();
            _currentState = nextState;
            nextState.Enter();
        }

        private void Update()
        {
            if(_currentState != null)
                _currentState.Stay();
        }
        
        public void ChangeState(GameManagerStateType stateType)
        {
            switch (stateType)
            {
                case GameManagerStateType.Ready:
                    TransitionTo(_gameReadyState);
                    break;
                case GameManagerStateType.Playing:
                    TransitionTo(_gamePlayingState);
                    break;
                case GameManagerStateType.Clear:
                    TransitionTo(_gameClearState);
                    break;
                case GameManagerStateType.Over:
                    TransitionTo(_gameOverState);
                    break;
            }
        }
    }
}
