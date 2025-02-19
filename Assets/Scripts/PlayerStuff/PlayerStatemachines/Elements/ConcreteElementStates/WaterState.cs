using UnityEngine;
using UnityEngine.Rendering;

public class WaterState : ElementalState
{
    
    public WaterState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Current Element: Water");

        element.PC.Projectile = element.ElementalBullets[0];
        element.PC.Ab1 = element.ElementalAbilities1[0];
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
    }
}
