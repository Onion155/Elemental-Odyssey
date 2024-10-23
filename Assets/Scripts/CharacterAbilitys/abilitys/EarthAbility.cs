using UnityEngine;

public class EarthAbility : PlayerAbilityBaseState
{
    public override void EnterState(PlayerAbilityStateManager ability)
    {
        Debug.Log("Player is using Earth");
    }
    public override void UpdateState(PlayerAbilityStateManager ability)
    {

    }
}
