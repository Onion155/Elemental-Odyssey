using UnityEngine;

public class FireBullet : ProjectileBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
