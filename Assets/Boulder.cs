using UnityEngine;

public class Boulder : ProjectileBase
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            DealDamage(collision.gameObject);
            Debug.Log("Trying to deal damage");
        }
    }
}
