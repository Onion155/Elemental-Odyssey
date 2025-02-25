using NUnit.Framework.Internal.Commands;
using UnityEditor.Rendering;
using UnityEngine;

public class WaterSpiritAbility : MonoBehaviour
{
    // heals the player over time when called
    // dies after a while
    [SerializeField]
   private CharacterStatBase PlayerStats;

    private int lifespan = 1000;
    private int HPS = 100;
    private int healingamount = 10;
    private void Awake()
    {
        PlayerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterStatBase>();
    }
    private void Update()
    {
        if (lifespan > 0)
        {
            if (HPS <= 0)
            {
                PlayerStats.Heal(healingamount);
                HPS = 100;
            }
            lifespan--;
            HPS--;
        }
        else { Destroy(gameObject); }
    }
}
