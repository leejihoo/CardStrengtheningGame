using System;
using Enum;
using Scene;
using UnityEngine;

namespace Main
{
    public class GameManager : Singleton<GameManager>
    {
        public Action OnGameStart;
        public Action OnGameReset;
        public Action OnGameClear;
        public Action OnGameOver;
    
        [SerializeField] private GameManagerStateMachine _gameManagerStateMachine;
        [SerializeField] private SceneManagerHelper _sceneManagerHelper;

        public override void Awake()
        {
            base.Awake();
            OnGameReset += LoadTitleScene;
        }

        private void OnDestroy()
        {
            // 이벤트 해제
            // OnGameStart = null;
            // OnGameReset = null;
            // OnGameClear = null;
            // OnGameOver = null;
        }

        public void ChangeState(GameManagerStateType stateType)
        {
            _gameManagerStateMachine.ChangeState(stateType);
        }

        public void ChangeState(string stateType)
        {
        
        }

        public void LoadTitleScene()
        {
            Debug.Log("타이틀 로드 작동");
            StartCoroutine(_sceneManagerHelper.LoadAsyncScene("TitleScene"));
        }

        public void LoadMainScene()
        {
            Debug.Log("작동");
            StartCoroutine(_sceneManagerHelper.LoadAsyncScene("MainScene"));
        }

        public void AnnounceGameClear()
        {
            ChangeState(GameManagerStateType.Clear);
        }
        
        public void AnnounceGameOver()
        {
            ChangeState(GameManagerStateType.Over);
        }
    }
}
