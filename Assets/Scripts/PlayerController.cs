using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Body;
    public BoxCollider2D Groundcheck;
    public LayerMask GroundMask;
    public LayerMask SlowedMask;

    public Transform WaterBullet; // this is the  projectile the player will spawn
    public float BulletDirection;

 
    private float groundDecay = 0.712f;// slowing effect for smooth movement
    private bool grounded; // touching ground is true
    private bool slowed; // this will slow them down and prevent them from jumping
    private float groundSpeed = 5f; // how fast the player can move
    private float jumpSpeed = 10f; // fast the player jumps

    private float moveX;
    private float moveY;

    // Update is called once per frame
    void Update()
    {
        GetInput();
        applyMovement();
    }
    
    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
    }

    // get inputs (old unity system)
    void GetInput()
    {
         // move around using old unity axis system
         moveX = Input.GetAxis("Horizontal");
         moveY = Input.GetAxis("Vertical");

    }

    // apply movement
    void applyMovement()
    {
        if (Mathf.Abs(moveX) > 0){
            Body.linearVelocity = new Vector2(moveX * groundSpeed, Body.linearVelocity.y);// this is to make it so it only changes the x axis and leaves the y axis if it is unchanged

            // make the player face direction its moving
            float direction = Mathf.Sign(moveX);
            transform.localScale = new Vector3(direction, 1, 1);
            BulletDirection = direction; // sends the direction over to the bullet
        }

        if (Input.GetButton("Jump") && grounded){
            Body.linearVelocity = new Vector2(Body.linearVelocity.x, jumpSpeed);
        }

    }
    
    // checks if touching ground layer
    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, GroundMask).Length > 0;
        slowed = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, SlowedMask).Length > 0;
    }

    // if touching ground layer then slow over time
    void ApplyFriction()
    {
        // slows the player
       if (slowed && Body.linearVelocity.y <= 0)
        {
            groundSpeed = 2f;
            Body.linearVelocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }
        // this applys friction 
        else if (grounded && Body.linearVelocity.y <= 0)
        {
            groundSpeed = 5f;
            Body.linearVelocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }
        

    }
}
