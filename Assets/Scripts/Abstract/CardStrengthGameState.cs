using Interface;
using UnityEngine;

namespace Abstract
{
    public abstract class CardStrengthGameState: ScriptableObject, IState
    {
        public abstract void Enter();

        public abstract void Stay();

        public abstract void Exit();
    }
}
