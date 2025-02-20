using UnityEngine;

public class FireState : ElementalState
{
    public FireState(Elemental element, ElementalStateMachine elementstateMachine) : base(element, elementstateMachine)
    {
    }
    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Current Element: Fire");
        // ability and bullet
        element.PC.Projectile = element.ElementalBullets[3];
        element.PC.Ab1 = element.ElementalAbilities1[3];

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
