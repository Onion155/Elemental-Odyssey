using UnityEngine;
using UnityEngine.UI;

public class PlayerManaDisplay : MonoBehaviour
{
    private Slider ManaSlider;
    void Start()
    {
        ManaSlider = GetComponent<Slider>();
    }
    public void SetMax(int amount)
    {
        ManaSlider.maxValue = amount;
    }

    public void SetValue(int amount)
    {
        ManaSlider.value = amount;
    }
}
