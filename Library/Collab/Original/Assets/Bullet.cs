using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

   // public GameObject hitEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Quaternion = no rotation
        //Instantiate explanation on shooting.cs file
        //GameObject explosion = Instantiate(hitEffect, transform.position, Quaternion.identity);
       // Destroy(explosion, 5f);
        Destroy(gameObject);
    }

    private void OnBecameInvisible() //when bullet leaves screen
    {
        Destroy(gameObject); //destroy bullet
        Debug.Log("Bullet gone");
    }

}
