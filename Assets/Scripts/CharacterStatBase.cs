using UnityEngine;

public class CharacterStatBase : MonoBehaviour
{
    public int MaxHeath = 100;
    public int CurrentHeath = 100;
    public int defenece = 0;

    private void Start()
    {
        CurrentHeath = MaxHeath;
    }

    public void TakeDamage(int amount)
    {
        amount -= defenece;
        CurrentHeath -= amount;

        if (CurrentHeath <= 0)
        {
            CurrentHeath = 0;
            Debug.Log(gameObject.name +  " died");
        }
    }

    public void Heal(int amount)
    {
        CurrentHeath += amount;

        if (CurrentHeath < MaxHeath)
        {
            CurrentHeath = MaxHeath;
        }
    }
}
