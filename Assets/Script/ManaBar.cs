using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public Gradient gradient;

    public Image fill;
    public void setMana(int mana)
    {
        slider.value = mana;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void setMaxMana(int maxMana)
    {
        slider.maxValue = maxMana;
        slider.value = maxMana;

        fill.color = gradient.Evaluate(1f);
    }

}
