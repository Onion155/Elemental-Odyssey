using UnityEngine;

public class ElementControler : MonoBehaviour
{

    public Rigidbody2D rb;
    private PlayerController Player;
    public float lifespan = 100;
    private float ProjectileSpeed = 5;

    private void Awake() // this needs to be changed so the bullet goes towards the mouse and not the player direaction
    {
        //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //transform.localScale = new Vector3(Player.BulletDirection, 1, 1);
        //ProjectileSpeed *= Player.BulletDirection;
        // Convert to world coordinates
        // Retrieve mouse position in screen coordinates

        // this tells the game cowardantes of the mouse using the above values
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
        Debug.Log("Mouse World Position: " + mouseWorldPosition);
    }

    private void FixedUpdate()
    {
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
}
