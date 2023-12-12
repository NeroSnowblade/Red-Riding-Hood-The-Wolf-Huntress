using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPlayerControllerUi : MonoBehaviour
{
    // public Slider slider;

    // public void setMaxHealth(float maxHealth)
    // {
    //     slider.maxValue = maxHealth;
    //     slider.value = maxHealth;
    // }

    // public void setHealth(float health)
    // {
    //     slider.value = health;
    // }
    public Slider slider;
	public Gradient gradient;
	public Image fill;

	public void setMaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;

		fill.color = gradient.Evaluate(1f);
	}

    public void setHealth(float health)
	{
		slider.value = health;

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
