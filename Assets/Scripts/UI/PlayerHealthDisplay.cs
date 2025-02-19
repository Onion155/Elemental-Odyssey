using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthDisplay : MonoBehaviour
{
    public Slider healthSlider;
    public TMP_Text healthText;

    public void SetMax(int amount) 
    {
        healthSlider.maxValue = amount;
    }

   public void SetValue(int amount)
    {
        healthSlider.value = amount;
        healthText.text = amount.ToString();

    }
}
