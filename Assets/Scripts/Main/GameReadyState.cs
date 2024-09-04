using Abstract;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(menuName = "ScriptableObject/State/GameReadyState", fileName = "GameReadyState")]
    public class GameReadyState : CardStrengthGameState
    {
        public override void Enter()
        {
            GameManager.Instance.OnGameReset.Invoke();
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
