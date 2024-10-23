using UnityEngine;

// this is the Abstract state that the other states will be derived from

public abstract class PlayerAbilityBaseState 
{
    public abstract void EnterState(PlayerAbilityStateManager ability);

    public abstract void UpdateState(PlayerAbilityStateManager ability);

}
