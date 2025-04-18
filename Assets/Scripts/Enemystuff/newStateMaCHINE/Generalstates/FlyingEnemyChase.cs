using UnityEngine;

public class FlyingEnemyChase : State
{
    [SerializeField] private Transform playerPos;

    public override void Enter()
    {
        Debug.Log("Flying Enemy entered chasestate");
        ebase.body.velocity = Vector2.zero;
        playerPos = ebase.PlayerStats.gameObject.transform.transform;
    }
    public override void StateUpdate()
    {

    }
    public override void StateFixedUpdate()
    {
        if (ebase.isWithinAttackingDistance) // if in attack range go to attack state
        {
            ebase.ChangeState(ebase.AttackState);
        }
        else if (!ebase.IsAggroed) // if not in chase range go back to idling
        {
            ebase.ChangeState(ebase.IdleState);
        }
        ChasePlayer();
    }
    public override void Exit()
    {
        ebase.body.velocity = Vector2.zero;
    }
    private void ChasePlayer()
    {
        Vector2 targetPosition = new Vector2(playerPos.position.x, playerPos.position.y);

        Vector2 currentPosition = body.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;

       
        body.velocity = direction* ebase.moveSpeed;
    }
}
