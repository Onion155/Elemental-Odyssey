using Unity.VisualScripting;
using UnityEngine;


public class CharacterBase : MonoBehaviour
{
    public CharacterStatBase Playerstats;

    public int Damage;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       Playerstats.TakeDamage(Damage);
        Debug.Log(gameObject.name + " has dealth damage-" + Playerstats.name + " has " + Playerstats.CurrentHeath + " health left");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
