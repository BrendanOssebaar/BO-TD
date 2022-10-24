using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Slider slider;
    public void setMaxLife(float HP)
    {
        slider.maxValue = HP;
    }

    public void setLife(float hp)
    {
        slider.value = hp;
    }
}
