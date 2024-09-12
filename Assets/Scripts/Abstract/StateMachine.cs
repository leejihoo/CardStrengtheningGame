using Interface;
using UnityEngine;

namespace Abstract
{
    public abstract class StateMachine : MonoBehaviour
    {
        protected IState CurrentState { get; private set; }
        
        protected virtual void Initialize(IState startingState)
        {
            CurrentState = startingState;
            CurrentState.Enter();
        }

        protected virtual void TransitionTo(IState nextState)
        {
            CurrentState.Exit();
            CurrentState = nextState;
            nextState.Enter();
        }
        
        protected virtual void Update()
        {
            if(CurrentState != null)
                CurrentState.Stay();
        }
    }
}
