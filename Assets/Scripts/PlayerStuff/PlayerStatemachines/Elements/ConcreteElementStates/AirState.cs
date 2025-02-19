using UnityEngine;

public class AirState : ElementalState
{
    public AirState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        element.PC.Projectile = element.ElementalBullets[1];
        Debug.Log("Current Element: Air");
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
