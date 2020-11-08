using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumSpawning : MonoBehaviour
{

    private float spawnRadius = 20f, nextSpawn, wave;


    private int type, diversity = 2, frequency = 2;
    private Vector2 spawnPosition;
    public GameObject[] enemies = new GameObject[4];

    void Start()
    {
        StartCoroutine(progression());
        nextSpawn = 4f + Time.time;
       // startTime = Time.time;

    }

    void Update()
    {
        if (Time.time >= nextSpawn)
        {
            wave = Random.Range(frequency, frequency + 2);
            for (int i = 0; i < wave; i++)
            {
                Spawn();
                nextSpawn = Time.time + 2f;
            }
        }
    }

    void Spawn()
    {
        spawnPosition = Camera.main.transform.position;
        spawnPosition += Random.insideUnitCircle.normalized * spawnRadius;
        type = Random.Range(0, diversity);
        GameObject enemy = Instantiate(enemies[type]) as GameObject;
        enemy.transform.position = spawnPosition;
    }

    IEnumerator progression()
    {
        while (true)
        {
            yield return new WaitForSeconds(15f);
            if (diversity != 4)
            {
                diversity++;
            }
            if (frequency != 15)
            {
                frequency++;
            }
        }
    }
}
