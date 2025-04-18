using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RangedEnemyAttack : State
{
    private float Firetimer = 0;
    public GameObject Projectile;
    public Transform ProjectileNode;
    private List<GameObject> activeProjectiles = new List<GameObject>();
    private float stoppingDistance = 0.1f;

    public override void Enter()
    {
        Debug.Log("Flying Enemy entered chasestate");
        ebase.body.velocity = Vector2.zero;
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

        CreateBullet();

        for (int i = activeProjectiles.Count - 1; i >= 0; i--)
        {
            GameObject proj = activeProjectiles[i];

            if (proj == null) // It was destroyed
            {
                activeProjectiles.RemoveAt(i);
                continue;
            }

            Vector2 targetPosition = proj.GetComponent<EnemyBulletControl>().TargetPos;
            Vector2 currentPosition = proj.transform.position;
            Vector2 direction = (targetPosition - currentPosition).normalized;
            
            if ((currentPosition - targetPosition).sqrMagnitude < stoppingDistance )
            {
                Destroy(proj);
                continue;
            }

            proj.GetComponent<EnemyBulletControl>().MoveBullet(direction);
        }
    }
    public override void Exit()
    {
        activeProjectiles.Clear();
    }

    private void CreateBullet()
    {
        if (Firetimer <= 0)
        {
            GameObject newProjectile = Instantiate(Projectile, ProjectileNode.position, Quaternion.identity);

            // give it an end destination
            Vector2 targetPosition = ebase.PlayerStats.gameObject.transform.position;
            newProjectile.GetComponent<EnemyBulletControl>().TargetPos = targetPosition;

            newProjectile.transform.SetParent(body.transform);

            // Add to list
            activeProjectiles.Add(newProjectile);
            Firetimer = 100;
        }
        else Firetimer--;
    }
}
