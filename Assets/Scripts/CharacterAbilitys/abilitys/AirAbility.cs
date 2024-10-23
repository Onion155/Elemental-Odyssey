using UnityEngine;

public class AirAbility : PlayerAbilityBaseState
{
    public override void EnterState(PlayerAbilityStateManager ability)
    {
        Debug.Log("Player is using Air");
    }
    public override void UpdateState(PlayerAbilityStateManager ability)
    {

    }
}
