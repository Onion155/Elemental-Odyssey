using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    // these states are just blanks they do not call specificly to a state just the parent , this is done so i can use any child state 
    // for example i can have flying idle or ground idle in stead of having just one idle
    [Header("States")]
    public State ChaseState;
    public State IdleState;
    public State AttackState;

    [Header("CurrentState")]
   [SerializeField] private State state;

    [Header("Referances")]
    public Rigidbody2D body;
    public CharacterStatBase PlayerStats; // this is used as a referances to the player and also his functionalty( like dealing damage to it)

    [Header("movement Variables")]
    public bool IsFacingRight = false;
    public int RandomMovementRange;
    public int moveSpeed;
    #region Distance checks
    public bool IsAggroed { get; set; }
    public bool isWithinAttackingDistance { get; set; }
    #endregion

    [Header("Stats")]
    public int Damage = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatBase>();
        // send data to states
        ChaseState.SetUp(body, this);
        IdleState.SetUp(body, this);
        AttackState.SetUp(body, this);

        // start a state
        state = IdleState;
        state.Enter();
    }

    // Update is called once per frame
    void Update()
    {
        state.StateUpdate();
    }
    private void FixedUpdate()
    {
        state.StateFixedUpdate();
    }
    public void ChangeState(State changedstate)
    {
        state.Exit();
        state = changedstate;
        state.Enter();
    }

    #region Movement
    public void MoveEnemy(Vector2 velocity) // Velocity is x,y
    {
        body.MovePosition(velocity); // if you want it to ignore y do it in that script
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
