using UnityEngine;

public class EnemyStateMachine 
{
    // ### THIS CONTROLS THE ENTERING AND EXITING OF STATES AS WELL AS WITCH ONE TO INITIALIZE IN ### //
    public EnemyState CurrentEnemyState {  get; set; } // referance to the enemy states

    // this will be the initial state it starts in 
    public void Initialize(EnemyState startingState)
    {
        CurrentEnemyState = startingState;
        CurrentEnemyState.EnterState();
    }

    // called when you want to enter a new state
    public void ChangeState(EnemyState newState) // called when you want to enter a new state
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = newState;
        CurrentEnemyState.EnterState();
    }
}

