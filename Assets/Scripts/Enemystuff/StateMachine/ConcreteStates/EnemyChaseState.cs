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
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();

        Fly += 0.1f;
        enemy.MoveEnemy(new Vector2(0, Fly));
    }

   
    
}
