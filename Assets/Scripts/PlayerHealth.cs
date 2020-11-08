using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    private static int maxHealth;
    public int currentHealth;
    public Text healthText;

    public HealthBar healthBar;

    public Joystick joystick1;
    public Joystick joystick2;

    public ShipManager ship;
    public SpriteRenderer render;

    public ParticleSystem enemyExplode;


    // Start is called before the first frame update
    void Start()
    {
        if (ship.GetCurrentShip() == 0)
        {
            maxHealth = 150;
        }
        else if (ship.GetCurrentShip() == 1)
        {
            maxHealth = 200;
        }
        else if (ship.GetCurrentShip() == 2)
        {
            maxHealth = 250;
        }

        currentHealth = maxHealth;
        //Debug.Log("CurrentHealth: " + currentHealth);
        healthBar.SetMaxHealth(maxHealth);
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }

    public void TakeHumanDamage(int damage)
    {

        ScreenShake.instance.StartShake(1f, .7f);

        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        } else if (currentHealth > 0) { 
            StartCoroutine(Blink());
        }
        healthBar.SetHealth(currentHealth);
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();

    }

    void RemoveEnemies()
    {
        GameObject[] enemies1 = GameObject.FindGameObjectsWithTag("Enemy1");
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2Hit");

        foreach (GameObject enemy in enemies1) { 
            enemy.SetActive(false);
        }
        foreach (GameObject enemy in enemies2)
        {
            enemy.SetActive(false);
        }
    }

    void Die()
    {
        //FindObjectOfType<AudioManager>().Play("PlayerDeath");

        Time.timeScale = 0.5f;

        RemoveEnemies();
        Timer.Finish();

        render.enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;

        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Shooting>().enabled = false;

        //joystick2.enabled = false;
        //joystick1.enabled = false;
        //joystick2.GetComponent<Image>().enabled = false;
        //joystick1.GetComponent<Image>().enabled = false;



        //Destroy(gameObject);
        gameObject.GetComponent<Shooting>().enabled = false;
        healthText.GetComponent<Text>().enabled = false;

        GameObject explosion = Instantiate(enemyExplode.gameObject, transform.position, transform.rotation);
        Destroy(explosion, 3f);
        gameObject.GetComponent<PlayerHealth>().enabled = false;

        Time.timeScale = 1.0f;
        Loader.instance.LoadGameOverScreen(1);
    }


    IEnumerator Blink()
    {
        render.enabled = false;
        yield return new WaitForSeconds(0.1f);
        render.enabled = true;
        yield return new WaitForSeconds(0.1f);
        render.enabled = false;
        yield return new WaitForSeconds(0.1f);
        render.enabled = true;
        yield return new WaitForSeconds(0.1f);
        render.enabled = false;
        yield return new WaitForSeconds(0.1f);
        render.enabled = true;
        yield return new WaitForSeconds(0.1f);
        render.enabled = false;
        yield return new WaitForSeconds(0.1f);
        render.enabled = true;
        yield return new WaitForSeconds(0.1f);
        render.enabled = false;
        yield return new WaitForSeconds(0.1f);
        render.enabled = true;
    }


}
