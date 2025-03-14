using UnityEngine;

public class CameraControls : MonoBehaviour
{
    private float followSpeed = 4f;
    public Transform player;
    private Vector2 xLimits = new Vector2(-12f, 12f);
    private Vector2 yLimits = new Vector2(-7f, 7f);
    private float yOffset = 2f; 

    void Update()
    {
        // Get the desired camera position
        Vector3 targetPosition = transform.position;
        targetPosition.x = Mathf.Clamp(player.position.x, xLimits.x, xLimits.y);
        targetPosition.y = Mathf.Clamp(player.position.y, yLimits.x, yLimits.y);

        // Update camera position
        transform.position = Vector3.Slerp(transform.position,new Vector3(targetPosition.x, targetPosition.y + yOffset, transform.position.z), followSpeed * Time.deltaTime);
    }

    private void FollowPlayer()
    {
        Vector3 newPos = new Vector3(player.position.x, player.position.y + 1f, transform.position.z);

        if (newPos.x < -24f || newPos.x > 24 )
        {
            newPos.x = transform.position.x;
        }
        if (newPos.y < -14f || newPos.y> 14f)
        {
            newPos.y = transform.position.y;
        }
        transform.position = Vector3.Slerp(transform.position, newPos, followSpeed * Time.deltaTime);
    }
}
