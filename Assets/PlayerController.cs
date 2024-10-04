using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{

    public Rigidbody2D rb;
    public BoxCollider2D Groundcheck;
    public LayerMask GroundMask;
    public float Speed = 5f;
    [Range(0f, 1f)]
    public float groundDecay;
    public bool grounded;

    public float JumpHight = 5f;

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
        ApplyGrounded();
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
            rb.linearVelocity = new Vector2(moveX*Speed,rb.linearVelocity.y);// this is to make it so it only changes the x axis and leaves the y axis if it is unchanged
        }

        if (Mathf.Abs(moveY) > 0 && grounded){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveY*Speed);
        }

    }
    
    // checks if touching ground layer
    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, GroundMask).Length > 0;
    }

    // if touching ground layer then slow over time
    void ApplyGrounded()
    {
        if (grounded)
        {
            rb.linearVelocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }

    }
}
