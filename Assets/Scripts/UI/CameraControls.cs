using UnityEngine;

public class CameraControls : MonoBehaviour
{
    
    public Transform player;
    private Vector2 xLimits = new (-12f, 12f);
    private Vector2 yLimits = new (-7f, 7f);
    private const float yOffset = 2f; 
    private const float followSpeed = 4f;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        // Camera pos and borders
        Vector3 targetPosition = transform.position;
        targetPosition.x = Mathf.Clamp(player.position.x, xLimits.x, xLimits.y);
        targetPosition.y = Mathf.Clamp(player.position.y, yLimits.x, yLimits.y);

        // Update camera position
        transform.position = Vector3.Slerp(transform.position, new Vector3(targetPosition.x, targetPosition.y + yOffset, transform.position.z), followSpeed * Time.deltaTime);
    }

    // called when you change rooms
    public void SetLimits(Vector2 xlimit , Vector2 ylimit)
    {
        xLimits = new Vector2(xlimit.x - 12, xlimit.y + 12);
        yLimits = new Vector2(ylimit.x - 7, ylimit.y + 7);
    }
}
