using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class WaterBullet : ProjectileBase
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            DealDamage(collision.gameObject);
            Debug.Log("Trying to deal damage");
            Destroy(gameObject);
        }
    }
}
