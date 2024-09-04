using System;
using Enum;
using Interface;
using Main;
using UnityEngine;
using UnityEngine.UI;

namespace Util
{
    public class OneButtonPopup : Popup
    {
        public Button button;

        private void Awake()
        {
            RegisterButtonEvent();
        }
        
        private void RegisterButtonEvent()
        {
            button.onClick.AddListener(() => GameManager.Instance.ChangeState(GameManagerStateType.Ready));
        }
    }
}
