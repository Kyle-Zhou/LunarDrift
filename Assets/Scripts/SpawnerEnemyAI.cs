using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerEnemyAI : EnemyAI
{

    public GameObject spawned;
    public Transform spawn1;
    public Transform spawn2;

    public float spawnPeriod = 5.0f;

    public Rigidbody2D rb3;

    public float stopDistance;

    private int spawnCount = 0;

    private Scene scene;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.speed = 2f;
        StartCoroutine(spawningEnemyTimer());
        if (scene.name == "Medium")
        {
            base.speed  *= 1.25f;
        }
        else if (scene.name == "Hard")
        {
            base.speed *= 1.5f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector2 direction = (PlayerMovement.Position - rb3.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb3.rotation = angle;

        //if enemy is too far away
        if (Vector2.Distance(transform.position, base.getPlayer().position) > stopDistance)
        {
            //move closer to player
            transform.position = Vector2.MoveTowards(transform.position, base.getPlayer().position, base.speed * Time.deltaTime);
            // if close enough but not TOO close 
        }
        else if ((Vector2.Distance(transform.position, base.getPlayer().position) < stopDistance))
        {
            //stop moving
            transform.position = this.transform.position;
        }
        
    }

    public void Spawn()
    {
        spawnCount++;
        Instantiate(spawned, spawn1.position, spawn1.rotation);
        Instantiate(spawned, spawn2.position, spawn2.rotation);
        if (spawnCount > 3)
        {
            Destroy(gameObject);
        }
    }


    IEnumerator spawningEnemyTimer()
    {
        while (true) //Tentative
        {
            yield return new WaitForSeconds(spawnPeriod);
            Spawn();
        }
    }
}


