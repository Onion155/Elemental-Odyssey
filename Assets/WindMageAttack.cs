using System.Threading;
using TMPro;
using UnityEngine;

public class WindMageAttack : State
{
    public GameObject[] Walls;
    public int Raduis = 5;
    public int maxTries = 10;
    public LayerMask obstacleLayer;
    private Vector2 targetPosition;
    public override void Enter()
    {
        // find locations for the walls then set them to active
        CheckForWallLocations();
    }
    public override void StateUpdate()
    {
     // hide the walls if they have been around enough  
    }
    public override void StateFixedUpdate()
    {

    }
    public override void Exit()
    {
        
    }

    private void CheckForWallLocations()
    {
        foreach(GameObject wall in Walls)
        {
            Debug.Log(wall.name + ": currently checking for possible spawn places");
            for (int i = 0; i < maxTries; i++)
            {
                Debug.Log("Currently on attempt- " + i);
                Vector2 randomOffset = Random.insideUnitCircle * Raduis;
                Vector2 candidate = (Vector2)transform.position + randomOffset;

                // Check for wall
                RaycastHit2D wallCheck = Physics2D.Raycast(transform.position, randomOffset.normalized, randomOffset.magnitude, obstacleLayer);
                if (wallCheck.collider != null)
                {
                    continue; // Wall in the way, try again
                }
                targetPosition = candidate;
                setwall(wall);
                break;
            }
            
        }
    }
    private void setwall(GameObject wall)
    {
        wall.SetActive(true);
        Debug.Log("Found a location-" + targetPosition);
        wall.transform.position = targetPosition;
    }
}
