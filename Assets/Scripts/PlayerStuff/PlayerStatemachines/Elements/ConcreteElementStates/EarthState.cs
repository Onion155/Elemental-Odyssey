using UnityEngine;

public class EarthState : ElementalState
{
    public EarthState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        element.PC.Projectile = element.ElementalBullets[2];
        Debug.Log("Current Element: Earth");
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
