using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerText : MonoBehaviour
{

    public Text timerText;
    public Timer timer;

    private bool done = false;

    // Update is called once per frame
    void Update()
    {
        if (done)
        {
            return;
        }

        if (int.Parse(timer.getSeconds()) >= 60)
        {
            timerText.text = timer.getMinutes() + ":" + "59";
        }

        timerText.text = timer.getMinutes() + ":" + timer.getSeconds();

    }



}

