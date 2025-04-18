using UnityEngine;

public class FlyingEnemyIdle : State
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

        Debug.Log("Entered the flying idle stage");
        body.velocity = Vector2.zero;
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
            body.velocity = ebase.moveSpeed * direction;
        }

    }
    public override void StateFixedUpdate()
    {

    }
    public override void Exit()
    {
        body.velocity = Vector2.zero;
        Debug.Log("Exiting Flying Idle");
    }
    void PickNewDestination()
    {
        Debug.Log("Trying to find an new point");
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

            targetPosition = candidate;
            return;
        }

        // If no valid destination found, stay put
        targetPosition = transform.position;
        Debug.Log("Failed To find a valid destination");
        
    }
}
