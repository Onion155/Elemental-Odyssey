using UnityEngine;

public class FireAbility : PlayerAbilityBaseState
{
    public override void EnterState(PlayerAbilityStateManager ability)
    {
        Debug.Log("Player is using Fire");
    }
    public override void UpdateState(PlayerAbilityStateManager ability)
    {

    }
}
