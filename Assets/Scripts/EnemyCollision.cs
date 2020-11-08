using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{

    public EnemyAI enemyMovement;
    public ParticleSystem deadEnemyExplode; 
    //public ParticleSystem enemyExplode;

    //private void Start()
    //{
    //    enemyExplode = GetComponent<ParticleSystem>();
    //}

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Player"))
        {
            enemyMovement.enabled = false;
            //if (!enemyExplode.isPlaying) { 
            //enemyExplode.Play();
            //} else
            //{
            //    enemyExplode.Stop();
            //}
            GameObject deadExplode = Instantiate(deadEnemyExplode.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(deadExplode, 3f);
            //enemyExplode.SetActive(true);
            if (gameObject.CompareTag("Enemy1")){
                collisionInfo.gameObject.GetComponent<PlayerHealth>().TakeHumanDamage(20);
            } else if (gameObject.CompareTag("Enemy2Hit"))
            {
                collisionInfo.gameObject.GetComponent<PlayerHealth>().TakeHumanDamage(50);
            }
        }

    }
}



