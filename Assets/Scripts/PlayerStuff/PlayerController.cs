using System.Xml.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
public class PlayerController : MonoBehaviour
{
    #region Public variable
    [Header("Refernaces")]
    public Rigidbody2D Body;

    [Header("LayerMasks")]
    public BoxCollider2D Groundcheck;
    public LayerMask GroundMask;
    public LayerMask SlowedMask;

    [Header("ElementalBullets")]
    public GameObject Projectile;
    public Transform ProjectileList;
    public Transform ProjectileNode;
    public Elemental element;
    public GameObject Ab1;
    public GameObject Ab2;

    [Header("PlayerInputControls")]
    public PlayerControls PlayerControls;
    public InputAction move;
    public InputAction fire;
    public InputAction ability1;
    public InputAction ability2;
    public InputAction changeelement;
    #endregion
    #region Private Variables
    private float groundDecay = 0.712f;// slowing effect for smooth movement
    private bool grounded; // touching ground is true
    private bool slowed; // this will slow them down and prevent them from jumping
    private float groundSpeed = 5f; // how fast the player can move
    private float jumpSpeed = 10f; // fast the player jumps

    private Vector2 moveDirection;
   
    private int Firetimer;
    private int AbilityTimer1;
    private int AbilityTimer2;

    private bool isfacingRight = false;
    #endregion

    Animator animator;

    private void Awake()
    {
        PlayerControls = new PlayerControls(); 
    }
    private void OnEnable()
    {
        // movement
        move = PlayerControls.Player.Move;
        move.Enable();

        // abillitys and attack
        fire = PlayerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire; // this connects the action to the function

        ability1 = PlayerControls.Player.Ability1;
        ability1.Enable();
        ability1.performed += Ability1;

        ability2 = PlayerControls.Player.Ability2;
        ability2.Enable();
        ability2.performed += Ability2;

        // change element
        changeelement = PlayerControls.Player.ChangeElement;
        changeelement.Enable();
        changeelement.performed += ChangeElement;

    }
    private void OnDisable()
    {
        move.Disable();
        fire.Disable();
        ability1.Disable();
        ability2.Disable();
        changeelement.Disable();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        GetInput();
        ApplyMovement();

        if (Firetimer > 0) // these if statements might need to be optimised
         {
            Firetimer--;
         }
        if (AbilityTimer1 > 0)
        {
            AbilityTimer1--;
        }
        if (AbilityTimer2 > 0)
        {
            AbilityTimer1--;
        }

    }

    private void FixedUpdate()
    {
        CheckGround();
        ApplyFriction();
        animator.SetFloat("XVelocity",Mathf.Abs(Body.velocity.x));// Abs sets the value to its absolute value so it will always be a positive value
        animator.SetFloat("YVelocity",Body.velocity.y);
    }

    #region Movemnt
    // get inputs (old unity system)
    void GetInput()
    {
        // move around using new unity input system
        moveDirection = move.ReadValue<Vector2>();

    }

    
    // apply movement
    void ApplyMovement()
    {
        if (Mathf.Abs(moveDirection.x) > 0){
            Body.velocity = new Vector2(moveDirection.x * groundSpeed, Body.velocity.y);// this is to make it so it only changes the x axis and leaves the y axis if it is unchanged

            FlipSprite();
        }

        if (Input.GetButton("Jump") && grounded){ // this is still done with old input system
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
        if (isfacingRight && moveDirection.x < 0f || !isfacingRight && moveDirection.x > 0f)
        {
            isfacingRight = !isfacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
    #endregion

    #region action functions
    private void Fire(InputAction.CallbackContext context)
    {
      if (Firetimer <= 0)
         {
            GameObject newProjectile = Instantiate(Projectile, ProjectileNode);
            newProjectile.transform.SetParent(ProjectileList);
            Firetimer = 100;
         }
        
    }

    private void Ability1(InputAction.CallbackContext context)
    {
        if (AbilityTimer1 <= 0)
        {
            Debug.Log("Ability1");
            GameObject newProjectile = Instantiate(Ab1, ProjectileNode);
           if(Ab1.GetComponent<ProjectileBase>() != null) // if not a projectile it should sort its own parent out if needed
            {
                newProjectile.transform.SetParent(ProjectileList);
            }
            AbilityTimer1 = 1000;
        }
    }
    private void Ability2(InputAction.CallbackContext context)
    {
        if (AbilityTimer1 <= 0)
        {
            Debug.Log("Ability2");
            GameObject newProjectile = Instantiate(Ab2, ProjectileNode);
            newProjectile.transform.SetParent(ProjectileList);
            AbilityTimer2 = 1000;
        }
    }

    private void ChangeElement(InputAction.CallbackContext context)
    {
        // should change the states here or tell the state machine what to change to 
        Debug.Log("Trying to change Element" );
        element.abilitynum++;
        if(element.abilitynum >4)
        {
            element.abilitynum = 0;
        }

        element.CheckState();
    }
    #endregion
}