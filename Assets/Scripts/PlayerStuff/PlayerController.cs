using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    [Header("Refernaces")]
    public Rigidbody2D Body;

    [Header("LayerMasks")]
    public BoxCollider2D Groundcheck;
    public LayerMask GroundMask;
    public LayerMask SlowedMask;

    [Header("ElementalBullets")]
    public GameObject[] ProjectileList;
    public Transform Projectiles;
    public Transform ProjectileNode;
 
    private float groundDecay = 0.712f;// slowing effect for smooth movement
    private bool grounded; // touching ground is true
    private bool slowed; // this will slow them down and prevent them from jumping
    private float groundSpeed = 5f; // how fast the player can move
    private float jumpSpeed = 10f; // fast the player jumps

    private float moveX;
    private float moveY;

    private bool Fire1;
    private int Fire1timer;

    private bool isfacingRight = false;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        applyMovement();
        checkShooting();
    }
    
    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        animator.SetFloat("XVelocity",Mathf.Abs(Body.velocity.x));// Abs sets the value to its absolute value so it will always be a positive value
        animator.SetFloat("YVelocity",Body.velocity.y);
    }

    // get inputs (old unity system)
    void GetInput()
    {
         // move around using old unity axis system
         moveX = Input.GetAxis("Horizontal");
         moveY = Input.GetAxis("Vertical");

        // shooting inputs
        Fire1 = Input.GetButton("Fire1");

    }

    void checkShooting()
    {
        if(Fire1timer > 0)
        {
            Fire1timer--;
        }
        else if(Fire1 && Fire1timer <= 0)
        {
            GameObject newProjectile = Instantiate(ProjectileList[0], ProjectileNode);
            newProjectile.transform.SetParent(Projectiles);
            Fire1timer = 30;
        }
    }
    // apply movement
    void applyMovement()
    {
        if (Mathf.Abs(moveX) > 0){
            Body.velocity = new Vector2(moveX * groundSpeed, Body.velocity.y);// this is to make it so it only changes the x axis and leaves the y axis if it is unchanged

            FlipSprite();
        }

        if (Input.GetButton("Jump") && grounded){
            Body.velocity = new Vector2(Body.velocity.x, jumpSpeed);
            animator.SetBool("isJumping", !grounded);
        }

    }
    
    // checks if touching ground layer
    void CheckGround()
    {
        grounded = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, GroundMask).Length > 0;
        animator.SetBool("isJumping", !grounded);
        slowed = Physics2D.OverlapAreaAll(Groundcheck.bounds.min, Groundcheck.bounds.max, SlowedMask).Length > 0;
    }

    // if touching ground layer then slow over time
    void ApplyFriction()
    {
        // slows the player
       if (slowed && Body.velocity.y <= 0)
        {
            groundSpeed = 2f;
            Body.velocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }
        // this applys friction 
        else if (grounded && Body.velocity.y <= 0)
        {
            groundSpeed = 5f;
            Body.velocity *= groundDecay;// checks if player is in contact with ground layer if they are they will get drag(slowdown over time)
        }
        

    }

    void FlipSprite()
    {
        if (isfacingRight && moveX < 0f || !isfacingRight && moveX > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
