using UnityEngine;

public class WaterWall : ProjectileBase
{
    private void Awake()
    {
        CheckDirection();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
