using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyChaseState : EnemyState
{

   
    public EnemyChaseState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("You have been spotted");
        enemy.MoveEnemy(new Vector2(0, 0)); // stops the enemy

    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        if (enemy.isWithinAttackingDistance) // if in attack range go to attack state
        {
            enemy.StateMachine.ChangeState(enemy.AttackState);
        }
        else if (!enemy.IsAggroed) // if not in chase range go back to idling
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

   
    
}
