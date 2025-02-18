using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    // here it should handle the diffrent elements 
    // each element is a state and each one should ave access to the players stats so they can alter them 
    // each elemental state should give the player access to its respective element
    // each element should have 2 abilities and change around 2 stats of he player
    public CharacterStatBase PlayerStats { get; set; }


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

        StateMachine.Initialize(WaterState); // gives the initial state 
    }

    private void Update()
    {
        StateMachine.CurrentElement.FrameUpdate(); // allows you to use update in whatever class your in 
    }
}
