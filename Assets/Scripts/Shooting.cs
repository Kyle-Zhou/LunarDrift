using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public Transform firePoint2;
    public Transform firePoint3;

    public GameObject bulletPrefab; 
    public float bulletForce = 20f;

    public float fireRate = 0f;

    //public GameObject manager;

    public Weapon weapon;

    public Joystick joystick;

    private static int currentWeapon;

    private void Start()
    {
        //weapon = (manager.GetComponent<Weapon>().getCurrentWeapon());
        currentWeapon = weapon.getCurrentWeapon();
        //Debug.Log(weapon);

    }

    public void Shoot()
    {
        if (Time.time >= fireRate)
        {
            if (currentWeapon == 0)
            {
                ShootPistol();
                fireRate = Time.time + 0.4f;
            }
            else if (currentWeapon == 1)
            {
                ShootShotgun();
                fireRate = Time.time + 0.3f;
            }
            else if (currentWeapon == 2)
            {
                ShootTwo();
                fireRate = Time.time + 0.2f;
            }
        }
        
    }


    void ShootPistol() {
        //Instantiate = makes a copy of
        //params (object that's being copied, position of the object, rotation of the object)

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        //ForceMode2D.Impulse adds an instant, one time force to a rigidbody
    }

    void ShootShotgun()
    {

        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        rb3.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);
    }


    void ShootTwo()
    {
        GameObject bullet1 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
    }
}


