using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthDisplay : MonoBehaviour
{
    private Slider healthSlider;
    void Start()
    {
        healthSlider = GetComponent<Slider>();
        healthSlider.maxValue = 100; // temporatry fix should work in the functrion 
        healthSlider.value = healthSlider.maxValue;
    }

    public void SetMax(int amount) // this does not work for some odd reason find out why 
    {
        healthSlider.maxValue = amount;
    }

   public void SetValue(int amount)
    {
        healthSlider.value = amount;
    }

    
}
