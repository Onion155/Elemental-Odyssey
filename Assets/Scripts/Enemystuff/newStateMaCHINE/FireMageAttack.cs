using System.Threading;
using TMPro;
using UnityEngine;

public class FireMageAttack : State
{
    public GameObject barrier;
    public FirebarrierControl firebarrier;
    private int timer = 500;
    public override void Enter()
    {
        barrier.SetActive(true);
        timer = 5000;
    }
    public override void StateUpdate()
    {
        if ( timer == 0)
        {
            barrier.SetActive(false);
        }
        else { timer--; }
        // make sphere around the enemy that will make it hard to kill him
        // the wall should block the players abilities and bullets
        // the barrier should stay up for a couple of seconds
        // and damage the player if he gets too close
    }
    public override void StateFixedUpdate()
    {

    }
    public override void Exit()
    {
        barrier.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
