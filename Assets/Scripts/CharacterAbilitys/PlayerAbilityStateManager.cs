using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAbilityStateManager : MonoBehaviour
{
    // referance objects
    public Rigidbody2D Body;
    public ElementControler element;


    // this is all the state machine phases here
    PlayerAbilityBaseState currentState;
    PhysicalAbility PhysicalAbility = new PhysicalAbility();
    WaterAbility WaterState = new WaterAbility();
    FireAbility FireState = new FireAbility();
    EarthAbility EarthAbility = new EarthAbility();
    AirAbility AirAbility = new AirAbility();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentState = PhysicalAbility;
        currentState.EnterState(this); // sends the enter state data to the current state
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this); // sends this data to the currentstate
        
        // this moves the player into the diffrent states
        if (Input.GetKeyDown(KeyCode.Z))
        {
            currentState = WaterState;
            currentState.EnterState(this);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            currentState = FireState;
            currentState.EnterState(this);
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            currentState = AirAbility;
            currentState.EnterState(this);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            currentState = EarthAbility;
            currentState.EnterState(this);
        }

        
    }
}
