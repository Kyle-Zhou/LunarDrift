using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    public Slider slider2;

    public void SetMaxValue(int total)
    {
        slider2.maxValue = total;
        slider2.value = 0;

    }

    public void SetProgress(int progress)
    {
        slider2.value = progress;
        //Debug.Log(slider2.value);
    }
}
