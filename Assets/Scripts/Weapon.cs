using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private static int gunDamage;
    private static int currentWeapon;
    public ShipManager ship;

    void Start()
    {

        if (ship.GetCurrentShip() == 0)
        {
            currentWeapon = 0;
        } else if (ship.GetCurrentShip() == 1)
        {
            currentWeapon = 1;
        } else if (ship.GetCurrentShip() == 2)
        {
            currentWeapon = 2;
        }


        if (currentWeapon == 0)
        {
        gunDamage = 40;
        //fireRate = 1.0f

        } else if (currentWeapon == 1)
        {
            gunDamage = 30;
        } else if (currentWeapon == 2)
        {
            gunDamage = 60;
        }
    }

    public int getCurrentWeapon()
    {
        return currentWeapon;
    }

    public void setCurrentWeapon(int currentWeapon)
    {
        Weapon.currentWeapon = currentWeapon;
    }


    //public void setGunDamage(int gunDamage)
    //{
    //    this.gunDamage = gunDamage;
    //}

    public int getGunDamage()
    {
        return gunDamage;
    }
}
