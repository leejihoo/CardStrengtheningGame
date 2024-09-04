using Abstract;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(menuName = "ScriptableObject/State/GameOverState", fileName = "GameOverState")]
    public class GameOverState : CardStrengthGameState
    {
        public override void Enter()
        {
            GameManager.Instance.OnGameOver.Invoke();
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
