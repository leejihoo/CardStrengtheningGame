using Abstract;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(menuName = "ScriptableObject/State/GamePlayingState", fileName = "GamePlayingState")]
    public class GamePlayingState : CardStrengthGameState
    {
        public override void Enter()
        {
            GameManager.Instance.OnGameStart.Invoke();
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
