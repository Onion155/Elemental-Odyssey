using UnityEngine;

public class ElementalBullet :ProjectileBase
{
    private void Awake()
    {
        CheckDirection();
    }
    
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
