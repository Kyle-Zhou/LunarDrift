using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootingEnemyAI : EnemyAI
{

    //public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public Rigidbody2D rb;

    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float nextTimeToFire = .5f;
    public float bulletSpeed = 5f;
    private Scene scene;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.speed = 2f;
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Medium")
        {
            base.speed *= 1.25f;
        }
        else if (scene.name == "Hard")
        {
            base.speed *= 1.5f;
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Shoot();

        Vector2 direction = (PlayerMovement.Position - rb.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        //if enemy is too far away
        if (Vector2.Distance(transform.position, base.getPlayer().position) > stoppingDistance)
        {
            //move closer to player
            transform.position = Vector2.MoveTowards(transform.position, base.getPlayer().position, base.speed * Time.deltaTime);
        // if close enough but not TOO close 
        } else if ((Vector2.Distance(transform.position, base.getPlayer().position) < stoppingDistance) && (Vector2.Distance(transform.position, base.getPlayer().position) > retreatDistance))
        {
            //stop moving
            transform.position = this.transform.position;
        //if too close (might want to remove this)
        } else if (Vector2.Distance(transform.position, base.getPlayer().position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, base.getPlayer().position, -base.speed * Time.deltaTime);

        }
    }

    void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 5f);

            nextTimeToFire = Time.time + 1f / fireRate;
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);

        }
    }


}
