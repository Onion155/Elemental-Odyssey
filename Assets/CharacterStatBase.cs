using UnityEngine;

public class CharacterStatBase : MonoBehaviour
{
    // character health
    [Range(1f, 100f)]
    public float health;

    // damage multiplyer
    [Range(0f, 100f)]
    public float damage;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log(this.gameObject + "Has died");
        }
    }
}
