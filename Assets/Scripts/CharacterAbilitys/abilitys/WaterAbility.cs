using System;
using UnityEditor.Playables;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class WaterAbility : PlayerAbilityBaseState
{
    
  public override void EnterState(PlayerAbilityStateManager ability)
    {
        Debug.Log("Player is using Water");
    }
   public override void UpdateState(PlayerAbilityStateManager ability)
    {
        Inputhandler(ability); // if player presses Q spawns water bullet if E the other ability
    }

    void Inputhandler(PlayerAbilityStateManager ability)
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            ability.element.CreateObject();
            // when the player presses q it should shoot a bullet
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            // when the player presss e should use ability 
        }
    }
}
