using UnityEngine;

public class EarthState : ElementalState
{
    public EarthState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Current Element: Earth");

        //ability and bullet
        element.PC.Projectile = element.ElementalBullets[2];
        element.PC.Ab1 = element.ElementalAbilities1[2];

        // stats
        element.PlayerStats.SetMaxH(200);
        element.PlayerStats.Heal(50);
        element.PlayerStats.SetDefense(4);
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
