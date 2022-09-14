using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArmourBar : MonoBehaviour
{

	[SerializeField] private Slider slider;
	[SerializeField] private Gradient gradient;
	[SerializeField] private Image fill;

	void Start()
	{

	}

	public void SetMaxArmour(int currarmour)
	{
		slider.maxValue = currarmour;
		slider.value = currarmour;

		//fill.color = gradient.Evaluate(1f);
	}

	public void SetArmour(int currarmour)
	{
		slider.value = currarmour;

		//fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
