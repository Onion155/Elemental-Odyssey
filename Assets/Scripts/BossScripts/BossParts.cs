using UnityEngine;

public class BossParts : MonoBehaviour
{
    public int Damage = 10;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CharacterStatBase playerStats = collision.GetComponent<CharacterStatBase>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(Damage);
            }
        }
    }
}
