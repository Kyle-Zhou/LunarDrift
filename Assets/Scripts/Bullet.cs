using System.Collections;using System.Collections.Generic;using UnityEngine;public class Bullet : MonoBehaviour{

    //public GameObject enemyExplode;
    public ParticleSystem enemyExplode;

    private static int deathCount = 0;

    //public Color[] colors = new Color[6];

    public GameObject player;
    public Weapon weapon;


    private void Start()
    {
        //colors[0] = Color.cyan;
        //colors[1] = Color.red;
        //colors[2] = Color.green;
        //colors[3] = new Color(255, 165, 0);
        //colors[4] = Color.yellow;
        //colors[5] = Color.magenta;

        //gameObject.GetComponent<SpriteRenderer>().color = colors[Random.Range(0, colors.Length)];



    }



    private void OnCollisionEnter2D(Collision2D collision)    {

        if (collision.transform.gameObject.CompareTag("Enemy1")) {

            //ParticleSystem.MainModule main = enemyExplode.main;

            //Color color = gameObject.GetComponent<SpriteRenderer>().color;
            //color.a -= Time.deltaTime * 35;
            //main.startColor = color;

            //Quaternion = no rotation
            //Instantiate explanation on shooting.cs file                       //Quaternion.Identity
            GameObject explosion = Instantiate(enemyExplode.gameObject, transform.position, transform.rotation);
            Destroy(explosion, 3f);
            Destroy(collision.gameObject);
            ScreenShake.instance.StartShake(.5f, .3f);
            deathCount++;

        } else if (collision.transform.gameObject.CompareTag("Enemy2Hit"))
        {

            //ParticleSystem.MainModule main = enemyExplode.main;

            //Color color = gameObject.GetComponent<SpriteRenderer>().color;
            //color.a -= Time.deltaTime * 35;
            //main.startColor = color;

            //Quaternion = no rotation
            //Instantiate explanation on shooting.cs file                       //Quaternion.Identity
            GameObject explosion = Instantiate(enemyExplode.gameObject, transform.position, transform.rotation);
            Destroy(explosion, 3f);

            //int dmg = (manager.GetComponent<Weapon>().getGunDamage());

            int dmg2 = weapon.getGunDamage();
            //Debug.Log(dmg2);
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg2);

            ScreenShake.instance.StartShake(.6f, .3f);

            deathCount++;
        }

        //player.GetComponent<PlayerProgress>().AddProgress(1);
        //player.GetComponent<ProgressBar>().SetProgress(1);

        Destroy(gameObject);    }    private void OnBecameInvisible() //when bullet leaves screen    {        Destroy(gameObject); //destroy bullet        //Debug.Log("Bullet gone");    }    public int GetDeathCount()
    {
        return deathCount;
    }    public void SetDeathCount(int deathCount)
    {
        Bullet.deathCount = deathCount;
    }}