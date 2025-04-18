using UnityEngine.UI;
using UnityEngine;


public class CharacterStatBase : MonoBehaviour
{
    [Header("Refernaces")]
    public PlayerHealthDisplay healthDisplay;
    public PlayerManaDisplay manaDisplay;

    [Header("Health stats")]
    public int MaxHeath = 100;
    public int CurrentHeath = 100;
    [Header("Mana stats")]
    public int MaxMana = 300;
    public int CurrentMana = 300;
    [Header("Other stats")]
    public int defenece = 0;

    private void Start()
    {
        CurrentHeath = MaxHeath;
        CurrentMana = MaxMana;

        // send initial data to bars
        //Health
        healthDisplay.SetMax(MaxHeath);
        healthDisplay.SetValue(CurrentHeath);
        //Mana
        manaDisplay.SetMax(MaxMana);
        manaDisplay.SetValue(CurrentMana);

        
    }

    public void TakeDamage(int amount)
    {
        if(amount < defenece)
        {
            amount = 0;
        }
        else { amount -= defenece; }

        CurrentHeath -= amount;
       
        if (CurrentHeath <= 0)
        {
            CurrentHeath = 0;
            Debug.Log(gameObject.name +  " died");
        }
            healthDisplay.SetValue(CurrentHeath);
    }

    public void Heal(int amount)
    {
        CurrentHeath += amount;
        
        if (CurrentHeath > MaxHeath)
        {
            CurrentHeath = MaxHeath;
        }
        healthDisplay.SetValue(CurrentHeath);
        Debug.Log("Healed Player +" + amount);
    }

    public void SetMaxH(int amount)
    {
        if (amount < 0)
        {
            MaxHeath = 1;
        }
        else { MaxHeath = amount; }
        if (CurrentHeath > MaxHeath)
        {
            CurrentHeath = MaxHeath;
            healthDisplay.SetValue(CurrentHeath);
        }
        healthDisplay.SetMax(MaxHeath);
       
    }
    
    public void SetDefense(int amount)
    {
        defenece = amount;
    }

   
}
