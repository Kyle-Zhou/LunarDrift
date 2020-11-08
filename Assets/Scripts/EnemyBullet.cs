using System.Collections;using System.Collections.Generic;using UnityEngine;public class EnemyBullet : MonoBehaviour{
    public ParticleSystem characterShotPS;

    private void OnCollisionEnter2D(Collision2D collision)    {

        if (collision.transform.gameObject.CompareTag("Player"))
        {
            //Quaternion = no rotation
            //Instantiate explanation on shooting.cs file                       //Quaternion.Identity
            GameObject explosion = Instantiate(characterShotPS.gameObject, transform.position, transform.rotation);
            Destroy(gameObject);
            Destroy(explosion, 3f);
            collision.gameObject.GetComponent<PlayerHealth>().TakeHumanDamage(15);
            Destroy(gameObject, 5f);
        }

    }


    private void OnBecameInvisible() //when bullet leaves screen
    {        Destroy(gameObject); //destroy bullet
                             //Debug.Log("Bullet gone");
    }}