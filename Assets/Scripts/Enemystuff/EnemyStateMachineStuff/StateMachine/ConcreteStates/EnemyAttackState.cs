using UnityEngine;

public class EnemyAttackState : EnemyState 
{
    private int attackcooldown = 0;
    public EnemyAttackState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine) // this is basicly an onAawake function
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();
        Debug.Log("Enemy is attacking you");
        

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if(!enemy.isWithinAttackingDistance)
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        if (attackcooldown > 0)
        {
            attackcooldown--;
        }
        else if (attackcooldown <= 0)
        {
            enemy.PlayerStats.TakeDamage(enemy.EnemyDamagePerHit);
            attackcooldown = 1000;
        }
    }
}
