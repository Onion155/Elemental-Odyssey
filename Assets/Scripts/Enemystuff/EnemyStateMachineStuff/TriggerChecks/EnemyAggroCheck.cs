using UnityEngine;

public class EnemyAggroCheck : MonoBehaviour
{
    public GameObject PlayerTarget { get; set; } // the player

    private Enemy _enemy; // the parent object to access SetAggroedStatus

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();


        SetPlayer();
        // P.S. it does not give a error when the player is not found through the tag like normal

    }

    // sets the aggro status to true or false based on if the player is in the raduis or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetAggroedStatus(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == PlayerTarget)
        {
            _enemy.SetAggroedStatus(false);
        }
    }

    private void SetPlayer()
    {
        PlayerTarget = GameObject.FindGameObjectWithTag("Player");
    }
}
