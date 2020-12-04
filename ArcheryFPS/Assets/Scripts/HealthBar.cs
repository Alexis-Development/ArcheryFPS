using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    enum HealthState { low, half, full };

    public Slider slider;
    public Image fill;

    HealthState _healthState;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        _healthState = HealthState.full;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
        float percentHealth = health / slider.maxValue * 100;
        Debug.Log(percentHealth);
        if (percentHealth < 20 && fill.color != Color.red)
        {
            fill.color = Color.red;
            return;
        }
        if (percentHealth < 50 && fill.color != Color.yellow)
        {
            fill.color = Color.yellow;
        }
    }
}
