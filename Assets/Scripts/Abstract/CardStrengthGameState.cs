using Enum;
using Interface;
using UnityEngine;

namespace Abstract
{
    public abstract class CardStrengthGameState: ScriptableObject, IState
    {
        [field: SerializeField] public GameManagerStateType StateType { get; set; }
        public abstract void Enter();

        public abstract void Stay();

        public abstract void Exit();
    }
}
