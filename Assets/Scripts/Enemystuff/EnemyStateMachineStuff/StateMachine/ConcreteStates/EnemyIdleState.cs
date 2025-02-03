using UnityEngine;

public class EnemyIdleState : EnemyState
{
    private Vector3 _targetPos;
    private Vector3 _direction;
    private Vector3 _RandomPos;

    public EnemyIdleState(Enemy enemy, EnemyStateMachine enemyStateMachine) : base(enemy, enemyStateMachine)
    {
    }

    public override void AnimationTriggerEvent(Enemy.AnimationTriggerType triggerType)
    {
        base.AnimationTriggerEvent(triggerType);
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Enemy is idling");
        _direction = Vector3.zero;
        // need to wait unttil they hit the ground or force them to the floor and then do the _targetPos
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate() 
    {
        base.FrameUpdate();

        if ( enemy.IsAggroed) // if aggro is true go to EnemyChaseState
        {
            enemy.StateMachine.ChangeState(enemy.ChaseState);
        }

        
        _direction = (_targetPos - enemy.transform.position).normalized; // gives is the vecot dirction for the enemy to go to the point

        enemy.MoveEnemy(_direction * enemy.RandomeMovementSpeed);

        if ((enemy.transform.position - _targetPos).sqrMagnitude < 0.01f) // if at point find another point to move to 
        {
            GetRandomePointInCircle();
        }
        else if(_targetPos == Vector3.zero)
        {
            GetRandomePointInCircle();
        }
    }

    

   private void GetRandomePointInCircle() // finds a random point in the circle 
    {
        _targetPos = enemy.Rb.position + new Vector2(UnityEngine.Random.insideUnitCircle.x, 0) * enemy.RandomMovementRange;
    }

    
}
