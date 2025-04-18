using TMPro;
using UnityEngine;

public class EnemyIdle : State
{
    

    public float wanderRadius = 5f;
    public float stoppingDistance = 0.1f;
    public float waitTime = 1f;
    public LayerMask obstacleLayer;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1f;

    private Vector2 targetPosition;
    private float waitTimer;
    private int maxTries = 10;
    public override void Enter()
    {
       
        Debug.Log("Entered the idle stage");
        PickNewDestination();
    }
    public override void StateUpdate()
    {
        if (ebase.IsAggroed) // if aggro is true go to EnemyChaseState
        {
            ebase.ChangeState(ebase.ChaseState);
        }

        Vector2 currentPosition = body.position;
       // float distance = Vector2.Distance(currentPosition, targetPosition);

        if ((currentPosition - targetPosition).sqrMagnitude < stoppingDistance)
        {
            
             waitTimer += Time.fixedDeltaTime;
             if (waitTimer >= waitTime)
              {
                
                PickNewDestination();
                waitTimer = 0f;
              }
        }
        else
        {
            Vector2 direction = (targetPosition - currentPosition).normalized;
            body.velocity = new Vector2(direction.x * ebase.moveSpeed, body.velocity.y);
        }

    }
    public override void StateFixedUpdate()
    {
     
    }
    public override void Exit()
    {
        Debug.Log("Exiting GroundIdle");
        body.velocity = Vector2.zero;
    }
    void PickNewDestination()
    {
        for (int i = 0; i < maxTries; i++)
        {
            Vector2 randomOffset = Random.insideUnitCircle * wanderRadius;
            Vector2 candidate = (Vector2)transform.position + randomOffset;

            // Check for wall
            RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, randomOffset.normalized, randomOffset.magnitude, obstacleLayer);
            if (wallCheck.collider != null)
            {
                continue; // Wall in the way, try again
            }

            // Check for ground under 
            RaycastHit2D groundCheck = Physics2D.Raycast(candidate, Vector2.down, groundCheckDistance, groundLayer);
            if (groundCheck.collider == null)
            {
                continue; // No ground, skip this one
            }

            targetPosition = new Vector2(candidate.x, body.position.y);
            return;
        }

        // If no valid destination found, stay put
        targetPosition = transform.position;
    }


}
