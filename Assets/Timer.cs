using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    private float startTime;
    private static bool done = false;

    private static string minutes;
    private static string seconds;


    //private static int min;
    //private static int sec;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        done = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (done)
        {
            return;
        }

        float intTime = Time.time - startTime;
        minutes = ((int)intTime / 60).ToString();
        //min = ((int)intTime / 60);
        seconds = (intTime % 60).ToString("00");
        //sec = Mathf.RoundToInt(intTime % 60);
    }

    public static void Finish()
    {
        //Debug.Log(seconds);
        //Debug.Log(DifficultyManager.difficulty);

        done = true;
        if (DifficultyManager.difficulty == "Easy") {
            //Debug.Log(int.Parse(minutes) * 60);
            if (int.Parse(seconds) + (int.Parse(minutes) * 60) > PlayerPrefs.GetInt("EasyHighScore")) {
                PlayerPrefs.SetInt("EasyHighScore", int.Parse(seconds) + (int.Parse(minutes)*60));
            }

        }
        else if (DifficultyManager.difficulty == "Medium")
        {
            //Debug.Log(int.Parse(minutes) * 60);
            if (int.Parse(seconds) + (int.Parse(minutes) * 60) > PlayerPrefs.GetInt("MediumHighScore"))
            {
                PlayerPrefs.SetInt("MediumHighScore", int.Parse(seconds) + (int.Parse(minutes) * 60));
            }
        }
        else if (DifficultyManager.difficulty == "Hard")
        {
            //Debug.Log(int.Parse(minutes) * 60);
            if (int.Parse(seconds) + (int.Parse(minutes) * 60) > PlayerPrefs.GetInt("HardHighScore"))
            {
                PlayerPrefs.SetInt("HardHighScore", int.Parse(seconds) + (int.Parse(minutes) * 60));
            }
        }

    }

    public string getMinutes()
    {
        return minutes;
    }

    public string getSeconds()
    {
        return seconds;
    }

}

