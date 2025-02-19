using UnityEngine;

public class FireState : ElementalState
{
    public FireState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        element.PC.Projectile = element.ElementalBullets[3];
        Debug.Log("Current Element: Fire");
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
