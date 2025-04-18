using UnityEngine;

public class FirebarrierControl : MonoBehaviour
{
    Collider2D barrier;
    int timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        barrier = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (timer == 0)
            {
                Debug.Log("trying to damage enemy");
                collision.gameObject.GetComponent<CharacterStatBase>().TakeDamage(50);
                timer = 100;
            }
            else { timer--; }
        }
    }
}
