using Abstract;
using UnityEngine;

namespace Main
{
    [CreateAssetMenu(menuName = "ScriptableObject/State/GamePlayingState", fileName = "GamePlayingState")]
    public class GamePlayingState : CardStrengthGameState
    {
        public override void Enter()
        {
            if (GameManager.Instance == null)
            {
                Debug.Log("GameManager.Instance가 null 입니다. ");
            }

            if (GameManager.Instance.OnGameStart == null)
            {
                Debug.Log("GameManager.Instance.OnGameStart가 null 입니다. ");
                return;
            }
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
