using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy2Hit")) { 
                gameObject.GetComponent<SplittingEnemyAI>().Split();
            }
            Destroy(gameObject);
        }
    }

}
