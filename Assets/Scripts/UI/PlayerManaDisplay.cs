using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerManaDisplay : MonoBehaviour
{
    public Slider ManaSlider;
    public TMP_Text ManaText;

    public void SetMax(int amount)
    {
        ManaSlider.maxValue = amount;
    }

    public void SetValue(int amount)
    {
        ManaSlider.value = amount;
        ManaText.text = amount.ToString();
    }
}
