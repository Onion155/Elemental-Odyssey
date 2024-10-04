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
    public float drag;
    public bool grounded;

    public float JumpHight = 5f;
   

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

       if (Mathf.Abs(moveX) > 0){
            rb.linearVelocity = new Vector2(moveX*Speed,rb.linearVelocity.y);
        }

        if (Mathf.Abs(moveY) > 0){
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveY*Speed);
        }


    }

    private void FixedUpdate()
    {
        CheckGround();

        if (grounded)
        {
            rb.linearVelocity *= drag;
        }
        
    }

    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, GroundMask).Length > 0;
    }
}
