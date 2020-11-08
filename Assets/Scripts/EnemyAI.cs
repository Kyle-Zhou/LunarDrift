using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{

    public float speed;
    private Transform player;
    private Scene scene;
    //public Transform[] EnemyTransforms;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Medium")
        {
            speed = speed * 1.25f;
        } else if (scene.name == "Hard")
        {
            speed = speed * 1.5f;
        }
    }

    private void FixedUpdate()
    {
        //params (current enemy, player position, speed of travel)
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        transform.Rotate(0, 0, 50*Time.deltaTime);

        float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
        if (distance > 50)
        {
            Destroy(gameObject);
        }
    }

    //private void FixedUpdate()
    //{
    //    float distance = Vector3.Distance(player.transform.position, gameObject.transform.position);
    //    if (distance > 50)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    public Transform getPlayer()
    {
        return player;
    }

}
