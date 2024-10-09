using UnityEngine;


public class CharacterBase : MonoBehaviour
{
    public CharacterStatBase stats;

    public float Damage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        stats.health -= Damage;
        Debug.Log("The player has "+ stats.health + " health left");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}