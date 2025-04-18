using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public Rigidbody2D RB;
    private Vector2 ProjectileSpeed = new Vector2(5 , 5);
    public Vector2 TargetPos;
    private void Start()
    {
    }

    private void Awake()
    {
        //CheckDirection();
    }
    private void Update()
    {
       
    }
    public void MoveBullet(Vector2 velocity)
    {

        RB.velocity = velocity * ProjectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<CharacterStatBase>().TakeDamage(5);
            Destroy(gameObject);
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
    }
    
}
