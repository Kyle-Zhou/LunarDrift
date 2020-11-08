using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyManager : MonoBehaviour
{
    public static string difficulty;

    public void PlayEasy()
    {
        difficulty = "Easy";
        Loader.instance.LoadGameOverScreen(2);
    }

    public void PlayMedium()
    {
        if (PlayerPrefs.GetInt("EasyHighScore") > 120) { 
            difficulty = "Medium";
            Loader.instance.LoadGameOverScreen(3);
        }
    }

    public void PlayHard()
    {
        if (PlayerPrefs.GetInt("EasyHighScore") > 120)
        {
            difficulty = "Hard";
            Loader.instance.LoadGameOverScreen(4);
        }
    }

    //private void Awake()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    PlayerPrefs.SetString("_last_scene_", scene.name);
    //}

}
