using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Body;
    public BoxCollider2D Groundcheck;
    public LayerMask GroundMask;


    [Range(0f, 1f)] 
    public float groundDecay = 0.89f;
    private bool grounded;
    public float groundSpeed = 5f;
    public float jumpSpeed;

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
        }

        if (Input.GetButton("Jump") && grounded){
            Body.linearVelocity = new Vector2(Body.linearVelocity.x, jumpSpeed);
        }

    }
    
    // checks if touching ground layer
    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, GroundMask).Length > 0;
    }

    // if touching ground layer then slow over time
    void ApplyFriction()
    {
        if (grounded && moveX == 0 && Body.linearVelocity.y <= 0)
        {
            Body.linearVelocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }

    }
}
