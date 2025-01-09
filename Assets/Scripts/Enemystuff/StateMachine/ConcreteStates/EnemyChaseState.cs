using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyChaseState : EnemyState
{

    private float Fly = 0;
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

        if (!enemy.IsAggroed) // if no longer aggro then go back to idle
        {
            enemy.StateMachine.ChangeState(enemy.IdleState);
        }

    }

   
    
}
