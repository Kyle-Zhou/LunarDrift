using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplittingEnemyAI : EnemyAI
{

    public GameObject splittedPrefab;
    public Transform spawnLocation1;
    public Transform spawnLocation2;
    private Scene scene;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.speed = 3f;
        if (scene.name == "Medium")
        {
            speed = speed * 1.25f;
        }
        else if (scene.name == "Hard")
        {
            speed = speed * 1.5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //params (current enemy, player position, speed of travel)
        transform.position = Vector2.MoveTowards(transform.position, base.getPlayer().position, speed * Time.deltaTime);
        transform.Rotate(0, 0, 50 * Time.deltaTime);
    }

    public void Split()
    {
        Instantiate(splittedPrefab, spawnLocation1.position, spawnLocation1.rotation);
        Instantiate(splittedPrefab, spawnLocation2.position, spawnLocation2.rotation);
    }

}
