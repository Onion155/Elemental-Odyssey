using UnityEngine;

// video to this link - https://www.youtube.com/watch?v=RQd44qSaqww
public interface IEnemyMovable
{
    Rigidbody2D Rb { get; set; }

    bool IsFacingRight { get; set; }

    void MoveEnemy(Vector2 velocity);

    void CheckForLeftOrRightFacing(Vector2 velocity);
}
