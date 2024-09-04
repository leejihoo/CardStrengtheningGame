using Abstract;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(menuName = "ScriptableObject/State/GameClearState", fileName = "GameClearState")]
    public class GameClearState : CardStrengthGameState
    {
        public override void Enter()
        {
            GameManager.Instance.OnGameClear.Invoke();
        }

        public override void Stay()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}
