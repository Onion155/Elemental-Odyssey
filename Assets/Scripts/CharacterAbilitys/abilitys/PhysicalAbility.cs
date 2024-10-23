using UnityEngine;

public class PhysicalAbility : PlayerAbilityBaseState
{
  public override void EnterState(PlayerAbilityStateManager ability)
    {
        Debug.Log("Player is using BRUTE FORCE. FUCK YEA!!!");
    }
   public override void UpdateState(PlayerAbilityStateManager ability)
    {

    }
}
