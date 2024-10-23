using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class ElementControler : MonoBehaviour
{
    public Rigidbody2D rb;
    private float lifespan = 100;
    private float ProjectileSpeed = 5;


    private void Awake()
    {
        // needs to spawn where the player is standing and then it needs to go towards the mouse( the mouse coards at the time of being made)
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)); // tells us where the mouse is 
        Debug.Log("Mouse World Position: " + mouseWorldPosition);
    }
    private void FixedUpdate()
    {
        // deletes the object after a little while
        if (lifespan >= 0)
        {
            rb.linearVelocityX = ProjectileSpeed;
            lifespan -= 1;
        }
        else if (lifespan <= 0)
        {
            Destroy(this.gameObject);
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
            Destroy(this.gameObject);
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

    public void CreateObject(Rigidbody2D body)
    {
        Instantiate(this.gameObject, body.transform.position,Quaternion.identity);
    }

    public void DestroyObject()
    {
        Destroy(this);
    }
}
