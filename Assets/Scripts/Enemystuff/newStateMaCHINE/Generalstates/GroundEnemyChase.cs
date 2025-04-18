using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GroundEnemyChase : State
{
    [SerializeField] private Transform playerPos;

    public override void Enter()
    {
        Debug.Log("Ground Enemy entered chase state");
        playerPos = ebase.PlayerStats.gameObject.transform.transform;
       
    }
    public override void StateUpdate()
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
    public override void StateFixedUpdate()
    {
        
    }
    public override void Exit()
    {
        body.velocity = Vector2.zero;
    }
private void ChasePlayer()
    {
        Vector2 targetPosition = new Vector2(playerPos.position.x, ebase.transform.position.y);

        Vector2 currentPosition = body.position;
        Vector2 direction = (targetPosition - currentPosition).normalized;

        body.velocity = new Vector2(direction.x * ebase.moveSpeed, body.velocity.y);
    }

}
