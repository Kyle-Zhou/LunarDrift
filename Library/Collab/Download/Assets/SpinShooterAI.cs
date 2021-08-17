using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinShooterAI : EnemyAI
{

    public Rigidbody2D rb;

    public GameObject enemyBulletPrefab;
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;

    public float fireRate = 5f;
    private float nextTimeToFire = .3f;
    private float bulletSpeed = 10f;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        base.speed = 3f;

    }

    // Update is called once per frame
    void Update()
    {

        Shoot();
        transform.position = Vector2.MoveTowards(transform.position, base.getPlayer().position, speed * Time.deltaTime);
        transform.Rotate(0, 0, 100 * Time.deltaTime);

    }

    void Shoot()
    {
        if (Time.time >= nextTimeToFire)
        {
            GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, firePoint.rotation);
            Destroy(bullet, 8f);

            nextTimeToFire = Time.time + 1f / fireRate;
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);


            GameObject bullet2 = Instantiate(enemyBulletPrefab, firePoint1.position, firePoint1.rotation);
            Destroy(bullet2, 8f);

            nextTimeToFire = Time.time + 1f / fireRate;
            Rigidbody2D rb3 = bullet2.GetComponent<Rigidbody2D>();
            rb3.AddForce(firePoint1.up * bulletSpeed, ForceMode2D.Impulse);


            GameObject bullet3 = Instantiate(enemyBulletPrefab, firePoint2.position, firePoint2.rotation);
            Destroy(bullet3, 8f);

            nextTimeToFire = Time.time + 1f / fireRate;
            Rigidbody2D rb4 = bullet3.GetComponent<Rigidbody2D>();
            rb4.AddForce(firePoint2.up * bulletSpeed, ForceMode2D.Impulse);


            GameObject bullet4 = Instantiate(enemyBulletPrefab, firePoint3.position, firePoint3.rotation);
            Destroy(bullet4, 8f);

            nextTimeToFire = Time.time + 1f / fireRate;
            Rigidbody2D rb5 = bullet4.GetComponent<Rigidbody2D>();
            rb5.AddForce(firePoint3.up * bulletSpeed, ForceMode2D.Impulse);

        }
    }


}
