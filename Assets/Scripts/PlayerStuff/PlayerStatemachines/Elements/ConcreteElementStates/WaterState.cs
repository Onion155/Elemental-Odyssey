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
        // ability and bullets
        element.PC.Projectile = element.ElementalBullets[0];
        element.PC.Ab1 = element.ElementalAbilities1[0];

        // stats
        element.PlayerStats.SetMaxH(150);
        element.PlayerStats.Heal(50);
        element.PlayerStats.SetDefense(3);

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
