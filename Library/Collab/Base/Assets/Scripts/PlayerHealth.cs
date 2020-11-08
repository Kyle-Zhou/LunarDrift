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

    public ShipManager ship;

    public SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {

        if (ship.GetCurrentShip() == 0)
        {
            maxHealth = 150;
        } else if (ship.GetCurrentShip() == 1)
        {
            maxHealth = 200;
        } else if (ship.GetCurrentShip() == 2)
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
        StartCoroutine(Blink());
        if (currentHealth <= 0)
        {
            //health bar + text disappear
            //gameIndex

            Timer.Finish();
            //gameObject.GetComponent<HealthBar>().enabled = false;
            //gameObject.GetComponent<Timer>().enabled = false;
            //gameObject.GetComponent<TimerText>().enabled = false;

            SceneManager.LoadScene(1);
        }
        healthBar.SetHealth(currentHealth);
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();

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

    //public void upgradeHealth(int addedAmount)
    //{
    //    if (maxHealth + addedAmount <= 200) { 
    //        maxHealth += addedAmount;
    //        slider.value = maxHealth;
    //    }
    //}

}
