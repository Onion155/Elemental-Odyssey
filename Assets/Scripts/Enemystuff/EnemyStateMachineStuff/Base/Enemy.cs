using UnityEditor;
using UnityEngine;

// video to this link - https://www.youtube.com/watch?v=RQd44qSaqww

public class Enemy : MonoBehaviour, IDamageAble, IEnemyMovable, ITriggerCheckable
{
    //### THIS IS THE BASE FOR ALL ENEMIES, ENEMYS SHOULD HAVE THEIR OWN SCRIPT THAT INHERIT FROM THIS SCRIPT ###//

    // Damage and Die
    [field: SerializeField] public float MaxHealth { get; set; } = 100f; // the filed serialzed is there so you can look at it from the unity window like it was public (but you wont be able to change it as if it was private
    public float CurrentHealth { get; set; }

    

    // movemment , facing
    public Rigidbody2D Rb { get; set; }
    public CharacterStatBase PlayerStats { get; set; }

    public bool IsFacingRight { get; set; } = false; // all enemies should start by facingf left 

    #region State Machine Variables
    public EnemyStateMachine StateMachine { get; set; }
    public EnemyChaseState ChaseState { get; set; }
    public EnemyIdleState IdleState { get; set; }
    public EnemyAttackState AttackState { get; set; }
    #endregion

    #region Distance checks
    public bool IsAggroed { get; set; }
    public bool isWithinAttackingDistance { get; set; }
    #endregion

    #region Idle Variables 
    public float RandomMovementRange = 1f; // how far will the enemy move each time while in idle
    public float RandomeMovementSpeed = 1f; // how fast it moves to those places
    #endregion

    #region Attack Variables 
    public int EnemyDamagePerHit = 1;
    #endregion

    private void Awake()
    {
        StateMachine = new EnemyStateMachine();

        IdleState = new EnemyIdleState(this, StateMachine);
        ChaseState = new EnemyChaseState(this, StateMachine);
        AttackState = new EnemyAttackState(this, StateMachine);
    }
    // Damage and Die
    private void Start()
    {
        CurrentHealth = MaxHealth;

        Rb = GetComponent<Rigidbody2D>();
        Invoke("SetReferances", 0.1f); // makes it wait 1millisecond before looking for the player because he is spawned in before then

        StateMachine.Initialize(IdleState); // gives the initial state 
    }
    private void SetReferances()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatBase>();
    }
    private void Update()
    {
        StateMachine.CurrentEnemyState.FrameUpdate(); // allows you to use update in whatever class your in 
    }

    private void FixedUpdate()
    {
       
    }

    #region Health and die function
    public void Damage(float damageAmount)
    {
        CurrentHealth -= damageAmount;
        Debug.Log("Enemy took Damage- " + damageAmount);

        if (CurrentHealth <= 0f)
        {
            Die();
        }
    }

    public void Die()
    {
       Destroy(gameObject);
    }

    #endregion

 
    #region movement and facing

    // apply the movement to the enemy 
    public void MoveEnemy(Vector2 velocity) // Velocity is x,y
    {
        Rb.velocity = new Vector2 (velocity.x, Rb.velocity.y); // we just use x of velocity here and then y is kept to the current one so we have gravity applied
        CheckForLeftOrRightFacing(velocity);
    }

    public void CheckForLeftOrRightFacing(Vector2 velocity)
    {
        if (IsFacingRight && velocity.x < 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z); // makes it face right if not moving
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
        else if (!IsFacingRight && velocity.x > 0f)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z); // make it face left if not moving
            transform.rotation = Quaternion.Euler(rotator);
            IsFacingRight = !IsFacingRight;
        }
    }
    #endregion

    #region Animation Triggers
    private void AnimationTriggerEvent(AnimationTriggerType triggerType)
    {
       StateMachine.CurrentEnemyState.AnimationTriggerEvent(triggerType);
    }

   

    public enum AnimationTriggerType
    {
        EnemyDamaged, PlayFootStepSound
    }
    #endregion

    #region Distance checks
    public void SetAggroedStatus(bool IsAggroed2)
    {
        IsAggroed = IsAggroed2;
    }

    public void SetWithinAttackingDistance(bool isWithinAttackingDistance2)
    {
        isWithinAttackingDistance = isWithinAttackingDistance2;
    }
    #endregion

}
