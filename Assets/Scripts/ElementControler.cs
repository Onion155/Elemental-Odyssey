using Unity.Collections.LowLevel.Unsafe;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ElementControler : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform firePoint;
    public GameObject Projecttile;


    private float lifespan = 100;
    public float ProjectileSpeed = 5;

    private void Start()
    {
      rb = GetComponent<Rigidbody2D>();

      rb.linearVelocity = transform.right * ProjectileSpeed;
    }

    private void FixedUpdate()
    {
        // deletes the object after a little while
        if (lifespan >= 0)
        {
            lifespan -= 1;
        }
        else if (lifespan <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8)// if in enemy layer do damage
        {
            Debug.Log("Hit an Enemy");
            // do something
        }
        else // this destroys the bullet if it hits something other than the enemy
        {
            Debug.Log("hit something");
           // Destroy(this.gameObject);
        }
    }

    public float GetLifespan()
    {
        return lifespan;
    }
    public float SetLifespan(float a)
    {
        return (lifespan = a);
    }

    public float GetProjSpeed()
    {
        return ProjectileSpeed;
    }

    public void CreateObject()// creates object
    {
        // creates the object, spawns it on the body and faces the mouse direction
        Instantiate(Projecttile, firePoint.position, Quaternion.identity);
    }
    public void DestroyObject()// destroy object
    {
        Destroy(this);
    }
}
