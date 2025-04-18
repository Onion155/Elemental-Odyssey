using UnityEngine;

public class EnemyAttackingDistanceCheck : MonoBehaviour
{

    public GameObject PlayerTarget { get; set; } // the player

    private EnemyBase _enemy; // the parent object to access SetAggroedStatus

    private void Awake()
    {
        _enemy = GetComponentInParent<EnemyBase>();
        // P.S. it does not give a error when the player is not found through the tag like normal

    }

    // sets the aggro status to true or false based on if the player is in the raduis or not
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemy.SetWithinAttackingDistance(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _enemy.SetWithinAttackingDistance(false);
        }
    }

   
}
