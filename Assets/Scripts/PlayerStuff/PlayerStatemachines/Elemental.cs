using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    // here it should handle the diffrent elements 
    // each element is a state and each one should ave access to the players stats so they can alter them 
    // each elemental state should give the player access to its respective element
    // each element should have 2 abilities and change around 2 stats of he player
    public CharacterStatBase PlayerStats { get; set; }
    public PlayerController PC { get; set; }

    public GameObject[] ElementalBullets; // 0:Water; 1:Air; 2:Earth; 3:Fire
    public GameObject[] ElementalAbilities1;// 0:Water; 1:Air; 2:Earth; 3:Fire
    public GameObject[] ElementalAbilities2;// 0:Water; 1:Air; 2:Earth; 3:Fire
    // store abilities hjere 
    //store bullets here 
    // change them out depending on the satate/

    public int abilitynum = 0;

    #region State Machine Variables
    public ElementalStateMachine StateMachine { get; set; }
    public AirState AirState { get; set; }
    public EarthState EarthState { get; set; }
    public FireState FireState { get; set; }
    public WaterState WaterState { get; set; }
    #endregion

    private void Awake()
    {
        StateMachine = new ElementalStateMachine();
        AirState = new AirState(this, StateMachine);
        EarthState = new EarthState(this, StateMachine);
        FireState = new FireState(this, StateMachine);
        WaterState = new WaterState(this, StateMachine);
    }

    private void Start()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatBase>();
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        StateMachine.Initialize(WaterState); // gives the initial state 
    }

    private void Update()
    {
        StateMachine.CurrentElement.FrameUpdate(); // allows you to use update in whatever class your in
    }

    public void CheckState()
    {
        if (abilitynum == 0)
        {
            StateMachine.ChangeState(WaterState);
        }
        else if (abilitynum == 1)
        {
            StateMachine.ChangeState(AirState);
        }
        else if (abilitynum == 2)
        {
            StateMachine.ChangeState(EarthState);
        }
        else if (abilitynum == 3)
        {
            StateMachine.ChangeState(FireState);
        }
    }
}
