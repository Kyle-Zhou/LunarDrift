using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgress : MonoBehaviour
{

    private static int maxProgress;
    private static int currentProgress = 0;
    private static int nukeCounter = 0;

    public ProgressBar progressBar;
    public Text progressText;

    public Text nukeText;

    public Bullet bullet;

    //private GameObject[] enemies;

    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy1");
        //enemies = GameObject.FindGameObjectsWithTag("Enemy2Hit");
        maxProgress = 5;
        currentProgress = 0;
        nukeCounter = 0;
        progressBar.SetMaxValue(maxProgress);
        //progressBar.SetProgress();
        progressText.text = maxProgress.ToString();

    }

    private void Update()
    {
        if (bullet.GetDeathCount() > 0)
        {
            AddProgress(1);
            //bullet.SetDeathCount(bullet.GetDeathCount() - 1);
            bullet.SetDeathCount(0);
        }
    }

    public void AddProgress(int increaseAmount)
    {
        currentProgress += increaseAmount;
        progressBar.SetProgress(currentProgress);
        progressText.text = (maxProgress - currentProgress).ToString();


        if (currentProgress >= maxProgress)
        {
            FindObjectOfType<AudioManager>().Play("Nuke");
            NukeEnemy1();
            NukeEnemy2();

            //progressText.gameObject.SetActive(true);

            StartCoroutine(ShowMessage());

            currentProgress = 0;
            progressBar.SetProgress(0);

            if (nukeCounter > 0)
            {
                maxProgress = 10 * (nukeCounter);
            }
            progressText.text = maxProgress.ToString();
            progressBar.SetMaxValue(maxProgress);

        }
    }

    IEnumerator ShowMessage()
    {
        nukeText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        nukeText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        nukeText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        nukeText.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.4f);
        nukeText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        nukeText.gameObject.SetActive(false);

    }


    //public void NukeAll()
    //{
    //    GameObject[] enemies = FindObjectsOfType(GameObject);
    //    foreach (GameObject enemy in enemies)
    //    {
    //        if (!enemy.GetComponenet())
    //    }
    //}

    public void NukeEnemy1()
    {
        nukeCounter += 1;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy1");

        //enemies = GameObject.FindGameObjectsWithTag("Enemy2Hit");
        //Debug.Log("nuked");
        foreach(GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
    }

    public void NukeEnemy2()
    {
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2Hit");

        //enemies = GameObject.FindGameObjectsWithTag("Enemy2Hit");
        Debug.Log("nuked");
        foreach (GameObject enemy in enemies2)
        {
            GameObject.Destroy(enemy);
        }
    }

    public void SlowTime()
    {
        float timer = 0.0f;
        float runTime = 2.0f;
        while (timer < runTime)
        {
            Time.timeScale = 0.1f;
            timer += Time.deltaTime;
            //yield;
        }
        
    }

}
