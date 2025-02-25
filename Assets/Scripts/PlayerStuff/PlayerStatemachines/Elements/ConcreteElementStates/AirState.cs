using UnityEngine;

public class AirState : ElementalState
{
    public AirState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Current Element: Air");

        //ability and bullet
        element.PC.Projectile = element.ElementalBullets[1];
        element.PC.Ab1 = element.ElementalAbilities1[1];
        
        // stats
        element.PlayerStats.SetMaxH(70);
        element.PlayerStats.SetDefense(1);
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
