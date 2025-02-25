using System;
using UnityEngine;

public class AirDash : MonoBehaviour
{
    // this should maybe get the direction the player is moving and then dash them in that direction
    // currently the player can only cast this if they are standin still( this is because the only one script can acces the player rb at a time) apply dash stuff to the player controller script
    private Rigidbody2D PC;
    public float DashSpeed = 100;


    private void Awake()
    {
        PC = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        Debug.Log(PC.gameObject.name);

        CheckDirection();
        Dash();
    }

    private void CheckDirection()
    {
        if (PC.transform.lossyScale.x >= 0)
        {
            // should go left
            DashSpeed *= -1;
            Debug.Log("Dashing Left");
        }
        else { Debug.Log("Dashing Right");
               }
    }

    private void Dash()
    {
        PC.AddForce(new Vector2(DashSpeed, 0)); // kinda works need to be improved
        Destroy(gameObject);
    }
}
