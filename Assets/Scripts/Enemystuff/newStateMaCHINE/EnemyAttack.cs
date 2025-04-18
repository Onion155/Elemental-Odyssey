using UnityEngine;
using System.Collections;

public class EnemyAttack : State
{
     int attackcooldown = 0;

    public override void Enter()
    {
        Debug.Log("EnemyAttacking");
        attackcooldown = 0;
        body.velocity = Vector2.zero;
    }
    public override void StateUpdate()
    {
       
    }
    public override void StateFixedUpdate()
    {
        if (!ebase.isWithinAttackingDistance)
        {
           ebase.ChangeState(ebase.ChaseState);
        }

        if (attackcooldown > 0)
        {
            attackcooldown--;
            Debug.Log("Enemy attacking is on cooldown");
        }
        else if (attackcooldown <= 0)
        {
            Debug.Log("Enemy is trying to deal damage");
            ebase.PlayerStats.TakeDamage(ebase.Damage);
            attackcooldown = 200;
        }
    }
    public override void Exit()
    {

    }

    
}
