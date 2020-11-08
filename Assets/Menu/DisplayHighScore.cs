using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighScore : MonoBehaviour
{

    public Text easyHighScoreText;
    public Text mediumHighScoreText;
    public Text HardHighScoreText;

    public Text mediumText;
    public Text hardText;

    public GameObject mediumLocked;
    public GameObject hardLocked;

    void Start()
    {
        easyHighScoreText.text =  (PlayerPrefs.GetInt("EasyHighScore") / 60) + ":" + (PlayerPrefs.GetInt("EasyHighScore") % 60).ToString("00");


        if (PlayerPrefs.GetInt("EasyHighScore") > 120) {
            mediumLocked.SetActive(false);
            mediumHighScoreText.gameObject.SetActive(true);
            mediumText.gameObject.SetActive(true);
            mediumHighScoreText.text = (PlayerPrefs.GetInt("MediumHighScore") / 60) + ":" + (PlayerPrefs.GetInt("MediumHighScore") % 60).ToString("00");
        }

        if (PlayerPrefs.GetInt("MediumHighScore") > 120) {
            hardLocked.SetActive(false);
            HardHighScoreText.gameObject.SetActive(true);
            hardText.gameObject.SetActive(true);
            HardHighScoreText.text = (PlayerPrefs.GetInt("HardHighScore") / 60) + ":" + (PlayerPrefs.GetInt("HardHighScore") % 60).ToString("00");
        }
    }

}
