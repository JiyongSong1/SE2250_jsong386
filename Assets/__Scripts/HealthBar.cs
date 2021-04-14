using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerHealthManager
{

    public Slider slider;

    // Update is called once per frame
    public void SetMaxHealth(int health)
    {
        //sets the slider value corresponding to text
        slider.maxValue = health;
        slider.value = health;
    }

    //sets the slider value corresponding to text
    public void SetHealth(int health){
        slider.value = health;
    }
}
