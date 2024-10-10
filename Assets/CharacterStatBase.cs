using UnityEngine;

public class CharacterStatBase : MonoBehaviour
{
    public int MaxHeath = 100;
    public int CurrentHeath = 100;

    private void Start()
    {
        CurrentHeath = MaxHeath;
    }

    public void TakeDamage(int amount)
    {
        CurrentHeath -= amount;

        if (CurrentHeath <= 0)
        {
            CurrentHeath = 0;
            Debug.Log("you died");
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
