using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider xpSlider;


    public void SetMaxXP(int xp)
    {
        xpSlider.maxValue = xp;
        xpSlider.value = xp;
    }

    public void SetXP(int xp)
    {
        xpSlider.value = xp;
    }
}
